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
Os campos a serem alimentados para pessoa cadastrada no sistema, podem variar de acordo com cada tipo de cadastro que estão listados abaixo:

### Paciente:
(todos os campos obrigatórios) e mais;

-Tel de Emergência;

-Alergias (que serão organizadas em uma lista para ser apresentadas no banco de dados);

-Cuidados específicos ( que serão organizados em uma lista para ser apresentado no banco de dados);

-Convênio;

-Status de Atendimento (onde será informado através de um "query param", se o paciente já foi atendido, está aguardando atendimento, está em atendimento ou não foi atendido);

-Total de Atendimentos (que será alimentado a cada vez que o sistema identificar um atendimento realizado).

### Médico:
(todos os campos obrigatórios) e mais;
- Instituição de Ensino;
- CRM/UF;
- Especialização (será informada através de um "query param", onde poderá ser selecionado Clinica Geral, Anestesia, Dermatologia, Ginecologia, Neurologia, Pediatria, Psiquiatria ou Ortopedia);
- Status no Sistema; informando caso seja um médico ativo ou inativo;
- Atendimentos realizados (que será acrescido a cada atendimento identificado pelo sistema).



### Atualização
Essa funcionalidade permite que seja atualizado/alterado os dados de um paciente no sistema e pode ser utlizado sempre que necessário pelo usuário do sistema.
Para se realizar a atualização de um paciente será utilizado o endpoint "/api/pacientes/{identificador}" e deverá ser feita através de uma requisição HTTP PUT e do identificador (Id) do cliente.
O corpo da requisição deve conter um objeto JSON com os campos que serão atualizados.
Da mesma forma que no cadastro, quando houver sucesso na atualização, a resposta será um HTTP Status Code 200 (OK), contendo no corpo da resposta os dados atualizados do paciente.
No caso de requisição com dados inválidos, o HTTP Status Code 400 (Bad Request) será retornado, informando uma mensagem de erro explicativa no corpo da resposta.
Em caso de não ser encontrado registro com o código informado, o HTTP Status Code 404 (Not Found) será retornado, retornando uma mensagem de erro explicativa no corpo da resposta.

### Listagem
Essa funcionalidade permite que seja listado os pacientes já cadastrados previamente no sistema, e deve ser realizado através de uma requisição HTTP Get, e poderá ser realizada de duas formas, utlizando-se o endpoint "/api/paciente" ou "/api/pacientes/{identificador}", onde a primeira permite que seja listado todos os pacientes e a segunda faz uma busca através do identificador (Id);
Quando a listagem é realizada de maneira genérica, o sistema permite que seja feita uma filtragem atráves de um "query param"  um status não obrigatório que permite identificar o status de atendimento pré definido (AGUARDANDO_ATENDIMENTO, EM_ATENDIMENTO, ATENDIDO e NÃO ATENDIDO), o sistema então retornará com um JSON contentado a listagem dos pacientes encontrados. Já quando a listagem é realizada através do identificador (Id), o "query param" não é apresentado e o sistema retorna um JSON com o paciente com o identificador (Id) correspondente.
Quando a listagem ocorrer de forma correta a resposta será um HTTP Status Code 200 OK com a listagem dos pacientes, ou os dados do paciente solicitado.
Na listagem realizada pelo identificador (Id), caso o registro não seja encontrado o sistema retornará a resposta HTTP Status Code 404 (Not Found) informando a mensagem de erro explicativa no corpo da resposta.

### Exclusão
Essa funcionalidade permite que seja removido um paciente cadastrado previamente no sistema, e deve ser realizado através de uma requisição HTTP Delete, utilizando-se o endpoint /api/pacientes/{identificador}.
Em caso da exclusão ser bem sucedida o sistema deve retornar um HTTP com o Status Code 204 (No Content), sem a necessidade de um JSON de retorno do sistema.
Caso os dados não sejam encontrados o sistema o retorno enviado será um HTTP Status Code 404 (Not Found), retornando uma mensagem de erro explicativa no corpo da resposta.




