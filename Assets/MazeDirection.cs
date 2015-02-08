using UnityEngine;

public enum MazeDirection {
	North = 1,
	East = 2,
	South = 4,
	West = 8
}

public static class MazeDirections
{
	public const int Count = 4;

	public static MazeDirection RandomValue() 
	{
		 return (MazeDirection) UnityEngine.Random.Range(0, Count);
	}

	private static IntVector2[] vectors = {
		new IntVector2(0, 1),
		new IntVector2(1, 0),
		new IntVector2(0, -1),
		new IntVector2(-1, 0)
	};
	
	public static IntVector2 ToIntVector2 (MazeDirection direction) {
		return vectors[(int)direction];
	}
}