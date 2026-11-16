
namespace VillageFactories
{
    using Ninjas;
    using Enums;

    public interface VillageFactory
    {
        public Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina);
        public Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost);
        public Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool);
    }

    public class KonohaFactory : VillageFactory
    {
        public Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Konohagakure, stamina);
        public Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Konohagakure, jutsuSpecialty, elementBoost);
        public Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Konohagakure, bijuuPool);
    }

    public interface AllianceFactory : VillageFactory
    {
        
    }

    public class SunaFactory : AllianceFactory { 
        public Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Sunagakure, stamina);
        public Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Sunagakure, jutsuSpecialty, elementBoost);
        public Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Sunagakure, bijuuPool);
    }
    public class KiriFactory : AllianceFactory { 
        public Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Kirigakure, stamina);
        public Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Kirigakure, jutsuSpecialty, elementBoost);
        public Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Kirigakure, bijuuPool);
    }

    public class IwaFactory : AllianceFactory { 
        public Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Iwagakure, stamina);
        public Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Iwagakure, jutsuSpecialty, elementBoost);
        public Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Iwagakure, bijuuPool);
    }

    public class KumoFactory : AllianceFactory { 
        public Chunin CreateChunin(string name, ChakraType chakraNature, int attack, double heal, int hp, int stamina) => new Chunin(name, chakraNature, attack, heal, hp, Location.Kumogakure, stamina);
        public Jonin CreateJonin(string name, ChakraType chakraNature, int attack, double heal, int hp, string jutsuSpecialty, double elementBoost) => new Jonin(name, chakraNature, attack, heal, hp, Location.Kumogakure, jutsuSpecialty, elementBoost);
        public Kage CreateKage(string name, ChakraType chakraNature, int attack, double heal, int hp, int bijuuPool) => new Kage(name, chakraNature, attack, heal, hp, Location.Kumogakure, bijuuPool);
    }
}