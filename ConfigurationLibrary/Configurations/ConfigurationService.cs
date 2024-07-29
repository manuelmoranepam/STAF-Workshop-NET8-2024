using ConfigurationLibrary.Interfaces.Configurations;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationLibrary.Configurations;

public class ConfigurationService : IConfigurationService
{
	private readonly IConfiguration _configuration;

	public ConfigurationService(string filePath)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

		_configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile(filePath, false, true)
			.Build();
	}

	public IConfiguration GetConfiguration()
	{
		return _configuration;
	}

	public T GetConfigurationSection<T>(string sectionName)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(sectionName);

		var section = _configuration.GetSection(sectionName).Get<T>();

		if (Equals(section, default(T)) || section is null)
		{
			throw new ArgumentException($"Section {sectionName} not found in configuration file.");
		}

		return section;
	}

	public T GetConfigurationValue<T>(string key)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(key);

		var value = _configuration.GetValue<T>(key);

		if (Equals(value, default(T)) || value is null)
		{
			throw new ArgumentException($"Key {key} not found in configuration file.");
		}

		return value;
	}
}
