# Desafio.API

Tecnologias: 
  - C#
  - AspNet Core
  - Entity Framework
  - Banco de dados PostgreSQL com Docker
  - Swagger
  - Teste unitários com Xunit

Motivos:
  - Familiaridade com a linguagem
  - Banco de dados Open Source e amplamente utilizado
  - Swagger para facilitar os testes com a API
  - Xunit framework amplamente utilizado para teste unitarios

Como Executar:
  - Clonar o projeto
  - Instalar o Docker
  - No terminal na pasta da API executar o comando "docker compose up -d" para instalr o Postgres e iniciar o banco de dados
  - No terminal na pasta da API executar o comando "dotnet ef database update" isso ira criar as tabelas no banco de dados e popular com as seeds
  - Executar o projeto
  - URL: http://localhost:{porta}/swagger/index.html

Observações:
  - Métodos simples de Create/Update/Delete retornam a lista atualizada de objetos para reduzir o número de requisições do front-end para o back-end
  - O algoritmo principal está na classe EntregaService, com comentários explicando alguns pontos e decisões 
  - O projeto conta com migrations
  - O projeto possui algumas seeds para já popular o banco e facilitar testes

Controllers e/ou endpoints
  - StatusDroneController
    ![image](https://github.com/user-attachments/assets/637e2031-24f8-44ae-82a6-5ada8bf490a2)
    Criação, listagem e deleção de possiveis status para os drones

  -StatusPedidoController
    ![image](https://github.com/user-attachments/assets/2b35f468-de3a-461d-b1d3-aa2fe9aba916)
    Criação, listagem e deleção de possiveis status para os pedidos

  - DroneController
    ![image](https://github.com/user-attachments/assets/87a5ff4b-dbe4-4b0c-bfb9-43968e44d79b)
    Criação, listagem e atualização dos drones
  
  - PedidoController
    ![image](https://github.com/user-attachments/assets/cb8ea159-65ab-46d6-9c2c-d8a2447050e0)
    Criação, listagem e atualização dos pedidos

  -EntregaController
    ![image](https://github.com/user-attachments/assets/e0d72d37-192a-4868-a37e-e949c1c1fcba)
    Alocar os drones para realizar a entrega dos pedidos 
    Listar entregas em andamento


