using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelsManager : MonoBehaviour
{

    private WheelCollider[] wheelColliders;

    [Range(.8f,1.3f)]public float tireGrip = 1;

    [Range(1,2)]public float forwardValue = 1;
    [Range(1,2)]public float sidewaysValue = 2;
    
    private WheelFrictionCurve  forwardFriction,sidewaysFriction;

    private float[] forwardSlip;
    private float[] sidewaysSlip;
    private float[] overallSlip;

    void Start(){
        findValues();
        setUpWheels();
    }

    void setUpWheels(){
        forwardSlip = new float[4];
        sidewaysSlip = new float[4];
        overallSlip = new float[4];
        for (int i = 0; i < wheelColliders.Length; i++){

            forwardFriction = wheelColliders[i].forwardFriction;

            forwardFriction.asymptoteValue = 1;
            forwardFriction.extremumSlip = 0.065f;
            forwardFriction.asymptoteSlip = 0.8f;
            //curve.stiffness = (inputM.vertical < 0)? ForwardFriction * 2 :ForwardFriction ;
            wheelColliders[i].forwardFriction = forwardFriction;
            
            sidewaysFriction = wheelColliders[i].sidewaysFriction;

            sidewaysFriction.asymptoteValue = 1;
            sidewaysFriction.extremumSlip = 0.065f;
            sidewaysFriction.asymptoteSlip = 0.8f;
            //curve.stiffness = (inputM.vertical < 0)? SidewaysFriction * 2 :SidewaysFriction ;
            wheelColliders[i].sidewaysFriction = sidewaysFriction;

        }
    }

    void Update(){
        manageFriction();
    }

    void findValues(){
        foreach (Transform i in gameObject.transform){
            if(i.transform.name == "carColliders"){
                wheelColliders = new WheelCollider[i.transform.childCount];
                for (int q = 0; q < i.transform.childCount; q++){
                    wheelColliders[q] = i.transform.GetChild(q).GetComponent<WheelCollider>();
                }    
            }
        }
    }

    void manageFriction(){

        WheelHit hit;
        for (int i = 0; i < wheelColliders.Length ; i++){
            if(wheelColliders[i].GetGroundHit(out hit)){
/*
                forwardFriction = wheelColliders[i].forwardFriction;
                forwardFriction.stiffness = 1 - Mathf.Abs( hit.forwardSlip /2 )/ forwardValue;
                wheelColliders[i].forwardFriction = forwardFriction;

                sidewaysFriction = wheelColliders[i].sidewaysFriction;
                sidewaysFriction.stiffness = 1 - Mathf.Abs( hit.sidewaysSlip  )/ sidewaysValue;
                wheelColliders[i].sidewaysFriction = sidewaysFriction;
*/
                overallSlip[i] = Mathf.Abs(hit.forwardSlip + hit.sidewaysSlip);

                forwardFriction = wheelColliders[i].forwardFriction;
                forwardFriction.stiffness = tireGrip - (overallSlip[i] / 2 ) / forwardValue;
                wheelColliders[i].forwardFriction = forwardFriction;

                sidewaysFriction = wheelColliders[i].sidewaysFriction;
                sidewaysFriction.stiffness = tireGrip - overallSlip[i] / sidewaysValue;
                wheelColliders[i].sidewaysFriction = sidewaysFriction;
                



                forwardSlip[i] = hit.forwardSlip;
                sidewaysSlip[i] = hit.sidewaysSlip;
            }
        }

    }
    
    void OnGUI(){
        float pos = 50;
        GUI.Label(new Rect(300, pos, 200, 20),"forward: " + forwardSlip[0].ToString("0.0")  +  forwardSlip[1].ToString("0.0") + forwardSlip[2].ToString("0.0") + forwardSlip[3].ToString("0.0"));
        pos+=25f;
        GUI.Label(new Rect(300, pos, 200, 20),"sideways: " + sidewaysSlip[0].ToString("0.0")  +  sidewaysSlip[1].ToString("0.0") + sidewaysSlip[2].ToString("0.0") + sidewaysSlip[3].ToString("0.0"));
        pos+=25f;
        GUI.Label(new Rect(300, pos, 200, 20),"slip: " + overallSlip[0].ToString("0.0")  +  overallSlip[1].ToString("0.0") + overallSlip[2].ToString("0.0") + overallSlip[3].ToString("0.0"));
        pos+=25f;
    }

}
