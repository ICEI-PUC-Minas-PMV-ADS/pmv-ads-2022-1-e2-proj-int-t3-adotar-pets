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

|Caso de Teste        |CT-01 - Cadastro de novos usuários na plataforma|
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 002: O site deverá fornecer um formulário de cadastro para Pessoa Física (adotantes) Pessoa Jurídica (ONGs / protetores).<br>RF - 004: O site deverá fornecer um link de logout para todos os usuários autenticados.
|Objetivos do Teste   |Verificar o fluxo de cadastro de novos usuários na plataforma por meio de novos cadastros, login de usuários já cadastrados e o seu logout.|
|Passos               |1: Acesso da plataforma;<br>2: Realizar o cadastro das entidades (ONG/Protetor/Adotante);
|Critérios de êxito   |1: Acesso do usuário a plataforma via login<br>2: Comunicação com o banco de dados de forma estável;<br>3: Validação dos campos do formulário de cadastro<br>|

|Caso de Teste        |CT-02 - Fluxo de cadastro de animais                            |
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 005: OO site deverá permitir, por parte das ONGs e protetores, o cadastro de animais para adoção com fotos, descrição, condições especiais e pontuação mínima para recebimento direto de pedidos de adoção.<br>RF - 007: O site deverá possuir uma página dedicada para o perfil do pet cadastrado, com botões para o fluxo de adoção ou de doação para a entidade responsável.<br>RF - 009: O site deverá fornecer às ONGs e protetores a possibilidade de gerenciar os dados de um animal cadastrado, bem como seu status de disponibilidade para adoção.| 
|Objetivos do Teste   |Verificar o fluxo de cadastro de novos animais na plataforma|
|Passos               |1: Acesso a plataforma com cadastro de ONG ou Protetor;<br>2:	Acessar a área de usuário;<br>3: reencher campos de cadastro de um novo pet<br>4	Entrar no perfil do novo pet;<br>5: Voltar a pagina do usuário e editar campos do pet cadastrado anteriormente<br>6:	Entrar no perfil do pet cadastrado e verificar alterações;|
|Critérios de êxito   |1: Gerar novo registro de pet, a partir do preenchimento do formulário de cadastro do pet<br>2: Validação dos campos de cadastro;<br>3: Gerar uma página de perfil para o pet com as informações fornecidas<br>4: A plataforma deve gerar alterações no perfil, caso o usuário o faça|

|Caso de Teste        |CT-03 - Fluxo de adoção do usuário adotante                     |
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 006: O site deverá fornecer aos adotantes uma página de busca de animais para adoção, com filtros por tipo de animal, porte, raça e gênero.<br>RF - 007: O site deverá possuir uma página dedicada para o perfil do pet cadastrado, com botões para o fluxo de adoção ou de doação para a entidade responsável.<br>RF - 008: O site deverá fornecer um questionário de adoção dinâmico, com sistema interno de pontuação (score), que será respondido por adotantes e direcionados, por e-mail, ao responsável pelo animal se a pontuação mínima for satisfatória.| 
|Objetivos do Teste   |Gerar requisição de adoção para um pet, com o preenchimento e o envio deste para a ONG responsável pelo perfil do pet.|
|Passos               |1: O usuário realizará uma busca pelo animal pela página de busca;<br>2:	O usuário irá clicar no botão de adoção<br>3: O site deverá verificar a autenticação do usuário, se ele estiver logado, deve seguir para a página de preenchimento de formulário, caso contrário o usuário deverá realizar o login como usuário (adotante);<br>4:	Preencher o formulário de adoção e realizar o envio;<br>5:	Verificar se o email contendo os dados do pretendente a adotante chegou ao email da ONG, caso ele tenha chegado ao score desejado<br>6:	Caso não tenha chegado ao score desejado, o perfil deverá constar na página de histórico do perfil de usuário da ONG.|
|Critérios de êxito   |1: Gerar requisição de adoção para a ong;<br>2: Enviar um email para a ONG com os dados de usuário(adotante), caso ele tenha atendido o score mínimo;<br>3: Inserir dados dos usuários no histórico de adotantes no perfil da ONG.|

### b. Testes de controle de acesso:

Os testes de controle de acesso serão realizados com o objetivo de avaliar o controle de acesso dos usuários a funcionalidades restritas de cada entidade.

|Caso de Teste        |CT-04 - Login de usuários                     |
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 002: O site deverá fornecer um formulário de cadastro para Pessoa Física (adotantes) Pessoa Jurídica (ONGs / protetores).<br>RF - 011: O site deverá fornecer um formulário de edição de perfil para todas as entidades de usuário.| 
|Objetivos do Teste   |Verificar o fluxo de acesso dos usuários a plataforma.|
|Passos               |1: Realizar login com usuário(adotante);<br>2:	Acessar a área de usuário adotante;<br>3: Realizar alterações nos dados;<br>4:	Verificar se as alterações foram validadas;<br>5:	Fazer logout;<br>6:	Verificar se o usuário não possui mais acesso a área restrita;<br>7:	Realizar login com usuário ONG;<br> 8:	Acessar a área de usuário adotante;<br>9: Realizar alterações nos dados<br>10: Verificar se as alterações foram validadas;<br>11: Fazer logout<br>12: Verificar se o usuário não possui mais acesso a área restrita;|
|Critérios de êxito   |1: Realizar o login e ter acesso a área restrita de usuário;<br>2:	Permitir o acesso e alterações de campos dos usuários validados;<br>3:	Restringir o acesso a área restrita de usuários não permitidos (não logados)|

