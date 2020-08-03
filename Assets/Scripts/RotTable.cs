using UnityEditorInternal;
using UnityEngine;

public class RotTable : MonoBehaviour
{
    private Transform model;
    private float tiltAroundZ;
    private bool bRotate, bMoveUpDown, bIsUp, bPaint;
    private float rotate, timer, waitingTime, paintTime;
    private Vector3 maxPos, minPos;

    private Transform roll1, roll2, roll3;
    private Roller roller1, roller2, roller3; 

    // Start is called before the first frame update
    public RotTable(Transform t, Transform r1, Transform r2, Transform r3)
    {
        model = t;
        roll1 = r1;
        roll2 = r2;
        roll3 = r3;

        tiltAroundZ = 0.5f;
        rotate = 0f;
        SetSpeed(0);
        timer = 0f;
        maxPos = new Vector3(model.localPosition.x, 0.7f, model.localPosition.z );
        minPos = model.localPosition;

        bRotate = true;
        bMoveUpDown = false;
        bIsUp = false;

        roller1 = new Roller(roll1, 0.01359491f, -0.0051f);
        roller2 = new Roller(roll2, 0.0084f, -0.009359201f);
        roller3 = new Roller(roll3, 0.0050f, -0.01365004f);

        paintTime = 2;
        bPaint = false;
    }

    public void SetSpeed(int speed)
    {
        switch (speed)
        {
            case 1:
                waitingTime = 8;
                break;
            case 2:
                waitingTime = 4;
                break;
            case 3:
                waitingTime = 2;
                break;
            default:
                waitingTime = 2;
                break;
        }
    }
    // Update is called once per frame
    public void TurnON()
    {
        if (bRotate)
        {
            rotate += tiltAroundZ;
            model.Rotate(0, 0, tiltAroundZ);
            if (rotate == 90)
            {
                rotate = 0f;
                bRotate = false;
                bMoveUpDown = true;
            }
        }
        else
        {
            if (bMoveUpDown)
            {
                if (bIsUp)
                {
                    if (bPaint)
                    {
                        roller1.Paint();
                        //roller2.Paint();
                        roller3.Paint();

                        timer += Time.deltaTime;
                        if (timer > paintTime)
                        {
                            timer = 0f;
                            bPaint = false;
                        }
                    }
                    else 
                        Down();
                }
                else
                    Up();
            }
            else
            {   //waiting time in down position
                timer += Time.deltaTime;
                if (timer > waitingTime)
                {
                    timer = 0f;
                    bRotate = true;
                    bMoveUpDown = false;
                }
            }
        }
    }

    void Down()
    {
        model.Translate(Vector3.back * Time.deltaTime * 2);
        Vector3 localPos = model.localPosition;

        if (localPos.y < minPos.y)
        {
            bIsUp = false;
            bMoveUpDown = false;
        }
    }
    void Up()
    {
        model.Translate(Vector3.forward * Time.deltaTime * 2);
        
        Vector3 localPos = model.localPosition;

        if (localPos.y > maxPos.y)
        {
            bIsUp = true;
            bPaint = true; 
        }
    }
}
