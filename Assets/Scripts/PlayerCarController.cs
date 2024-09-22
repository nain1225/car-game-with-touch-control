using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [Header("Wheel Transform")]
    public Transform FL;
    public Transform FR;
    public Transform BL;
    public Transform BR;

    [Header("Wheel Collider")]
    public WheelCollider FL_COLLIDER;
    public WheelCollider FR_COLLIDER;
    public WheelCollider BL_COLLIDER;
    public WheelCollider BR_COLLIDER;

    [Header("Car Engine")]
    public float acceleration = 300f;
    private float presentAcceleration = 0f;
    public float BreakPower = 3000f;
    private float presentbreak = 0f;

    [Header("Car Steering")]
    public float wheelTorque = 30f;
    private float TurnAngle = 0f;

    [Header("Sound Effects")]
    public AudioSource audioSource;
    public AudioClip fastAcceleration;
    public AudioClip slowAcceleration;
    public AudioClip stop;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void Update()
    {
        move();
        CarSteering();
        //ApplyBreaks();
    }
    private void move()
    {
        FL_COLLIDER.motorTorque = presentAcceleration;
        FR_COLLIDER.motorTorque = presentAcceleration;
        BL_COLLIDER.motorTorque = presentAcceleration;
        BR_COLLIDER.motorTorque = presentAcceleration;
        presentAcceleration = acceleration * SimpleInput.GetAxis("Vertical");

        if (presentAcceleration > 0)
        {
            audioSource.PlayOneShot(fastAcceleration, 0.2f);
        }
        else if (presentAcceleration < 0)
        {
            audioSource.PlayOneShot(slowAcceleration, 0.2f);
        }
        else if (presentAcceleration == 0)
        {
            audioSource.PlayOneShot(stop, 0.1f);
        }

    }

    private void CarSteering()
    {
        FL_COLLIDER.steerAngle = TurnAngle;
        FR_COLLIDER.steerAngle = TurnAngle;

        TurnAngle = wheelTorque * SimpleInput.GetAxis("Horizontal");
        SteeringWheel(FL_COLLIDER, FL);
        SteeringWheel(FR_COLLIDER, FR);
        SteeringWheel(BL_COLLIDER, BL);
        SteeringWheel(BR_COLLIDER, BR);
    }
    
    //animation
    private void SteeringWheel(WheelCollider WC,Transform Wt)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);
        Wt.position = position;
        Wt.rotation = rotation;
    }

    public void ApplyBreaks()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            presentbreak = BreakPower;
        }
        else
        {
            presentbreak = 0f;
        }
            FR_COLLIDER.brakeTorque = presentbreak;
            FL_COLLIDER.brakeTorque = presentbreak;
            BR_COLLIDER.brakeTorque = presentbreak;
            BL_COLLIDER.brakeTorque = presentbreak;*/

        StartCoroutine(Breaking());
    }
    IEnumerator Breaking()
    {
        presentbreak = BreakPower;
        FR_COLLIDER.brakeTorque = presentbreak;
        FL_COLLIDER.brakeTorque = presentbreak;
        BR_COLLIDER.brakeTorque = presentbreak;
        BL_COLLIDER.brakeTorque = presentbreak;

        yield return new WaitForSeconds(2f);

        presentbreak = 0f;
        FR_COLLIDER.brakeTorque = presentbreak;
        FL_COLLIDER.brakeTorque = presentbreak;
        BR_COLLIDER.brakeTorque = presentbreak;
        BL_COLLIDER.brakeTorque = presentbreak;
    }
    /*public void OnPause()
    {
        Time.timeScale = 0F;
        PauseCanvas.SetActive(true);
        UICanvas.SetActive(false);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void onResume()
    {
        Time.timeScale = 1f;
    }*/
}
