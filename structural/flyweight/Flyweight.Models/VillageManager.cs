using CompositePart;

namespace VillageManager
{
    public class NinjaVillage
    {
        private List<Shinobi> _Shinobis = new List<Shinobi>();

        public void Add(Shinobi shinobi)
        {
            _Shinobis.Add(shinobi);
        }

        public void Display()
        {
            Console.WriteLine("*** Village Shinobi Registry ***");
            foreach (var shinobi in _Shinobis)
            {
                shinobi.Display();
            }
        }
    }
}