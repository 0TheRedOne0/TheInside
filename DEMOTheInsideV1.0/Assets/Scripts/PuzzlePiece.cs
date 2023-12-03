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
            if (Vector2.Distance(ThisPiece.transform.position, PS.transform.position) < 0.1)
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
            // Use ScreenToWorldPoint on the mouse position to convert it to world space
            Vector3 newPosition = cam2.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam2.nearClipPlane));
            // Set the object's position
            transform.position = new Vector3(newPosition.x, newPosition.y , newPosition.z + 0.4f);

            // Log the new position for debugging
            Debug.Log("New Position: " + transform.position);

        }
    }
    /*Vector3 GetMPos()
    {
        return cam2.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0 , Input.mousePosition.z));
        // return new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);

    }*/
}
