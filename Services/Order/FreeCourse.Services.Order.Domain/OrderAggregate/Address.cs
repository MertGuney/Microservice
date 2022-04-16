using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string Province { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string Line { get; private set; }

        public Address()
        {

        }
        public Address(string provice, string district, string street, string zipCode, string line)
        {
            Province = provice;
            District = district;
            Street = street;
            ZipCode = zipCode;
            Line = line;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Province, District, Street, ZipCode, Line };
        }
    }
}
