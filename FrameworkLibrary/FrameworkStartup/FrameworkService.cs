﻿using ConfigurationLibrary.Configurations;
using ConfigurationLibrary.Interfaces.Configurations;
using LoggerLibrary.Interfaces.Loggers;
using LoggerLibrary.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebDriverLibrary.Configurations;
using WebDriverLibrary.Interfaces.Configurations;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverLibrary.WebDrivers;

namespace FrameworkLibrary.FrameworkStartup;

public class FrameworkService
{
	private readonly IServiceProvider _serviceProvider;

	public FrameworkService(string appSettingsFilePath, string loggerFilePath)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(appSettingsFilePath);
		ArgumentException.ThrowIfNullOrWhiteSpace(loggerFilePath);

		_serviceProvider = new ServiceCollection()
			.AddSingleton<IConfigurationService>(new ConfigurationService(appSettingsFilePath))
			.AddScoped<ILoggerService>(provider =>
			{
				var configurationService = provider.GetRequiredService<IConfigurationService>();

				return new SerilogLoggerService(configurationService, loggerFilePath);
			})
			.AddSingleton<IWebDriverConfiguration, WebDriverConfiguration>()
			.AddScoped<IWebDriverService, SeleniumWebDriverService>()
			.BuildServiceProvider();
	}

	public IServiceProvider GetServiceProvider()
	{
		return _serviceProvider;
	}
}
