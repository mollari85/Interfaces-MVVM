using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;

namespace InterfaceGood.model
{
    public class PuckanEngine : IRocketEngine, INotifyPropertyChanged
    {

        public PuckanEngine(string type = "Puckan", double power = 1000)
        {

            this.type = type;
            this.power = power;
            this.photoPath = photoFilePath(@"C:\Users\Администратор\source\repos\InterfaceGood\puckan.jpg");

        }
        private string photoFilePath(string sTmp)
        {
            string pattern = ".jpg,.bmp,.jpng,.jpeg,.tiff";
            if (File.Exists(sTmp))
            {
                string extention = Path.GetExtension(sTmp);
                string f = pattern.Contains(extention) ? sTmp : null;
                return (f);
            }
            return (null);

        }
        private double weight;
        public double Weight { get { return weight; } } 
        private string type;
        public string Type { get { return type; } }
        private double power;
        public double Power { get { return power; } }
        private string photoPath;
        public string PhotoPath { get { return photoPath; } }
        private string message = null;
        public string Message { get { return message; } set { if (message != value) { message = value; OnPropertyChanged();  } } }



        bool IRocketEngine.Start()
        {
            Message = "Puckan has started";
            return (true);
        }

        bool IRocketEngine.State()
        {
            Message = "Puckan is OK";
            return (true);
        }

        void IRocketEngine.Stop()
        {
            Message = "Puckan Stopped";

        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
