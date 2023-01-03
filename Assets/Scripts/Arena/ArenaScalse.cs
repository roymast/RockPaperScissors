using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScalse : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public GameObject Up;
    public GameObject Down;

    // Start is called before the first frame update
    void Start()
    {                
        SetRingPos();
        SetRingSize();
    }

    private void SetRingPos()
    {
        ArenaSize arenaSize = ArenaSize.Instance;        
        Vector3 leftPos = new Vector3(arenaSize.Left, 0, 0);
        Vector3 rightPos = new Vector3(arenaSize.Right, 0, 0);
        Vector3 upPos = new Vector3(0, arenaSize.Up, 0);
        Vector3 downPos = new Vector3(0, arenaSize.Down, 0);

        Left.transform.position = leftPos;
        Right.transform.position = rightPos;
        Up.transform.position = upPos;
        Down.transform.position = downPos;
    }

    private void SetRingSize()
    {
        float worldWidth = ArenaSize.Instance.Width;
        float worldHeight = ArenaSize.Instance.Height;
        Vector3 leftSize = new Vector3(worldHeight / 2, 2, 2);
        Vector3 rightSize = new Vector3(worldHeight / 2, 2, 2);
        Vector3 upSize = new Vector3(worldWidth / 2, 2, 2);
        Vector3 downSize = new Vector3(worldWidth / 2, 2, 2);

        Left.transform.localScale = leftSize;
        Right.transform.localScale = rightSize;
        Up.transform.localScale = upSize;
        Down.transform.localScale = downSize;        
    }
    
    IEnumerator SizeChecker()
    {
        ArenaSize arenaSize = ArenaSize.Instance;
        while (true)
        {
            Debug.Log("("+ arenaSize.Width + ", " + arenaSize.Height+ ")");
            Debug.Log("mouse(" + Camera.main.ScreenToWorldPoint(Input.mousePosition)+")");
            yield return new WaitForSeconds(1);
        }
    }
    
}
