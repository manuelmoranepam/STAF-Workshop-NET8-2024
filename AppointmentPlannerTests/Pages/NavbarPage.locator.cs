using OpenQA.Selenium;

namespace AppointmentPlannerTests.Pages;

internal partial class NavbarPage
{
	private readonly By _doctorsMenuItemLocator = By.XPath("//ejs-sidebar[@id = 'plannerSiderBar']//div[contains(@class, 'doctors')]");

	private IWebElement DoctorsMenuItem => _webDriver.FindElement(_doctorsMenuItemLocator);
}
