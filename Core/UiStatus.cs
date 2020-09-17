using System;

namespace Probel.Reactor.Core
{
    public class UiStatus
    {
        #region Constructors

        public UiStatus(string value)
        {
            TimeStamp = DateTime.Now;
            Message = value;
        }

        #endregion Constructors

        #region Properties

        public string Message
        {
            get;
            set;
        }

        public DateTime TimeStamp { get; }

        #endregion Properties
    }
}