
using Atividade01.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

var builder = new ConfigurationBuilder ()
    .SetBasePath("C: \\Users\\AnaLe\\OneDrive\\Desktop\\TREINAMENTO\\Atividade01\\Atividade01")
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

string connectionString = configuration.GetConnectionString("ConexaoPadrao");

ClienteService clienteService = new ClienteService(connectionString);


int opcao;
do
{
    Console.Clear();
    Console.WriteLine("==== MENU ====");
    Console.WriteLine("1 - Cadastrar Cliente");
    Console.WriteLine("2 - Listar Clientes");
    Console.WriteLine("3 - Atualizar Cliente");
    Console.WriteLine("4 - Remover Cliente");
    Console.WriteLine("5 - Cadastrar Pedido");
    Console.WriteLine("6 - Listar Pedidos por Cliente");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Escolha uma opção:");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1: CadastrarCliente(); break;
        case 2: ListarClientes(); break;
        case 3: AtualizarCliente(); break;
        case 4: RemoverCliente(); break;
        case 5: CadastrarPedido(); break;
        case 6: ListarPedidosPorCliente(); break;
        case 0: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida."); break;
    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
} while (opcao != 0);