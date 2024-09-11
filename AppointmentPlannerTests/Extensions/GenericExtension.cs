using System.Text;

namespace AppointmentPlannerTests.Extensions;

public static class GenericExtension
{
	public static string ToString<T>(this T obj)
	{
		var stringBuilder = new StringBuilder();

		var properties = typeof(T).GetProperties();

		foreach (var property in properties)
		{
			stringBuilder.AppendLine($"\t\t{property.Name}: {property.GetValue(obj)}");
		}

		return stringBuilder.ToString().TrimEnd();
	}
}