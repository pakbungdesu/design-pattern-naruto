
namespace Contexts
{
    using States;
    using Envs;

    public class Ninja
    {
        private State _state = null!;

        public Ninja(State initialState)
        {
            ChangeState(initialState);
        }

        public void ChangeState(State s)
        {
            _state = s;
            _state.SetNinja(this);
        }

        public void PerformAction(int enemies, int members, float overallChakraPercentage)
        {
            _state.PerformAction(enemies, members, overallChakraPercentage);
        }

        public void EnvironmentChanged(Env location, float overallChakraPercentage, int allMembers, int membersEnv)
        {
            _state.EnvironmentChanged(location, overallChakraPercentage, allMembers, membersEnv);
        }

        public void DisplayCurrentState()
        {
            Console.WriteLine($"Cuurent State of this Ninja: {_state.GetType()}");
        }
    }
}