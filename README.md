O que está sendo Entregue nestes desafio:
============================================================================
1) No que concerne as APIS estou entregando tudo o que foi pedido:
- 1) O CRUD DE VAGAS
- 2) O CRUD DE CANDIDATOS
- 3) A POSSIBILIDADE DE UM CANDIDADTO SE INSCREVER A UMA VAGA
- 4) A LISTAGEM DE CANDIDATOS CANDIDATADOS A UMA VAGA
- 5) O CADASTRO DE CURRICULOS DE CANDIDATOS

Com exceção do item 5, foram feitas  as coberturas de testes em todos os
serviços de dominio e validação de entidades, inclusive dos value objects
criados.

2) O site SPA (ANGULAR), foi feito somente para o CRUD de VAGAS.

Procedimentos para subir e testar as aplicações:

1) No SQLSERVER criar um banco de dados com um nome qualquer

2) Rodar o arquivo ScriptBanco.Txt dentro deste banco

3) Para subir a Api editar o arquivo em appsettings.json /src/ProjetoApp.Api/
   e alterar o NomeConexao para  a conexão do banco criado e que
   teve o ScriptBanco.txt rodado.

   "NomeConexao": "sua conexao sqlserver"

5) Foi criada uma documentação SWAGGER para testar as APIS. 
Subindo a aplicação Localhost, poderão ser executados testes 
da da API VIA SWAGGER https://localhost:44380/swagger/index.html

6) Todos os endpoints estão protegidos por um token, para acessos aos métodos é 
necessário gerá-lo fazendo uso do método Gerar-Token da seção Segurança, 
passando o login ATS, assim o token é gerado. Informando
este token no Authorize do SWAGGER, os métodos podem ser testados normalmente via
SWAGGER sem problemas. De dentro do site ANGULAR, este token é criado
internamente pelo APP e consome os endpoints normalmente. 
O token deve ser passado no SWAGGER sem as aspas iniciais e finais, somente
o token puro.

7) O site SPA angular foi disponibilizado na pasta /src/AppAts/
7) Via terminal, vá até esta pasta e rode o comando o npm install
8) digite o comando ng s para subir para porta 4200. 
*** (supondo que o angular cli e o npm esteja instalado na maquina)

com isso, o site já pode ser rodado em localhost:4200, rodando junto com as
APIS em https://localhost:44380

