namespace VetApi
{
    public class Database
    {
        private static List<Animal> Animals =
    [
        new ()
        {
            Id = 1,
            Name = "Misiek",
            Category = "Pies",
            Color = "Niebieski",
            Weight = 33.3
        },
        new ()
        {
            Id = 2,
            Name = "Sara",
            Category = "Pies",
            Color = "Czarno-biały",
            Weight = 12.5
        }
    ];

        private static List<Visit> Visits =
        [
            new ()
        {
            Id = 1,
            Animal = Animals[0],
            Date = DateTime.Now,
            Description = "Zjadł kamień - pomylił z chrupkiem",
            Cost = 350.00,
        },
        new ()
        {
            Id = 2,
            Animal = Animals[0],
            Date = DateTime.Now + new TimeSpan(1,0,0,0),
            Description = "Zjadł opatrunki z poprzedniego zabiegu",
            Cost = 550.00,
        }
        ];

        public static List<Animal> GetAnimals()
        {
            return Animals;
        }

        public static void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public static void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
        }

        public static List<Visit> GetVisits()
        {
            return Visits;
        }

        public static void AddVisit(Visit visit)
        {
            Visits.Add(visit);
        }
    }
}
