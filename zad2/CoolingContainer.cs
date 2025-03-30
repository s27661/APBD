using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class CoolingContainer : Container
    {
        public override char Type => 'C';
        public override string SerialNumber { get; }
        private static string Produce { get; set; }
        private static double Temperature { get; set; }

        public static Dictionary<string, double> CoolingValues = new Dictionary<string, double>()
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            {"Cheese",7.2},
            {"Sausages",5},
            {"Butter",20.5},
            {"Eggs",19},
        };

        public CoolingContainer(int netMass, int tarMass, int maxMass, int height, int depth, string produce, double temperature) : base(netMass, tarMass, maxMass, height, depth)
        {
            Temperature = temperature;
            Produce = produce;
            SerialNumber = SetSerialNumber(Type);

            if (!CoolingValues.ContainsKey(produce))
            {
                throw new ArgumentException("Invalid produce");
            }

            if (temperature < CoolingValues[produce])
            {
                throw new ArgumentException("Temperature too low");
            }
        }
    }
}
