# Registro de Testes de Usabilidade

## Relatório de Teste de Usabilidade

### **1-Propósito do Teste**

O propósito é verificar se a interface e a performance da solução proporcionam uma boa experiência para o usuário, ao identificar se há necessidade de alterações antes da entrega do projeto

### **2-Metodologia**
Conforme estabelecido no plano de teste de usabilidade, foram aplicados os testes de “Heurística de Nielsen” e o de “Descoberta de problemas”. O teste heurístico foi aplicado ao longo do desenvolvimento, a medida em que as funcionalidades foram entregues. Já o de descoberta de problemas foi aplicado na entrega da primeira versão funcional da solução.

### **3-Teste Heurístico**

#### **3.1-Ferramentas**
Foi definida a seguinte escala para definição dos níveis de problemas de usabilidade a serem resolvidos pela equipe:

| Escala       | Descrição                                         
|--------|-
|Nível 01  |Não há um problema de usabilidade         | 
|Nível 02 | Problema estético que só será corrigido caso haja tempo disponível.
|Nível 03 | Problema de usabilidade com baixa prioridade na correção.  
|Nível 04 | Problema com média/alta prioridade de correção.  
|Nível 05 | Problema com altíssima necessidade de correção, inviabilizando a entrega da funcionalidade.


#### **3.2-Resultados**
Os testes heurísticos aplicados ao longo do desenvolvimento da solução foram registrados. Na primeira aplicação do teste foram analisadas as telas de cadastro e login (RF-002, RF-003). O único problema crítico encontrado foi o de Controle e liberdade para o usuário. Para corrigir o grupo optou por adicionar um botão de retorno em ambas as páginas. Em seguida, após a produção de todas as telas foi reaplicado o teste das 10 Heurísticas de Nielsen em todas as páginas do projeto. A avaliação foi feita pelos participantes da equipe de back-end, que não trabalharam diretamente na construção da interface da página. Algumas das heurísticas foram avaliadas em conjunto devido a similaridade dos temas. A seguir os resultados:

| Heurísticas (Nielsen)   |  Notas dos avaliadores   |  Média  | Consenso   | Considerações   | Melhorias   |
| ------------------- | --------------------- | -------------------- | -------------------- | -------------------- | -------------------- |
|  01-Visibilidade do Status do Sistema |  Avaliador 1: 1 Avaliador 2: 1 Avaliador 3: 1  | 1,0   | 1   | O sistema informa a partir dos títulos, como por exemplo: “entre para continuar” e “cadastre-se em nosso site”, e através dos subtítulos na navbar, em tempo real, onde o usuário se encontra e o que deve fazer na página.   | N/A   |
|  02-Correspondência entre o sistema e o mundo real |  Avaliador 1: 1 Avaliador 2: 1 Avaliador 3: 1 |  1,0   | 1   | O site teve compatibilidade com o mundo real, podendo usar o sistema sem interferências significativas      | N/A   |
|  03-Correspondência entre o sistema e o mundo real |  Avaliador 1: 1 Avaliador 2: 3 Avaliador 3: 3 | 2,3   | 3   | O site teve compatibilidade com o mundo real, podendo usar o sistema sem interferências significativas      | Adicionar o botão de retorno à tela de cadastro   |
|  04-Consistência e padronização |  Avaliador 1: 1 Avaliador 2: 1 Avaliador 3: 1 | 1,0   | 1   | Consistência e padronização: O sistema utiliza o mesmo padrão de botões de ação na cor amarela para ações primárias, a cor verde para ações secundárias, tons de preto para títulos e a cor vermelha para mensagens de erro. Ainda, o mesmo estilo de formulários para o preenchimento de dados.      | N/A   |
|  05-Prevenção de erros / 09-Ajude os usuários a reconhecer, diagnosticar e recuperar erros |  Avaliador 1: 1 Avaliador 2: 1 Avaliador 3: 1 | 1,0   | 1   | O sistema informa através de mensagens na cor vermelha, exatamente abaixo do erro cometido, além de destacar também de vermelho o local do erro. Assim, o usuário pode visual qual e onde está o erro que cometeu antes de enviar. O envio do formulário também é interrompido caso tenha dados errados ou não preenchidos.      | N/A   |
|  06-Reconhecimento em vez de recordação / 08-Estética e design minimalista |  Avaliador 1: 1 Avaliador 2: 1 Avaliador 3: 1 | 1,0   | 1   | O sistema informa através de mensagens na cor vermelha, exatamente abaixo do erro cometido, além de destacar também de vermelho o local do erro. Assim, o usuário pode visual qual e onde está o erro que cometeu antes de enviar. O envio do formulário também é interrompido caso tenha dados errados ou não preenchidos.      | N/A   |
|  07- Eficiência e flexibilidade de uso  |  Avaliador 1: 1 Avaliador 2: 1 Avaliador 3: 1 | 1,0   | 1   | O usuário tem a opção do autocompletar com informações que já preencheu antes, como nome, CEP, email, etc.      | N/A   |
|  10-Ajuda e documentação  |  Avaliador 1: 1 Avaliador 2: 1 Avaliador 3: 1 | 1,0   | 1   | No footer de todas as páginas há links para perguntas frequentes, contato com a administração da página, políticas de uso e informações sobre a plataforma.      | N/A   |

