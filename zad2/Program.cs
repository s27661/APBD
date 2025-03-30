namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lc1 = new LiquidContainer(1000, 600, 5000, 6000, 10000);
            var lc2 = new LiquidContainer(1850, 800, 9000, 6000, 10000);
            var lc3 = new LiquidContainer(6000, 1000, 12000, 12000, 10000);


            var cc1 = new CoolingContainer(2200, 650, 3000, 3000, 10000, "Cheese", 8.0);
            var cc2 = new CoolingContainer(3500, 750, 7000, 6000, 10000, "Frozen pizza", -28);
            var cc3 = new CoolingContainer(2800, 650, 6000, 3000, 10000, "Bananas", 14);

            var gc1 = new GasContainer(7000, 1000, 9000, 6000, 10000);
            var gc2 = new GasContainer(9000, 5000, 21000, 6000, 10000);
            var gc3 = new GasContainer(500, 5000, 1000, 6000, 10000);

            Console.WriteLine("load container");
            Console.WriteLine(lc1.NetMass);
            lc1.LoadContainer(2000);
            Console.WriteLine(lc1.NetMass);

            var ship1 = new Ship(100, 10000, 8.0);


            ship1.LoadContainer(gc3);

            ship1.LoadContainers(new List<Container> {lc2, gc2, cc2});

            ship1.RemoveContainer(gc3);

            var ship2 = new Ship(200, 20000, 12.0);

            ship2.LoadContainer(gc1);

            Console.WriteLine("empty container");
            Console.WriteLine(gc3.NetMass);
            gc3.EmptyContainer();
            Console.WriteLine(gc3.NetMass);

            Console.WriteLine(lc1);
            Console.WriteLine(ship1);
            Console.WriteLine(ship2);

            Ship.SwapBetweenShips(ship1, ship2, gc2);
            Console.WriteLine(ship1);
            Console.WriteLine(ship2);

            ship1.ReplaceContainer("KON-C-1", cc3);

            Console.WriteLine(ship1);





















        }
    }
}
