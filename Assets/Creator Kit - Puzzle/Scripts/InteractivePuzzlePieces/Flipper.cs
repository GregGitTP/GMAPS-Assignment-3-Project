using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : InteractivePuzzlePiece<HingeJoint>
{
    [Range(500f, 2000f)]
    public float power = 700f;

    void Awake ()
    {
        JointMotor flipperMotor = physicsComponent.motor;
        flipperMotor.targetVelocity = power;
        physicsComponent.motor = flipperMotor;

        //HingeJoint hinge = GetComponent<HingeJoint>();

        //if (hinge)
        //{

        //    // Make the spring reach shoot for a 70 degree angle.
        //    // This could be used to fire off a catapult.

        //    JointSpring hingeSpring = hinge.spring;
        //    hingeSpring.spring = 10;
        //    hingeSpring.damper = 3;
        //    hingeSpring.targetPosition = 70;
        //    hinge.spring = hingeSpring;
        //    hinge.useSpring = true;
        //}
    }
    
    protected override void ApplyActiveState ()
    {
        physicsComponent.useMotor = true;

        
    }

    protected override void ApplyInactiveState ()
    {
        physicsComponent.useMotor = false;
    }
}
