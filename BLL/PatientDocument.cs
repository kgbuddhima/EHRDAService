﻿using System;
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

        #region Public methods

        /// <summary>
        /// validate login credentials of patient member
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>PatientID</returns>
        public int CheckPatientLogin(Credentials credentials)
        {
            try
            {
                if (credentials!=null)
                {
                    return _repository.CheckPatientLogin(credentials);
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// validate login credentials of staff member
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>StaffID</returns>
        public int CheckStaffLogin(Credentials credentials)
        {
            try
            {
                if (credentials != null)
                {
                    return _repository.CheckStaffLogin(credentials);
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deactivate patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public bool Deactivatepatient(int patientId)
        {
            try
            {
                if (patientId > 0)
                {
                    return _repository.Deactivatepatient(patientId);
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                else throw new NullReferenceException();
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
        /// Get patient by PIN
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public Patient GetPatient(string pin)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(pin))
                {
                    Patient result = _repository.GetPatient(pin);
                    if (result != null)
                    {
                        result.Address = GetPatientAddress(result.PatientId);
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
                if (patient != null && patient.Address != null)
                {
                    bool result = _repository.SavePatient(patient);
                    if (result)
                    {
                        if (patient.Address != null)
                        {
                            _repository.SavePatientAddress(patient.Address, patient.PatientId);
                        }
                        patient.UserCredentials = new Credentials()
                        {
                            UserID = patient.PatientId,
                            UserName= patient.PIN,
                            Password="abc@123"
                        };
                        if (patient.UserCredentials != null)
                        {
                            _repository.SavePatientCredentials(patient.UserCredentials);
                        }
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
        /// Insert a new address od a  patient
        /// </summary>
        /// <param name="address"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public bool SavePatientAddress(Address address, int patientId)
        {
            try
            {
                if (address != null || patientId <= 0)
                {
                    return _repository.SavePatientAddress(address, patientId);
                }
                else return false;
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
                    bool result =  _repository.UpdatePatient(patient);
                    if (result)
                    {
                        if (GetPatientAddress(patient.PatientId) != null)
                        {
                            _repository.UpdatePatientAddress(patient.Address, patient.PatientId);
                        }
                        else
                        {
                            _repository.SavePatientAddress(patient.Address, patient.PatientId);
                        }
                        if (patient.UserCredentials!=null)
                        {
                            _repository.UpdatePatientCredentials(patient.UserCredentials);
                        }
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
        /// Update an exisitng address od a  patient
        /// </summary>
        /// <param name="address"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public bool UpdatePatientAddress(Address address, int patientId)
        {
            try
            {
                if (address != null || patientId <= 0)
                {
                    return _repository.UpdatePatientAddress(address, patientId);
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
