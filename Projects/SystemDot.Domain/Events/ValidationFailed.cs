using System.Collections.Generic;

namespace SystemDot.Domain.Events
{
    public abstract class ValidationFailed
    {
        public List<int> Fields { get; private set; }
        public List<string> Messages { get; private set; }

        protected ValidationFailed()
        {
            Fields = new List<int>();
            Messages = new List<string>();
        }

        public ValidationFailed FailWith(int field, string message)
        {
            Fields.Add(field);
            FailWith(message);
            return this;
        }

        public ValidationFailed FailWith(string message)
        {
            if(!Messages.Contains(message)) 
                Messages.Add(message);

            return this;
        }

        public bool IsEmpty()
        {
            return Fields.Count == 0 && Messages.Count == 0;
        }
    }
}