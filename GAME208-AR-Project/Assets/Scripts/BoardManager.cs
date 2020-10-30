using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject [,] Pieces;
    public GameObject HeldPiece;
    public int HeldX = -3; 
    public int HeldY = -3;


    public void OnPieceSelected(GameObject Selection)
    {
        HeldPiece = Selection;
        HeldX = HeldPiece.GetComponent<PieceMovement>().BoardX;
        HeldY = HeldPiece.GetComponent<PieceMovement>().BoardY;
    }

    public void OnSpaceSelected(int SpaceX, int SpaceY)
    {
        if (HeldPiece.GetComponent<PieceMovement>().Kinged)
        {
            if ((Mathf.Abs(SpaceX - HeldX) == 1 && Mathf.Abs(SpaceY - HeldY) == 1) && Pieces[SpaceX, SpaceY] == null)
            {
                Pieces[SpaceX, SpaceY] = Pieces[HeldX, HeldY];
                HeldPiece.GetComponent<PieceMovement>().BoardX = SpaceX;
                HeldPiece.GetComponent<PieceMovement>().BoardY = SpaceY;
                Pieces[HeldX, HeldY] = null;
                HeldX = -3;
                HeldY = -3;
            }
            else if ((Mathf.Abs(SpaceX - HeldX) == 2 && Mathf.Abs(SpaceY - HeldY) == 2) && Pieces[SpaceX, SpaceY] == null && Pieces[SpaceX + HeldX / 2, SpaceY + HeldY / 2] != null)
            {
                if (Pieces[SpaceX + HeldX / 2, SpaceY + HeldY / 2].GetComponent<PieceMovement>().Direction != HeldPiece.GetComponent<PieceMovement>().Direction)
                Pieces[SpaceX, SpaceY] = Pieces[HeldX, HeldY];
                HeldPiece.GetComponent<PieceMovement>().BoardX = SpaceX;
                HeldPiece.GetComponent<PieceMovement>().BoardY = SpaceY;
                Pieces[HeldX, HeldY] = null;
                Pieces[SpaceX + HeldX / 2, SpaceY + HeldY / 2].GetComponent<PieceMovement>().OnCaptured();
                Pieces[SpaceX + HeldX / 2, SpaceY + HeldY / 2] = null;
                HeldX = -3;
                HeldY = -3;
            }
        }
        else
        {
            if ((Mathf.Abs(SpaceX - HeldX) == 1 && SpaceY - HeldY == HeldPiece.GetComponent<PieceMovement>().Direction) && Pieces[SpaceX, SpaceY] == null)
            {
                Pieces[SpaceX, SpaceY] = Pieces[HeldX, HeldY];
                HeldPiece.GetComponent<PieceMovement>().BoardX = SpaceX;
                HeldPiece.GetComponent<PieceMovement>().BoardY = SpaceY;
                Pieces[HeldX, HeldY] = null;
                HeldX = -3;
                HeldY = -3;
            }
            else if (Mathf.Abs(SpaceX - HeldX) == 2 && (SpaceY - HeldY) == (HeldPiece.GetComponent<PieceMovement>().Direction * 2) && Pieces[SpaceX, SpaceY] == null && Pieces[SpaceX + HeldX / 2, SpaceY + HeldY / 2] != null)
            {
                if (Pieces[SpaceX + HeldX / 2, SpaceY + HeldY / 2].GetComponent<PieceMovement>().Direction != HeldPiece.GetComponent<PieceMovement>().Direction)
                Pieces[SpaceX, SpaceY] = Pieces[HeldX, HeldY];
                HeldPiece.GetComponent<PieceMovement>().BoardX = SpaceX;
                HeldPiece.GetComponent<PieceMovement>().BoardY = SpaceY;
                Pieces[HeldX, HeldY] = null;
                Pieces[SpaceX + HeldX / 2, SpaceY + HeldY / 2].GetComponent<PieceMovement>().OnCaptured();
                Pieces[SpaceX + HeldX / 2, SpaceY + HeldY / 2] = null;
                HeldX = -3;
                HeldY = -3;
            }

            if ((SpaceY == 7 && HeldPiece.GetComponent<PieceMovement>().Direction > 0) || (SpaceY == 0 && HeldPiece.GetComponent<PieceMovement>().Direction < 0))
            {
                HeldPiece.GetComponent<PieceMovement>().Kinged = true;
            }
        }
    }
}
