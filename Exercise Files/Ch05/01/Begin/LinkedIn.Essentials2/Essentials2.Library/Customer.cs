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
            return this!.Id.CompareTo(other?.Id);
        }

        public T Map<T>(IMapper<Customer, T> mapper)
        {
            return mapper.Map(this);
        }
    }
    public record struct CustomerRecordStruct : IComparable<CustomerRecordStruct?>
    {
        public int Id { get; set; }
        public DateOnly CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(CustomerRecordStruct? other)
        {
            if (this.Id > other?.Id)
                return 1;
            if (this.Id < other?.Id)
                return -1;
            return 0;
        }
        public T Map<T>(IMapper<CustomerRecordStruct, T> mapper)
        {
            return mapper.Map(this);
        }
    }
    public record class CustomerRecordClass : IComparable<CustomerRecordClass?>
    {
        public int Id { get; set; }
        public DateOnly CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(CustomerRecordClass? other)
        {
            if (this.Id > other?.Id)
                return 1;
            if (this.Id < other?.Id)
                return -1;
            return 0;
        }
        public T Map<T>(IMapper<CustomerRecordClass, T> mapper)
        {
            return mapper.Map(this);
        }
    }
}