using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    public record Employee
    {
        private string _firstName;
        private string? _lastName;
        public Employee(string firstName) => _firstName = firstName;
        public int Id { get; set; }
        public string FirstName
        {
            get => _firstName; set => _firstName = value;
        }
        public string LastName { get => _lastName!; init => _lastName = value; }
        public override string ToString() => $"+{FirstName}-{LastName}";
    }
}