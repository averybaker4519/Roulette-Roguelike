public interface ISpinModifier : IGameModifiers
{
    public void ApplyModifier(SpinContext context, RouletteWheel wheel = null);
}