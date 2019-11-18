using RestApi.Interfaces;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.UnitTests
{
    public class TestPatientAppContext : DbContext, IDatabaseContext
    {
        public TestPatientAppContext()
        {
            this.Patients = new InMemoryDbSet<Patient>();
            this.Episodes= new InMemoryDbSet<Episode>();
        }
        public IDbSet<Patient> Patients { get; set; }

        public IDbSet<Episode> Episodes { get; set; }
    }
}
