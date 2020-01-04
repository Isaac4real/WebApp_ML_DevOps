using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
namespace WebApplication2.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}*/

namespace CalculateSimpleInterest.Models
{
    public class Movies
    {
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public int Year { get; set; }
    }
}
