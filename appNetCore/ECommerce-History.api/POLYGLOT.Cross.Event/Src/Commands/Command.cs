using POLYGLOT.Cross.Event.Src.Events;
using System;

namespace POLYGLOT.Cross.Event.Src.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
