using Ninjas;

namespace Jutsus
{
    public abstract class Jutsu
    {
        public string? Name { get; }
        public abstract void Execute(Ninja attacker, Ninja target);
    }
}