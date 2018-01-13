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

        public PatientDocument()
        {
            _repository = new PatientRepository();
        }

        /// <summary>
        /// Get patient by ID
        /// </summary>
        /// <returns></returns>
        public int? GetNextPatientId()
        {
            try
            {
                return _repository.GetNextPatientId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get address of a patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Address GetPatientAddress(int patientId)
        {
            try
            {
                if (patientId > 0)
                {
                    return _repository.GetPatientAddress(patientId);
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get patient by ID
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatient(int patientId)
        {
            try
            {
                if (patientId > 0)
                {
                    Patient result = _repository.GetPatient(patientId);
                    if (result != null)
                    {
                        result.Address = GetPatientAddress(patientId);
                    }
                    return result;
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetPatientCollection()
        {
            try
            {
                return _repository.GetPatientCollection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get total number of patients
        /// </summary>
        /// <returns></returns>
        public int? GetPatientCount()
        {
            try
            {
                return _repository.GetPatientCount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save Patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public bool SavePatient(Patient patient)
        {
            try
            {
                if (patient != null)
                {
                    return _repository.SavePatient(patient);
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public bool UpdatePatient(Patient patient)
        {
            try
            {
                if (patient != null)
                {
                    return _repository.UpdatePatient(patient);
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }                    
        }
    }
}
