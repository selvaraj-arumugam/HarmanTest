using System;
using System.Linq;
using System.Web.Http;
using System.Net;
using RestApi.Interfaces;
using RestApi.Models;
using System.Net.Http; 

namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly IDatabaseContext _provider;
        public PatientsController(IDatabaseContext provider)
        {
            _provider = provider;
        }
        [HttpGet]
        public HttpResponseMessage Get(int patientId)
        {
            try
            {
                var result = _provider.Patients.Where(x => x.PatientId == patientId).FirstOrDefault();
                if (result != null)
                {
                    result.Episodes = _provider.Episodes.Where(x => x.PatientId == patientId).ToList(); 
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                { 
                    return Request.CreateResponse(HttpStatusCode.NotFound,"No Record Found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
         
    }
}