using ConfigurationLibrary.Configurations;
using ConfigurationLibrary.Interfaces.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FrameworkLibrary.FrameworkStartup;

public class FrameworkService
{
	private readonly IServiceProvider _serviceProvider;

	public FrameworkService(string filePath)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

		_serviceProvider = new ServiceCollection()
			.AddSingleton<IConfigurationService>(new ConfigurationService(filePath))
			.BuildServiceProvider();
	}

	public IServiceProvider GetServiceProvider()
	{
		return _serviceProvider;
	}
}
