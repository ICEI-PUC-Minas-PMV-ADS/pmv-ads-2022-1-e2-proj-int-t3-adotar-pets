# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

A definição exata do problema e os pontos mais relevantes a serem tratados neste projeto foi consolidada com a participação dos usuários em um trabalho de imersão feito pelos membros da equipe a partir da observação dos usuários em seu local natural e por meio de entrevistas. Os detalhes levantados nesse processo foram consolidados na forma de personas e histórias de usuários.

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas na Figuras que se seguem.


  ![Persona-Iza](https://user-images.githubusercontent.com/91227939/158077823-fa7e5bdf-223b-4952-b6c9-907368a2d093.png)
  ![Persona-Sulamita](https://user-images.githubusercontent.com/91227939/158077918-1f4632bd-3616-4dd9-8a34-338852ff72b8.png)

  

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

![Historia-de-usuario](https://user-images.githubusercontent.com/91227939/158077944-c13f5e33-fca5-476e-9799-3977fc80b440.png)


> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RF-001| O site deverá possuir uma landing page, com campos de busca, log in, cadastro de novos usuários, cartões informativos e outras ferramentas básicas para a sua navegação na  plataforma | ALTA | 
|RF-002| O botão de cadastro deverá redirecionar o usuário a uma nova página a qual será permitido o cadastro de novos usuários na plataforma   | ALTA |
|RF-003| O site deverá apresentar uma forma dos usuários redefinir sua senha em caso de esquecimento pelo usuário | ALTA |
|RF-004| O site deverá apresentar no menu principal um link para uma página secundária com informações sobre o serviço prestado pelo site | MÉDIA |
|RF-005| O site deverá apresentar no menu principal um link para os perfis dos pets cadastrados pelas ONG´s para adoção | ALTA |
|RF-006| O site deverá permitir, por parte das ONG 's, o cadastro de animais para adoção, tendo esse novo animal uma página de perfil gerada para a visualização dos usuários da plataforma | ALTA |
|RF-007| O site deverá apresentar no menu principal um link para uma página secundária com as informações dos animais que já foram adotados (descrição e foto) | ALTA |
|RF-008| A página de perfil do animal a ser adotado deverá possuir um botão que redireciona o usuário a uma nova página com um formulário de solicitação de adoção | ALTA |
|RF-009| O formulário deverá ser criado com perguntas objetivas, sobre as pretensões do usuário, perfil doméstico e físico da casa, tendo essas respostas apenas abertas ao usuário e a ONG | MÉDIA |
|RF-010| O site deverá apresentar no formulário de solicitação de adoção um método de envio dos dados cadastrados para a ONG que cadastrou o animal com um “score” do adotante conforme conjunto de respostas (pontuação) | MÉDIA |
|RF-011| O site deverá apresentar na página dos perfis dos pets uma marcação de adotado, para que não seja permitido o envio de novas propostas de adoção | MÉDIA |
|RF-012| O site deverá apresentar na página de adotados a desmarcação de adotado caso o animal adotado seja devolvido e irá retornar para a lista de animais para adoção na página de perfis de pets | BAIXA |
|RF-013| O site deverá apresentar na página dos perfis dos pets um score para cada animal cadastrado com a quantidade de interessados que preencheram o formulário para adoção | MÉDIA |
|RF-014| O site deverá apresentar no corpo de sua página principal card com link para redirecionamento para a página secundária de perfis dos pets já filtrado por gatos e cachorros | ALTA |
|RF-015| O site deverá apresentar no rodapé um link de contato para redirecionamento para página secundária com formulário para envio de e-mail | MÉDIA |
|RF-016| O site deverá apresentar no rodapé um link de contato para redirecionamento para página secundária com a Política de Privacidade e Termos de Uso | BAIXA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA | 
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


>Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

<p align = "center">
  <img src = "pmv-ads-2022-1-e2-proj-int-t3-adotar-pets/docs/img/DCaso.jpeg">
</p>

>O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
