using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private Vector2 offset;
    [SerializeField] private GameObject PS;
    [SerializeField] private GameObject ThisPiece;
    [SerializeField] private bool placed;
    [SerializeField] private Camera cam2;
    public GameManager GM;
   

    void OnMouseUp()
    {
        Debug.Log("Soltada");
        if (ThisPiece.gameObject.tag == PS.gameObject.tag)
        {
            if (Vector2.Distance(ThisPiece.transform.position, PS.transform.position) < 10)
            {
                transform.position = PS.transform.position;
                placed = true;
                GM.Puzzle += 1;
            }
        }
    }
    private void OnMouseDrag()
    {
        if (placed) return;
        else
        {
            //Debug.Log("Agarrada"); 
            // offset = GetMPos() - (Vector2)transform.position;
            transform.position = GetMPos();
            Debug.Log(GetMPos());
        }
    }
    Vector3 GetMPos()
    {
        return cam2.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        // return new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);

    }
}