|Caso de Teste        |CT-05 - Modificação da senha                     |
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 012: O site deverá fornecer um formulário de recuperação de senha.| 
|Objetivos do Teste   |Permitir a alteração de senha por parte dos usuários.|
|Passos               |1: Na página de login, acessar o campo de esqueci a senha;<br>2:	Preencher os campos pedidos para o envio do formulário de recuperação de senha;<br>3:	No email cadastrado do usuário, acessar o link de recuperação de senha;<br>4:	Preencher os campos de alteração;<br>5:	Verificar se houve alteração da senha ao realizar o login com a nova senha;|
|Critérios de êxito   |1:	Acesso a página de formulário de recuperação de senha;<br>2:	Envio de email com link para página de recuperação de senha do usuário que fez a requisição;<br>3:	Validação do usuário com a nova senha.|

## Testes Realizados

### CT-01: Cadastro de novos usuários na plataforma

O acesso a pagina de cadastro de novos usuários pode ser realizada acessando a página de login, pelo botão superior da landing page da plataforma, conforme a imagem:

IMAGEM 1

Ao acessar a pagina de login o usuário estará na sessão de login, podendo se cadastrar no botão “Clique aqui” abaixo do botão de entrar, conforme a imagem:

IMAGEM 2

Na pagina de cadastro os usuários se diferenciam entre adotante e protetor pelo tipo de documento que é inserido, nesse caso, o usuário adotante será uma pessoa física utilizando um CPF e no caso de uma ONG será utilizado um CNPJ.

Para esse caso de teste será utilizado os seguintes passos:
### 1-	Tentar cadastrar com:
#### a.	Algum campo faltante;
#### b.	CNPJ ou CPF errado;
#### c.	Data de nascimento de usuário menor que 18 anos;
#### d.	CEP errado
#### e.	Email errado
#### f.	Senhas com menos de 8 caracteres e não combinantes;
#### g.	Usuários testes: Adotante e ONG;

Os usuários testados serão:

### a.	Adotante:
#### a.	Nome: Usuário Teste;
#### b.	CPF: 530.634.160-88;
#### c.	CEP: 41218-155;
#### d.	Data de Nascimento: 01/01/1990;
#### e.	Email: usuarioTeste@testando.com;
#### f.	Senha: teste123;
### b.	ONG:
#### a.	Nome: ONG Teste;
#### b.	CNPJ: 41.426.959/0001-70;
#### c.	CEP: 92440-592;
#### d.	Data de Nascimento: 01/01/1990;
#### e.	Email: ONGTeste@testando.com;
#### f.	Senha: teste123;

Para os casos de teste temos:
### a.	Algum campo faltante:

Imagem 3

### b.	CNPJ ou CPF errado:

Imagem 4

A validação de documentação segue uma lógica própria cuja plataforma verifica antes de poder enviar a requisição de cadastro do usuário, nesse caso, o valor 5, do CPF do usuário, foi substituído por um 2, transformando em um documento inválido, sendo assim, bloqueado para dar prosseguimento.

### c. Data de nascimento de usuário menor que 18 anos;

Imagem 5

Uma validação para o usuário é que ele seja maior de idade, assim, quando a plataforma identifica um usuário com uma idade menor que 18, ela não permite a sequência da requisição.

### d.	CEP errado

Imagem 6

### e.	Email errado

Imagem 7

### f.	Senhas com menos de 8 caracteres e não combinantes;

### g.	Usuários testes: Adotante e ONG;

Após o cadastro de um novo usuário, o recém cadastrado é redirecionado para a tela de login para fazer o seu primeiro login na plataforma, utilizando os campos de email e a senha cadastrados.

Imagem 8 e 9

Podemos verificar que os casos de teste foram realizados com sucesso, não gerando erros, assim podemos gerar um score 3 para esse teste.

### CT-04 - Login de usuários

Utilizando os usuários cadastrados do CT-01, pode-se realizar o login desses usuários na plataforma, neste teste será testado os seguintes casos:
### a.	Campos errados
### b.	Login adotante
### c.	Login protetor
Para o primeiro caso, acessamos a página de login, e foram realizados os testes:

Imagem 10

Para o teste de acesso do usuário temos:

Foi possível o acesso do usuário a uma área do usuário adotante, podendo editar os campos de imagem, nome e email. Ao ser alterado um desses campos, é enviado um alerta da plataforma confirmando a alteração:

Imagem 11

O Logout é feito por meio do botão na tela superior clicando em sair:

Imagem 12

Ao clicar em sair o usuário é reenviado para a landing page, o teste foi realizado com a ong teste cadastrada, obtendo os mesmos resultados, assim podemos classificar esse teste com um score 3.







<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Enumere quais cenários de testes foram selecionados para teste. Neste tópico o grupo deve detalhar quais funcionalidades avaliadas, o grupo de usuários que foi escolhido para participar do teste e as ferramentas utilizadas.
 
## Ferramentas de Testes (Opcional)

Comente sobre as ferramentas de testes utilizadas.
 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
