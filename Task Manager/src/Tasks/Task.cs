using System;
using System.Globalization;

namespace TaskManager
{
    public class Task {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime? DueDate { get; private set; }

        public TaskType Type { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskState State { get; private set; }

        public Task(string title, TaskType type, string? desc = null, DateTime? due_date = null,
                    TaskPriority priority = TaskPriority.Normal)
        {
            Title = title;
            Description = desc;
            DueDate = due_date;
            Type = type;
            Priority = priority;
            State = TaskState.New;
        }

        public void SetTaskComplete() =>
            State = TaskState.Completed;

        public void SetTaskIrrelevant() =>
            State = TaskState.Irrelevant;

        public override string ToString()
        {
            var date_string = (DueDate == null ? " " : $", Due till {DueDate.GetValueOrDefault().ToString("d", new CultureInfo("en-GB"))}");
            return $"- {Title}\n[{Type}] [{State}]\nPriority: {Priority}{date_string}\n{Description}";
        }
    }
}
