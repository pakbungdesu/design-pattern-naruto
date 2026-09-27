
namespace Ninjas
{
    public interface Ninja
    {
        string Name { get; set; }
        string BasicToken { get; set; }
        string AdvancedToken { get; set; }
        bool Request(Ninja caller);
    }
}