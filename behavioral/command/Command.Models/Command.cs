
namespace Commands
{
    using Receivers;
    using Ninjas;

    public interface CommandMode
    {
        void execute();
    }

    public class TailedCloakMode : CommandMode
    {
        private readonly TailedBeast _tailedBeast;

        public int intensity { get; set; }
        public TailedCloakMode(TailedBeast tb, int intensity)
        {
            _tailedBeast = tb;
            this.intensity = intensity;
        }
        public void execute() => _tailedBeast.Cloak(this.intensity);
    }

    public class TailedFightMode : CommandMode
    {
        private readonly TailedBeast _tailedBeast;

        public Ninja target { get; set; }

        public TailedFightMode(TailedBeast tb, Ninja target)
        {
            _tailedBeast = tb;
            this.target = target;
        }
        public void execute() => _tailedBeast.Fight(this.target);
    }

    public class TailedDefendMode : CommandMode
    {
        private readonly TailedBeast _tailedBeast;

        public Ninja attacker { get; set; }
        public TailedDefendMode(TailedBeast tb, Ninja attacker)
        {
            _tailedBeast = tb;
            this.attacker = attacker;
        }
        public void execute() => _tailedBeast.Defend(this.attacker);
    }

    public class SusanooCloakMode : CommandMode
    {
        private readonly Susanoo _susanoo;

        public int intensity { get; set; }
        public SusanooCloakMode(Susanoo ssn, int intensity)
        {
            _susanoo = ssn;
            this.intensity = intensity;
        }

        public void execute() => _susanoo.Cloak(this.intensity);
    }

    public class SusanooFightMode : CommandMode
    {
        private readonly Susanoo _susanoo;

        public Ninja target { get; set; }
        public SusanooFightMode(Susanoo ssn, Ninja target)
        {
            _susanoo = ssn;
            this.target = target;
        }
        public void execute() => _susanoo.Fight(this.target);
    }

    public class SusanooDefendMode : CommandMode
    {
        private readonly Susanoo _susanoo;

        public Ninja attacker { get; set; }
        public SusanooDefendMode(Susanoo ssn, Ninja attacker)
        {
            _susanoo = ssn;
            this.attacker = attacker;
        }

        public void execute() => _susanoo.Defend(this.attacker);
    }
}