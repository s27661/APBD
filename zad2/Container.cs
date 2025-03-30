using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public abstract class Container
    {
        public int NetMass { get; set; }
        public int TarMass { get; set; }
        public int MaxMass { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }        
        public abstract string SerialNumber { get; }
        public abstract char Type { get; }
        public static List <Container> Containers = new List <Container> ();

        protected Container(int netMass, int tarMass, int maxCapacity, int height, int depth)
        {
            NetMass = netMass;
            TarMass = tarMass;
            MaxMass = maxCapacity;
            Height = height;
            Depth = depth;
            Containers.Add(this);
        }
        public virtual void EmptyContainer()
        {
            NetMass = 0;
        }

        public virtual void LoadContainer(int mass)
        {
            if (mass+NetMass > MaxMass) 
            {
                throw new OverFillException("Container overfill");
            }
            NetMass += mass;
        }

        protected string SetSerialNumber(char type)
        {
            return $"KON-{type}-{Containers.Count}";
        }

        public override string ToString()
        {
            return $"Container {SerialNumber} currrent load: {NetMass} ";
        }

















    }
















    internal class OverFillException : Exception
    {
        public OverFillException(string? message) : base(message)
        {
        }
    }
}
