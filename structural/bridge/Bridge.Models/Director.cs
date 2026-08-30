using Builders;
using Chakras;

namespace Directors
{
    public class Director
{
    public void MakeKonohaNinja(NinjaBuilder builder, string name)
    {
        builder.Reset();
        builder.SetName(name);
        builder.BuildUniform(new FireChakra());
        builder.BuildWeapon(new FireChakra());
        builder.BuildDefence(new FireChakra());
        builder.BuildJacket(new FireChakra());
    }

    public void MakeSunaNinja(NinjaBuilder builder, string name)
    {
        builder.Reset();
        builder.SetName(name);
        builder.BuildUniform(new WindChakra());
        builder.BuildWeapon(new WindChakra());
        builder.BuildDefence(new WindChakra());
        builder.BuildCloak(new WindChakra());
    }
}
}