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
        /// Deactivate patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        bool Deactivatepatient(int patientId);

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
        /// Get patient by PIN
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        Patient GetPatient(string pin);

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
        /// Insert a new address od a  patient
        /// </summary>
        /// <param name="address"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        bool SavePatientAddress(Address address, int patientId);

        /// <summary>
        /// Update Patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        bool UpdatePatient(Patient patient);

        /// <summary>
        /// Update an exisitng address od a  patient
        /// </summary>
        /// <param name="address"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        bool UpdatePatientAddress(Address address, int patientId);
    }
}
