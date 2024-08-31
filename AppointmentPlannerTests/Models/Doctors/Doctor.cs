using TechTalk.SpecFlow.Assist.Attributes;

namespace AppointmentPlannerTests.Models.Doctors;

public class Doctor
{
	[TableAliases(nameof(FirstName))]
	public string FirstName { get; set; } = string.Empty;

	[TableAliases(nameof(LastName))]
	public string LastName { get; set; } = string.Empty;

	[TableAliases(nameof(IsMale))]
	public bool IsMale { get; set; }

	[TableAliases(nameof(MobileNumber))]
	public string MobileNumber { get; set; } = string.Empty;

	[TableAliases(nameof(Email))]
	public string Email { get; set; } = string.Empty;

	[TableAliases(nameof(Department))]
	public string Department { get; set; } = string.Empty;

	[TableAliases(nameof(Education))]
	public string Education { get; set; } = string.Empty;

	[TableAliases(nameof(Experience))]
	public string Experience { get; set; } = string.Empty;

	[TableAliases(nameof(Designation))]
	public string Designation { get; set; } = string.Empty;

	[TableAliases(nameof(DutyTiming))]
	public string DutyTiming { get; set; } = string.Empty;
}
