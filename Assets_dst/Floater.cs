using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngular = 0.5f;
    private void FixedUpdate()
    {
        rigidbody.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);


        if (transform.position.y < 0f)
        {
            float displacementMuliplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMuliplier, 0f), transform.position, ForceMode.Acceleration);
            rigidbody.AddForce(displacementMuliplier * -rigidbody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidbody.AddTorque(displacementMuliplier * -rigidbody.angularVelocity * waterAngular * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }


    }
}
