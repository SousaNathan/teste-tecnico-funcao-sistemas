# Teste Técnico - Desenvolvedor .NET | Função Sistemas

Bem-vindo ao teste prático para o cargo de Desenvolvedor .NET. Abaixo estão as tarefas e requisitos necessários para a realização deste teste.

## Objetivo do Teste

Avaliar o conhecimento técnico e a lógica de desenvolvimento para a vaga de desenvolvedor .NET.

## Requisitos Necessários

- **Solution:** [FI.WebAtividadeEntrevista.zip](http://atende.funcao.com.br/download/FI.WebAtividadeEntrevista.zip)
- **Visual Studio 2022:** [Baixe aqui](https://visualstudio.microsoft.com/pt-br/downloads/)
- **Observação:** Ao instalar o Visual Studio, inclua as opções: “Pacote de direcionamento do .NET Framework 4.8”, “SDK do .NET Framework 4.8” e “SQL Server Express 2019 LocalDB”.

## Como Começar

Após fornecer os requisitos necessários, descompacte o arquivo ZIP **FI.WebAtividadeEntrevista.zip**. Dentro, você encontrará a solution **FI.WebAtividadeEntrevista.sln** referente a um sistema de manutenção de dados de clientes. Ao executar o sistema, você verá a aba “Clientes” com a funcionalidade de incluir um novo cliente através do botão “Novo Cliente”.

## Tarefas do Teste

Com base no sistema fornecido, as seguintes implementações devem ser realizadas:

### 1. Implementação do CPF do Cliente

- Adicionar um novo campo denominado "CPF" na tela de cadastro/alteração de clientes.
- O campo "CPF" deve ser obrigatório e seguir a formatação padrão de CPF (999.999.999-99).
- Validar o CPF de acordo com o cálculo de verificação padrão.
- Garantir que o CPF não seja duplicado no banco de dados.
- Alterar o banco de dados para incluir o campo "CPF" na tabela **CLIENTES**.

### 2. Implementação do Botão Beneficiários

- Adicionar um botão "Beneficiários" na tela de cadastro de clientes.
- Ao clicar, abrir um pop-up para inclusão de "CPF" e "Nome do beneficiário".
- Exibir um grid com os beneficiários cadastrados, permitindo a manutenção (alteração e exclusão).
- Validar o CPF do beneficiário de acordo com o padrão (999.999.999-99) e garantir que o CPF não seja duplicado para o mesmo cliente.
- Gravar os beneficiários na tabela **BENEFICIARIOS**, que inclui os campos: "ID", "CPF", "NOME" e "IDCLIENTE".

## Layout das Telas

Após implementar as funcionalidades acima, o layout das telas deverá ser organizado da seguinte forma:

- **Cadastro de Cliente:** Tela de cadastro com o campo "CPF" e o botão "Beneficiários".
- **Pop-up de Beneficiários:** Pop-up com campos para CPF e Nome, além de um grid para manutenção de beneficiários.

## Tarefas Realizadas

Este teste envolveu a implementação de diversas funcionalidades, bem como a atualização e revisão do código base. As principais tarefas realizadas incluem:

- Implementação do campo **CPF** para os clientes, com validação de CPF e a formatação **999.999.999-99**.
- Inclusão de um botão **Beneficiários** no cadastro de clientes, permitindo a inclusão, alteração e exclusão de beneficiários, com a validação do CPF do beneficiário.
- Criação de novas tabelas no banco de dados para armazenar o campo **CPF** dos clientes e os dados dos beneficiários, com as devidas alterações nas estruturas existentes.

Além disso, o projeto passou por uma atualização geral para melhorar a performance e compatibilidade com versões mais recentes das bibliotecas:

- Todos os pacotes do projeto foram atualizados para garantir a compatibilidade com as versões mais recentes.
- O pacote do **Bootstrap** foi atualizado para a versão mais recente. O layout original apresentava conflitos com as classes do Bootstrap no HTML e com a versão utilizada originalmente. Para resolver esses conflitos, o framework foi atualizado e todas as classes do Bootstrap no código HTML foram revistas e alteradas para garantir que funcionassem corretamente com a nova versão.
- Revisão de todos os componentes visuais para garantir que seguissem os novos padrões do Bootstrap, assegurando uma melhor responsividade e estrutura.

O sistema agora está mais robusto, com todas as melhorias implementadas, pronto para seguir com as funcionalidades adicionais que venham a ser necessárias.
