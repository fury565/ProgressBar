using System;
using System.Threading;
namespace ProgressBar
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgressBar bar = new ProgressBar(5);
            bar.DisplayProgress();
            for(int i = 0; i < 5; i ++)
            {
                bar.notifyCompleted();
                Thread.Sleep(300);
                bar.DisplayProgress();
            }
            ProgressBarCustomizable barc = new ProgressBarCustomizable();
            barc.DisplayProgress();
            barc.AddTaskToBar(5, "Startup");
            barc.AddTaskToBar(20, "Loading recent files");
            barc.AddTaskToBar(15, "Final preparations");
            barc.DisplayProgress();
            Thread.Sleep(500);
            barc.notifyCompleted();
            barc.DisplayProgress();
            barc.DivideCurrentTask(4);
            for(int i = 0; i < 4; i++)
            {
                Thread.Sleep(500);
                barc.notifyCompleted();
                barc.DisplayProgress();
            }
            Thread.Sleep(1500);
            barc.notifyCompleted();
            barc.DisplayProgress();
        }
    }
}
