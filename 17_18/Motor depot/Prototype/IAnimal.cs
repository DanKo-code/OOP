using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Prototype
{
    interface IAnimal
    {
        void SetName(string name);

        string GetName();

        IAnimal Clone();
    }
}
