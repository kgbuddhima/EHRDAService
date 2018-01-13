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
                return null;
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
                    return cn.Query<Patient>("GetPatientById", new { PatientId= patientId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
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
                return null;
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
                return null;
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
                        PatientName = patient.PatientName,
                        NIC = patient.NIC,
                        Gender = patient.Gender,
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
                return false;
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
                            PatientName = patient.PatientName,
                            NIC = patient.NIC,
                            Gender = patient.Gender,
                            Birthday = patient.Birthday,
                            UpdatedDate = patient.UpdatedDate,
                            IsActive=patient.IsActive
                        },
                        commandType: CommandType.StoredProcedure);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
