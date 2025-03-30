using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    internal class Ship
    {
        public List<Container> Containers = new List<Container>();
        public int MaxCapacity { get; set; }
        public int MaxWeight { get; set; }
        public double MaxSpeed { get; set; }

        public Ship(int maxCapacity, int maxWeight, double maxSpeed)
        {
            MaxCapacity = maxCapacity;
            MaxWeight = maxWeight;
            MaxSpeed = maxSpeed;
        }

        public void LoadContainer(Container container)
        {
            if (checkWeight() > MaxWeight * 1000)
            {
                throw new Exception("Containers to heavy");
            }
            if (Containers.Count > MaxCapacity)
            {
                throw new Exception("To much containers");
            }
            Containers.Add(container);
        }
        public void LoadContainers(List<Container> containers)
        {
            foreach (var container in containers)
            {
                LoadContainer(container);
            }
        }
        public int checkWeight()
        {
            int weight = 0;
            for (int i = 0; i < Containers.Count; i++)
            {
                weight += Containers[i].TarMass + Containers[i].NetMass;
            }
            return weight;
        }

        public void ReplaceContainer(string toSwapSerialNumber, Container container)
        {
            foreach (var cont in Containers)
            {
                if (cont.SerialNumber == toSwapSerialNumber)
                {
                    RemoveContainer(cont);
                    break;
                }                
                
            }
            LoadContainer(container);
        }

        public static void SwapBetweenShips(Ship from, Ship to, Container container)
        {
            from.RemoveContainer(container);
            to.LoadContainer(container);
        }

        public void RemoveContainer(Container container)
        {
            Containers.Remove(container);

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Ship: ");
            foreach (var cont in Containers)
            {
                sb.AppendLine(cont.ToString());
            }
            sb.AppendLine($"ship weight: {checkWeight()}");
            return sb.ToString();
        }
    }
}
