using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTextile : MonoBehaviour
{
    public Transform rotTable;
    public Transform roller1, roller2, roller3;

    RotTable rotativeMachine;
    // Start is called before the first frame update
    void Start()
    {
        rotativeMachine = new RotTable(rotTable, roller1, roller2, roller3);
    }

    // Update is called once per frame
    void Update()
    {
       rotativeMachine.TurnON();
    }
}
