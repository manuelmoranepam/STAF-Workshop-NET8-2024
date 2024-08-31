using System;
using System.Linq;
using WebDriverLibrary.Extensions.WebDrivers;

namespace AppointmentPlannerTests.Pages.Doctors;

public partial class DoctorListPage
{
	private void ClickAddNewDoctorButton()
	{
		try
		{
			_webDriver.WaitUntilElementIsClickable(_addNewDoctorButtonLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			AddNewDoctorButton.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickAddNewDoctorButtonErrorMessage, _addNewDoctorButtonLocator);

			throw;
		}
	}

	private void ClickCancelNewDoctorFormButton()
	{
		try
		{
			_webDriver.WaitUntilElementIsClickable(_cancelNewDoctorFormButtonLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			CancelNewDoctorFormButton.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickCancelNewDoctorFormButtonErrorMessage, _cancelNewDoctorFormButtonLocator);

			throw;
		}
	}

	private void ClickSaveNewDoctorFormButton()
	{
		try
		{
			_webDriver.WaitUntilElementIsClickable(_saveNewDoctorFormButtonLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			SaveNewDoctorFormButton.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickSaveNewDoctorFormButtonErrorMessage, _saveNewDoctorFormButtonLocator);

			throw;
		}
	}

	private void EnterDoctorName(string firstName, string lastName)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
		ArgumentException.ThrowIfNullOrWhiteSpace(lastName);