Demonstrações: 
![TesteDeUsabilidade-Heuristica01](/docs/img/TesteRF002-003-Heuristica01.png)

![TesteDeUsabilidade-Heuristica02](/docs/img/TesteRF002-003-Heuristica02.png)

![TesteDeUsabilidade-Heuristica03](/docs/img/TesteRF002-003-Heuristica03.png)

![TesteDeUsabilidade-Heuristica04](/docs/img/TesteRF002-003-Heuristica04.png)

![TesteDeUsabilidade-Heuristica05-09](/docs/img/TesteRF002-003-Heuristica05-09.png)

![TesteDeUsabilidade-Heuristica06-08](/docs/img/TesteRF002-003-Heuristica06-08.png)

![TesteDeUsabilidade-Heuristica07](/docs/img/TesteRF002-003-Heuristica07.png)

![TesteDeUsabilidade-Heuristica10](/docs/img/TesteRF002-003-Heuristica10.png)



### **4-Teste de detecção de problemas**

#### **4-1 Perfil do Usuário**
O teste foi aplicado a usuários com idade entre 20 e 40 anos, com nível superior completo, mais de um ano de conhecimentos básicos de informática (uso do mouse e teclado), de utilização de aplicativos básicos (como por exemplo, o Office) e de como acessar a web e utilizar navegadores, além de possuir alguma noção sobre criação de animais domésticos. 

#### **4.2- Tarefas**
Foi solicitado que cada usuário executasse uma das seguintes tarefas:

- 1-Tentasse adotar o Pet  de nome “Petito”.  
Para isso, o usuário terá que passar pelo fluxos de cadastro, autenticação, busca e adoção, que correspondem aos requisitos: RF-001, RF-002, RF-003, RF-006, RF-007, RF-008.

- 2-Simular ser um protetor e cadastrar o Pet de nome “Gatito” e troque o status dele para indisponível.
Para isso o usuário terá que passar pelos fluxos de cadastro, autenticação e cadastro de animal, que correspondem aos requisitos:  RF-001, RF-002, RF-005, RF-009.

- 3-Enviar uma mensagem de ajuda para a plataforma 
Para isso o usuário terá que passar pelo fluxo de contato, que corresponde aos requisitos: 
RF-001 e RF-014.

- 4-Localizar as informações de termos de uso, politica de privacidade, e sobre nós na plataforma. 
Para isso o usuário terá que localizar três páginas diferentes que se localizam no rodapé da página e correspondem aos requisitos: RF-001, RF-013, RF-015, RF-016.

- 5-Cadastrar na página e editar o próprio perfil
Para isso o usuário terá que passar pelo fluxo de cadastro, autenticação e edição de perfil, que correspondem aos requisitos: RF-001, RF-002, RF-003, RF-011.

#### **4.3-Ferramentas**
Foi definida a seguinte escala para definição dos níveis de problemas de usabilidade a serem resolvidos pela equipe:

