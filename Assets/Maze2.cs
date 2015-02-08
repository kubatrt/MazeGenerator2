using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze2 : MonoBehaviour 
{
	public MazeCell cellPrefab;
	public IntVector2	size;
	public float generationStepDelay;
	public IntVector2 RandomCoord 
	{
		get { return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z)); }
	}
	
	private MazeCell[,]	cells;



	public MazeCell GetCell(IntVector2 coord) {
		return cells[coord.x, coord.z];
	}

	public bool ContainsCoord(IntVector2 coord) 
	{
		return (coord.x >= 0 && coord.x < size.x && coord.z >= 0 && coord.z < size.z);
	}
	
	public IEnumerator Generate()
	{
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
		cells = new MazeCell[size.x, size.z];
		IntVector2 coord = RandomCoord; //new IntVector2(0,0); 
		// TODO
		while(ContainsCoord(coord) && GetCell (coord) == null) 
		{
			yield return delay;
			CreateCell(coord);
			coord += MazeDirections.ToIntVector2( MazeDirections.RandomValue());
			//coord.x += 1;
		}
	}


	private void CreateCell(IntVector2 coord)
	{
		MazeCell newCell = Instantiate (cellPrefab) as MazeCell;
		cells[coord.x, coord.z] = newCell;
		newCell.name = "MazeCell " + coord.x + "," + coord.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coord.x - size.x * 0.5f + 0.5f, 0f, coord.z - size.z * 0.5f + 0.5f);
		Debug.Log (newCell.name);
	}

}
