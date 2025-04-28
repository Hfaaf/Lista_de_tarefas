namespace ListaDeTarefas;

class Program
{
    private static Tarefas tarefas = new();
    private static Menu menu = new();

    static void Main(string[] args)
    {
        bool sair = false;

        while (!sair)
        {
            Console.Clear();
            menu.Inicio(
                    titulo: "Lista de Tarefas",
                    opc1: "AdicionarTarefas",
                    opc2: "Listar Tarefas",
                    opc3: "Sair"
                    );

            string? entrada = Console.ReadLine();


            if (int.TryParse(entrada, out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        tarefas.AdicionarTarefas();
                        break;
                    case 2:
                        Console.Clear();
                        tarefas.ListarTarefas();
                        break;
                    case 3:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Console.ReadKey();
                        break;

                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número.");
                Console.ReadKey();
            }
        }
    }

    public static void Titulo(string titulo)
    {
        string tracos = new string('-', titulo.Length);
        Console.WriteLine(tracos);
        Console.WriteLine(titulo);
        Console.WriteLine(tracos);
    }

}