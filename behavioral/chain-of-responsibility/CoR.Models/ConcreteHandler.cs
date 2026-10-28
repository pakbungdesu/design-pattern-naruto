namespace ConcreteHandlers
{
    using Handlers;
    using Levels;
    using Requests;

    // Handler 1: Checks if the ninja is dead or alive
    public class LabelHandler : MedicalHandler
    {
        public LabelHandler() : base() { }
        public override void HandleRequest(InjuryRequest request)
        {

            if (request.Patient.IsDead)
            {
                Console.WriteLine($"[Death Checked] {request.Patient.Name} has already passed away. Medical treatment cannot be administered.");
                return; // Stop the chain
            } 
            else if (request.Patient.HP <= 50) { request.SeverityLevel = Level.Critical; } 
            else if (request.Patient.HP <= 200) { request.SeverityLevel = Level.Emergency; } 
            else if (request.Patient.HP <= 500) { request.SeverityLevel = Level.Urgent; } 
            else if (request.Patient.HP <= 1000) { request.SeverityLevel = Level.LessUrgent; } 
            else { 
                request.SeverityLevel = Level.None;
                Console.WriteLine($"[Triage Center] {request.Patient.Name} is in good health ({request.Patient.HP} HP). No medical treatment needed.");
                return; // Stop the chain
            }

            base.HandleRequest(request);
        }
    }

    //Handler 2: Field Medic for minor physical injuries
    public class FieldMedicHandler : MedicalHandler
    {
        public FieldMedicHandler() : base() { }

        public override void HandleRequest(InjuryRequest request)
        {
            if (request.SeverityLevel == Level.LessUrgent)
            {
                Console.WriteLine($"[Field Medic] Providing First Aid for {request.Patient.Name} (Symptom: {request.Symptom}).");
                request.Patient.Heal(2.0);
                return; // Stop the chain
            }
            base.HandleRequest(request);
        }
    }

    // Handler 3: Hospital Medic for moderate to urgent physical injuries
    public class HospitalMedicHandler : MedicalHandler
    {
        public HospitalMedicHandler() : base() { }

        public override void HandleRequest(InjuryRequest request)
        {
            if (request.SeverityLevel == Level.Urgent)
            {
                Console.WriteLine($"[Hospital Medic] Performing surgery and intensive treatment for {request.Patient.Name} (Symptom: {request.Symptom}).");            
                request.Patient.Heal(3.5);
            }
            base.HandleRequest(request);
        }
    }

    // Handler 4: Special Team for critical physical / mental / curse injuries
    public class SpecialistHandler : MedicalHandler
    {
        public SpecialistHandler() : base() { }
        public override void HandleRequest(InjuryRequest request)
        {
            if (request.SeverityLevel == Level.Emergency)
            {
                Console.WriteLine($"[Special Team] {request.Patient.Name} is in critical condition! Immediate intervention required.");              
                request.Patient.Heal(5.5);
            }
            base.HandleRequest(request);
        }
    }

    // Handler 5: Lady Tsunade for miraculous recovery
    public class TsunadeHandler : MedicalHandler
    {
        private static readonly TsunadeHandler _instance = new TsunadeHandler();
        private TsunadeHandler(): base() { }

        public override void HandleRequest(InjuryRequest request)
        {
            if (request.SeverityLevel == Level.Critical)
            {
                Console.WriteLine($"[Lady Tsunade] Administering Legendary Healing to save {request.Patient.Name}!");  
                request.Patient.Heal(10);
            }

            base.HandleRequest(request);
        }

        public static TsunadeHandler GetInstance()
        {
            return _instance;
        }
    }

    // Post-treatment step - Rehabilitation
    public class RehabilitationHandler : MedicalHandler
    {
        public RehabilitationHandler() : base() { }
        public override void HandleRequest(InjuryRequest request)
        {
            Console.WriteLine($"[Rehabilitation Center] {request.Patient.Name} is undergoing physical therapy.");
            base.HandleRequest(request);
        }
    }
}