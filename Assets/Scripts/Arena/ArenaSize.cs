using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSize : MonoBehaviour
{
    public static ArenaSize Instance { get; private set; }
    public Vector2 Size;
    public float Width;
    public float Height;
    public float Left;
    public float Right;
    public float Up;
    public float Down; 
    private void Awake()
    {        
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        Width = GetScreenToWorldWidth;
        Height = GetScreenToWorldHeight;
        Left = -Width / 2;
        Right = Width / 2;
        Up = Height / 2;
        Down = -Height / 2;
        Size = new Vector2(Width, Height);        
    }    
    private static float GetScreenToWorldHeight
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
            var height = edgeVector.y * 2;
            return height;
        }
    }
    private static float GetScreenToWorldWidth
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
            var width = edgeVector.x * 2;
            return width;
        }
    }
}
