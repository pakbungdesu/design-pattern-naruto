
namespace Handlers
{
    using Requests;

    public interface Handler
    {
        public Handler SetNext(Handler nextHandler);

        public void HandleRequest(InjuryRequest request);
    }

    public class MedicalHandler : Handler
    {
        protected Handler? NextHandler;

        public virtual Handler SetNext(Handler nextHandler)
        {
            NextHandler = nextHandler;
            return nextHandler;
        }

        public virtual void HandleRequest(InjuryRequest request)
        {
            if (NextHandler != null)
            {
                NextHandler.HandleRequest(request);
            }
        }
    }
}