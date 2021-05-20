using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{

    public class Client
    {
        public string ClientId { get; set; }
        public string Name { get; set; }

        public Client()
        {
            ClientId = Guid.NewGuid().ToString();
        }

        public Client(string name) : this()
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Client;
            return customer != null &&
                    ClientId == customer.ClientId &&
                    Name == customer.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClientId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
    

}
