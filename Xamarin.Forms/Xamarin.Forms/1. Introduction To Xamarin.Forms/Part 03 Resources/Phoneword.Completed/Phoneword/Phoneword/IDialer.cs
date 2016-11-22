using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword
{
    public interface IDialer
    {
        bool Dial(string number);
    }
}
