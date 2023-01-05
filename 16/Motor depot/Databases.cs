using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot
{
    internal static class Databases
    {
        public static List<System.UserAccount> UsersUccounts = new List<System.UserAccount>();

        public static List<System.CarInfo> CarsList = new List<System.CarInfo>()
        {
            new System.CarInfo("Dima", 20, 100, true),
            new System.CarInfo("Lexa", 50, 70, true),
            new System.CarInfo("Misha", 90, 50, true),
        };

        public static List<System.Order> OrderList = new List<System.Order>();
    }
}
