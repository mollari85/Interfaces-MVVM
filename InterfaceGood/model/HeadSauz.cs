using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InterfaceGood.model
{
    class HeadSauz : IRocketHead,INotifyPropertyChanged
    {
        public HeadSauz(int weight=400,int seats=200,string type="Sauz")
        {
            this.weight = weight;
            this.seats = seats;
            this.type = type;
        }
        private int weight;
        public int Weight { get { return (weight); } }

        private int seats;
        public int Seats { get { return (seats); } }

        string type;
        public string Type { get { return (type); } }

        string message = null;
        public string Message { get { return (message); } set { message = value; OnPropertyChanged(); } }
    
        public string GetMessage()
        {
            return (message);
        }
        public override string ToString()
        {
            return (type);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
