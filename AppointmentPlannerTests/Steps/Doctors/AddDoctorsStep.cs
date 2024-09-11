using AppointmentPlannerTests.Extensions;
using AppointmentPlannerTests.Models.Doctors;
using AppointmentPlannerTests.Pages.Doctors;
using LoggerLibrary.Interfaces.Loggers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace AppointmentPlannerTests.Steps.Doctors;

[Binding]
public sealed class AddDoctorsStep
{
	private readonly ScenarioContext _scenarioContext;
	private readonly DoctorListPage _doctorListPage;
	private readonly ILoggerService _loggerService;

	public AddDoctorsStep(ScenarioContext scenarioContext)
	{
		_scenarioContext = scenarioContext;

		var webDriverService = scenarioContext["WebDriverService"] as IWebDriverService;

		_loggerService = (scenarioContext["LoggerService"] as ILoggerService)!;

		_doctorListPage = new DoctorListPage(webDriverService!, _loggerService!);
	}

	[When(@"I fill and submit the New Doctor form with the following data")]
	public void WhenIFillAndSubmitTheNewDoctorFormWithTheFollowingData(Table table)
	{
		var doctor = table.CreateInstance<Doctor>();

		doctor.Email = $"{doctor.FirstName}.{doctor.LastName}.{DateTime.Now.Ticks}@mailinator.com";
		doctor.MobileNumber = $"1234567890";

		_loggerService.LogInformation("\tDoctor Data:\n" + doctor.ToString<Doctor>());

		_scenarioContext["Doctor"] = doctor;

		_doctorListPage.OpenNewDoctorForm();
		_doctorListPage.FillNewDoctorForm(doctor);
		_doctorListPage.SubmitNewDoctorForm();
	}

	[Then(@"I verify that the new doctor is added successfully")]
	public void ThenIVerifyThatTheNewDoctorIsAddedSuccessfully()
	{
		var expectedDoctor = _scenarioContext["Doctor"] as Doctor;

		var fullname = $"Dr. {expectedDoctor!.FirstName} {expectedDoctor!.LastName}";

		var actualDoctor = _doctorListPage.GetDoctorByName(fullname);

		Assert.Multiple(() =>
		{
			Assert.That(actualDoctor.FirstName, Is.EqualTo(expectedDoctor.FirstName));
			Assert.That(actualDoctor.LastName, Is.EqualTo(expectedDoctor.LastName));
			Assert.That(actualDoctor.Designation, Is.EqualTo(expectedDoctor.Designation));
			Assert.That(actualDoctor.Experience, Is.EqualTo(expectedDoctor.Experience));
			Assert.That(actualDoctor.Education, Is.EqualTo(expectedDoctor.Education));
		});
	}
}
