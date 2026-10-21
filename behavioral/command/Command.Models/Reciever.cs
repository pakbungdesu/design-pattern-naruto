
namespace Receivers
{
    using Enums;
    using Ninjas;

    public interface Beast
    {
        public string ChakraColor { get; set; }
        public int intensity { get; set; }
        public Ninja target { get; set; }
        public Ninja attacker { get; set; }

        void Cloak(int intensity);
        void Fight(Ninja target);
        void Defend(Ninja attacker);
    }

    public class TailedBeast: Beast
    {
        public int Tails { get; set; }
        public string ChakraColor { get; set; }
        public ElementNature ElementNature { get; set; }
        public int intensity { get; set; } = 10;
        public Ninja? target { get; set; }
        public Ninja? attacker { get; set; }

        public TailedBeast(int tails, string chakraColor, ElementNature elementNature)
        {
            Tails = tails;
            ChakraColor = chakraColor;
            ElementNature = elementNature;
        }

        public void Cloak(int intensity)
        {

            Console.WriteLine($"[Tailed Beast] Activating {Tails}-tails cloak with {ChakraColor} chakra with intensity level {intensity}!");
        }

        public void Fight(Ninja target)
        {
            Console.WriteLine($"[Tailed Beast] Unleashing elemental {ElementNature} combat attack on {target.Name}!");
        }

        public void Defend(Ninja attacker)
        {
            Console.WriteLine($"[Tailed Beast] Forming a dense chakra barrier to defend against {attacker.Name}!");
        }
    }

    public class Susanoo: Beast
    {
        public Stage Stage { get; set; }
        public string ChakraColor { get; set; }
        public int intensity { get; set; } = 10;
        public Ninja? target { get; set; } = null;
        public Ninja? attacker { get; set; } = null;

        public Susanoo(Stage stage, string chakraColor)
        {
            Stage = stage;
            ChakraColor = chakraColor;
        }

        public void Cloak(int intensity) => Console.WriteLine($"[Susanoo] Manifesting stage '{Stage}' with {ChakraColor} ethereal armor with intensity level {intensity}!");
        public void Fight(Ninja target) => Console.WriteLine($"[Susanoo] Striking with ethereal weapon at stage '{Stage}' on {target.Name}!");
        public void Defend(Ninja attacker) => Console.WriteLine($"[Susanoo] Absolute defense engaged at stage '{Stage}' against {attacker.Name}!");
    }
}