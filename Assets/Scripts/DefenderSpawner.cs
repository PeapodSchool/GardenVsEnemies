using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defender defender;

    public void SetSelectedDefender(Defender selectedDefender) 
    {
        defender = selectedDefender;
    }


    public void OnMouseDown()
    {
        Vector2 worldPos = GetSquareClicked();

    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(
            Input.mousePosition.x,
            Input.mousePosition.y);
        Debug.Log("X = " + clickPos.x.ToString()
            + " Y = " + clickPos.y.ToString());
        Vector2 worldPos = Camera.main.
            ScreenToWorldPoint(clickPos);
        Debug.Log("X = " + worldPos.x.ToString()
            + " Y = " + worldPos.y.ToString());
        //Vector2 roundedPos = SnapToGrid(worldPos);
        return new Vector2();
    }
}
