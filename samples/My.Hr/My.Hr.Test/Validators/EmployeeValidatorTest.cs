﻿using Beef.Test.NUnit;
using Beef.Validation;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using My.Hr.Business;
using My.Hr.Business.Data;
using My.Hr.Business.DataSvc;
using My.Hr.Business.Entities;
using My.Hr.Business.Validation;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace My.Hr.Test.Validators
{
    [TestFixture]
    public class EmployeeValidatorTest
    {
        private Func<IServiceCollection, IServiceCollection>? _testSetup;
        private readonly Mock<IEmployeeDataSvc> _employeeDataSvc = new Mock<IEmployeeDataSvc>();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var rd = new Mock<IReferenceDataData>();
            rd.Setup(x => x.GenderGetAllAsync()).ReturnsAsync(new GenderCollection { new Gender { Id = Guid.NewGuid(), Code = "F" } });
            rd.Setup(x => x.USStateGetAllAsync()).ReturnsAsync(new USStateCollection { new USState { Id = Guid.NewGuid(), Code = "WA" } });
            rd.Setup(x => x.RelationshipTypeGetAllAsync()).ReturnsAsync(new RelationshipTypeCollection { new RelationshipType { Id = Guid.NewGuid(), Code = "FR" } });

            var eds = new Mock<IEmployeeDataSvc>();

            _testSetup = sc => sc
                .AddGeneratedValidationServices()
                .AddGeneratedReferenceDataManagerServices()
                .AddGeneratedReferenceDataDataSvcServices()
                .AddScoped(_ => rd.Object)
                .AddScoped(_ => eds.Object);
        }

        private Employee CreateValidEmployee() => new Employee
        {
            Email = "sarah.smith@org.com",
            FirstName = "Sarah",
            LastName = "Smith",
            GenderSid = "F",
            Birthday = DateTime.Now.AddYears(-20),
            StartDate = new DateTime(2010, 01, 01),
            PhoneNo = "(425) 333 4444",
        };

        [Test]
        public async Task A110_Validate_Initial()
        {
            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .ExpectMessages(
                    "First Name is required.",
                    "Email is required.",
                    "Last Name is required.",
                    "Gender is required.",
                    "Birthday is required.",
                    "Start Date is required.",
                    "Phone No is required.")
                .CreateAndRunAsync<IValidator<Employee>, Employee>(new Employee());
        }

        [Test]
        public async Task A120_Validate_BadData()
        {
            var e = new Employee
            {
                Email = "xxx",
                FirstName = 'x'.ToLongString(),
                LastName = 'x'.ToLongString(),
                GenderSid = "X",
                Birthday = DateTime.Now.AddYears(10),
                StartDate = new DateTime(1996, 12, 31),
                PhoneNo = "(425) 333 4444"
            };

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .ExpectMessages(
                    "Email is invalid.",
                    "First Name must not exceed 100 characters in length.",
                    "Last Name must not exceed 100 characters in length.",
                    "Gender is invalid.",
                    "Birthday is invalid as the Employee must be at least 18 years of age.",
                    "Start Date must be greater than or equal to January 1, 1999.")
                .CreateAndRunAsync<IValidator<Employee>, Employee>(e);
        }

        [Test]
        public async Task A130_Validate_Address_Empty()
        {
            var e = CreateValidEmployee();
            e.Address = new Address();

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .ExpectMessages(
                    "Street1 is required.",
                    "City is required.",
                    "State is required.",
                    "Post Code is required.")
                .CreateAndRunAsync<IValidator<Employee>, Employee>(e);
        }

        [Test]
        public async Task A140_Validate_Address_Invalid()
        {
            var e = CreateValidEmployee();
            e.Address = new Address
            {
                Street1 = "8365 Rode Road",
                City = "Redmond",
                StateSid = "FR",
                PostCode = "XXXXXXXXXX"
            };

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .ExpectMessages(
                    "State is invalid.",
                    "Post Code is invalid.")
                .CreateAndRunAsync<IValidator<Employee>, Employee>(e);
        }

        [Test]
        public async Task A150_Validate_Address_OK()
        {
            var e = CreateValidEmployee();
            e.Address = new Address
            {
                Street1 = "8365 Rode Road",
                City = "Redmond",
                StateSid = "WA",
                PostCode = "98052"
            };

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .CreateAndRunAsync<IValidator<Employee>, Employee>(e);
        }

        [Test]
        public async Task A160_Validate_Contacts_Empty()
        {
            var e = CreateValidEmployee();
            e.EmergencyContacts = new EmergencyContactCollection { new EmergencyContact() };

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .ExpectMessages(
                    "First Name is required.",
                    "Last Name is required.",
                    "Phone No is required.",
                    "Relationship is required.")
                .CreateAndRunAsync<IValidator<Employee>, Employee>(e);
        }

        [Test]
        public async Task A170_Validate_Contacts_Invalid()
        {
            var e = CreateValidEmployee();
            e.EmergencyContacts = new EmergencyContactCollection 
            { 
                new EmergencyContact
                {
                    FirstName = "Brian",
                    LastName = "Bellows",
                    PhoneNo = "425 333 4445",
                    RelationshipSid = "XX"
                }
            };

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .ExpectMessages("Relationship is invalid.")
                .CreateAndRunAsync<IValidator<Employee>, Employee>(e);
        }

        [Test]
        public async Task A180_Validate_Contacts_TooMany()
        {
            var e = CreateValidEmployee();
            e.EmergencyContacts = new EmergencyContactCollection();

            for (int i = 0; i < 6; i++)
            {
                e.EmergencyContacts.Add(new EmergencyContact
                {
                    FirstName = "Brian",
                    LastName = "Bellows",
                    PhoneNo = "425 333 4445",
                    RelationshipSid = "FR"
                });
            }

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .ExpectMessages("Emergency Contacts must not exceed 5 item(s).")
                .CreateAndRunAsync<IValidator<Employee>, Employee>(e);
        }

        [Test]
        public async Task A190_Validate_UpdateTerminated()
        {
            var e = CreateValidEmployee();
            e.Id = 1.ToGuid();

            var eds = new Mock<IEmployeeDataSvc>();
            eds.Setup(x => x.GetAsync(1.ToGuid())).ReturnsAsync(new Employee { Termination = new TerminationDetail { Date = DateTime.UtcNow } });

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .AddScopedService(eds)
                .ExpectErrorType(Beef.ErrorType.ValidationError, "Once an Employee has been Terminated the data can no longer be updated.")
                .OperationType(Beef.OperationType.Update)
                .CreateAndRunAsync<IValidator<Employee>, Employee>(e);
        }

        [Test]
        public async Task B110_CanDelete_NotFound()
        {
            var eds = new Mock<IEmployeeDataSvc>();
            eds.Setup(x => x.GetAsync(1.ToGuid())).ReturnsAsync((Employee)null!);

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .AddScopedService(eds)
                .ExpectErrorType(Beef.ErrorType.NotFoundError)
                .RunAsync(async () => await EmployeeValidator.CanDelete.ValidateAsync(1.ToGuid()));
        }

        [Test]
        public async Task B110_CanDelete_Invalid()
        {
            var eds = new Mock<IEmployeeDataSvc>();
            eds.Setup(x => x.GetAsync(1.ToGuid())).ReturnsAsync(new Employee { StartDate = DateTime.UtcNow.AddDays(-1) });

            await ValidationTester.Test()
                .ConfigureServices(_testSetup!)
                .AddScopedService(eds)
                .ExpectErrorType(Beef.ErrorType.ValidationError, "An employee cannot be deleted after they have started their employment.")
                .RunAsync(async () => await EmployeeValidator.CanDelete.ValidateAsync(1.ToGuid()));
        }
    }
}