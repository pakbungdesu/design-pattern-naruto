
namespace Factories
{
    using Ninjas;
    using Enums;

    public abstract class VillageFactory
    {
        public abstract Chunin CreateChunin();
        public abstract Jonin CreateJonin();
        public abstract Kage CreateKage();
    }

    public class KonohaFactory : VillageFactory
    {
        public override Chunin CreateChunin() => new Chunin { Village = Location.Konohagakure };
        public override Jonin CreateJonin() => new Jonin { Village = Location.Konohagakure };
        public override Kage CreateKage() => new Kage { Village = Location.Konohagakure };
    }

    public abstract class AllianceFactory : VillageFactory { }
    public class SunaFactory : AllianceFactory { 
        public override Chunin CreateChunin() => new Chunin { Village = Location.Sunagakure }; 
        public override Jonin CreateJonin() => new Jonin { Village = Location.Sunagakure }; 
        public override Kage CreateKage() => new Kage { Village = Location.Sunagakure }; }
    public class KiriFactory : AllianceFactory { 
        public override Chunin CreateChunin() => new Chunin { Village = Location.Kirigakure }; 
        public override Jonin CreateJonin() => new Jonin { Village = Location.Kirigakure }; 
        public override Kage CreateKage() => new Kage { Village = Location.Kirigakure }; 
    }

    public class IwaFactory : AllianceFactory { 
        public override Chunin CreateChunin() => new Chunin { Village = Location.Iwagakure }; 
        public override Jonin CreateJonin() => new Jonin { Village = Location.Iwagakure }; 
        public override Kage CreateKage() => new Kage { Village = Location.Iwagakure }; 
    }

    public class KumoFactory : AllianceFactory { 
        public override Chunin CreateChunin() => new Chunin { Village = Location.Kumogakure }; 
        public override Jonin CreateJonin() => new Jonin { Village = Location.Kumogakure }; 
        public override Kage CreateKage() => new Kage { Village = Location.Kumogakure }; 
    }
}