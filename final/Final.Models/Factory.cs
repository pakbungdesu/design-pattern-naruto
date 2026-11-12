
namespace Factories
{
    using Ninjas;
    using Enums;

    public abstract class VillageFactory
    {
        public abstract Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina);
        public abstract Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost);
        public abstract Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool);
    }

    public class KonohaFactory : VillageFactory
    {
        public override Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Konohagakure, stamina);
        public override Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Konohagakure, jutsuSpecialty, elementBoost);
        public override Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Konohagakure, bijuuPool);
    }

    public abstract class AllianceFactory : VillageFactory { }
    public class SunaFactory : AllianceFactory { 
        public override Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Sunagakure, stamina);
        public override Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Sunagakure, jutsuSpecialty, elementBoost);
        public override Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Sunagakure, bijuuPool);
    }
    public class KiriFactory : AllianceFactory { 
        public override Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Kirigakure, stamina);
        public override Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Kirigakure, jutsuSpecialty, elementBoost);
        public override Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Kirigakure, bijuuPool);
    }

    public class IwaFactory : AllianceFactory { 
        public override Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Iwagakure, stamina);
        public override Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Iwagakure, jutsuSpecialty, elementBoost);
        public override Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Iwagakure, bijuuPool);
    }

    public class KumoFactory : AllianceFactory { 
        public override Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Kumogakure, stamina);
        public override Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Kumogakure, jutsuSpecialty, elementBoost);
        public override Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Kumogakure, bijuuPool);
    }
}