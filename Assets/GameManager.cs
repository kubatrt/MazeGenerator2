using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Maze2	mazePrefab;

	private Maze2 mazeInstance;

	void Start () 
	{
		BeginGame();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			RestartGame();
		}
	}

	private void BeginGame() 
	{
		mazeInstance = Instantiate (mazePrefab) as Maze2;
		mazeInstance.transform.parent = transform;
		StartCoroutine(mazeInstance.Generate());
		Debug.Log("BeginGame()");
	}

	private void RestartGame() 
	{
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame ();
	}
}
