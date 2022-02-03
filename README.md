# online-auction
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
