using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverLibrary.Enums;
using WebDriverLibrary.Interfaces.Configurations;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriverLibrary.WebDrivers;

public class SeleniumWebDriverService : IWebDriverService
{
	private readonly IWebDriverConfiguration _webDriverConfiguration;
	private readonly IWebDriver _webDriver;

	public SeleniumWebDriverService(IWebDriverConfiguration webDriverConfiguration)
	{
		_webDriverConfiguration = webDriverConfiguration;

		_webDriver = CreateWebDriver();

		ApplyConfigurations();
	}

	public IWebDriver CreateWebDriver()
	{
		return _webDriverConfiguration.BrowserType switch
		{
			BrowserType.Chrome => CreateChromeDriver(),
			BrowserType.Firefox => CreateFirefoxDriver(),
			BrowserType.Edge => CreateEdgeDriver(),
			_ => throw new ArgumentException("Invalid browser type.")
		};
	}

	private IWebDriver CreateChromeDriver()
	{
		_ = new DriverManager().SetUpDriver(new ChromeConfig());

		var options = GetChromeDriverOptions();

		var driver = new ChromeDriver(options);

		return driver;
	}

	private ChromeOptions GetChromeDriverOptions()
	{
		var options = new ChromeOptions();

		options.AddArgument("--incognito");

		ApplyGenericOptions(options);

		return options;
	}

	private IWebDriver CreateFirefoxDriver()
	{
		_ = new DriverManager().SetUpDriver(new FirefoxConfig());

		var options = GetFirefoxDriverOptions();

		var driver = new FirefoxDriver(options);

		return driver;
	}

	private FirefoxOptions GetFirefoxDriverOptions()
	{
		var options = new FirefoxOptions();

		options.AddArgument("--private");

		ApplyGenericOptions(options);

		return options;
	}

	private IWebDriver CreateEdgeDriver()
	{
		_ = new DriverManager().SetUpDriver(new EdgeConfig());

		var options = CreateEdgeDriverOptions();

		var driver = new EdgeDriver(options);

		return driver;
	}

	private EdgeOptions CreateEdgeDriverOptions()
	{
		var options = new EdgeOptions();

		options.AddArgument("--inprivate");

		ApplyGenericOptions(options);

		return options;
	}

	private void ApplyGenericOptions(dynamic options)
	{
		options.PageLoadStrategy = _webDriverConfiguration.PageLoadStrategy;

		if (_webDriverConfiguration.IsHeadless)
		{
			options.AddArgument("--headless");
		}
	}

	private void ApplyConfigurations()
	{
		_webDriver.Manage().Timeouts().PageLoad = _webDriverConfiguration.PageLoadTimeout;
		_webDriver.Manage().Timeouts().ImplicitWait = _webDriverConfiguration.ImplicitTimeout;
		_webDriver.Manage().Timeouts().AsynchronousJavaScript = _webDriverConfiguration.AsyncJavaScriptTimeout;
		_webDriver.Manage().Cookies.DeleteAllCookies();

		if (_webDriverConfiguration.IsMaximized)
			_webDriver.Manage().Window.Maximize();
	}

	public IWebDriver GetWebDriver()
	{
		return _webDriver;
	}

	public IWebDriverConfiguration GetWebDriverConfiguration()
	{
		return _webDriverConfiguration;
	}

	public void DisposeWebDriver()
	{
		if (_webDriver is not null)
		{
			_webDriver.Close();
			_webDriver.Quit();
			_webDriver.Dispose();
		}
	}

	public void NavigageTo(string url)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(url);

		_webDriver.Navigate().GoToUrl(url);
	}

	public string GetCurrentUrl()
	{
		return _webDriver.Url;
	}

	public string GetPageTitle()
	{
		return _webDriver.Title;
	}
}