| Escala       | Descrição                                         
|--------|-
|Nível 01  |Não há um problema de usabilidade         | 
|Nível 02 | Problema estético que só será corrigido caso haja tempo disponível.
|Nível 03 | Problema de usabilidade com baixa prioridade na correção.  
|Nível 04 | Problema com média/alta prioridade de correção.  
|Nível 05 | Problema com altíssima necessidade de correção, inviabilizando a entrega da funcionalidade.


### **4.4-Resultados**

| Número da Tarefa   |  Orientações   |  Tempo de execução  | Erros   | Finalizou a tarefa?   | Observações   |
| -------------- | --------------------- | -------------------- | -------------------- | -------------------- | -------------------- |
| 01 |  Usuário 01: Tente adotar o pet de Nome “Torresmo”  | 3'54''   | 2   |Conseguiu candidatar para adoção.   | A mensagem de erro nos campos de validação não desaparece quando o requisito é cumprido. /Dificuldade de perceber se o login foi feito.   |
|  02 |  Usuário 02: Simule ser um protetor e cadastre um pet de nome “Gatito”, pode inventar as informações sobre ele. |  4'48''   | 1   | Conseguiu concluir com intervenção      | O processo de cadastro foi feito com tranquilidade, porém precisou da intervenção do aplicador, pois não havia na interface lugar que indicasse onde fazer o cadastro do protetor. O teste precisou ser interrompido e aplicado a partir de outro ponto.   |
|  03|  Usuário 03: Envie uma mensagem com uma dúvida para  a plataforma | 44''   | 0   | Fez o envio      | Não houve comentários significativos.   | 
|  04 | Usuário 04: Encontre as informações de “termos de uso”, “política de privacidade” e “sobre nós | 29''   | 0   | Encontrou as páginas      | Encontrou todas as páginas com tranquilidade e bem rápido   |
|  05 |  Usuário 05: Cadastre na plataforma e faça alguma edição no seu perfil | 1'35''   | 0   | Conseguiu editar o perfil     | Fez alteração da imagem de perfil e da senha com tranquilidade, mas comentou do botão de salvar ser pequeno   |

### **4.5-Análises, recomendações**

A partir dos resultados dos testes feito com os usuários foram identificados 4 problemas de usabilidade. Sendo eles: 

`Tarefa 01:`

**Erro 1:** Dificuldade de perceber que o login foi efetuado com sucesso.

Nível: 4

Requisitos: RF-001 e RF-003.

Solução: A equipe optou por redirecionar o usuário para a tela de busca de animais quando ele consegue fazer o login ao invés de retornar para a landing page.

**Erro 2:** Mensagem de erro na validação não desaparece ao cumprir o requisito

Nível: 2

Requisitos: RF-002.

Solução: A equipe acredita que a melhor solução é colocar a validação instantânea. Caso haja tempo já será feita a atleração. 


`Tarefa 02:`

**Erro 1:** Não encontrou onde é feito o cadastro do protetor

Nível: 5

Requisitos: RF-001 e RF-002.

Solução: A equipe optou por alterar o rodapé e criar uma sessão de protetores com o acesso direto para o cadastro de pets que já redireciona para o cadastro do protetor.

`Tarefa 05:`

**Erro 1:** Botão de salvar pequeno

Nível: 2

Requisitos: RF-011

Solução: A equipe aumentará o tamanho do botão caso haja disponibilidade de tempo

### **4.5-Considerações**

Os erros de nível 4 e 5 foram corrigidos pela equipe e os de nível 2 estão sujeitos à disponibilidade de tempo. Nenhum erro foi encontrado nos testes das tarefas 03 e 04. 

###  **5-Conclusão**

Os teste de usabilidade aplicados mostraram-se úteis na identificação
dos problemas de usabilidade na plataforma. Foi possível identificar vários problemas, com diferentes graus de importância e impacto na experiência do usuário. Concluiu-se que o sistema deverá sofrer alterações como: adição de links na landing page, mudanças nos redirecionamentos, adição de botões e mudança no tamanho dos mesmos, entre outros.
Asism, a equipe conclui que a usabilidade da aplicação web é efeciente e consegue proprorcionar uma boa experiência para o usuário.