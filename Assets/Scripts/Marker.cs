using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
	public int boardWidth = 10;
	public int boardHeight = 10;
	public GameObject boardSquarePrefab;
	public float boardSquareScale = 0.95f;

	public Vector3[,] board;

	// Use this for initialization
	void Start () {
		board = new Vector3[boardWidth, boardHeight];
		BuildBoard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BuildBoard()
	{
		for (int y = 0; y < boardHeight; y++)
		{
			for (int x = 0; x < boardWidth; x++)
			{
				GameObject sq = Instantiate(boardSquarePrefab);
				sq.transform.position = new Vector3(x, y, 0);
				sq.transform.localScale = new Vector3(
					boardSquareScale, boardSquareScale, boardSquareScale);
			}
		}
	}
}
