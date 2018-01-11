using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject markerPrefab;
    
    private Vector3[,] board;

    private void Start()
    {
        print("Marker:Start()");
        if (board == null)
        {
            board = Board.board;
        }
        print("X = " + board[1,2].x);

        GameObject m = Instantiate(markerPrefab);
        m.transform.position = new Vector3(board[3, 3].x, board[3, 3].y, -2);
        
    }
}
