using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputs : MonoBehaviour{

   
    [HideInInspector]public float vertical;
    [HideInInspector]public float horizontal;
    [HideInInspector]public bool handbrake;
    [HideInInspector]public bool boosting;
    [SerializeField] private FloatingJoystick joy;
    [SerializeField] private MyButton accel;
    [SerializeField] private MyButton decel;

    [SerializeField] private MyButton brake;

    [SerializeField] private MyButton boost;

    public TimerManager timerManager;

    private bool raceStarted = false;






    void Update()
    {
        keyboard();
    }

    public void keyboard () {
        vertical = accel.buttonInt - decel.buttonInt;

        horizontal = joy.Horizontal;
        handbrake = brake.buttonPressed ; 
        boosting = boost.buttonPressed;

        if(brake.buttonPressed)
        Debug.Log("Handbraked");

        // vertical = Input.GetAxis ("Vertical");
        // horizontal = Input.GetAxis ("Horizontal");
        // if (Input.GetKey (KeyCode.LeftShift)) boosting = true;
        // else boosting = false;

        // handbrake = Input.GetKey(KeyCode.Space);

    }

}
