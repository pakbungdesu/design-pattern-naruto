
namespace Handlers
{
    using Requests;

    public interface Handler
    {
        public Handler SetNext(Handler? nextHandler);

        public void HandleRequest(InjuryRequest request);
    }

    public class MedicalHandler : Handler
    {
        protected Handler? NextHandler;

        public MedicalHandler()
        {
            NextHandler = null;
            Console.WriteLine($"[Medical Handler] {this.GetType().Name} NextHandle = {NextHandler?.GetType().Name ?? "null"}");
        }

        public virtual Handler SetNext(Handler? nextHandler)
        {
            NextHandler = nextHandler;
            Console.WriteLine($"[Medical Handler] {this.GetType().Name} NextHandle = {NextHandler?.GetType().Name ?? "null"}");
            return NextHandler ?? this;
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