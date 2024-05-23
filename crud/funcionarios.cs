using System;
using System.Collections.Generic;

public class Funcionario
{
    private static int proximoId = 1;
    public int Id { get; }
    public string Nome { get; set; }
    public decimal Salario { get; set; }
    public bool Gerente { get; set; }
    public bool GerenteProducao { get; set; }
    public string Senha { get; set; }
    public int[] Permissoes { get; set; }

    public Funcionario()
    {
        Id = proximoId++;
    }

    public void CadastrarFrutas()
    {
        List<Fruta> frutas = new List<Fruta>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Gerente de Produção:");
            Console.WriteLine("1. Cadastrar Frutas");
            Console.WriteLine("2. Visualizar Frutas Cadastradas");
            Console.WriteLine("3. Modificar Fruta");
            Console.WriteLine("4. Excluir Fruta");
            Console.WriteLine("5. Sair");

            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out int opcaoGerenteProducao))
            {
                Console.WriteLine("Por favor, insira um número válido.");
                Console.ReadKey();
                continue;
            }

            switch (opcaoGerenteProducao)
            {
                case 1:
                    CadastrarFruta(frutas);
                    break;
                case 2:
                    VisualizarFrutasCadastradas(frutas);
                    break;
                case 3:
                    ModificarFruta(frutas);
                    break;
                case 4:
                    ExcluirFruta(frutas);
                    break;
                case 5:
                    Console.WriteLine("Saindo do menu Gerente de Produção...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    private void CadastrarFruta(List<Fruta> frutas)
    {
        Fruta novaFruta = new Fruta();
        Console.Clear();
        Console.WriteLine("Cadastro de Fruta:");
        Console.Write("Nome da fruta: ");
        novaFruta.Nome = Console.ReadLine();

        while (true)
        {
            Console.Write("Preço da fruta: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                novaFruta.Preco = preco;
                break;
            }
            else
            {
                Console.WriteLine("Por favor, insira um preço válido.");
            }
        }

        Console.Write("Tipo da fruta: ");
        novaFruta.Tipo = Console.ReadLine();
        frutas.Add(novaFruta);
        Console.WriteLine("Fruta cadastrada com sucesso!");
        Console.ReadKey();
    }

    private void VisualizarFrutasCadastradas(List<Fruta> frutas)
    {
        Console.Clear();
        if (frutas.Count == 0)
        {
            Console.WriteLine("Nenhuma fruta cadastrada.");
        }
        else
        {
            Console.WriteLine("\nFrutas Cadastradas:");
            foreach (var fruta in frutas)
            {
                Console.WriteLine($"Nome: {fruta.Nome}, Preço: {fruta.Preco}, Tipo: {fruta.Tipo}");
            }
        }
        Console.ReadKey();
    }

    private void ModificarFruta(List<Fruta> frutas)
    {
        Console.Clear();
        if (frutas.Count == 0)
        {
            Console.WriteLine("Nenhuma fruta cadastrada para modificar.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Modificar Fruta:");
        Console.WriteLine("Lista de Frutas:");
        for (int i = 0; i < frutas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Nome: {frutas[i].Nome}, Preço: {frutas[i].Preco}, Tipo: {frutas[i].Tipo}");
        }

        Console.Write("Escolha o número da fruta que deseja modificar ou digite 0 para sair: ");
        if (!int.TryParse(Console.ReadLine(), out int indice) || indice <= 0 || indice > frutas.Count)
        {
            Console.WriteLine("Por favor, escolha um número válido.");
            return;
        }

        Fruta frutaSelecionada = frutas[indice - 1];
        Console.WriteLine($"Modificando a fruta: {frutaSelecionada.Nome}");

        Console.Write("Novo nome da fruta: ");
        frutaSelecionada.Nome = Console.ReadLine();

        while (true)
        {
            Console.Write("Novo preço da fruta: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal novoPreco))
            {
                frutaSelecionada.Preco = novoPreco;
                break;
            }
            else
            {
                Console.WriteLine("Por favor, insira um preço válido.");
            }
        }

        Console.Write("Novo tipo da fruta: ");
        frutaSelecionada.Tipo = Console.ReadLine();

        Console.WriteLine("Fruta modificada com sucesso!");
        Console.ReadKey();
    }

    private void ExcluirFruta(List<Fruta> frutas)
    {
        Console.Clear();
        if (frutas.Count == 0)
        {
            Console.WriteLine("Nenhuma fruta cadastrada para excluir.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Excluir Fruta:");
        Console.WriteLine("Lista de Frutas:");
        for (int i = 0; i < frutas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Nome: {frutas[i].Nome}, Preço: {frutas[i].Preco}, Tipo: {frutas[i].Tipo}");
        }

        Console.Write("Escolha o número da fruta que deseja excluir ou digite 0 para sair: ");
        if (!int.TryParse(Console.ReadLine(), out int indice) || indice <= 0 || indice > frutas.Count)
        {
            Console.WriteLine("Por favor, escolha um número válido.");
            return;
        }

        Fruta frutaSelecionada = frutas[indice - 1];
        Console.WriteLine($"Excluindo a fruta: {frutaSelecionada.Nome}");
        frutas.RemoveAt(indice - 1);
        Console.WriteLine("Fruta excluída com sucesso!");
        Console.ReadKey();
    }
}
