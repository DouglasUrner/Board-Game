using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	[Header("Set in Inspector")]
	public int width = 10;
	public int height = 10;
	public float squareScale = 0.95f;
	public GameObject squarePrefab;
	public Material squareMaterial;

	private static Vector3[,] _board;
	
	/*
	 * Create the board.
	 */
	private void Awake() {
		print("Board.Awake()");
		BuildBoard("Board", Camera.main);
	}

	/*
	 * BuildBoard(string name)
	 * 
	 * Construct an array of Vector3s representing the locations in board
	 * and a board layout, boardWidth x boardHeight, of squarePrefabs. The
	 * board layout is contained in a new empty GameObject whose name is given
	 * by the argument name. By default we center the main camera on the board.
	 * If centerCamera is false the camera location is unchanged.
	 */
	public void BuildBoard(string name, Camera camera = null) {
		print("BuildBoard()");
		// Create the board array.
		_board = new Vector3[width, height];
		
		// Create an empty GameObject to hold the board's squares.
		GameObject boardGO = new GameObject();
		boardGO.name = name;
		
		// Initialize the squares and instantiate the squarePrefabs in the
		// boardGO and then set their locations and scale.
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				_board[x, y] = new Vector3(x, y, 0);
				
				// Add a square for this space as a child of the boardGO.
				GameObject sq = Instantiate(squarePrefab);
				sq.transform.parent = boardGO.transform;
				sq.transform.position = _board[x, y];
				sq.transform.localScale = 
					new Vector3(squareScale, squareScale, squareScale);
				if (squareMaterial != null) {
					MeshRenderer mr = sq.GetComponent<MeshRenderer>();
					mr.material = squareMaterial;
				}
				sq.name = squarePrefab.name + " (" + x + ", " + y + ")";
			}
		}
		
		// Center the main camera on the board.
		if (camera != null) {
			camera.transform.position =
				new Vector3(width / 2f, (height - 1) / 2f,
					camera.transform.position.z);
		}
	}
	
	public static Vector3[,] board {
		get { print("Board.board - get()");return _board; }
	}
}
