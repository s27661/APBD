using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public override char Type => 'L';
        public override string SerialNumber { get; }
        private bool _isDangerous { get; }
        public LiquidContainer(int netMass, int tarMass, int maxCapacity, int height, int depth) : base(netMass, tarMass, maxCapacity, height, depth)
        {
            SerialNumber = SetSerialNumber(Type);
        }

        public void NotifyHazard()
        {
            Console.WriteLine("Hazard notification at: " + SerialNumber);
        }

        public override void LoadContainer(int mass)
        {
            NetMass += mass;
            if (NetMass > MaxMass)
            {
                throw new OverFillException("Container Overflow!");
            }
            if (_isDangerous)
            {
                if (NetMass > MaxMass * 0.5)
                {
                    NotifyHazard();
                }
            }
            else
            {
                if (NetMass > MaxMass * 0.9)
                {
                    NotifyHazard(); 
                }
            }
        }

    }
}
