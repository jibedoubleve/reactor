using ReactiveUI;

namespace Probel.Reactor.Core
{
    public static class Interactions
    {
        #region Properties

        public static Interaction<string, bool> YesNo { get; } = new Interaction<string, bool>();

        #endregion Properties
    }
}