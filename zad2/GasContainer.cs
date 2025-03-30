using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class GasContainer : Container, IHazardNotifier
    {
        public override char Type => 'G';
        public override string SerialNumber { get; }

        public GasContainer(int netMass, int tarMass, int maxMass, int height, int depth) : base(netMass, tarMass, maxMass, height, depth)
        {
            SerialNumber = SetSerialNumber(Type);
        }

        public override void EmptyContainer()
        {
            NetMass = Convert.ToInt32(NetMass * 0.05);
        }


        public void NotifyHazard()
        {
            Console.WriteLine("Hazard notification at: " + SerialNumber);
        }
    }
}
