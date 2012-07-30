namespace Carbon.Models
{
	public enum AgentType
	{
		Unknown = 0,

		/// <summary>
		///  An organization has agency: it exhibits intentionality, and has rights, responsibilities, and obligations.
		///  e.g. company, institution (university, school), not for profit, assoication (e.g. club), a group (standard body) etc.
		/// </summary>
		Organization = 1,

		Person = 2
	}
}