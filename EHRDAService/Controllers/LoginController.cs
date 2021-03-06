﻿using System;
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
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        IPatientDocument _document;

        public LoginController()
        {
            _document = new PatientDocument();
        }

        [Route("ChekPatientLogin")]
        [HttpPost]
        public HttpResponseMessage CheckPatientLogin([FromBody]Credentials credentials)
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
        public HttpResponseMessage CheckStaffLogin([FromBody]Credentials credentials)
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
    }
}
