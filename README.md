# Leilão Online
Projeto em C# que gerencia leilões, utilizando o padrão state e com a implementação de testes unitários com xUnit

Algumas informações úteis para a criação de testes:

Nomenclaturas para orgaização de testes:
- Classe -> Nome da classe e método a ser testado
- Método -> Retorno esperado dado um cenário

Definição de atributos do xUnit:
- [Fact] -> Define método que realiza um teste com parâmetros de entrada imutáveis, presentes dentro do próprio método
- [Theory] -> Define método que realiza vários testes com base nos parâmetros passados
- [InlineData] -> Simula uma passagem de parâmetros para o método. Sempre deve ter a mesma estrutura da assinatura do método.
  - ex.: [InlineData("a", 0)] -> O método deve ser public void Teste(string v1, int v2)

*Informações retiradas de documentações da Microsoft*

TDD:

O principal conceito que o TDD prega, é que devemos nos atentar aos testes ANTES da implementação do método em si, e seguindo a ordem como ilustrada na imagem abaixo:

![image](https://user-images.githubusercontent.com/26116319/152895777-485f0fab-fa9d-4609-9368-c32a76098bd1.png)

*"E como vamos testar os métodos privados?"*

A documentação da Microsoft diz que dificilmente precisaremos testar métodos privados, além de que estes métodos em algum momento deverão ser chamados por métodos públicos. Desta forma, testaremos o método privado testando o público mais "próximo" dele.

