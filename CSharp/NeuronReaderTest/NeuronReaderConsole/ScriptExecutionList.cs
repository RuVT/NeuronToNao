using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronReaderConsole
{
    public class ScriptExecutionList
    {
        private static ScriptExecutionList instance;
        public static ScriptExecutionList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScriptExecutionList();
                }
                return instance;
            }
        }


        private ConcurrentBag<ProcessStartInfo> processList;
        public ConcurrentBag<ProcessStartInfo> ProcessList
        {
            get
            {
                if(processList == null)
                {
                    processList = new ConcurrentBag<ProcessStartInfo>();
                }
                return processList;
            }
        }

        private BackgroundWorker processDispatcher;
        public BackgroundWorker ProcessDispatcher
        {
            get
            {
                if(processDispatcher == null)
                {
                    processDispatcher = new BackgroundWorker();
                    processDispatcher.DoWork += ProcessDispatcher_DoWork;
                    processDispatcher.WorkerSupportsCancellation = true;
                }
                return processDispatcher;
            }
        }

        private ScriptExecutionList()
        {
            ProcessDispatcher.RunWorkerAsync();
        }

        private void ProcessDispatcher_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                if (ProcessList.Count > 0)
                {
                    ProcessStartInfo info = ProcessList.First();
                    Process currentProcess = Process.Start(info);
                    currentProcess.WaitForExit();
                    ProcessList.TryTake(out info);
                    Console.Beep(5000, 1000);
                }
            }
        }
    }
}
