using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScripts : MonoBehaviour
{
    public WheelCollider sağÖnTekerlek, solÖnTekerlek, sağArkaTekerlek, solArkaTekerlerk;

    public float motorSpeed, turnSpeed;
    void Update()
    {
        sağArkaTekerlek.motorTorque = motorSpeed * Input.GetAxisRaw("Vertical");
        solArkaTekerlerk.motorTorque = motorSpeed * Input.GetAxisRaw("Vertical");
        sağÖnTekerlek.steerAngle = turnSpeed * Input.GetAxisRaw("Horizontal");
        solÖnTekerlek.steerAngle = turnSpeed * Input.GetAxisRaw("Horizontal");
    }
}
