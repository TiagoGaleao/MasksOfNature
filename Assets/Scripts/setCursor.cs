using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCursor : MonoBehaviour
{
    public Texture2D mousePointer;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 cursorHotspot = new Vector2(0, 0);
        Cursor.SetCursor(mousePointer, cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}