using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Prototype
{
    class Sheep : IAnimal 
    {
        private string name;

        public Sheep() { }

        private Sheep(Sheep donor) => this.name = donor.name;

        public void SetName(string name) => this.name = name;

        public string GetName() => name;

        public IAnimal Clone() => new Sheep(this);
    }
}
