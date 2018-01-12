using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;

namespace DAL
{
    public class PatientRepository : IPatientRepository
    {
        public bool SavePatient(Patient patient)
        {
            return true;
        }
    }
}
