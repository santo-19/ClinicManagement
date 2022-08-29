using ClinicLib;
namespace UnitTest
{
    public class Tests
    {
        ILogin log;
        IHome home;
        IScheduleAppointments sa;
        ICancelSchedule cs;

        [SetUp]
        public void Setup()
        {
            log = new Login();
            home = new Home();
            sa = new ScheduleAppointments();
            cs = new CancelSchedule();
        }
        [Test]
        public void TestLogin()
        {
            bool actual_res = log.UserLogin("santo19", "Santo@19");
            bool expected_res = true;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestAllDoctors()
        {
            int actual_res = home.viewAllDoctors().Count();
            int expected_res = 5;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestAddPatients()
        {
            int p;
            int actual_res = home.addPatients(new Patients(07, "Suresh", "Raja", "M", 22, Convert.ToDateTime("07/09/2000")), out p);
            int expected_res = 1;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestValidatePatients()
        {
            bool actual_res = home.validatePatients("Ramesh", "Raj", "M", 23, "03/04/1999");
            bool expected_res = true;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestDoctorsBySpecs()
        {
            int actual_res = sa.displayDoctorsBasedOnSpecialization("General").Count;
            int expected_res = 1;
            Assert.AreEqual(expected_res, actual_res);
        }

        [Test]
        public void TestForAllSlots()
        {
            int actualValue = sa.getAllSlotsForDoctor(101, DateTime.Parse("26/08/2022")).Count();
            int expectedValue = 3;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestBookAppointmentForPatient()
        {
            int actualValue = sa.bookAppointment(514, 2000);
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestValidaeScheduleForAppointment()
        {
            bool actualValue = sa.ValidateScheduleAppointment(2000, "Orthopedics");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestValidateIndianFormatDate()
        {
            bool actualValue = sa.ValidateIndianFormatDate("27/11/2000");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestdisplayAppointmentsOfPatient()
        {
            int actualValue = cs.displayAppointmentsOfPatient(2000, DateTime.Parse("27/08/2022")).Count();
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestCancelAppointment()
        {
            int actualValue = cs.cancelAppointment(510, 2000);
            int expectedValue = 0;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestValidateAppointmentID()
        {
            List<int> list = new List<int>() { 501 };
            bool actualValue = sa.ValidateAppointmentID(list, 501);
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestValidateDateLimit()
        {
            bool actualValue = sa.ValidateDateLimit("29/08/2022");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestValidateDoctorID()
        {
            List<int> list = new List<int>() { 103 };
            bool actualValue = sa.ValidateDoctorID(103, list);
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
