using System;
using TaskManager;

internal partial class Program
{
    public static bool AddTask(List<TaskManager.Task> tasks)
    {
        Console.WriteLine("Enter a title");
        var title = Console.ReadLine();
        if (title == null || title == "")
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            return false;
        }

        Console.WriteLine("Enter a description");
        var description = Console.ReadLine();

        Console.WriteLine("Enter the deadline");
        DateTime? due_date = null;
        if (DateTime.TryParse(Console.ReadLine(), out DateTime deadline) && deadline > DateTime.Now)
            due_date = deadline;

        Console.WriteLine("Enter the type");
        if (!Enum.TryParse(Console.ReadLine(), out TaskType type))
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            return false;
        }

        Console.WriteLine("Assign the priority");
        if (!Enum.TryParse(Console.ReadLine(), out TaskPriority priority))
            priority = TaskPriority.Normal;


        tasks.Add(new TaskManager.Task(title, type, description, due_date, priority));
        Console.WriteLine($"\n{tasks.Last().ToString()}");
        return true;
    }

    public static bool EnterTitle(List<TaskManager.Task> tasks, out int i)
    {
        i = -1;
        Console.WriteLine("Enter a title");
        var title = Console.ReadLine();
        if (title == null || title == "")
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            return false;
        }

        i = tasks.FindIndex(a => a.Title == title);
        if (i == -1)
        {
            Console.WriteLine("Input error. The task with this title was not found");
            return false;
        }
        return true;
    }

    public static bool SetTaskDone(List<TaskManager.Task> tasks)
    {
        if (!EnterTitle(tasks, out int i))
            return false;

        if (tasks[i].State != TaskState.Irrelevant) 
        {
            tasks[i].SetTaskComplete();
            Console.WriteLine($"The task [{tasks[i].Title}] is completed!");
        }
        else
        {
            Console.WriteLine($"The task [{tasks[i].Title}] is no longer relevant!");
        }
        return true;
    }

    public static bool SetTaskIrrelevant(List<TaskManager.Task> tasks)
    {
        if (!EnterTitle(tasks, out int i))
            return false;

        if (tasks[i].State != TaskState.Completed) 
        {
            tasks[i].SetTaskIrrelevant();
            Console.WriteLine($"The task [{tasks[i].Title}] is no longer relevant!");
        }
        else
        {
            Console.WriteLine($"The task [{tasks[i].Title}] is already completed!");
        }
        return true;
    }

    public static bool ShowTaskList(List<TaskManager.Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("The task list is still empty.");
            return false;
        }

        foreach (var i in tasks)
        {
            Console.WriteLine($"{i.ToString()}\n");
        }
        return true;
    }

    private static void Main(string[] args)
    {
        List<TaskManager.Task> tasks = new List<TaskManager.Task>();
        while (true)
        {
            var command = Console.ReadLine();
            if (command!.ToLower() == "add" && !AddTask(tasks))
                continue;

            if (command.ToLower() == "list" && !ShowTaskList(tasks))
                continue;

            if (command.ToLower() == "done" && !SetTaskDone(tasks))
                continue;

            if (command.ToLower() == "wontdo" && !SetTaskIrrelevant(tasks))
                continue;

            if (command.ToLower() == "quit" || command.ToLower() == "q")
                break;
        }
    }
}
