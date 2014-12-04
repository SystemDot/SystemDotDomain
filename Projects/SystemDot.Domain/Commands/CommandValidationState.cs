using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SystemDot.Core;

namespace SystemDot.Domain.Commands
{
    public class CommandValidationState<TCommand>
    {
        private readonly List<string> messages;
        private readonly PropertyMessageDictionary propertyMessages;

        public bool IsValid { get; private set; }

        public CommandValidationState()
        {
            messages = new List<string>();
            propertyMessages = new PropertyMessageDictionary();
            IsValid = true;
        }

        public void FailWith<TProperty>(string message)
        {
            messages.Add(message);
            IsValid = false;
        }

        public void FailCommandPropertyWith<TProperty>(Expression<Func<TCommand, TProperty>> property, string message)
        {
            propertyMessages.AddMessageForProperty(property.Body.As<MemberExpression>().Member.Name, message);
            IsValid = false;
        }

        public IEnumerable<string> GetMessages()
        {
            return messages;
        }

        public IEnumerable<string> GetMessagesForProperty<TProperty>(Expression<Func<TCommand, TProperty>> property)
        {
            return propertyMessages.GetMessagesForProperty(property.Body.As<MemberExpression>().Member.Name);
        }

        private class PropertyMessageDictionary
        {
            private readonly Dictionary<string, List<string>> inner;

            public PropertyMessageDictionary()
            {
                inner = new Dictionary<string, List<string>>();
            }

            public void AddMessageForProperty(string name, string message)
            {
                if (!inner.ContainsKey(name))
                {
                    inner.Add(name, new List<string>());
                }

                inner[name].Add(message);
            }

            public IEnumerable<string> GetMessagesForProperty(string name)
            {
                return !inner.ContainsKey(name)
                    ? new List<string>()
                    : inner[name];
            }
        }
    }
}