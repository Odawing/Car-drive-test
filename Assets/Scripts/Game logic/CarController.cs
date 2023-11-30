using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 1000; // max speed for car movement
    public float acceleration = 250; // car acceleration when pushed move button
    public float deaceleration = -100; // car deaceleration when unpushed move button

    public bool isPushedMove, isPushedStop;

    private WheelJoint2D[] wheelJoints;
    private JointMotor2D backWheel, forwardWheel; // car wheel motors

    private ParticleSystem dirtParticle;

    private void Start()
    {
        wheelJoints = GetComponents<WheelJoint2D>();
        backWheel = wheelJoints[0].motor;
        forwardWheel = wheelJoints[0].motor;
        dirtParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        var carAngle = transform.localEulerAngles.z;
        if (carAngle >= 180) carAngle -= 360;

        if (isPushedMove)
        {
            // when car slip
            if (backWheel.motorSpeed > 0)
            {
                dirtParticle.Play();
                backWheel.motorSpeed = 0;
            }

            // accelerate car
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed -
                (acceleration + Physics.gravity.y * Mathf.PI * (carAngle / 180) * 80) * Time.deltaTime, -maxSpeed, maxSpeed);
        }
        else
        {
            // deaccelerate car
            if (backWheel.motorSpeed < 0)
            {
                backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed -
                 (deaceleration + Physics.gravity.y * Mathf.PI * (carAngle / 180) * 80) * Time.deltaTime, -maxSpeed, 0);
            }
            else
            {
                backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed -
                 (-deaceleration + Physics.gravity.y * Mathf.PI * (carAngle / 180) * 80) * Time.deltaTime, 0, maxSpeed);
            }
        }
        

        if (isPushedStop)
        {
            backWheel.motorSpeed = 0;
        }

        // make forward wheel motor same as back
        forwardWheel.motorSpeed = backWheel.motorSpeed;

        // Set structs
        wheelJoints[0].motor = backWheel;
        wheelJoints[1].motor = forwardWheel;
    }
}
