using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    public BoardManager Board; //attach the BoardManager Object
    public int BoardX, BoardY;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    void OnMouseDown()
    {
        Board.OnSpaceSelected(BoardX, BoardY);
    }
}
