using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private Vector2 offset;
    private PieceSlot PS;
    [SerializeField] private bool placed;

    public void Init(PieceSlot slot)
    {
        PS = slot;
    }

    void Update()
    {
        if (placed) return;
        var MPos = GetMPos();
        transform.position = MPos - offset;
    }
    void OnMouseDown()
    {
        offset = GetMPos() - (Vector2)transform.position;
    }

    void OnMouseUp() 
    {
        if(Vector2.Distance(transform.position, PS.transform.position) < 3 )
        {
            transform.position = PS.transform.position;
            placed = true;
        }
    }

    Vector2 GetMPos ()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
