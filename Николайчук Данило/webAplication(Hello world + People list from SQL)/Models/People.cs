using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace webAplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
