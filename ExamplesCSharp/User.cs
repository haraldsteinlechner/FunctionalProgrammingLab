using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesCSharp
{ 

    // Immutable class
    public class User
    {
        private readonly string name;
        private readonly DateTime lastSeen;

        public User(string name, DateTime lastSeen)
        {
            this.name = name;
            this.lastSeen = lastSeen;
        }
        public User WithName(string name)
        {
            return new User(name, lastSeen);
        }

        public User WithLastSeen(DateTime lastSeen)
        {
            return new User(name, lastSeen);
        }
    }



    public record User2
    {
        public string Name { get; init; }
        public DateTime LastSeen { get; init; }
    }

}
