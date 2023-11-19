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

    public Task()
    {
    }

    private string Title;
    private string Description;
    private DateTime DueDate;
    private bool IsCompleted;

    public void setTitle(string title)
    {
        this.Title = title;
    }

    public void setDescription(string description)
    {
        this.Description = description;
    }

    public void setDate(DateTime date)
    {
        this.DueDate = date;
    }

    public void setIsCompleted(bool isCompleted)
    {
        this.IsCompleted = isCompleted;
    }

    public string getTitle()
    {
        return this.Title;
    }

    public string getDescription()
    {
        return this.Description;
    }

    public DateTime getDueDate()
    {
        return this.DueDate;
    }

    public bool getIsCompleted()
    {
        return this.IsCompleted;
    }
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
                        CreateTask();
                        break;
                    case 2:
                        ListAllTasks();
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

    static void CreateTask()
    {
        Task newTask = new Task();

        Console.WriteLine("Digite o título da tarefa: ");
        newTask.setTitle(Console.ReadLine());

        Console.WriteLine("Digite a descrição da tarefa: ");
        newTask.setDescription(Console.ReadLine());

        Console.WriteLine("Digite a data de vencimento (formato: dd/mm/yyyy): ");
        // if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
        // {
        //     newTask.setDueDate(dueDate);
        // }
        // else
        // {
        //     Console.WriteLine("Data inválida. A tarefa não terá uma data de vencimento.");
        //     newTask.setDueDate(DateTime.MinValue);
        // }

        newTask.setIsCompleted(false);

        tasks.Add(newTask);

        Console.WriteLine("Tarefa criada com sucesso.");
    }

    static void ListAllTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Não há tarefas cadastradas.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Título: {task.getTitle()} | Descrição: {task.getDescription()} | Data de Vencimento: {task.getDueDate().ToString("dd/MM/yyyy")} | Concluída: {(task.getIsCompleted() ? "Sim" : "Não")}");
            }
        }
    }

}
