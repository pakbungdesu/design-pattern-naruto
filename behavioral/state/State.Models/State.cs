
namespace States
{
    using Envs;
    using Contexts;

    public abstract class State
    {
        protected Ninja _ninja = null!;

        public void SetNinja(Ninja ninja)
        {
            _ninja = ninja;
        }

        public abstract void PerformAction(int enemies, int members, float overallChakraPercentage);
        public abstract void EnvironmentChanged(Env location, float overallChakraPercentage, int allMembers, int membersEnv);
    }
    
    public class Stealth : State
    {
        public override void PerformAction(int enemies, int members, float overallChakraPercentage)
        {
            Console.WriteLine($"[Stealth] Total Enemies: {enemies}, Total Members: {members}, Chakra: {overallChakraPercentage}%");

            if (enemies > members)
            {
                if (overallChakraPercentage >= 60f)
                    Console.WriteLine("Stealth: Outnumbered, but high chakra. Continuing stealth actions.");
                else
                {
                    Console.WriteLine("Stealth: Outnumbered and low chakra. Switching to Evacuate.");
                    _ninja.ChangeState(new Evacuate());
                }
            }
            else
            {
                if (overallChakraPercentage >= 60f)
                {
                    Console.WriteLine("Stealth: Advantageous numbers & high chakra. Switching to Assault.");
                    _ninja.ChangeState(new Assualt());
                }
                else
                    Console.WriteLine("Stealth: Continuing stealth quietly.");
            }
        }

        public override void EnvironmentChanged(Env location, float overallChakraPercentage, int allMembers, int membersEnv)
        {
            Console.WriteLine($"[Stealth] Env changed at {location}. Total Members: {allMembers}, Native Members: {membersEnv}, Chakra: {overallChakraPercentage}%");

            if(membersEnv >= allMembers * 0.6)
            {
                if(overallChakraPercentage >= 50f)
                {
                    Console.WriteLine("Stealth: Native members >= 60% and high chakra. Switching to Assault.");
                    _ninja.ChangeState(new Assualt());
                }
            } else if(membersEnv >= allMembers * 0.4)
            {
                Console.WriteLine("Stealth: Native members 40 ~ 60%. Continuing stealth quietly.");
            } else
            {
                Console.WriteLine("Stealth: Lack of native members and low chakra. Switching to Evacuate.");
                _ninja.ChangeState(new Evacuate());
            }
        }
    }

    public class Assualt : State
    {
        public override void PerformAction(int enemies, int members, float overallChakraPercentage)
        {
            Console.WriteLine($"[Assualt] Total Enemies: {enemies}, Total Members: {members}, Chakra: {overallChakraPercentage}%");

            if (enemies > members)
            {
                if (overallChakraPercentage >= 60f)
                {
                    Console.WriteLine("Assault: Outnumbered with good chakra. Pulling back to Stealth.");
                    _ninja.ChangeState(new Stealth());
                }
                else
                {
                    Console.WriteLine("Assault: Outnumbered and low chakra. Switching to Evacuate.");
                    _ninja.ChangeState(new Evacuate());
                }
            }
            else
            {
                if (overallChakraPercentage >= 60f)
                    Console.WriteLine("Assault: Pressing direct assault with full force!");
                else
                {
                    Console.WriteLine("Assault: Chakra dropped. Dropping back to Stealth.");
                    _ninja.ChangeState(new Stealth());
                }
            }
        }

        public override void EnvironmentChanged(Env location, float overallChakraPercentage, int allMembers, int membersEnv)
        {
            Console.WriteLine($"[Assault] Env changed at {location}. Total Members: {allMembers}, Local Members: {membersEnv}, Chakra: {overallChakraPercentage}%");

            if(membersEnv >= allMembers * 0.6)
            {
                if(overallChakraPercentage >= 50f)
                {
                    Console.WriteLine("Assault: Native members >= 60% and high chakra. Pressing direct assault with full force!");
                }
            } 
            else if(membersEnv >= allMembers * 0.4)
            {
                Console.WriteLine("Assualt: Native members 40 ~ 60%. Switching to Stealth.");
                _ninja.ChangeState(new Stealth());
            } 
            else
            {
                Console.WriteLine("Stealth: Lack of native members and low chakra. Switching to Evacuate.");
                _ninja.ChangeState(new Evacuate());
            }
        }
    }

    public class Evacuate : State
    {
        public override void PerformAction(int enemies, int members, float overallChakraPercentage)
        {
            Console.WriteLine($"[Evacuate] Total Enemies: {enemies}, Total Members: {members}, Chakra: {overallChakraPercentage}%");

            if (enemies > members)
            {
                if (overallChakraPercentage >= 60f)
                {
                    Console.WriteLine("Evacuate: Regaining composure. Shifting to Stealth.");
                    _ninja.ChangeState(new Stealth());
                }
                else
                    Console.WriteLine("Evacuate: Falling back safely, keeping distance.");
            }
            else
            {
                if (overallChakraPercentage >= 60f)
                {
                    Console.WriteLine("Evacuate: Coast is clear and chakra is high. Launching Assault!");
                    _ninja.ChangeState(new Assualt());
                }
                else
                {
                    Console.WriteLine("Evacuate: Safe numbers, shifting to Stealth.");
                    _ninja.ChangeState(new Stealth());
                }
            }
        }

        public override void EnvironmentChanged(Env location, float overallChakraPercentage, int allMembers, int membersEnv)
        {
            Console.WriteLine($"[Evacuate] Env changed at {location}. Total Members: {allMembers}, Local Members: {membersEnv}, Chakra: {overallChakraPercentage}%");

            if(membersEnv >= allMembers * 0.6)
            {
                if(overallChakraPercentage >= 50f)
                {
                    Console.WriteLine("Evacuate: Native members >= 60% and high chakra. Switching to Assault.");
                    _ninja.ChangeState(new Assualt());
                }
            } 
            else if(membersEnv >= allMembers * 0.4)
            {
                Console.WriteLine("Evacuate: Native members 40 ~ 60%. Switching to Stealth.");
                _ninja.ChangeState(new Stealth());
            } 
            else
            {
                Console.WriteLine("Evacuate: Lack of native members and low chakra. Keeping distance.");
            }
        }
    }
}