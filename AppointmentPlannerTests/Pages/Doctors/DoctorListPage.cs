using AppointmentPlannerTests.Models.Doctors;
using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace AppointmentPlannerTests.Pages.Doctors;

public partial class DoctorListPage
{
	private readonly IWebDriverService _webDriverService;
	private readonly ILoggerService _loggerService;
	private readonly IWebDriver _webDriver;

	public DoctorListPage(IWebDriverService webDriverService, ILoggerService loggerService)
	{
		ArgumentNullException.ThrowIfNull(webDriverService);
		ArgumentNullException.ThrowIfNull(loggerService);

		_webDriverService = webDriverService;
		_loggerService = loggerService;
		_webDriver = _webDriverService.GetWebDriver();

		_loggerService.LogInformation(_pageInitializedMessage);
	}

	public void OpenNewDoctorForm()
	{
		ClickAddNewDoctorButton();
	}

	public void FillNewDoctorForm(Doctor doctor)
	{
		ArgumentNullException.ThrowIfNull(doctor);

		EnterDoctorName(doctor.FirstName, doctor.LastName);
		SelectDoctorGender(doctor.IsMale);
		EnterMobileNumber(doctor.MobileNumber);
		EnterEmail(doctor.Email);
		EnterEducation(doctor.Education);
		EnterDesignation(doctor.Designation);
		SelectDepartment(doctor.Department);
		SelectExperience(doctor.Experience);
		SelectDutyTiming(doctor.DutyTiming);
	}

	public void SubmitNewDoctorForm()
	{
		ClickSaveNewDoctorFormButton();
	}

	public void CloseNewDoctorForm()
	{
		ClickCancelNewDoctorFormButton();
	}

	public Doctor GetDoctorByName(string name)
	{
		var index = GetDoctorIndexByName(name);

		var doctor = new Doctor()
		{
			FirstName = GetDoctorsFirstName(index),
			LastName = GetDoctorsLastName(index),
			Designation = GetDoctorsDesignation(index),
			Education = GetDoctorsEducation(index),
			Experience = GetDoctorsExperience(index)
		};

		return doctor;
	}
}
