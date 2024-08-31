using ConfigurationLibrary.Interfaces.Configurations;
using FrameworkLibrary.FrameworkStartup;
using LoggerLibrary.Interfaces.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace AppointmentPlannerTests.Hooks;

[Binding]
public sealed class Hook
{
	private const string _filePath = "appsettings.json";
	private const string _applicationUrl = "ApplicationUrl";

	private readonly IServiceProvider _serviceProvider;

	public Hook()
	{
		_serviceProvider = new FrameworkService(_filePath)
			.GetServiceProvider();
	}

	[BeforeScenario]
	public void BeforeScenario(ScenarioContext scenarioContext)
	{
		var configurationService = _serviceProvider.GetRequiredService<IConfigurationService>();

		var loggerService = _serviceProvider.GetRequiredService<ILoggerService>();

		var webDriverService = _serviceProvider.GetRequiredService<IWebDriverService>();

		var url = configurationService.GetConfigurationValue<string>(_applicationUrl);

		webDriverService.NavigageTo(url);

		scenarioContext["ConfigurationService"] = configurationService;
		scenarioContext["LoggerService"] = loggerService;
		scenarioContext["WebDriverService"] = webDriverService;
	}

	[AfterScenario]
	public static void AfterScenario(ScenarioContext scenarioContext)
	{
		var webDriverService = scenarioContext["WebDriverService"] as IWebDriverService;

		webDriverService!.DisposeWebDriver();

		var logger = scenarioContext["LoggerService"] as ILoggerService;

		logger!.CloseAndFlush();
	}
}
