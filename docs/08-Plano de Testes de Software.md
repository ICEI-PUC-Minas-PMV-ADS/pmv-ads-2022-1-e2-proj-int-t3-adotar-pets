# Plano de Testes de Software

## Plano de testes

Os planos de teste serão realizados de acordo com as funcionalidades e controle de acesso. A realização dos testes apresentará um score cuja classificação é apresentada na tabela abaixo:

|Score|Ação                           |Exemplo                                                                                                   |
|-----|-------------------------------|----------------------------------------------------------------------------------------------------------|
|0	   |A ação testada apresentou problemas críticos que inviabilizam a plataforma.|A plataforma apresenta um _looping_ infinito no cadastro de novos dados.|
|1    |A ação testada apresentou problemas graves que podem gerar problemas a plataforma.|A plataforma apresenta um tempo muito grande para realizar busca em um banco de dados.|
|2    |A ação testada problemas leves que possui uma probabilidade baixa de apresentar danos a plataforma|O usuário não faz o login automático ao realizar o cadastro.|
|3    |A ação testada não apresentou erros aparentes|-|

Os testes de seguirão os planos de acordo com suas classificações:

### a. Testes de funcionalidades

Os testes de funcionalidades serão realizados com o objetivo de verificar as funcionalidades propostas para a plataforma e como elas se comportam.

|Caso de Teste        |CT-01 - Fluxo de cadastro de animais                            |
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 005: OO site deverá permitir, por parte das ONGs e protetores, o cadastro de animais para adoção com fotos, descrição, condições especiais e pontuação mínima para recebimento direto de pedidos de adoção.<br>RF - 007: O site deverá possuir uma página dedicada para o perfil do pet cadastrado, com botões para o fluxo de adoção ou de doação para a entidade responsável.<br>RF - 009: O site deverá fornecer às ONGs e protetores a possibilidade de gerenciar os dados de um animal cadastrado, bem como seu status de disponibilidade para adoção.| 
|Objetivos do Teste   |Verificar o fluxo de cadastro de novos animais na plataforma|
|Passos               |1: Acesso a plataforma com cadastro de ONG ou Protetor;<br>2:	Acessar a área de usuário;<br>3: reencher campos de cadastro de um novo pet<br>4	Entrar no perfil do novo pet;<br>5: Voltar a pagina do usuário e editar campos do pet cadastrado anteriormente<br>6:	Entrar no perfil do pet cadastrado e verificar alterações;|
|Critérios de êxito   |1: Gerar novo registro de pet, a partir do preenchimento do formulário de cadastro do pet<br>2: Validação dos campos de cadastro;<br>3: Gerar uma página de perfil para o pet com as informações fornecidas<br>4: A plataforma deve gerar alterações no perfil, caso o usuário o faça|

|Caso de Teste        |CT-02 - Fluxo de adoção do usuário adotante                     |
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 006: O site deverá fornecer aos adotantes uma página de busca de animais para adoção, com filtros por tipo de animal, porte, raça e gênero.<br>RF - 007: O site deverá possuir uma página dedicada para o perfil do pet cadastrado, com botões para o fluxo de adoção ou de doação para a entidade responsável.<br>RF - 008: O site deverá fornecer um questionário de adoção dinâmico, com sistema interno de pontuação (score), que será respondido por adotantes e direcionados, por e-mail, ao responsável pelo animal se a pontuação mínima for satisfatória.| 
|Objetivos do Teste   |Gerar requisição de adoção para um pet, com o preenchimento e o envio deste para a ONG responsável pelo perfil do pet.|
|Passos               |1: O usuário realizará uma busca pelo animal pela página de busca;<br>2:	O usuário irá clicar no botão de adoção<br>3: O site deverá verificar a autenticação do usuário, se ele estiver logado, deve seguir para a página de preenchimento de formulário, caso contrário o usuário deverá realizar o login como usuário (adotante);<br>4:	Preencher o formulário de adoção e realizar o envio;<br>5:	O perfil deverá constar na página de histórico do perfil de usuário da ONG.|
|Critérios de êxito   |1: Gerar requisição de adoção para a ong;<br>2: Inserir dados dos usuários no histórico de adotantes no perfil da ONG.|

### b. Testes de controle de acesso:

Os testes de controle de acesso serão realizados com o objetivo de avaliar o controle de acesso dos usuários a funcionalidades restritas de cada entidade.

|Caso de Teste        |CT-03 - Cadastro de novos usuários na plataforma|
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 002: O site deverá fornecer um formulário de cadastro para Pessoa Física (adotantes) Pessoa Jurídica (ONGs / protetores).<br>RF - 004: O site deverá fornecer um link de logout para todos os usuários autenticados.
|Objetivos do Teste   |Verificar o fluxo de cadastro de novos usuários na plataforma por meio de novos cadastros, login de usuários já cadastrados e o seu logout.|
|Passos               |1: Acesso da plataforma;<br>2: Realizar o cadastro das entidades (ONG/Protetor/Adotante);
|Critérios de êxito   |1: Acesso do usuário a plataforma via login<br>2: Comunicação com o banco de dados de forma estável;<br>3: Validação dos campos do formulário de cadastro<br>|

|Caso de Teste        |CT-04 - Login de usuários                     |
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 002: O site deverá fornecer um formulário de cadastro para Pessoa Física (adotantes) Pessoa Jurídica (ONGs / protetores).<br>RF - 011: O site deverá fornecer um formulário de edição de perfil para todas as entidades de usuário.| 
|Objetivos do Teste   |Verificar o fluxo de acesso dos usuários a plataforma.|
|Passos               |1: Realizar login com usuário(adotante);<br>2:	Acessar a área de usuário adotante;<br>3: Realizar alterações nos dados;<br>4:	Verificar se as alterações foram validadas;<br>5:	Fazer logout;<br>6:	Verificar se o usuário não possui mais acesso a área restrita;<br>7:	Realizar login com usuário ONG;<br> 8:	Acessar a área de usuário adotante;<br>9: Realizar alterações nos dados<br>10: Verificar se as alterações foram validadas;<br>11: Fazer logout<br>12: Verificar se o usuário não possui mais acesso a área restrita;|
|Critérios de êxito   |1: Realizar o login e ter acesso a área restrita de usuário;<br>2:	Permitir o acesso e alterações de campos dos usuários validados;<br>3:	Restringir o acesso a área restrita de usuários não permitidos (não logados)|
