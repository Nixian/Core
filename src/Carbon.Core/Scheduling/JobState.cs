namespace Carbon.Scheduling
{
	public enum JobState
	{
		Waiting = 1, // Queued OR Pending

		Running = 2,

		Completed = 3  // Does not imply that the job completed succesfully
	}
}