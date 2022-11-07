using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.ConstrainedExecution;

namespace lab08
{
    abstract class workUnit
    {
        public workUnit(int health, int lossPerDay)
        {
            Health = health;
            LossPerUse = lossPerDay;
        }

        public int Health { get; set; }

        public int LossPerUse { get; set; }
    }

    class Worker : workUnit
    {
        public Worker(int health, int lossPerDay) : base(health, lossPerDay) { }
    }

    class Technique: workUnit
    {
        public Technique(int health, int lossPerDay) : base(health, lossPerDay) { }
    }

    class Boss
    {

        public delegate void StateHandler();
        public event StateHandler Upgrade;
        public event StateHandler TurnOn;

        public void Use(workUnit unit)
        {
            if (unit.Health > unit.LossPerUse)
            {
                unit.Health -= unit.LossPerUse;
                Upgrade?.Invoke();
            }
        }

        public void Reestablish(workUnit unit)
        {
            unit.Health = 100;
            TurnOn?.Invoke();
        }
    }

    //class StringEditor
    //{
    //    public static string RemovePunctuation(string str)
    //    {
    //        return Regex.Replace(str, "[.,;:]", string.Empty);
    //    }

    //    public static string AddSymbol(string str)
    //    {
    //        return str += "Lab08";
    //    }

    //    public static string ToUpper(string str)
    //    {
    //        return str.ToUpper();
    //    }

    //    public static string ToLower(string str)
    //    {
    //        return str.ToLower();
    //    }

    //    public static string RemoveSpace(string str)
    //    {
    //        return str.Replace(" ", string.Empty);
    //    }
    //}
}