using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    public class Customer : IComparable<Customer>
    {
        public int Id { get; set; }
        public DateOnly CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Customer? other)
        {
            if (this.Id > other?.Id)
                return 1;
            if (this.Id < other?.Id)
                return -1;
            return 0;
        }

        public T Map<T>(IMapper<Customer, T> mapper)
        {
            return mapper.Map(this);
        }
    }
}