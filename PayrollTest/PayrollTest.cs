using NUnit.Framework;
using PaymentImplementation;
using PayollDomain;
using PayrollApplication;
using PayrollBoundary;
using PayrollDatabase;
using RequestsFactory;
using System;
using TextParserTransactionSource;
using TransactionApplication;
using TransactionImplementation;

namespace PayrollTest
{
    [TestFixture]
    public class PayrollTest
    {
        private TransactionApp app = new PayrollApp(new TextParseTransactionSource(new TransactionFactoryImplementation()));

        [Test]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            app.ExexcuteTransaction("addSalariedEmployee", RequestFactory.rf.MakeSalariedEmployeeRequest(empId, "Bob", "Home", 1000));

            Employee e = PayrollDb.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);

            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestAddHourlyEmployee()
        {
            int empId = 1;
            app.ExexcuteTransaction("addHourlyEmployee", RequestFactory.rf.MakeHourlyEmployeeRequest(empId, "Bob", "Home", 50));

            Employee e = PayrollDb.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestAddCommissionedEmployee()
        {
            int empId = 1;
            app.ExexcuteTransaction("addCommissionedEmployee", RequestFactory.rf.MakeCommissionedEmployeeRequest(empId, "Bob", "Home", 0.5, 1000));

            Employee e = PayrollDb.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiWeeklySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void DeleteEmployee()
        {
            int empId = 4;
            app.ExexcuteTransaction("addCommissionedEmployee", RequestFactory.rf.MakeCommissionedEmployeeRequest(empId, "Bill", "Home", 3.2, 500));

            Employee e = PayrollDb.GetEmployee(empId);
            Assert.IsNotNull(e);
            app.ExexcuteTransaction("deleteEmployee", RequestFactory.rf.MakeDeleteEmployeeRequest(empId));

            e = PayrollDb.GetEmployee(empId);
            Assert.IsNull(e);
        }

        [Test]
        public void TestTimeCardTransaction()
        {
            int empId = 5;
            app.ExexcuteTransaction("addHourlyEmployee", RequestFactory.rf.MakeHourlyEmployeeRequest(empId, "Bob", "Home", 50));

            app.ExexcuteTransaction("addTimeCard", RequestFactory.rf.MakeTimeCardRequest(new DateTime(2005, 7, 31), 8.0, empId));

            Employee e = PayrollDb.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;

            TimeCard tc = hc.GetTimeCard(new DateTime(2005, 7, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }

        [Test]
        public void TestSalesReceiptTransaction()
        {
            int empId = 5;
            app.ExexcuteTransaction("addCommissionedEmployee", RequestFactory.rf.MakeCommissionedEmployeeRequest(empId, "Bill", "Home", 2.5, 1000));

            app.ExexcuteTransaction("addSalesReceipt", RequestFactory.rf.MakeSalesReceiptRequest(new DateTime(2005, 7, 31), 200, empId));

            Employee e = PayrollDb.GetEmployee(empId);
            Assert.IsNotNull(e, "Employee is null");

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification cc = pc as CommissionedClassification;

            SalesReceipt sr = cc.GetSalesReceipt(new DateTime(2005, 7, 31));
            Assert.IsNotNull(sr, "Sales receipt is null");
            Assert.AreEqual(200, sr.Amount);
        }

        [Test]
        public void AddServiceCharge()
        {
            int empId = 2;
            app.ExexcuteTransaction("addHourlyEmployee", RequestFactory.rf.MakeHourlyEmployeeRequest(empId, "Bob", "Home", 50));

            Employee e = PayrollDb.GetEmployee(empId);
            Assert.IsNotNull(e);

            UnionAffiliation af = new UnionAffiliation(50, 100.50);
            e.Affiliation = af;

            int memeberId = 86;
            PayrollDb.AddUnionMember(memeberId, e);

            app.ExexcuteTransaction("addServiceCharge", RequestFactory.rf.MakeServiceChargeRequest(memeberId, new DateTime(2005, 8, 8), 12.95));

            ServiceCharge sc = af.GetServiceCharge(new DateTime(2005, 8, 8));

            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount, .001);
        }

        //[Test]
        //public void TestChangeNameTransaction()
        //{
        //    int empId = 2;
        //    AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
        //    t.Execute();

        //    ChangeNameTransaction cnt = new ChangeNameTransaction(empId, "Bob");
        //    cnt.Execute();

        //    Employee e = PayrollDatabase.GetEmployee(empId);
        //    Assert.IsNotNull(e);
        //    Assert.AreEqual("Bob", e.Name);
        //}

        //[Test]
        //public void TestChangeHourlyTransaction()
        //{
        //    int empId = 3;
        //    AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Lance", "Home", 2500, 3.2);
        //    t.Execute();

        //    ChangeHourlyTransaction cht = new ChangeHourlyTransaction(empId, 27.52);
        //    cht.Execute();

        //    Employee e = PayrollDatabase.GetEmployee(empId);
        //    Assert.IsNotNull(e);

        //    PaymentClassification pc = e.Classification;
        //    Assert.IsNotNull(pc);
        //    Assert.IsTrue(pc is HourlyClassification);
        //    HourlyClassification hc = pc as HourlyClassification;
        //    Assert.AreEqual(27.52, hc.HourlyRate, .001);

        //    PaymentSchedule ps = e.Schedule;
        //    Assert.IsTrue(ps is WeeklySchedule);
        //}

        //[Test]
        //public void TestChangeSalariedTransaction()
        //{
        //    int empId = 3;
        //    AddHourlyEmployee h = new AddHourlyEmployee(empId, "Dom", "Home", 20.5);
        //    h.Execute();

        //    ChangeSalariedTransaction chs = new ChangeSalariedTransaction(empId, 1500.50);
        //    chs.Execute();

        //    Employee e = PayrollDatabase.GetEmployee(empId);
        //    Assert.IsNotNull(e);

        //    PaymentClassification pc = e.Classification;
        //    Assert.IsNotNull(pc);
        //    Assert.IsTrue(pc is SalariedClassification);
        //    SalariedClassification hc = pc as SalariedClassification;
        //    Assert.AreEqual(1500.50, hc.Salary, .001);

        //    PaymentSchedule ps = e.Schedule;
        //    Assert.IsTrue(ps is MonthlySchedule);
        //}

        //[Test]
        //public void TestChangeCommisionedTransaction()
        //{
        //    int empId = 3;
        //    AddHourlyEmployee h = new AddHourlyEmployee(empId, "Dom", "Home", 20.5);
        //    h.Execute();

        //    ChangeCommisionedTransaction chc = new ChangeCommisionedTransaction(empId, 10, 1500.50);
        //    chc.Execute();

        //    Employee e = PayrollDatabase.GetEmployee(empId);
        //    Assert.IsNotNull(e);

        //    PaymentClassification pc = e.Classification;
        //    Assert.IsNotNull(pc);
        //    Assert.IsTrue(pc is CommissionedClassification);
        //    CommissionedClassification cc = pc as CommissionedClassification;
        //    Assert.AreEqual(10, cc.HourlyRate, .001);
        //    Assert.AreEqual(1500.50, cc.Salary, .001);

        //    PaymentSchedule ps = e.Schedule;
        //    Assert.IsTrue(ps is BiWeeklySchedule);
        //}

        //[Test]
        //public void TestChangeDirectMethodTransaction()
        //{
        //    int empId = 3;
        //    AddHourlyEmployee h = new AddHourlyEmployee(empId, "Dom", "Home", 20.5);
        //    h.Execute();

        //    ChangeDirectMethodTransaction cdm = new ChangeDirectMethodTransaction(empId, "BPI", 1001);
        //    cdm.Execute();

        //    Employee e = PayrollDatabase.GetEmployee(empId);
        //    Assert.IsNotNull(e);

        //    PaymentMethod pm = e.Method;
        //    Assert.IsNotNull(pm);
        //    Assert.IsTrue(pm is DirectMethod);
        //    DirectMethod dm = pm as DirectMethod;
        //    Assert.AreEqual("BPI", dm.Bank);
        //    Assert.AreEqual(1001, dm.Account);
        //}

        //[Test]
        //public void TestChangeMailMethodTransaction()
        //{
        //    int empId = 3;
        //    AddHourlyEmployee h = new AddHourlyEmployee(empId, "Dom", "Home", 20.5);
        //    h.Execute();

        //    ChangeMailMethodTransaction cmm = new ChangeMailMethodTransaction(empId, "Manila");
        //    cmm.Execute();

        //    Employee e = PayrollDatabase.GetEmployee(empId);
        //    Assert.IsNotNull(e);

        //    PaymentMethod pm = e.Method;
        //    Assert.IsNotNull(pm);
        //    Assert.IsTrue(pm is MailMethod);
        //    MailMethod mm = pm as MailMethod;
        //    Assert.AreEqual("Manila", mm.Address);
        //}

        //[Test]
        //public void TestChangeHoldMethodTransaction()
        //{
        //    int empId = 3;
        //    AddHourlyEmployee h = new AddHourlyEmployee(empId, "Dom", "Home", 20.5);
        //    h.Execute();

        //    ChangeHoldMethodTransaction chm = new ChangeHoldMethodTransaction(empId);
        //    chm.Execute();

        //    Employee e = PayrollDatabase.GetEmployee(empId);
        //    Assert.IsNotNull(e);

        //    PaymentMethod pm = e.Method;
        //    Assert.IsNotNull(pm);
        //    Assert.IsTrue(pm is HoldMethod);
        //}

        //[Test]
        //public void TestChangeUnionMember()
        //{
        //    int empId = 8;
        //    AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
        //    t.Execute();
        //    int memberId = 7743;
        //    ChangeMemberTransaction cmt = new ChangeMemberTransaction(empId, memberId, 99.42);
        //    cmt.Execute();

        //    Employee e = PayrollDatabase.GetEmployee(empId);
        //    Assert.IsNotNull(e);
        //    Affiliation affiliation = e.Affiliation;
        //    Assert.IsNotNull(affiliation);
        //    Assert.IsTrue(affiliation is UnionAffiliation);
        //    UnionAffiliation uf = affiliation as UnionAffiliation;
        //    Assert.AreEqual(99.42, uf.Dues, .001);

        //    Employee member = PayrollDatabase.GetUnionMember(memberId);
        //    Assert.IsNotNull(member);
        //    Assert.AreEqual(e, member);
        //}

        //[Test]
        //public void TestPaySingleSalariedEmployee()
        //{
        //    int empId = 302;
        //    AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
        //    t.Execute();

        //    DateTime payDate = new DateTime(2001, 09, 30);
        //    PayDayTransaction pt = new PayDayTransaction(payDate);
        //    pt.Execute();

        //    PayCheck pc = pt.GetPaycheck(empId);
        //    Assert.IsNotNull(pc);
        //    Assert.AreEqual(payDate, pc.PayDate);
        //    Assert.AreEqual(1000.00, pc.GrossPay, .001);
        //    Assert.AreEqual(0.0, pc.Deductions, .001);
        //    Assert.AreEqual(1000.00, pc.NetPay, .001);
        //}

        //[Test]
        //public void PaySingleSalariedEmployeeOnWrongDate()
        //{
        //    int empId = 1;
        //    AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
        //    t.Execute();

        //    DateTime payDate = new DateTime(2001, 11, 29);
        //    PayDayTransaction pt = new PayDayTransaction(payDate);
        //    pt.Execute();

        //    PayCheck pc = pt.GetPaycheck(empId);
        //    Assert.IsNull(pc);
        //}

        //[Test]
        //public void TestPaySingleHourlyEmployeeNoTimeCards()
        //{
        //    int empId = 2;
        //    AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
        //    t.Execute();

        //    DateTime payDate = new DateTime(2001, 11, 9);
        //    PayDayTransaction pt = new PayDayTransaction(payDate);
        //    pt.Execute();

        //    ValidateHourlyPaycheck(pt, empId, payDate, 0.0);
        //}

        //[Test]
        //public void TestPaySingleHourlyEmployeeOneTimeCard()
        //{
        //    int empId = 2;
        //    AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
        //    t.Execute();

        //    DateTime payDate = new DateTime(2001, 11, 9); // Friday
        //    TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
        //    tc.Execute();

        //    PayDayTransaction pt = new PayDayTransaction(payDate);
        //    pt.Execute();
        //    ValidateHourlyPaycheck(pt, empId, payDate, 30.5);
        //}

        //private void ValidateHourlyPaycheck(PayDayTransaction pt, int empid, DateTime payDate, double pay)
        //{
        //    PayCheck pc = pt.GetPaycheck(empid);
        //    Assert.IsNotNull(pc);
        //    Assert.AreEqual(payDate, pc.PayDate);
        //    Assert.AreEqual(pay, pc.GrossPay, .001);
        //    Assert.AreEqual(0.0, pc.Deductions, .001);
        //    Assert.AreEqual(pay, pc.NetPay, .001);
        //}
    }
}
