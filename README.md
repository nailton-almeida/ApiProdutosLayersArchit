# Projeto Web API Rest de Produtos




Projeto desenvolvido para exercitar os conhecimentos obtidos de desenvolvido de Web API utilizando o .Net na versão 7. Abaixo segue as definições escolhidas para a implementação do projeto.


### Padrão Arquitetural


Foi definido que a arquitetura do projeto seria a de Camadas, visando escalabilidade através da facilidade no gerenciamento de mudanças, reutilização de código e integridade de dados.


### Abordagem de Desenvolvimento


Pelo uso do Entity Framework Core, utilizou-se a abordagem ```Code First```, no qual primeiramente foram definidas as entidades que a aplicação deveria interagir, para que somente em um segundo momento o banco de dados fosse criado.


### Banco de Dados
 A distribuição de banco de dados definida para persistir os dados recebidos pela Web API foi o Mysql. 




## Executando localmente


Se deseja utilizar o projeto localmente, realize os passos a seguir:


Baixe e instale Visual Studio através do link
```bash
https://visualstudio.microsoft.com/pt-br/
```




Baixe e instale o .Net Framework através do link
```bash
https://dotnet.microsoft.com/pt-br/download/dotnet-framework
```




Baixe e instale o Mysql através do link
```bash
  https://dev.mysql.com/downloads/installer/
```


Clone o projeto


```bash
  git clone https://link-para-o-projeto
```


Entre no diretório do projeto


```bash
  cd my-project
```


Arquivo appsettings.json


```bash
  Crie o arquivo appsettings.json na pasta raiz do projeto
```


Configure a string de conexão do banco de dados


```bash
  No arquivo appsettings.json, adicione a string de conexão para o banco de dados (https://www.connectionstrings.com/mysql-connector-net-mysqlconnection/)
```


Instale o Dotnet Tool na raiz do projeto
```bash
dotnet tool install --global dotnet-ef
```


Execute as migrações para o banco de dados
```bash
dotnet ef database update
```


## Documentação da API


A seguir são apresentados os endpoints definidos para a primeira versão da API de produtos.


### Endpoint de Produtos


#### Retorna todos os produtos


```http
  GET /v1/api/produtos
```


| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| Nenhum | Nenhum | Nenhuma |


#### Retorna um produto específico


```http
  GET /v1/api/produtos/{id}
```


| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do produto que você quer visualizar |


#### Cria um produto
```http
  POST v1/api/produtos
```


| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| Nenhum      | Nenhum | **Obrigatório**. Informar no corpo da requisição as informações do produto, conforme mostrado a abaixo |




```
{
  "id": 0,
  "nome": "string",
  "descricao": "string",
  "preco": 0,
  "imagemUrl": "string",
  "estoqueProduto": 0,
  "dataCadastro": "2023-07-12T15:52:52.129Z",
  "categoriaId": 0,
  "categoria": {
    "id": 0,
    "nome": "string",
    "imagemUrl": "string",
    "produtos": [
      "string"
    ]
  }
}
```


#### Remove um produto


```http
  DELETE /v1/api/produtos/{id}
```


| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do produto que você deseja remover |





















