## SISTEMA DE CADASTRO E CONTROLE DE ATENDIMENTO LABMEDICINE

### Objetivo do sistema

Esse sistema tem como objetivo criar uma API para realizar de forma automatizada o cadastro de pacientes, enfermeiro e médicos, assim como 
o controle de atendimentos realizados, armazenando as informações alimentadas em um banco de dados.

### Tecnologias utlizadas

- Linguagem C#;
- Sistema de Gerenciamento de Banco de Dados SQL Server.

### Funcionalidades

Através da utilização dos verbos CRUD (Create, Read, Update e Delete) alimentar um banco de dados, permitindo também a leitura, atualização e remoção das informações dos endpoints criados abaixo:
- Atendimento;
- Paciente;
- Médicos;
- Enfermeiros.

### Inicialização do Sistema

Na inicialização do sistema, alguns usuários fictícios serão carregados no banco de dados labmedicinedb já previamente configurado para receber as tabelas e dados do sistema.
Para criar os registros de pacientes, enfermeiros e médicos, foram utilizados dados fictícios, implementando a estratégica de cada CPF ser único, evitando qualquer
problema de dublicidade de informações no sistema, serão criados:
- 10 pacientes fictícios;
- 2 médicos fictícios;
- 2 enfermeiros fictício.

### Operação do Sistema
As funcionalidades do sistema irão operar basicamente da mesma forma nos endpoints de pacientes, médicos e enfermeiros, então para efeito de descrição será detalhado a utlização do endpoint "/paciente" que traz informações mais completas.

### Cadastro
Para se realizar o cadastro de um paciente será ulitlizado o endpoint "api/pacientes" e deve se realizado através da requisição HTTP Post. O corpo da requisição deve conter um objeto JSON com os seguintes campos obrigatórios: nome completo, gênero, data de nascimento, CPF, telefone e contato de emergência, e também um identificador (Id) que será gerado automaticamente pelo sistema. Conforme já mencioado o CPF deverá ser único por paciente e será validado para não haver duplicidade.
Em caso de sucesso, a resposta será um HTTP Status Code 201 (CREATED), contendo no corpo da resposta o código atribuído ao novo paciente cadastrado, além dos demais campos.
No caso dos dados serem inválidos, o HTTP Status Code 400 (Bad Request) será retornado, informando uma mensagem de erro explicativa no corpo da resposta.
Já se o CPF informado já estar cadastrado, o HTTP Status Code 409 (Conflict) será retornado, informando uma mensagem de erro explicativa no corpo da resposta.

### Atualização
Essa funcionalidade permite que seja atualizado/alterado os dados de um paciente no sistema e pode ser utlizado sempre que necessário pelo usuário do sistema.
Para se realizar a atualização de um paciente será utilizado o endpoint "/api/pacientes/{identificador}" e deverá ser feita através de uma requisição HTTP PUT e do identificador (Id) do cliente, que será gerado automaticamente quando realizado o cadastro no sistema.
O corpo da requisição deve conter um objeto JSON com os campos que serão atualizados.
Da mesma forma que no cadastro, quando houver sucesso na atualização, a resposta será um HTTP Status Code 200 (OK), contendo no corpo da resposta os dados atualizados do paciente.
No caso de requisição com dados inválidos, o HTTP Status Code 400 (Bad Request) será retornado, informando uma mensagem de erro explicativa no corpo da resposta.
Em caso de não ser encontrado registro com o código informado, o HTTP Status Code 404 (Not Found) será retornado, retornando uma mensagem de erro explicativa no corpo da resposta.

### Listagem



