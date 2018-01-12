﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BLL;
using BusinessEntity;

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

        // DELETE: api/Patient/5
        public void Delete(int id)
        {
        }

        [Route("GetPatient")]
        [HttpGet]
        public HttpResponseMessage GetPatient(int patientId)
        {
            try
            {
                Patient patient = _document.GetPatient(patientId);
                return Request.CreateResponse(HttpStatusCode.OK,patient);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        [Route("GetPatientsCollection")]
        [HttpGet]
        public string GetPatientsCollection()
        {
            return string.Empty;
        }

        [Route("SavePatient")]
        [HttpPost]
        public HttpResponseMessage SavePatient([FromBody]dynamic value)
        {
            string patient = Convert.ToString(value);
            bool saved = _document.SavePatient(patient);
            return Request.CreateResponse(HttpStatusCode.OK,"Saved");
        }


    }
}