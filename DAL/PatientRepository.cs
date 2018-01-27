using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using Dapper;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Utility;

namespace DAL
{
    public class PatientRepository : IPatientRepository
    {
        IDbConnection conn { get; set; }

        public IDbConnection dbConnection
        {
            get
            {
                if (conn == null)
                    return new SqlConnection(ConfigurationManager.AppSettings.Get("EHR_DB_CON"));
                return conn;
            }
        }

        /// <summary>
        /// validate login credentials of patient member
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>PatientID</returns>
        public int CheckPatientLogin(Credentials credentials)
        {
            try
            {
                using (IDbConnection cn = dbConnection)
                {
                    return cn.Query<int>("CheckPatientLogin",
                    new
                    {
                        PPassword = credentials.UserName,
                        PUserName = credentials.Password
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    return cn.Query<int>("CheckStaffLogin",
                    new
                    {
                        PPassword = credentials.UserName,
                        PUserName = credentials.Password
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    int result = cn.Query<int>("DeactivatePatient", new { PatientId = patientId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return Convert.ToBoolean(result);
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    return cn.Query<int>("GetNextPatientId", commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    return cn.Query<Patient>("GetPatientById", new { PatientId = patientId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    return cn.Query<Patient>("GetPatientByPIN", new { PIN = pin }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    return cn.Query<Address>("GetAddressOfpatient", new { PatientId = patientId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    return cn.Query<Patient>("GetPatientCollection", commandType: CommandType.StoredProcedure).ToList();
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    return cn.Query<int>("GetPatientCount", commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    int result = cn.Execute("Insertpatient", new
                    {
                        PatientId = patient.PatientId,
                        PIN = patient.PIN,
                        PatientName = UtilityLibrary.GetValueString(patient.PatientName),
                        NIC = UtilityLibrary.GetValueString(patient.NIC),
                        Gender = UtilityLibrary.GetValueString(patient.Gender),
                        Birthday = patient.Birthday,
                        JoinedDate = patient.JoinedDate,
                        UpdatedDate = patient.UpdatedDate
                    },
                    commandType: CommandType.StoredProcedure);
                    return Convert.ToBoolean(result);
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    int result = cn.Execute("InsertAddressofpatient", 
                    new
                    {
                        AddressL1 = address.AddressL1,
                        AddressL2 = address.AddressL2,
                        AddressL3 = address.AddressL3,
                        PostCode = address.PostCode,
                        City = address.City,
                        Country = address.Country,
                        PatientId = patientId
                    },
                    commandType: CommandType.StoredProcedure);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Patient Credentials
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public bool SavePatientCredentials(Credentials credentials)
        {
            try
            {
                using (IDbConnection cn = dbConnection)
                {
                    int result = cn.Execute("InsertPatientCredentials",
                    new
                    {
                        PatientID = credentials.UserID,
                        PPassword = credentials.UserName,
                        PUserName = credentials.Password
                    },
                    commandType: CommandType.StoredProcedure);
                    return Convert.ToBoolean(result);
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    int result = cn.Execute("UpdatePatient",
                        new
                        {
                            PatientId = patient.PatientId,
                            PatientName = UtilityLibrary.GetValueString(patient.PatientName),
                            NIC = UtilityLibrary.GetValueString(patient.NIC),
                            Gender = UtilityLibrary.GetValueString(patient.Gender),
                            Birthday = patient.Birthday,
                            UpdatedDate = patient.UpdatedDate,
                            IsActive = patient.IsActive
                        },
                        commandType: CommandType.StoredProcedure);
                    return Convert.ToBoolean(result);
                }
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
                using (IDbConnection cn = dbConnection)
                {
                    int result = cn.Execute("UpdateAddressofpatient", 
                    new
                    {
                        AddressL1 = address.AddressL1,
                        AddressL2 = address.AddressL2,
                        AddressL3 = address.AddressL3,
                        PostCode = address.PostCode,
                        City = address.City,
                        Country = address.Country,
                        PatientId = patientId
                    },
                    commandType: CommandType.StoredProcedure);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update patient credentials
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public bool UpdatePatientCredentials(Credentials credentials)
        {
            try
            {
                using (IDbConnection cn = dbConnection)
                {
                    int result = cn.Execute("UpdatePatientCredentials",
                    new
                    {
                        PatientID = credentials.UserID,
                        PPassword = credentials.UserName,
                        PUserName = credentials.Password
                    },
                    commandType: CommandType.StoredProcedure);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}