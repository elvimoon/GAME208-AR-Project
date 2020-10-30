using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public bool Kinged = false;
    public int Direction; //+1 for White, -1 for Black
    public BoardManager Board; //attach the BoardManager Object
    public int BoardX, BoardY;
    // Start is called before  the first frame update
    void Start()
    {
        Board.Pieces[BoardX, BoardY] = gameObject;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    void OnMouseDown()
    {
        Board.OnPieceSelected(gameObject);
    }

    public void OnCaptured()
    {
        Destroy(gameObject);
    }
}
