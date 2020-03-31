# Ateliex

# An�lise e Projeto

## Migrations

add-migration -name Initial -project Ateliex.EntityFrameworkCore -startupproject Ateliex.Windows
update-database -project Ateliex.EntityFrameworkCore -startupproject Ateliex.Windows
drop-database -project Ateliex.EntityFrameworkCore -startupproject Ateliex.Windows

## WPF

https://simpleinjector.readthedocs.io/en/latest/wpfintegration.html

### Nuget
- Microsoft.UI.Xaml

# Limita��es
- N�o � poss�vel observar a altera��o de um modelo em um plano comercial; o EF sobreescreve a propriedade modelo; era necess�rio para atualizar o pre�o de venda quando mudasse o custo de produ��o; por�m, como s�o agregados diferentes, isso n�o chega a ferir a l�gica de agregados?

# TODO
- Novos itens filhos n�o est�o pegando corretamente um novo Id.
- Adi��o de modelo na tabela de pre�os est� ficando duplicado.
- Id com n�mero da coluna ainda n�o funcionam corretamente; quando existe mais de uma p�gina de scroll, o problema � observado.
- Implementar os campos com a descri��o "sugerido" (ex.: pre�o de venda sugerido).
- Implementar os pedidos de vendas.