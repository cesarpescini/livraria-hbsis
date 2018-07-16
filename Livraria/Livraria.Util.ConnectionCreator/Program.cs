using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Livraria.Util.ConnectionCreator
{
    public class Program
    {
        // Apenas um EXEzinho usado para criar o arquivo de conexão
        // lembra que a senha do encriptador daqui tem que ser a mesma usada para decriptar no AES do ConexaoBD
        public static void Main(string[] args)
        {
            string rootPath = Path.GetPathRoot(Environment.CurrentDirectory);
            string fullPath = Environment.CurrentDirectory;
            string fullPathFile = Path.Combine(Environment.CurrentDirectory, "connection.xml");

            Console.WriteLine("Informe o endereço do servidor (ex: localhost):");
            string server = Console.ReadLine();

            Console.WriteLine("Informe o nome do banco de dados:");
            string database = Console.ReadLine();

            Console.WriteLine("Informe o nome de usuário do mysql:");
            string username = Console.ReadLine();

            Console.WriteLine("Informe a senha do usuário:");
            string password = Console.ReadLine();

            try
            {
                new XDocument(
                    new XElement("Connection",
                        new XElement("Database", database),
                        new XElement("Username", username),
                        new XElement("Password", password),
                        new XElement("Server", server)
                    )
                )
                .Save(fullPathFile);

                EncryptFile(fullPathFile, fullPath + "\\connection.snc");

                Console.WriteLine("XML criado com sucesso na pasta com o nome connection.xml'. Pressione qualquer tecla para sair");

                File.Delete(fullPathFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("erro " + ex.Message);

            }
        }

        private static void EncryptFile(string inputFile, string outputFile)
        {

            try
            {
                string password = @"Livraria"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);

                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao encriptar: " + e.Message);
            }
        }
    }
}
