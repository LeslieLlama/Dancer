using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script resizes the bounding box collider so that it perfectly matches the screens dimentions
//this is for the heads up indicator that activates when an enemy is off screen

public class CameraBox : MonoBehaviour
{
    BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        var vertExtent = Camera.main.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        boxCollider.size = new Vector2(horzExtent *2, vertExtent *2);
    }
}
