
# Calculadora de notas do Planilhas Google

Este projeto tem como objetivo criar uma aplicação em C# com .Net 7 Framework para interagir com o Planilhas Google. O aplicativo lê dados de uma planilha, realiza os cálculos necessários com base em critérios predefinidos e atualiza a planilha de acordo.

Este projeto foi criado com base no PROCESSO SELETIVO – DESAFIO DE PROGRAMAÇÃO da Tunts.Rocks 2024.

## Características

- Lê uma planilha do Planilhas Google.
- Calcula a situação de cada aluno com base nas notas dos exames e na frequência.
- Determina se um aluno foi "Reprovado por Nota", "Exame Final", "Aprovado" ou "Reprovado por Ausência".
- Calcula a “Nota de Aprovação Final” para alunos na situação de “Exame Final”.

## Critérios para cálculos
**Sistema de classificação:**

Se a média (m) dos três exames (P1, P2 e P3) for:

**m < 5:** O aluno é "Reprovado por nota".

**5 <= m < 7:** O aluno está agendado para um “Exame Final”.

**m >= 7:** O aluno é "Aprovado".

Caso o número de faltas ultrapasse 25% do total de aulas, o aluno é “Reprovado por Falta”, independente da nota.

**Cálculo do Exame Final:**

Se a situação for “Exame Final”, a “Nota de Aprovação Final” (naf) de cada aluno deverá satisfazer a seguinte equação: **5 <= (m + naf)/2.**

## Credenciais Google Sheets
Para executar a aplicação com sucesso, é necessário adquirir uma credencial do Google Sheets seguindo estas etapas:

    1. Acesse o Google Developer Console.
    2. Clique na seção "Biblioteca" do console.
    3. Selecione a API do Google Sheets.
    4. Acesse a opção "Gerenciar".
    5. Prossiga para a criação de credenciais.
    6. Preencha os dados solicitados no formulário.
    7. Após o preenchimento, será disponibilizado o download de um arquivo no formato .json.
    8. Adicione este arquivo à pasta do projeto.
    9. Execute os comandos conforme descrito na seção "Instruções de linha de comando".

## Instruções para Execução

Para executar o aplicativo, siga estas etapas:

    1. Clone o repositório em sua máquina local.
    2. Abra o arquivo de código no Visual Studio ou em qualquer IDE compatível com C#.
    3. Faça a build para resolver dependências.
    4. Execute o aplicativo.
    5. Siga as instruções para autenticar e interagir com o Planilhas Google.

## Instruções de linha de comando
Comandos de exemplo para executar o aplicativo:

```bash
    dotnet restore
    dotnet run
```
    
## Linguagem

Todo o código-fonte, incluindo atributos, classes, funções, comentários, etc., são escritos em inglês, exceto identificadores pré-definidos e textos especificados neste desafio.


## O que eu aprendi?


Com esse projeto, aprendi a criar uma API para o Planilhas Google, colocando em prática diversos conceitos que já havia aprendido, como loops e listas, por exemplo. Foi também o primeiro projeto que comecei do 0, e senti um avanço nas minhas habilidades de programação porque consegui exercitar não só os conceitos, mas também a abstração e a lógica.


## Referências

 - [Documentação C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
 - [Documentação do Planilhas Google](https://developers.google.com/sheets/api/guides/concepts?hl=pt-br)



## Obrigada

Para qualquer dúvida ou comentário, entre em contato comigo. Obrigada pelo seu interesse e contribuição!
