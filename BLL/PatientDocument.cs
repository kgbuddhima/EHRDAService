using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BusinessEntity;
using Newtonsoft.Json;

namespace BLL
{
    public class PatientDocument : IPatientDocument
    {
        IPatientRepository _repository;

        public PatientDocument()//IPatientRepository repository
        {
            _repository = new PatientRepository();
        }

        public Patient GetPatient(int patientId)
        {
            Patient p = new Patient()
            {
                ID = 1,
                Name = "buddhima",
                NIC = "12233"
            };
            return p;
        }

        public bool SavePatient(string patient)
        {
            Patient p = JsonConvert.DeserializeObject<Patient>(patient);
            return _repository.SavePatient(p);
        }
    }
}
