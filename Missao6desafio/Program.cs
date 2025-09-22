using System;
using System.Collections.Generic;
using System.Linq;

// Define a classe para um item individual do pedido.
public class ItemPedido
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    // Construtor para inicializar as propriedades do item.
    public ItemPedido(string nome, decimal preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    // Método para calcular o subtotal do item (preço * quantidade).
    public decimal CalcularSubtotal()
    {
        return Preco * Quantidade;
    }
}

// Define a classe para o pedido, que contém uma lista de itens.
public class Pedido
{
    private readonly List<ItemPedido> itens = new List<ItemPedido>();

    // Método para adicionar um novo item à lista de itens do pedido.
    public void AdicionarItem(ItemPedido item)
    {
        itens.Add(item);
    }

    // Método para calcular o valor total do pedido somando os subtotais de todos os itens.
    public decimal CalcularTotal()
    {
        // Usa LINQ para somar o subtotal de cada item na lista.
        return itens.Sum(item => item.CalcularSubtotal());
    }

    // Método para exibir os detalhes do pedido e o total final.
    public void ExibirDetalhes()
    {
        Console.WriteLine("--- Detalhes do Pedido ---");
        foreach (var item in itens)
        {
            Console.WriteLine($"Item: {item.Nome}, Preço Unitário: {item.Preco:C}, Quantidade: {item.Quantidade}, Subtotal: {item.CalcularSubtotal():C}");
        }
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Total do Pedido: {CalcularTotal():C}");
    }
}

// Classe principal para executar o programa.
public class Program
{
    public static void Main(string[] args)
    {
        // Cria uma nova instância da classe Pedido.
        Pedido pedido = new Pedido();

        // Cria e adiciona itens ao pedido.
        pedido.AdicionarItem(new ItemPedido("Notebook", 2500.00m, 1));
        pedido.AdicionarItem(new ItemPedido("Mouse sem fio", 75.50m, 2));
        pedido.AdicionarItem(new ItemPedido("Monitor Ultrawide", 1200.00m, 1));
        pedido.AdicionarItem(new ItemPedido("Teclado mecânico", 350.00m, 1));

        // Exibe os detalhes do pedido, incluindo o total.
        pedido.ExibirDetalhes();
    }
}
