using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressBar
{
    class ProgressBar
    {
        private int tasksToComplete=0;
        private int completedTasks=0;
        private int barSize = 30;
        public ProgressBar(int tasksToComplete)
        {
            this.tasksToComplete = tasksToComplete;
        }
        public void setNumberOfTasks(int num)
        {
            tasksToComplete = num;
        }
        public void notifyCompleted()
        {
            if (completedTasks != tasksToComplete)
            {
                completedTasks++;
            }
        }
        public void DisplayProgress()
        {
            double percentage = completedTasks / (double)tasksToComplete * barSize;
            Console.SetCursorPosition(0, 0);
            Console.Write("[");
            String completedSymbols = new string('#', (int)percentage);
            String incompletedSymbols = new string(' ', barSize-(int)percentage);
            Console.Write(completedSymbols);
            Console.Write(incompletedSymbols);
            Console.WriteLine("]");
            Console.WriteLine("Progress: " + completedTasks + "/" + tasksToComplete);
        }
    }
}
