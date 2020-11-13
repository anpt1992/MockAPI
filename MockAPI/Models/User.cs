using System;

namespace MockAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary => 32 * (int)(Age *1000);        
    }
}
