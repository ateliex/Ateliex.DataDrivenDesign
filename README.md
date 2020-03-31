# Ateliex

# Análise e Projeto

## Migrations

add-migration -name Initial -project Ateliex.EntityFrameworkCore -startupproject Ateliex.Windows
update-database -project Ateliex.EntityFrameworkCore -startupproject Ateliex.Windows
drop-database -project Ateliex.EntityFrameworkCore -startupproject Ateliex.Windows

## WPF

https://simpleinjector.readthedocs.io/en/latest/wpfintegration.html

### Nuget
- Microsoft.UI.Xaml

# Limitações
- Não é possível observar a alteração de um modelo em um plano comercial; o EF sobreescreve a propriedade modelo; era necessário para atualizar o preço de venda quando mudasse o custo de produção; porém, como são agregados diferentes, isso não chega a ferir a lógica de agregados?

# TODO
- Novos itens filhos não estão pegando corretamente um novo Id.
- Adição de modelo na tabela de preços está ficando duplicado.
- Id com número da coluna ainda não funcionam corretamente; quando existe mais de uma página de scroll, o problema é observado.
- Implementar os campos com a descrição "sugerido" (ex.: preço de venda sugerido).
- Implementar os pedidos de vendas.