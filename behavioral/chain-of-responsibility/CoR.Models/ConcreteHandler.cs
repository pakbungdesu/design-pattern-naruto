namespace ConcreteHandlers
{
    using Handlers;
    using Levels;
    using Requests;

    // Handler 1: Checks if the ninja is dead or alive
    public class DeathCheckHandler : MedicalHandler
    {
        public override void HandleRequest(InjuryRequest request)
        {

            if (request.Patient.IsDead)
            {
                Console.WriteLine($"[Death Checked] {request.Patient.Name} has already passed away (0 HP). Medical treatment cannot be administered.");
            }
            else if (NextHandler != null)
            {
                Console.WriteLine($"[Triage Center] Vital signs detected. {request.Patient.Name} is alive ({request.Patient.HP} HP). Passing to medical staff...");
                NextHandler.HandleRequest(request);
            }
        }
    }

    //Handler 2: Field Medic for minor physical injuries
    public class FieldMedicHandler : MedicalHandler
    {
        public override void HandleRequest(InjuryRequest request)
        {
            if (request.SeverityLevel == Level.LessUrgent)
            {
                Console.WriteLine($"[Field Medic] Providing First Aid for {request.Patient.Name} (Symptom: {request.Symptom}).");
                
                request.Patient.Heal(2.0);
            }
            else if (NextHandler != null)
            {
                Console.WriteLine($"[Field Medic] The condition of {request.Patient.Name} is too severe for the field! Referring to the hospital...");
                NextHandler.HandleRequest(request);
            }
        }
    }

    // Handler 3: Hospital Medic for moderate to urgent physical injuries
    public class HospitalMedicHandler : MedicalHandler
    {
        public override void HandleRequest(InjuryRequest request)
        {
            if (request.SeverityLevel == Level.Urgent)
            {
                Console.WriteLine($"[Hospital Medic] Performing surgery and intensive treatment for {request.Patient.Name} (Symptom: {request.Symptom}).");
                
                request.Patient.Heal(3.5);
            }
            else if (NextHandler != null)
            {
                Console.WriteLine($"[Hospital Medic] The condition of {request.Patient.Name} is beyond general practice! Urgent referral to Lady Tsunade...");
                NextHandler.HandleRequest(request);
            }
        }
    }

    // Handler 4: Special Team for critical physical / mental / curse injuries
    public class SpecialistHandler : MedicalHandler
    {
        public override void HandleRequest(InjuryRequest request)
        {
            if (request.SeverityLevel == Level.Emergency)
            {
                Console.WriteLine($"[Special Team] {request.Patient.Name} is in critical condition! Immediate intervention required.");
                
                request.Patient.Heal(5.5);
            }
            else if (NextHandler != null)
            {
                Console.WriteLine($"[Special Team] The condition of {request.Patient.Name} is beyond special care! Referring to Lady Tsunade...");
                NextHandler.HandleRequest(request);
            }
        }
    }

    // Handler 5: Lady Tsunade for miraculous recovery
    public class TsunadeHandler : MedicalHandler
    {
        public override void HandleRequest(InjuryRequest request)
        {
            Console.WriteLine($"[Lady Tsunade] Administering Legendary Healing to save {request.Patient.Name}!");
            
            request.Patient.Heal(10);

            Console.WriteLine($"[Lady Tsunade] {request.Patient.Name} undergoes miraculous recovery! ({request.Patient.HP} HP total)");

            if (NextHandler != null)
            {
                NextHandler.HandleRequest(request);
            }
        }
    }

    // Post-treatment step - Rehabilitation
    public class RehabilitationHandler : MedicalHandler
    {
        public override void HandleRequest(InjuryRequest request)
        {
            if (!request.Patient.IsDead)
            {
                Console.WriteLine($"[Rehabilitation Center] {request.Patient.Name} is undergoing physical therapy.");
            }
        }
    }
}