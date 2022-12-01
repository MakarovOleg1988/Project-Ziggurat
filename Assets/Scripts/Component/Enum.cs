
namespace Ziggurat
{
	public enum AnimationType : byte
	{
		Move = 0,
		FastAttack = 1,
		StrongAttack = 2,
		Die = 3
	}

	[System.Flags]
	public enum IgnoreAxisType : byte
	{
		None = 0,
		X = 1,
		Y = 2,
		Z = 4
	}

	public enum RespawnGate : byte
	{ 
	Red = 0,
	Green = 1,
	Blue = 2
	}

	public enum KnigthType : byte
	{
		Red = 0,
		Green = 1,
		Blue = 2
	}
}
