﻿using System;
using System.Collections.Generic;
using System.Linq;


public class Task
{
    private string Title;
    private string Description;
    private DateTime DueDate;
    private bool IsCompleted;
    private DateTime CreatedDate;

    public Task(string title, string description, DateTime dueDate, bool isCompleted)
    {
        this.Title = title;
        this.Description = description;
        this.DueDate = dueDate;
        this.IsCompleted = isCompleted;

    }

    public Task() { }

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
                        MarkTaskAsCompleted();
                        break;
                    case 4:
                        ListPendingTasks();
                        break;
                    case 5:
                        ListCompletedTasks();
                        break;
                    case 6:
                        DeleteTask();
                        break;
                    case 7:
                        SearchByKeyword();
                        break;
                    case 8:
                        ShowStatistics();
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

        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
        {
            newTask.setDate(dueDate);
        }
        else
        {
            Console.WriteLine("Data inválida. A tarefa não terá uma data de vencimento.");
            newTask.setDate(DateTime.MinValue);
        }

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
            int taskNumber = 1;
            foreach (var task in tasks)
            {
                Console.WriteLine($"{taskNumber++} - Título: {task.getTitle()} | Descrição: {task.getDescription()} | Data de Vencimento: {task.getDueDate().ToString("dd/MM/yyyy")} | Concluída: {(task.getIsCompleted() ? "Sim" : "Não")}");
            }
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.WriteLine("Digite o número da tarefa que deseja marcar como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].setIsCompleted(true);
            Console.WriteLine("Tarefa marcada como concluída.");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.");
        }
    }

    static void ListPendingTasks()
    {
        var pendingTasks = tasks.Where(task => !task.getIsCompleted()).ToList();

        if (pendingTasks.Count == 0)
        {
            Console.WriteLine("Não há tarefas pendentes.");
        }
        else
        {
            int taskNumber = 1;
            foreach (var task in pendingTasks)
            {
                Console.WriteLine($"{taskNumber++} - Título: {task.getTitle()} | Descrição: {task.getDescription()} | Data de Vencimento: {task.getDueDate().ToString("dd/MM/yyyy")}");
            }
        }
    }

    static void ListCompletedTasks()
    {
        var completedTasks = tasks.Where(task => task.getIsCompleted()).ToList();

        if (completedTasks.Count == 0)
        {
            Console.WriteLine("Não há tarefas concluídas.");
        }
        else
        {
            int taskNumber = 1;
            foreach (var task in completedTasks)
            {
                Console.WriteLine($"{taskNumber++} - Título: {task.getTitle()} | Descrição: {task.getDescription()} | Data de Vencimento: {task.getDueDate().ToString("dd/MM/yyyy")}");
            }
        }
    }

    static void DeleteTask()
    {
        Console.WriteLine("Digite o número da tarefa que deseja excluir: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Tarefa excluída com sucesso.");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.");
        }
    }

    static void SearchByKeyword()
    {
        Console.WriteLine("Digite a palavra-chave para buscar tarefas: ");
        string keyword = Console.ReadLine();

        var foundTasks = tasks.Where(task => task.getTitle().Contains(keyword) || task.getDescription().Contains(keyword)).ToList();

        if (foundTasks.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada com a palavra-chave fornecida.");
        }
        else
        {
            int taskNumber = 1;
            foreach (var task in foundTasks)
            {
                Console.WriteLine($"{taskNumber++} - Título: {task.getTitle()} | Descrição: {task.getDescription()} | Data de Vencimento: {task.getDueDate().ToString("dd/MM/yyyy")} | Concluída: {(task.getIsCompleted() ? "Sim" : "Não")}");
            }
        }
    }

    static void ShowStatistics()
    {
        Console.WriteLine($"Número de tarefas concluídas: {tasks.Count(task => task.getIsCompleted())}");
        Console.WriteLine($"Número de tarefas pendentes: {tasks.Count(task => !task.getIsCompleted())}");

        if (tasks.Count > 0)
        {
            var oldestTask = tasks[0];
            var newestTask = tasks[tasks.Count - 1];

            Console.WriteLine($"Tarefa mais antiga: {oldestTask.getTitle()} | Data de Vencimento: {oldestTask.getDueDate().ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Tarefa mais recente: {newestTask.getTitle()} | Data de Vencimento: {newestTask.getDueDate().ToString("dd/MM/yyyy")}");
        }
        else
        {
            Console.WriteLine("Não há tarefas para exibir estatísticas.");
        }
    }
}
