using System;
using System.Collections.Generic;
using System.Linq;


public class Task
{
    public Task(string title, string description, DateTime dueDate, bool isCompleted)
    {
        this.Title = title;
        this.Description = description;
        this.DueDate = dueDate;
        this.IsCompleted = isCompleted;
    }

    private string Title;
    private string Description;
    private DateTime DueDate;
    private bool IsCompleted;
}

class ToDoList
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Criar tarefa");
            Console.WriteLine("2. Listar todas as tarefas");
            Console.WriteLine("3. Marcar tarefa como concluída");
            Console.WriteLine("4. Listar tarefas pendentes");
            Console.WriteLine("5. Listar tarefas concluídas");
            Console.WriteLine("6. Excluir tarefa");
            Console.WriteLine("7. Pesquisar tarefas por palavra-chave");
            Console.WriteLine("8. Mostrar estatísticas");
            Console.WriteLine("9. Sair");
            Console.WriteLine("Escolha uma opção: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // CreateTask();
                        break;
                    case 2:
                        // ListAllTasks();
                        break;
                    case 3:
                        // MarkTaskAsCompleted();
                        break;
                    case 4:
                        // ListPendingTasks();
                        break;
                    case 5:
                        // ListCompletedTasks();
                        break;
                    case 6:
                        // DeleteTask();
                        break;
                    case 7:
                        // SearchByKeyword();
                        break;
                    case 8:
                        // ShowStatistics();
                        break;
                    case 9:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Escolha novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Escolha novamente.");
            }

            Console.WriteLine();
        }
    }
}