This repository contains code for assessments for Careflow Connect candidates.

The instructions to the assessor are found in 'Instructions for the assessor.txt'. This file describes the assessments available, and how to prepare them for the candidates.

The instructions to the candidate are found in 'Instructions for the candidate.txt'. This file describes the solution a little, and asks the candidate to implement some feature.


using (var mock = AutoMock.GetLoose())

            {
                mock.Provide<IDatabaseContext, InMemoryPatientContext>();
                mock.Mock<IDatabaseContext>()
                    .Setup(x => x.Patients)
                    .Callback<IDbSet<Patient>>(
                    p => p.Add(GetDemoPatient())

                    );
                //mock.Mock.mock
                //    .Setup(srv => srv.Patients)
                //    .Callback<DbSet<Patient>>(p => p.Add(
                //      GetDemoPatient()));

                var sut = mock.Create<PatientsController>();
                sut.Request = new HttpRequestMessage();
                sut.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey,
                                                  new HttpConfiguration());
                // Act
                var actionResult = sut.Get(patientId);
                // Assert
                Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);

            }
