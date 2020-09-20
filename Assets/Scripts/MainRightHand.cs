﻿using UnityEngine;
using GITEICaptoglove;

public class MainRightHand : MonoBehaviour
{
    //Assign transforms in Unity editor
    public Transform tHand;    
    public Transform tThumb;
    public Transform tIndex;
    public Transform tMiddle;
    public Transform tRing;    
    public Transform tPinky;    

    public myButton button;    
    public myLever lever;
    public myLight mylight;
    public myCapsule capsule;

    private MyHand RightHand = null;     
    private GUIStyle style;      

    // Start is called before the first frame update
    void Start()
    {
        //Configuration for Captoglove sensor as Right Hand 
        RightHand = new MyHand(2443, MyHand.eHandType.TYPE_RIGHT_HAND);
        RightHand.EnableLog();
        RightHand.SetHandTransform(tHand, Module.eModuleAxis.AXIS_X, Module.eModuleAxis.AXIS_Z, Module.eModuleAxis.AXIS_Y);
        RightHand.SetFingerTransform(tThumb, tIndex, tMiddle, tRing, tPinky);    

        //Messages in display
        style = new GUIStyle();
        style.normal.textColor = Color.black;        
        
        //Starts Captoglove sensor 
        RightHand.Start();        
    }

    // Update is called once per frame
    void Update()
    {      
        //Enables finger movement
        RightHand.MoveFingers();        

        //Interaction with capsule 
        if (RightHand.IsHandClosed() && capsule.bCollided)
        {                      
            CatchCapsule();
        }
        //Interaction with myLever
        else if (RightHand.IsHandClosed() && lever.bCollided)
        {
            CatchLever();
        }
        //Ineraction with mylight
        else if (RightHand.FingerGesture1() && mylight.bCollided) 
		{
            mylight.cColor = Color.blue;            
		}        
        else if (RightHand.FingerGesture2() && mylight.bCollided)
		{
            mylight.cColor = Color.yellow;            
        }        
        else if (RightHand.FingerGesture3() && mylight.bCollided)
		{
            mylight.cColor = Color.green;            
        }
        //Ineraction with button
        else if (RightHand.IsSensorPressed() && button.bCollided)                
        {
            button.PressButton();
        }
		else if (!RightHand.IsSensorPressed())
		{
            button.ReleaseButton();
        }

    }

    private void CatchCapsule()
    {
        Vector3 vMiddlePos = RightHand.GetMiddlePosition();
        capsule.ChangePosition(new Vector3(vMiddlePos.x, vMiddlePos.y, vMiddlePos.z + 1));
        capsule.ChangeRotation(RightHand.GetHandRotation());        
    }

    private void CatchLever()
    {
        Vector3 vHandPos = RightHand.GetHandPosition();
        Debug.Log("Hand z = " + vHandPos.z.ToString());

       if (vHandPos.z > -15f && 
           vHandPos.z < -12f )
        {
            lever.ChangePosition( vHandPos.z);
        }
    }

    void OnGUI()
    {        
        if (RightHand.GetPropertiesRead())
        {
            GUI.Label(new Rect(Screen.width-100, 0, 200f, 200f), "Right Hand ready", style);
        }
    }

    private void OnDestroy()
    {
        if(RightHand!= null)
            RightHand.Stop();
    }

}
