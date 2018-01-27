using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BusinessEntity;
using Utility;

namespace EHRDAService.Controllers
{
    [RoutePrefix("api/Patient")]
    public class PatientController : ApiController
    {
        IPatientDocument _document;

        public PatientController()
        {
            _document = new PatientDocument();
        }

        [Route("ChekPatientLogin")]
        [HttpPost]
        public HttpResponseMessage CheckPatientLogin(Credentials credentials)
        {
            try
            {
                int patientId = _document.CheckPatientLogin(credentials);
                if (patientId > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, patientId);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, CommonUnit.oFailed);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("CheckStaffLogin")]
        [HttpPost]
        public HttpResponseMessage CheckStaffLogin(Credentials credentials)
        {
            try
            {
                int staffId = _document.CheckStaffLogin(credentials);
                if (staffId > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, staffId);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, CommonUnit.oFailed);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("DeletePatient")]
        [HttpPost]
        public HttpResponseMessage DeletePatient(int id)
        {
            try
            {
                bool deactivated =  _document.Deactivatepatient(id);
                if (deactivated)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, CommonUnit.oSuccess);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, CommonUnit.oFailed);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("GetPatientById")]
        [HttpPost]
        public HttpResponseMessage GetPatientById(int patientId)
        {
            try
            {
                Patient patient = _document.GetPatient(patientId);
                if (patient != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, patient);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, CommonUnit.oFailed);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("GetPatientByPIN")]
        [HttpPost]
        public HttpResponseMessage GetPatientByPIN(string pin)
        {
            try
            {
                Patient patient = _document.GetPatient(pin);
                if (patient != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, patient);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, CommonUnit.oFailed);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("GetPatientsCollection")]
        [HttpPost]
        public string GetPatientsCollection()
        {
            return string.Empty;
        }

        [Route("SavePatient")]
        [HttpPost]
        public HttpResponseMessage SavePatient([FromBody]Patient value)
        {
            try
            {
                bool saved = _document.SavePatient(value);
                if (saved)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, CommonUnit.oSuccess);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, CommonUnit.oFailed);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("UpdatePatient")]
        [HttpPost]
        public HttpResponseMessage UpdatePatient([FromBody]Patient value)
        {
            try
            {
                bool saved = _document.UpdatePatient(value);
                if (saved)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, CommonUnit.oSuccess);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, CommonUnit.oFailed);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
