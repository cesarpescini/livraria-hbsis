# Passos para testar o projeto
  1. Instalar MySql Atenção com as configurações, o usuário deve ser root, a senha root. Caso sejá necessário fazer de uma maneira diferente leia as observações no final.
  2. Executar os comandos do arquivo DBLIVRARIA.txt. 
  3. Abrir a solução Livraria.sln, com visual studio 2017, será necessário o .NET framework 4.6.1 instalado na máquina para que o projeto funcione
  4. Executar o projeto Livraria.WebApi
  5. Com o projeto Livraria.WebApi rodando basta abrir a pasta livraria-frontend no VSCode e no terminal executar o comando npm start (será necessário ter node.js instalado na máquina)
  
  # IMPORTANTE
  O projeto lê a conexão com o bando de dados de um arquivo criptado chamado **connection.snc**, se necessário trocar a string de conexão deve-se executar o projeto **Livraria.Utils.ConnectionCreator**, o projeto vai pedir todas as informações da conexão e depois vai gerar o arquivo connection.snc na sua pasta de execução, basta copiar e colar o arquivo na pasta Livraria.WebApi dentro da raíz da solução.
