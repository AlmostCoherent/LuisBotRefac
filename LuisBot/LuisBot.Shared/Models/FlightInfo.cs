using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisBot.Shared.Models
{
    [Serializable]
    public class FlightInfo
    {
        public enum FlightTypes
        {
            International = 1, Domestic = 2
        }

        public enum ClassTypes
        {
            FirstClass = 1,
            Business = 2,
            Economy = 3
        }

        public enum IsMeal
        {
            Yes = 1,
            No = 2
        }

        public enum FoodMenu
        {
            Sandwich = 1,
            Noodles = 2,
            Samosa = 3,
            Cookies = 4,
            Juice = 5,
            Tea = 6,
            Coffee = 7
        }
    }
}
