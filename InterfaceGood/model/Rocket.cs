using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InterfaceGood.model
{
    public class Rocket:DependencyObject,INotifyPropertyChanged
    {
        public Rocket()
        {
                   
            Message = "it is rocket starts";
            CreateRocket();
            Singed_under_worker();
            this.seats = rocketHead.Seats;
            this.weight = rocketHead.Weight + RocketEngine.Weight;
        }
        private readonly double weight;
        public Double Weight { get { return (weight); } }

        private readonly int seats;
        public int Seats { get { return (seats); } }

        private IRocketEngine rocketEngine;
        public IRocketEngine RocketEngine
        {
            get { return rocketEngine; }
            set
            {
                if (rocketEngine != value)
                { rocketEngine = value;
                    OnPropertyChanged("PhotoPath");
                    
                }

            }
        }
        private IRocketHead rocketHead;
        public IRocketHead RocketHead
        {
            get { return rocketHead; }
            set { if (rocketHead != value) { rocketHead = value; OnPropertyChanged(); } }
        }
        

        private void CreateRocket()
        {
            this.rocketEngine = new PuckanEngine();
            this.rocketHead = new HeadSauz();
        }


        public void SetNewHead(IRocketHead head)
        {
            this.RocketHead = head;
        }
        public void SetNewEngine(IRocketEngine engine)
        {
            this.RocketEngine = engine;
           // OnPropertyChanged("PhotoPath");

            
        }

        public void UpdateView()
        {
        }

        public void TestEngineSystem()
        {            
            rocketEngine.Start();
            worker.ReportProgress(0);
            Thread.Sleep(1000);            

           rocketEngine.State();
            worker.ReportProgress(0);
            
            Thread.Sleep(1000);

           rocketEngine.Stop();
            worker.ReportProgress(0);
        }

        public static BackgroundWorker worker = new BackgroundWorker();
        private void Singed_under_worker()
        {
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int a=e.ProgressPercentage;
            Message =rocketEngine.Message;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Message = "Test Completed";
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            TestEngineSystem();
        }

        public void TestStart()
        {
            Message = rocketEngine.Message;
            rocketEngine.Start();
        }
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(Rocket), new PropertyMetadata(null));


        public bool GetFlightAbility()
        {
            //if result >=1 we can fly
            double result = rocketEngine.Power / (seats * 100 + Weight+1);
            if (result >= 1)
                return (true);
           return(false);
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
