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

        [Route("DeletePatient")]
        [HttpPost]
        public HttpResponseMessage DeletePatient([FromBody]int id)
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

        [Route("GetNextPatientId")]
        [HttpPost]
        public HttpResponseMessage GetNextPatientId()
        {
            try
            {
                int pId = (int)_document.GetNextPatientId();
                if (pId>0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pId);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, 0);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("GetPatientById")]
        [HttpPost]
        public HttpResponseMessage GetPatientById([FromBody]int patientId)
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
        public HttpResponseMessage GetPatientByPIN([FromBody]string pin)
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
        public HttpResponseMessage GetPatientsCollection()
        {
            try
            {
                List<Patient> col = _document.GetPatientCollection();
                if (col!=null && col.Count>0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, col);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, CommonUnit.oFailed);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
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
