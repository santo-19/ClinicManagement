using ClinicLib;
namespace UnitTesting
{
    public class Tests
    {
        ILogin log;
        IHome home;
        [SetUp]
        public void Setup()
        {
            log = new Login();
            home = new Home();
        }

        [Test]
        public void TestLogin()
        {
            bool actual_res = log.UserLogin("santo19", "Santo@19");
            bool expected_res = true;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestHome()
        {
            int actual_res = home.viewDoctors().Count();
            int expected_res = 1;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestAddPatients()
        {
            int actual_res = home.addPatients(new Patients(02, "Suresh", "Raja", "M", 22, Convert.ToDateTime("2000/07/09")));
            int expected_res = 1;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestValidatePatients()
        {
            bool actual_res = home.validatePatients(03, "Ramesh", "Raj", "M", 23, "03/04/1999");
            bool expected_res = true;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestDoctorsBySpecs()
        {
            int actual_res = home.doctorsBySpecialization("General").Count;
            int expected_res = 0;
            Assert.AreEqual(expected_res, actual_res);
        }
    }
}