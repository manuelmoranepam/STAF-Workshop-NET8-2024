using AppointmentPlannerTests.Pages;
using LoggerLibrary.Interfaces.Loggers;
using TechTalk.SpecFlow;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace AppointmentPlannerTests.Steps.Navigation;

[Binding]
public sealed class NavbarStep
{
	private readonly ScenarioContext _scenarioContext;
	private readonly NavbarPage _navbarPage;

	public NavbarStep(ScenarioContext scenarioContext)
	{
		_scenarioContext = scenarioContext;

		var loggerService = _scenarioContext["LoggerService"] as ILoggerService;
		var webDriverService = _scenarioContext["WebDriverService"] as IWebDriverService;

		_navbarPage = new NavbarPage(webDriverService!, loggerService!);
	}

	[Given(@"I navigate to the Doctors page")]
	public void GivenINavigateToTheDoctorsPage()
	{
		_navbarPage.NavigateToDoctorsPage();
	}
}
