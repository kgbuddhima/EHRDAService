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
        /// <summary>
        /// Get patient by ID
        /// </summary>
        /// <returns></returns>
        int? GetNextPatientId();

        /// <summary>
        /// Get patient by ID
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Patient GetPatient(int patientId);

        /// <summary>
        /// Get address of a patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Address GetPatientAddress(int patientId);

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns></returns>
        List<Patient> GetPatientCollection();

        /// <summary>
        /// Get total number of patients
        /// </summary>
        /// <returns></returns>
        int? GetPatientCount();

        /// <summary>
        /// Save Patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        bool SavePatient(Patient patient);

        /// <summary>
        /// Update Patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        bool UpdatePatient(Patient patient);
    }
}
