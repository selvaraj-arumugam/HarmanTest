using Moq;
using NUnit.Framework;
using RestApi.Controllers;
using RestApi.Interfaces;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace RestApi.UnitTests
{
    [TestFixture]
    public class GetPatientTests
    {

        [Test]
        [TestCase(1)]
        public void GetPatientWithEpisodes(int patientId)
        {
            // Arrange     
            var context = new TestPatientAppContext();
            context.Patients.Add(GetDemoPatient());
            context.Episodes.Add(GetDemoEpisode());
            var controller = new PatientsController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey,
                                              new HttpConfiguration());
            // Act
            var actionResult = controller.Get(patientId) as HttpResponseMessage;
            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        [TestCase(1)]
        public void GetPatientWithOutEpisodes(int patientId)
        {
            // Arrange     
            var context = new TestPatientAppContext();
            context.Patients.Add(GetDemoPatient()); 
            var controller = new PatientsController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey,
                                              new HttpConfiguration());
            // Act
            var actionResult = controller.Get(patientId) as HttpResponseMessage;
            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        [TestCase(11)]
        public void GetPatient_NotFound(int patientId)
        {
            // Arrange     
            var context = new TestPatientAppContext();
            context.Patients.Add(GetDemoPatient());
            var controller = new PatientsController(context);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey,
                                              new HttpConfiguration());
            // Act
            var actionResult = controller.Get(patientId) as HttpResponseMessage;
            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.NotFound);
        }
        Patient GetDemoPatient()
        { 
            return new Patient()
            {
                FirstName = "Millicent",
                NhsNumber = "1111111111",
                DateOfBirth = DateTime.Now,
                LastName = "Hammond",
                PatientId = 1
            };
        }
        Episode GetDemoEpisode()
        {
            return new Episode()
            {
                AdmissionDate = DateTime.Now,
                Diagnosis = "Irritation of inner ear",
                DischargeDate = DateTime.Now,
                EpisodeId = 1,
                PatientId = 1
            };
        }
    }
}