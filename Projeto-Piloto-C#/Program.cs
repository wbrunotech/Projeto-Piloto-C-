#region Codigo
using BancoLL;
using System.Net.Http.Json;

List<Cliente> Clientes = new List<Cliente>();
ConsultarCliente();

//Se o código não existir, perguntar se deseja cadastrar um novo cliente
void ConsultarCliente()
{
    Console.WriteLine("olá! Bem vindo ao Banco LL.");
    Console.WriteLine("Digite seu código.");
    string codigo = Console.ReadLine();
    Cliente cliente null;

    foreach (cliente cli in Clientes)
    {
        if (cli.Codigo == codigo)
        {
            cliente = cli;
        }
    }
    if (cliente == null)
    {
        Console.WriteLine("Este cliente não existe. Deseja cadastrar? Digite S ou N");
        string cadastrarCliente = Console.ReadLine();
        if (cadastrarCliente == "S")
        {
            Console.WriteLine("Digite seu código:");
            string codigoClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite seu nome:");
            string nossoClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite PF ou PJ:");
            string tipoPessoa = Console.ReadLine();
            if (tipoPessoa == "PF")
                cliente = new PessoaFisica(codigoClienteNovo, nomeClienteNovo);
            else
                cliente = new PessoaJuridica(codigoClienteNovo, nomeClienteNovo);
            Clientes.Add(cliente);
            ExibirMenu(cliente);
        }
        else
            ConsultarCliente()
    }
        }

//Exibir o menu com as opções Extrato, Saque e Depósito com o switch para selecionar a opção desejada
void ExibirMenu(Cliente cliente)
{
    Console.WriteLine($"Olá {cliente.Nome}");
    Console.WriteLine("Digite a opção desejada:");
    Console.WriteLine("1 - Extrato");
    Console.WriteLine("2 - Saque");
    Console.WriteLine("3 - Depósito");

    string menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            ExibirExtrato(cliente);
            break;
        case "2":
            RealizarSaque(cliente);
            break;
        case "3":
            RealizarDeposito(cliente);
            break;
        default:
            Console.WriteLine("Digite a opção correta.");
            ExibirMenu(cliente);
            break;
    }
}

void ExibirExtrato(Cliente cliente)
{
    Console.WriteLine("-------------EXTRATO-------------");

    foreach (Movimentacao mov in  cliente.Movimentacoes)
    {
        Console.WriteLine($"{mov.Tipo} - {mov.Valor}")
    }

    Console.WriteLine("Deseja exibir o menu novamente? Digite S ou N");
    string exibirMenu = Console.ReadLine();
    if (exibirMenu == "S")
    {
        ExibirMenu(cliente);
    }
    else
    {
        Console.WriteLine("Deseja consultar outro cliente? Digite S ou N");
        string consultarCliente = Console.ReadLine();
        if (consultarCliente == "S")
            ConsultarCliente();
    }
}

void RealizarSaque(Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja sacar:");
    string valor = Console.ReadLine();
    cliente.RealizarSaque(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar outra transação? Digite S ou N");
    string realizarOutraTransacao = Console.ReadLine();
    if (realizarOutraTransacao == "S")
        ExibirMenu(cliente);
    else
        Console.WriteLine("Foi um prazer lhe atender! Até mais!");
}

void RealizarDeposito(Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja depositar:");
    string valor = Console.ReadLine();
    cliente.RealizarDeposito(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar outra transação? Digite S ou N");
    string realizarOutraTransacao = Console.ReadLine();
    if (realizarOutraTransacao == "S")
        ExibirMenu(cliente);
    else
        Console.WriteLine("Foi um prazer lhe atender! Até mais!");
        }
    #endregion
