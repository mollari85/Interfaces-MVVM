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
    class RD100Engine : IRocketEngine, INotifyPropertyChanged
    {
        public RD100Engine(string type="RD100", double power=500)
        {
            this.type = type;
            this.power = power;
            this.photoPath = photoFilePath(@"C:\Users\Администратор\source\repos\InterfaceGood\RD100.jpg");

    }
        /// <summary>
        /// check if the path point to a picture and if it is picture return path  or else null
        /// </summary>
        /// <param name= path to the picture of an engine"sTmp"></param>
        /// <returns null or path></returns>
        private string photoFilePath(string sTmp)
        {
            string pattern = ".jpg,.bmp,.jpng,.jpeg,.tiff";
            if (File.Exists(sTmp))
            {
                string extention = Path.GetExtension(sTmp);
                return (pattern.Contains(extention) ? sTmp : null);
            }
            return (null);
        }

        private double weight;
        public double Weight { get { return weight; } }

        private string type;
        public string Type { get { return (type); } }

        private double power;
        public double Power { get { return power; } }

        private string photoPath;
        public string PhotoPath { get { return photoPath; } }

        private string message=null;
        public string Message { get { return (message);}set { if (value != message) { message = value; OnPropertyChanged(); } } }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Start()
        {
            Message="RD100 started";
            return (true);
        }

        public bool State()
        {
            Message = "RD is OK";
            return(true);
        }

        public void Stop()
        {
            Message = "RD is stopped";

        }
    }
}
