# ClothingStockApi
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/eujuliozs/ClothingStockApi/blob/master/LICENSE)

# Sobre o Projeto
  Uma Web Api Restful Back End, criada para fins de aprendizado que simula um stock de loja Usando Asp.Net Core
  
## Tecnologias
<div style="display: inline_block"><br>
  <img align-="center" height="40" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" />
  <img align-="center" height="40" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original-wordmark.svg" />
  <img align-="center" height="40" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg" />
  <img align-="center" height="40" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" />
</div>

## Relacionamento das classes


    +-------------------+
    |      Entity       |
    +-------------------+
    | - Id: int         |
    +-------------------+
             ^
             |
    +------------------------+
    |      Clothes           |
    +------------------------+
    | - Name: string?        |  
    | - Stock: int?          |   
    | - Color: string?       |  
    | - Description: string? |
    | - ImageUrl: string?    |
    | - Size: string?        |
    +------------------------+
    
# Endpoints
Endpoints são as Urls Pelas quais a API pode ser consumida
### Login
O usuário precisa se logar com este usuário e senha para que um JWT(Json Web Token) seja gerado,
e garanta que apenas usuários autenticados possam acessar os EndPoints da Api

<img src="https://github.com/eujuliozs/ClothingStockApi/blob/master/Assets/Login.png" height=348 width=374>
(Token)

