

namespace Requests
{
    using Ninjas;
    using Levels;

    public class InjuryRequest
    {
        public Ninja Patient { get; }
        public string Symptom { get; }
        public Level SeverityLevel { get; set;}

        public InjuryRequest(Ninja patient, string symptom)
        {
            Patient = patient;
            Symptom = symptom;
            SeverityLevel = Level.None;
        }
    }
}