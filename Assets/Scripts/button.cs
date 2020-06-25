using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public Transform btn;
    public Transform door;

    private Vector3 pressedPos, releasedPos; 
    private Vector3 doorUpPos, doorDownPos;

    // Start is called before the first frame update
    void Start()
    {
        pressedPos  = new Vector3(0, -0.02f, 0);
        releasedPos = new Vector3(0, 0.5f, 0);
        doorDownPos = new Vector3(3.38f, 0, 0.92f);
        doorUpPos   = new Vector3(3.38f, 0, 2.29f);
    }

    // Update is called once per frame
    void Update()
    {
        if(btn.localPosition == pressedPos)
        {
            door.localPosition = doorUpPos;
        }
        else
        {
            door.localPosition = doorDownPos;
        }
    
    }
}
