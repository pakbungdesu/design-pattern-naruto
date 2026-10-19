

namespace Requests
{
    using Ninjas;
    using Levels;

    public class InjuryRequest
    {
        public Ninja Patient { get; }
        public string Symptom { get; }
        public Level SeverityLevel { get; }

        public InjuryRequest(Ninja patient, string symptom, Level severityLevel)
        {
            Patient = patient;
            Symptom = symptom;
            SeverityLevel = severityLevel;
        }
    }
}