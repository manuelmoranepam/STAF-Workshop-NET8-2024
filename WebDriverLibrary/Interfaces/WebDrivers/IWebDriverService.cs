using OpenQA.Selenium;
using WebDriverLibrary.Interfaces.Configurations;

namespace WebDriverLibrary.Interfaces.WebDrivers;

public interface IWebDriverService
{
	IWebDriver CreateWebDriver();
	void DisposeWebDriver();
	string GetCurrentUrl();
	string GetPageTitle();
	IWebDriver GetWebDriver();
	IWebDriverConfiguration GetWebDriverConfiguration();
	void NavigageTo(string url);
}
