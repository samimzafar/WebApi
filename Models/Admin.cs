using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;
    }
}