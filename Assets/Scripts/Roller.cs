using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    private Transform model;
    private Vector3 maxPos, minPos;
    private bool bIsIn; 
      
    // Start is called before the first frame update
    public Roller(Transform t, float max, float min)
    {
        model = t;
        maxPos = new Vector3(model.localPosition.x, max, model.localPosition.z);
        minPos = new Vector3(model.localPosition.x, min, model.localPosition.z);
        
        bIsIn = true;
    }

    // Update is called once per frame
    public void Paint()
    {
        if (bIsIn)
            Out();
        else
            In();
    }
    void In()
    {
        model.Translate(Vector3.up * Time.deltaTime * 3.7f);
        Vector3 localPos = model.localPosition;

        if (localPos.y > maxPos.y)
        {
            bIsIn = true;
        }
    }
    void Out()
    {
        model.Translate(Vector3.down * Time.deltaTime * 3.7f);

        Vector3 localPos = model.localPosition;

        if (localPos.y < minPos.y)
        {
            bIsIn = false;
        }
    }
}
