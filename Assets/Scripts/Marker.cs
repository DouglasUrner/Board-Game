using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
	public int boardWidth = 10;
	public int boardHeight = 10;
	public GameObject boardSquarePrefab;
	public GameObject markerPrefab;
	public float boardSquareScale = 0.95f;

	public Vector3[,] board;
	public GameObject marker;

	// Use this for initialization
	void Start () {
		Camera.main.transform.position = new Vector3(
			boardWidth / 2, boardHeight / 2, -10);
		Camera.main.orthographicSize = boardHeight / 2 + 1;
		board = new Vector3[boardWidth, boardHeight];
		BuildBoard();
		marker = Instantiate(markerPrefab);
	}
	
	// Update is called once per frame
	void Update () {
		for (int x = 0; x < boardWidth; x++) {
			for (int y = 0; y < boardHeight; y++) {
				marker.transform.position = new Vector3(x, y, -1);
			}
		}
	}

	/*
	 * Create a board for this 
	 */
	void BuildBoard()
	{
		GameObject boardGO = GameObject.Find("Board");
		for (int y = 0; y < boardHeight; y++)
		{
			for (int x = 0; x < boardWidth; x++)
			{
				// Add a square to the board.
				GameObject sq = Instantiate(boardSquarePrefab);
				// Move it into position.
				sq.transform.position = new Vector3(x, y, 0);
				// Scale it down to make the individual squares visible.
				sq.transform.localScale = new Vector3(
					boardSquareScale, boardSquareScale, boardSquareScale);
				sq.transform.parent = boardGO.transform;
			}
		}
	}
}
