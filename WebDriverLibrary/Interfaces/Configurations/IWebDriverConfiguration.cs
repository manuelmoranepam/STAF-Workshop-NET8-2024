using OpenQA.Selenium;
using System;
using WebDriverLibrary.Enums;

namespace WebDriverLibrary.Interfaces.Configurations;

public interface IWebDriverConfiguration
{
	TimeSpan AsyncJavaScriptTimeout { get; set; }
	BrowserType BrowserType { get; set; }
	TimeSpan ImplicitTimeout { get; set; }
	bool IsHeadless { get; set; }
	bool IsMaximized { get; set; }
	TimeSpan LongTimeout { get; set; }
	TimeSpan MediumTimeout { get; set; }
	TimeSpan PageLoadTimeout { get; set; }
	PageLoadStrategy PageLoadStrategy { get; set; }
	TimeSpan PollingTimeout { get; set; }
	TimeSpan ShortTimeout { get; set; }
}
