using System;
using SystemDot.RelationalDataStore;

namespace OtherDomain
{
    public class CrudThing : IdEqualityBase<CrudThing>
    {
        public string Name { get; set; }

        public CrudThing(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}