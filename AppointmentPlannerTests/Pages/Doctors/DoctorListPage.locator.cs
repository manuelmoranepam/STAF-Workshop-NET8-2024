using OpenQA.Selenium;
using System.Collections.Generic;

namespace AppointmentPlannerTests.Pages.Doctors;

public partial class DoctorListPage
{
	private readonly By _addNewDoctorButtonLocator = By.XPath("//div[contains(@class, 'specialization-types')]//button");
	private readonly By _cancelNewDoctorFormButtonLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//div[contains(@class, 'e-footer-content')]//button[contains(text(), 'Cancel')]");
	private readonly By _saveNewDoctorFormButtonLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//div[contains(@class, 'e-footer-content')]//button[contains(text(), 'Save')]");
	private readonly By _doctorNameTextboxLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//input[@name = 'Name']");
	private readonly By _doctorMaleGenderLabelLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//label[@for = 'patientCheckMale']");
	private readonly By _doctorFemaleGenderLabelLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//label[@for = 'patientCheckFemale']");
	private readonly By _mobileNumberTextboxLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//input[@id = 'DoctorMobile']");
	private readonly By _emailTextboxLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//input[@name = 'Email']");
	private readonly By _departmentDropdownLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//div[contains(@class, 'doctor-department')]");
	private readonly By _departmentOptionListLocator = By.XPath("//div[@id = 'Specialization_popup']//ul[@id = 'Specialization_options']//li[contains(@class, 'e-list-item')]");
	private readonly By _educationTextboxLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//input[@name = 'Education']");
	private readonly By _experienceDropdownLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//div[@aria-describedby = 'Experience']");
	private readonly By _experienceOptionListLocator = By.XPath("//div[@id = 'Experience_popup']//ul[@id = 'Experience_options']//li[contains(@class, 'e-list-item')]");
	private readonly By _designationTextboxLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//input[@name = 'Designation']");
	private readonly By _dutyTimingDropdownLocator = By.XPath("//div[contains(@class, 'new-doctor-dialog') and contains(@style, 'display: flex;')]//div[@aria-describedby = 'DutyTiming']");
	private readonly By _dutyTimingOptionListLocator = By.XPath("//div[@id = 'DutyTiming_popup']//ul[@id = 'DutyTiming_options']//li[contains(@class, 'e-list-item')]");
	private readonly By _doctorDetailsListContainerLocator = By.XPath("//div[contains(@class, 'specialist-display')]//div[contains(@class, 'specialist-detail')]");
	private readonly By _doctorNameLabelPartialLocator = By.XPath(".//div[contains(@class, 'name')]");
	private readonly By _doctorEducationLabelPartialLocator = By.XPath(".//div[contains(@class, 'education')]");
	private readonly By _doctorDesignationLabelPartialLocator = By.XPath(".//div[contains(@class, 'specialization')]/span[contains(@class, 'specialization-text')]");
	private readonly By _doctorExperienceLabelPartialLocator = By.XPath(".//div[contains(@class, 'experience')]/span[contains(@class, 'specialization-text')]");

	private IWebElement AddNewDoctorButton => _webDriver.FindElement(_addNewDoctorButtonLocator);
	private IWebElement CancelNewDoctorFormButton => _webDriver.FindElement(_cancelNewDoctorFormButtonLocator);
	private IWebElement SaveNewDoctorFormButton => _webDriver.FindElement(_saveNewDoctorFormButtonLocator);
	private IWebElement DoctorNameTextbox => _webDriver.FindElement(_doctorNameTextboxLocator);
	private IWebElement DoctorMaleGenderLabel => _webDriver.FindElement(_doctorMaleGenderLabelLocator);
	private IWebElement DoctorFemaleGendeLabel => _webDriver.FindElement(_doctorFemaleGenderLabelLocator);
	private IWebElement MobileNumberTextbox => _webDriver.FindElement(_mobileNumberTextboxLocator);
	private IWebElement EmailTextbox => _webDriver.FindElement(_emailTextboxLocator);
	private IWebElement DepartmentDropdown => _webDriver.FindElement(_departmentDropdownLocator);
	private IList<IWebElement> DepartmentOptionList => _webDriver.FindElements(_departmentOptionListLocator);
	private IWebElement EducationTextbox => _webDriver.FindElement(_educationTextboxLocator);
	private IWebElement ExperienceDropdown => _webDriver.FindElement(_experienceDropdownLocator);
	private IList<IWebElement> ExperienceOptionList => _webDriver.FindElements(_experienceOptionListLocator);
	private IWebElement DesignationTextbox => _webDriver.FindElement(_designationTextboxLocator);
	private IWebElement DutyTimingDropdown => _webDriver.FindElement(_dutyTimingDropdownLocator);
	private IList<IWebElement> DutyTimingOptionList => _webDriver.FindElements(_dutyTimingOptionListLocator);
	private IList<IWebElement> DoctorDetailsListContainer => _webDriver.FindElements(_doctorDetailsListContainerLocator);
}
