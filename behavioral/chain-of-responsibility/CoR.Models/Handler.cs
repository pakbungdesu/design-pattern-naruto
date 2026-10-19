
namespace Handlers
{
    using Requests;

    public abstract class MedicalHandler
    {
       protected MedicalHandler? NextHandler;

        public MedicalHandler SetNext(MedicalHandler nextHandler)
        {
            NextHandler = nextHandler;
            return nextHandler;
        }

        public abstract void HandleRequest(InjuryRequest request);
    }
}