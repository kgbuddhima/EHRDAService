using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPatientDocument
    {
        Patient GetPatient(int patientId);

        bool SavePatient(string patient);
    }
}
