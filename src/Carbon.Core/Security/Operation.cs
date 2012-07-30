namespace Carbon.Security
{
	using System;

	[Flags]
    public enum Operation 
	{
		Read = 1,
        Create = 2,
		Modify = 4,
		Delete = 8
    }
}