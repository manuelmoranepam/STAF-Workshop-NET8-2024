using ConfigurationLibrary.Interfaces.Configurations;
using FrameworkLibrary.FrameworkStartup;
using LoggerLibrary.Interfaces.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using TechTalk.SpecFlow;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace AppointmentPlannerTests.Hooks;

[Binding]
public sealed class Hook
{
	private const string _filePath = "appsettings.json";
	private const string _logFilePath = "Logs";
	private const string _applicationUrl = "ApplicationUrl";

	[BeforeTestRun]
	public static void BeforeTestRun()
	{
		if (Directory.Exists(_logFilePath))
		{
			Directory.Delete(_logFilePath, true);
		}
	}

	[BeforeScenario]
	public void BeforeScenario(ScenarioContext scenarioContext)
	{
		var scenarioId = Guid.NewGuid().ToString();
		var logFullFilePath = $"{_logFilePath}/{scenarioId}.txt";

		var serviceProvider = new FrameworkService(_filePath, logFullFilePath)
			.GetServiceProvider();

		var configurationService = serviceProvider.GetRequiredService<IConfigurationService>();

		var loggerService = serviceProvider.GetRequiredService<ILoggerService>();

		var webDriverService = serviceProvider.GetRequiredService<IWebDriverService>();

		loggerService.LogInformation("Scenario: " + scenarioContext.ScenarioInfo.Title + "\n", scenarioId);

		var url = configurationService.GetConfigurationValue<string>(_applicationUrl);

		webDriverService.NavigageTo(url);

		scenarioContext["ScenarioId"] = scenarioId;
		scenarioContext["ServiceProvider"] = serviceProvider;
		scenarioContext["ConfigurationService"] = configurationService;
		scenarioContext["LoggerService"] = loggerService;
		scenarioContext["WebDriverService"] = webDriverService;
	}

	[BeforeStep]
	public void BeforeStep(ScenarioContext scenarioContext)
	{
		var logger = scenarioContext["LoggerService"] as ILoggerService;

		var definitionType = scenarioContext.StepContext.StepInfo.StepDefinitionType;
		var stepText = scenarioContext.StepContext.StepInfo.Text;

		logger!.LogInformation($"{definitionType} {stepText}", []);
	}

	[AfterStep]
	public void AfterStep(ScenarioContext scenarioContext)
	{
		var logger = scenarioContext["LoggerService"] as ILoggerService;

		var status = scenarioContext.StepContext.Status;
		var definitionType = scenarioContext.StepContext.StepInfo.StepDefinitionType;
		var stepText = scenarioContext.StepContext.StepInfo.Text;
		var message = $"{definitionType} {stepText}\n";

		LogOutcome(scenarioContext.TestError, logger!, status, message);
	}

	[AfterScenario]
	public void AfterScenario(ScenarioContext scenarioContext)
	{
		var logger = scenarioContext["LoggerService"] as ILoggerService;

		var title = scenarioContext.ScenarioInfo.Title;
		var message = $"Scenario: {title}\n";

		LogOutcome(scenarioContext.TestError, logger!, scenarioContext.ScenarioExecutionStatus, message);

		logger!.CloseAndFlush();

		var webDriverService = scenarioContext["WebDriverService"] as IWebDriverService;

		webDriverService!.DisposeWebDriver();

		var serviceProvider = scenarioContext["ServiceProvider"] as ServiceProvider;

		serviceProvider!.Dispose();
	}

	private static void LogOutcome(Exception? exception, ILoggerService logger, ScenarioExecutionStatus status, string message)
	{
		ArgumentNullException.ThrowIfNull(logger);
		ArgumentException.ThrowIfNullOrWhiteSpace(message);

		switch (status)
		{
			case ScenarioExecutionStatus.OK:
				logger.LogInformation($"\t{status} - {message}", []);
				break;
			case ScenarioExecutionStatus.StepDefinitionPending:
				logger.LogDebug($"\t{status} - {message}", []);
				break;
			case ScenarioExecutionStatus.UndefinedStep:
				logger.LogDebug($"\t{status} - {message}", []);
				break;
			case ScenarioExecutionStatus.BindingError:
				logger.LogError(exception!, $"\t{status} - {message}", []);
				break;
			case ScenarioExecutionStatus.TestError:
				logger.LogError(exception!, $"\t{status} - {message}", []);
				break;
			case ScenarioExecutionStatus.Skipped:
				logger.LogInformation($"\t{status} - {message}", []);
				break;
		}
	}
}
