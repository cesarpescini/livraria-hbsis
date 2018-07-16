using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Livraria.ConexaoBD
{
    public class AES
    {
        /// <summary>
        ///     Decripta um arquivo de conexão de banco de dados e retorna um hashtable contendo
        ///     server - servidor da conexão
        ///     username - usuario da conexão
        ///     password - senha da conexão
        ///     database - banco a se conectar
        /// </summary>
        /// <param name="arquivo">Caminho do arquivo de conexão criptografado</param>
        /// <returns></returns>
        public static Hashtable DecriptarArquivoConexao(String arquivo)
        {
            // Inicia hashtable que irá conter os dados da conexão
            Hashtable hashtableCon = new Hashtable();
            // Váriaveis que irão conter os dados da conexão
            string database, username, password, server;

            try
            {
                // Password da criptografia
                string passwordKey = @"Livraria";

                // Converte a chave em array de bytes para ser usada posteriormente
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] keyBytes = UE.GetBytes(passwordKey);

                //Inicia o decriptador
                using (Rijndael cipher = Rijndael.Create())
                {
                    // Configura o decriptador
                    cipher.Padding = PaddingMode.PKCS7;
                    cipher.Mode = CipherMode.CBC;

                    // Inicia a leitura do arquivo criptado
                    using (FileStream fs = new FileStream(arquivo, FileMode.Open, FileAccess.Read))
                    {
                        // XmlDocument que recebera o arquivo decriptado
                        XmlDocument xmlDocument = new XmlDocument();

                        // Decripta o arquivo
                        using (CryptoStream cs = new CryptoStream(fs, cipher.CreateDecryptor(keyBytes, keyBytes), CryptoStreamMode.Read))
                        {
                            // Converte o arquivo decriptado em XmlDocument
                            using (XmlReader reader = new XmlTextReader(cs))
                            {
                                xmlDocument.Load(reader);
                            }

                            // Lê o XmlDocument
                            database = xmlDocument.DocumentElement.SelectSingleNode("/Connection/Database").InnerText;
                            username = xmlDocument.DocumentElement.SelectSingleNode("/Connection/Username").InnerText;
                            password = xmlDocument.DocumentElement.SelectSingleNode("/Connection/Password").InnerText;
                            server = xmlDocument.DocumentElement.SelectSingleNode("/Connection/Server").InnerText;

                            // Insere as informações no Hashtable
                            hashtableCon.Add("database", database);
                            hashtableCon.Add("username", username);
                            hashtableCon.Add("password", password);
                            hashtableCon.Add("server", server);

                            return hashtableCon;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
