using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressBar
{
    class ProgressBarCustomizable
    {
        private List<int> tasksToComplete;
        private List<string> tasksToCompleteTitles;
        private int totalTaskValue = 0;
        private int completedTasks = 0;
        private int currentTask = 0;
        private int barSize = 30;
        private int dividedTaskValue = 0;//last two variables are only used for displying partial task progress
        private int dividedLeft = 0;//      it isnt necessary to use them for progress bar to work 
        public ProgressBarCustomizable()
        {
            tasksToComplete = new List<int>();
            tasksToCompleteTitles = new List<string>();
        }
        public void AddTaskToBar(int taskValue, string taskName)
        {
            tasksToComplete.Add(taskValue);
            totalTaskValue += taskValue;
            tasksToCompleteTitles.Add(taskName);
        }
        public void DivideCurrentTask(int numParts)//please use divisible numbers eg. 25/5, 48/4...
        {
            dividedTaskValue = tasksToComplete[currentTask] / numParts;
            dividedLeft = numParts;
        }
        public void notifyCompleted()
        {
            if (dividedLeft == 1)
            {
                currentTask++;
            }
            if (dividedLeft != 0)
            {
                completedTasks += dividedTaskValue;
                dividedLeft--;
            }
            else if (currentTask != tasksToComplete.Count)
            {
                completedTasks += tasksToComplete[currentTask];
                currentTask++;
            }
        }
        public void DisplayProgress()
        {
            if (totalTaskValue == 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\nNo tasks added");
            }
            else
            {
                double percentage = completedTasks / (double)totalTaskValue * barSize;
                Console.SetCursorPosition(0, 0);
                Console.Write("[");
                String completedSymbols = new string('#', (int)percentage);
                String incompletedSymbols = new string(' ', barSize - (int)percentage);
                Console.Write(completedSymbols);
                Console.Write(incompletedSymbols);
                Console.WriteLine("]");
                Console.WriteLine("Progress: " + completedTasks + "/" + totalTaskValue);
                if(currentTask==tasksToComplete.Count)
                    Console.WriteLine(tasksToCompleteTitles[currentTask - 1]);
                else
                    Console.WriteLine(tasksToCompleteTitles[currentTask]);
            }
            
        }
    }
}
