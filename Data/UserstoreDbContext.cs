using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace InformationSecurityConference.Data
{
    internal class UserstoreDbContext:DbContext
    {
        public UserstoreDbContext():base("name=ConnectionString")
        {
                
        }
    }
}