		try
		{
			_webDriver.WaitUntilElementIsVisible(_doctorNameTextboxLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			DoctorNameTextbox.Clear();

			DoctorNameTextbox.SendKeys($"{firstName} {lastName}");
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _enterDoctorNameErrorMessage, firstName, lastName, _doctorNameTextboxLocator);

			throw;
		}
	}

	private void SelectDoctorGender(bool isMale)
	{
		try
		{
			if (isMale)
			{
				ClickMaleGenderLabel();
			}
			else
			{
				ClickFemaleGenderLabel();
			}
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _selectDoctorGenderErrorMessage, []);

			throw;
		}
	}

	private void ClickMaleGenderLabel()
	{
		try
		{
			_webDriver.WaitUntilElementIsClickable(_doctorMaleGenderLabelLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			DoctorMaleGenderLabel.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickDoctorMaleGenderLabelErrorMessage, _doctorMaleGenderLabelLocator);

			throw;
		}
	}

	private void ClickFemaleGenderLabel()
	{
		try
		{
			_webDriver.WaitUntilElementIsClickable(_doctorFemaleGenderLabelLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			DoctorFemaleGendeLabel.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickDoctorFemaleGenderLabelErrorMessage, _doctorFemaleGenderLabelLocator);

			throw;
		}
	}

	private void EnterMobileNumber(string mobileNumber)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(mobileNumber);

		try
		{
			_webDriver.WaitUntilElementIsVisible(_mobileNumberTextboxLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			MobileNumberTextbox.Clear();

			MobileNumberTextbox.SendKeys(mobileNumber);
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _enterMobileNumberErrorMessage, mobileNumber, _mobileNumberTextboxLocator);

			throw;
		}
	}

	private void EnterEmail(string email)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(email);

		try
		{
			_webDriver.WaitUntilElementIsVisible(_emailTextboxLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			EmailTextbox.Clear();

			EmailTextbox.SendKeys(email);
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _enterEmailErrorMessage, email, _emailTextboxLocator);

			throw;
		}
	}

	private void EnterEducation(string education)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(education);

		try
		{
			_webDriver.WaitUntilElementIsVisible(_educationTextboxLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			EducationTextbox.Clear();

			EducationTextbox.SendKeys(education);
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _enterEducationErrorMessage, education, _educationTextboxLocator);

			throw;
		}
	}

	private void EnterDesignation(string designation)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(designation);

		try
		{
			_webDriver.WaitUntilElementIsVisible(_designationTextboxLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			DesignationTextbox.Clear();

			DesignationTextbox.SendKeys(designation);
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _enterDesignationErrorMessage, designation, _designationTextboxLocator);

			throw;
		}
	}

	private void SelectDepartment(string department)
	{
		ClickDepartmentDropdown();
		ClickDepartmentOption(department);
	}

	private void ClickDepartmentDropdown()
	{

		try
		{
			_webDriver.WaitUntilElementIsClickable(_departmentDropdownLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			DepartmentDropdown.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickDepartmentErrorMessage, _departmentDropdownLocator);

			throw;
		}
	}

	private void ClickDepartmentOption(string department)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(department);

		try
		{
			_webDriver.WaitUntilElementIsClickable(_departmentOptionListLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var departmentOption = DepartmentOptionList
				.FirstOrDefault(option => option.Text.Equals(department, StringComparison.OrdinalIgnoreCase));

			departmentOption!.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickDepartmentOptionErrorMessage, department, _departmentOptionListLocator);

			throw;
		}
	}

	private void SelectExperience(string experience)
	{
		ClickExperienceDropdown();
		ClickExperienceOption(experience);
	}

	private void ClickExperienceDropdown()
	{
		try
		{
			_webDriver.WaitUntilElementIsClickable(_experienceDropdownLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			ExperienceDropdown.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickExperienceErrorMessage, _experienceDropdownLocator);

			throw;
		}
	}

	private void ClickExperienceOption(string experience)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(experience);

		try
		{
			_webDriver.WaitUntilElementIsClickable(_experienceOptionListLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var experienceOption = ExperienceOptionList
				.FirstOrDefault(option => option.Text.Equals(experience, StringComparison.OrdinalIgnoreCase));

			experienceOption!.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickExperienceOptionErrorMessage, experience, _experienceOptionListLocator);

			throw;
		}
	}

	private void SelectDutyTiming(string dutyTiming)
	{
		ClickDutyTimingDropdown();
		ClickDutyTimingOption(dutyTiming);
	}

	private void ClickDutyTimingDropdown()
	{
		try
		{
			_webDriver.WaitUntilElementIsClickable(_dutyTimingDropdownLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			DutyTimingDropdown.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickDutyTimingErrorMessage, _dutyTimingDropdownLocator);

			throw;
		}
	}

	private void ClickDutyTimingOption(string dutyTiming)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(dutyTiming);

		try
		{
			_webDriver.WaitUntilElementIsClickable(_dutyTimingOptionListLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var dutyTimingOption = DutyTimingOptionList
				.FirstOrDefault(option => option.Text.Equals(dutyTiming, StringComparison.OrdinalIgnoreCase));

			dutyTimingOption!.Click();
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _clickDutyTimingOptionErrorMessage, dutyTiming, _dutyTimingOptionListLocator);

			throw;
		}
	}

	private int GetDoctorIndexByName(string name)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(name);

		try
		{
			_webDriver.WaitUntilElementIsVisible(_doctorDetailsListContainerLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var doctorCard = DoctorDetailsListContainer
				.FirstOrDefault(element => element.FindElement(_doctorNameLabelPartialLocator).Text.Equals(name, StringComparison.OrdinalIgnoreCase));

			var index = DoctorDetailsListContainer.IndexOf(doctorCard!);

			return index;
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _getDoctorIndexByNameErrorMessage, name, _doctorDetailsListContainerLocator);

			throw;
		}
	}

	private string GetDoctorsFirstName(int index)
	{
		try
		{
			_webDriver.WaitUntilElementIsVisible(_doctorDetailsListContainerLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var firstName = DoctorDetailsListContainer[index]
				.FindElement(_doctorNameLabelPartialLocator).Text.Split()[1].Trim();

			return firstName;
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _getDoctorsFirstNameErrorMessage, index, _doctorDetailsListContainerLocator);

			throw;
		}
	}

	private string GetDoctorsLastName(int index)
	{
		try
		{
			_webDriver.WaitUntilElementIsVisible(_doctorDetailsListContainerLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var lastName = DoctorDetailsListContainer[index]
				.FindElement(_doctorNameLabelPartialLocator).Text.Split()[2].Trim();

			return lastName;
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _getDoctorsLastNameErrorMessage, index, _doctorDetailsListContainerLocator);

			throw;
		}
	}

	private string GetDoctorsEducation(int index)
	{
		try
		{
			_webDriver.WaitUntilElementIsVisible(_doctorDetailsListContainerLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var education = DoctorDetailsListContainer[index]
				.FindElement(_doctorEducationLabelPartialLocator).Text.Trim();

			return education;
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _getDoctorsEducationErrorMessage, index, _doctorDetailsListContainerLocator);

			throw;
		}
	}

	private string GetDoctorsDesignation(int index)
	{
		try
		{
			_webDriver.WaitUntilElementIsVisible(_doctorDetailsListContainerLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var designation = DoctorDetailsListContainer[index]
				.FindElement(_doctorDesignationLabelPartialLocator).Text.Trim();

			return designation;
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _getDoctorsDesignationErrorMessage, index, _doctorDetailsListContainerLocator);

			throw;
		}
	}

	private string GetDoctorsExperience(int index)
	{
		try
		{
			_webDriver.WaitUntilElementIsVisible(_doctorDetailsListContainerLocator,
				_webDriverService.GetWebDriverConfiguration().LongTimeout,
				_webDriverService.GetWebDriverConfiguration().PollingTimeout);

			var experience = DoctorDetailsListContainer[index]
				.FindElement(_doctorExperienceLabelPartialLocator).Text.Trim();

			return experience;
		}
		catch (Exception e)
		{
			_loggerService.LogError(e, _getDoctorsExperienceErrorMessage, index, _doctorDetailsListContainerLocator);

			throw;
		}
	}
}
