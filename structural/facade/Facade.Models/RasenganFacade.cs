using NinjaSubsystems;
using WindSubsystems;
using ChakraSubsystems;

namespace RasenganFacades
{
    public class RasenganFacade
    {
        private CloneManager _cloneManager;
        private RasenganChakra _rasengan;
        private WindInfuser _windInfuser;

        public RasenganFacade(CloneManager cloneMn, NaturalChakra ntChakra, WindInfuser windInf)
        {
            _cloneManager = cloneMn;
            _rasengan = new ChakraAdapter(ntChakra);
            _windInfuser = windInf;
        }

        public void Cast(int n)
        {
            List<Ninja> ninjas = _cloneManager.SpawnClone(n);
            int rasenganChakra = _rasengan.Transform();

            if (ninjas.Count > 0 && rasenganChakra > 0)
            {
                _windInfuser.InfuseWind();
                Console.WriteLine($"[RasenganFacade] Rasengan casted successfully with {ninjas.Count} clones and power {rasenganChakra}!");
            }
            else
            {
                Console.WriteLine("[RasenganFacade] Failed to cast Rasengan.");
            }
        }
    }
}