# Registro de Testes de Software

Foi realizado o teste do primeiro caso definido pelo Plano de testes de software, que consiste em cadastrar novos usuários na plataforma e fazer login e logout dos mesmos.
A seguir os resultados do teste:

|Caso de Teste        |CT-01 - Cadastro de novos usuários na plataforma, login e logout|
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF - 002: O site deverá fornecer um formulário de cadastro para Pessoa Física (adotantes) Pessoa Jurídica (ONGs / protetores).<br>RF - 004: O site deverá fornecer um link de logout para todos os usuários autenticados.
|Objetivos do Teste   |Verificar o fluxo de cadastro de novos usuários na plataforma por meio de novos cadastros, login de usuários já cadastrados e o seu logout.|
|Passos               |1: Acesso da plataforma;<br>2: Realizar o cadastro das entidades (ONG/Protetor/Adotante);<br>3: Verificar se o acesso foi permitido desse usuário;<br>4: Realizar o logout;<br>5: Realizar login com os usuários cadastrados;<br>6:Verificar a validação e realizar o logout|
|Critérios de êxito   |1: Acesso do usuário a plataforma via login<br>2: Comunicação com o banco de dados de forma estável;<br>3: Validação dos campos do formulário de cadastro<br>4: Retirada da permissão de acesso do usuário ao realizar o logout|
Score	Ação	Exemplo

3	A ação testada não apresentou erros aparentes. 





