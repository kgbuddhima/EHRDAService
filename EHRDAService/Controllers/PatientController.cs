using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
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


        // GET: api/Patient
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Patient/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Patient
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Patient/5
        public void Put(int id, [FromBody]string value)
        {
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
