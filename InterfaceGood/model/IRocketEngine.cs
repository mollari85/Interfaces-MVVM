using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceGood.model
{
    public interface IRocketEngine
    {
        bool Start();
        bool State();
        void Stop();
        string Type { get; }
        double Power { get; }
        double Weight { get; }
        string PhotoPath { get; }
        string Message{get;set;}


    }
}
