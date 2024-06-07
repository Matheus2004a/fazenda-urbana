using System;
using System.Collections.Generic;

public class Program
{
    public static Funcionario FazerLogin(List<Funcionario> funcionarios)
{
    Console.WriteLine("Login:");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("Senha: ");
    string senha = Console.ReadLine();

    foreach (var funcionario in funcionarios)
    {
        if (funcionario.Nome == nome && funcionario.Senha == senha)
        {
            return funcionario;
        }
    }
    return null;
}


    public static void CadastrarFuncionario(List<Funcionario> funcionarios)
    {
        Funcionario novoFuncionario = new Funcionario();
        Console.WriteLine("Cadastro de Funcionário:");
        Console.Write("Nome: ");
        novoFuncionario.Nome = Console.ReadLine();

        while (true)
        {
            Console.Write("Salário: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salario))
            {
                novoFuncionario.Salario = salario;
                break;
            }
            else
            {
                Console.WriteLine("Por favor, insira um salário válido.");
            }
        }

        Console.Write("Senha: ");
        string senhaProvisoria1 = Console.ReadLine();
        Console.Write("Digite a senha novamente: ");
        string senhaProvisoria2 = Console.ReadLine();

        if (senhaProvisoria1 == senhaProvisoria2)
        {
            novoFuncionario.Senha = senhaProvisoria1;
        }
        else
        {
            Console.WriteLine("Senhas não correspondem. Cadastro cancelado.");
            return;
        }

        Console.WriteLine("Selecione o setor do funcionário:");
        Console.WriteLine("1. Produção");
        Console.WriteLine("2. Estoque");
        Console.WriteLine("3. Vendas");
        Console.WriteLine("4. Financeiro");
        Console.WriteLine("5. RH");
        Console.WriteLine("6. Administrativo");
        Console.Write("Escolha uma opção: ");
        if (!int.TryParse(Console.ReadLine(), out int opcaoSetor))
        {
            Console.WriteLine("Por favor, insira um número válido.");
            return;
        }

        switch (opcaoSetor)
        {
            case 1:
                novoFuncionario.GerenteProducao = true;
                novoFuncionario.Permissoes = new int[] { 1, 0, 0, 0, 0, 0 };
                break;
            case 2:
                novoFuncionario.Permissoes = new int[] { 0, 1, 0, 0, 0, 0 };
                break;
            case 3:
                novoFuncionario.Permissoes = new int[] { 0, 0, 1, 0, 0, 0 };
                break;
            case 4:
                novoFuncionario.Permissoes = new int[] { 0, 0, 0, 1, 0, 0 };
                break;
            case 5:
                novoFuncionario.Permissoes = new int[] { 0, 0, 0, 0, 1, 0 };
                break;
            case 6:
                novoFuncionario.Permissoes = new int[] { 0, 0, 0, 0, 0, 1 };
                break;
            default:
                Console.WriteLine("Opção inválida. Cadastro cancelado.");
                return;
        }

        funcionarios.Add(novoFuncionario);
        Console.WriteLine("Funcionário cadastrado com sucesso!");
    }

    public static void Main(string[] args)
    {
        List<Produto> produtos = new List<Produto>();
        List<Fornecedor> fornecedores = new List<Fornecedor>();
        List<Funcionario> funcionarios = new List<Funcionario>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Cadastro de Funcionário");
            Console.WriteLine("2. Login de Funcionário");
            Console.WriteLine("3. Sair");

            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Por favor, insira um número válido.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarFuncionario(funcionarios);
                    break;
                case 2:
                    Funcionario funcionarioLogado = FazerLogin(funcionarios);
                    if (funcionarioLogado != null)
                    {
                        Console.WriteLine($"Bem-vindo, {funcionarioLogado.Nome}!");
                        if (funcionarioLogado.GerenteProducao)
                        {
                            funcionarioLogado.CadastrarFrutas();
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID ou senha inválidos.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}