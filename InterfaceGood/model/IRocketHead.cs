using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceGood.model
{
    public interface IRocketHead
    {
        int Weight { get; }
        int Seats{ get; }
        string Type { get; }
        string Message { get; set; }
        string GetMessage();
        
    }
}
