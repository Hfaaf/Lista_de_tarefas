namespace ListaDeTarefas;

class Tarefas
{
    private Menu menu = new();

    public static Dictionary<string, string> _tarefas = [];
    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    public void AdicionarTarefas()
    {
        Console.Clear();
        Program.Titulo("Adicionar Tarefas");

        Console.Write("Insira o nome da tarefa: ");
        Nome = Console.ReadLine();

        while (string.IsNullOrEmpty(Nome) || _tarefas.ContainsKey(Nome))
        {
            if (string.IsNullOrEmpty(Nome))
            {
                Console.WriteLine("O nome não pode ser vazio");
                Console.Write("Digite uma outra tarefa: ");
                Nome = Console.ReadLine();
            }
            else
            {
                Console.Write("Tarefa já adicionada. Por favor adicione outra tarefa: ");
                Nome = Console.ReadLine();
            }
        }

        Console.Write("Adicione uma descrição: ");
        Descricao = Console.ReadLine() ?? string.Empty;

        _tarefas.Add(Nome, Descricao);

    }

    public void ListarTarefas()
    {
        bool voltar = false;

        while (!voltar)
        {
            Console.Clear();
            Program.Titulo("Listar Tarefas");

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Você tem {_tarefas.Count} tarefas adicionadas");
            Console.WriteLine("Tarefas Adicionadas:");

            foreach (var tarefa in _tarefas)
            {
                Console.WriteLine($"\nNome: {tarefa.Key}");
                Console.WriteLine($"Descrição: {tarefa.Value}");
            }
            Console.WriteLine("----------------------------------------------");

            menu.Inicio(
                titulo: "Opções",
                opc1: "Remover Tarefa",
                opc2: "Voltar"
            );

            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        RemoverTarefas();
                        break;
                    case 2:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("Pressione qualquer tecla para voltar");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Digite um número válido!");
                Console.ReadKey();
            }
        }
    }

    static void RemoverTarefas()
    {
        Program.Titulo("Remover Tarefa");

        Console.WriteLine("Digite `CANCELAR` Para voltar.");

        Console.Write("Digite o nome da tarefa que deseja excluir: ");
        string? tarefa = Console.ReadLine();
        while (string.IsNullOrEmpty(tarefa))
        {
            Console.WriteLine("Você não escreveu nada. Porfavor diga o nome de alguma tarefa");
            tarefa = Console.ReadLine();
        }
        if (tarefa == "CANCELAR")
        {
            return;
        }
        else if (_tarefas.ContainsKey(tarefa))
        {
            _tarefas.Remove(tarefa);
        }
        else
        {
            Console.WriteLine("\nTarefa não encontrada.");
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}