namespace ListaDeTarefas;

class Menu
{
    private static Tarefas tarefa = new();

    public void Inicio(string titulo, string opc1, string opc2, string opc3 = "")
    {
        Program.Titulo(titulo);
        Console.WriteLine($"-1- {opc1}");
        Console.WriteLine($"-2- {opc2}");
        if (opc3 != "")
            Console.WriteLine($"-3- {opc3}");
        Console.Write("\nEscolha uma opção: ");
    }

}