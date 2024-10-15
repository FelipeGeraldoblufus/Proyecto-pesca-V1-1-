using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoundObject : MonoBehaviour
{
    private void Start()
    {
        CombineRigidbodies();
    }

    void CombineRigidbodies()
    {
        // Get all the Rigidbody components in child objects
        Rigidbody[] childRigidbodies = GetComponentsInChildren<Rigidbody>();

        // If no child has a Rigidbody, there's nothing to combine
        if (childRigidbodies.Length == 0)
        {
            Debug.LogWarning("No Rigidbodies found in children.");
            return;
        }

        // Initialize variables for combined properties
        float totalMass = 0f;
        Vector3 combinedCenterOfMass = Vector3.zero;
        float totalDrag = 0f;
        float totalAngularDrag = 0f;

        // Iterate through child rigidbodies to accumulate their mass and weighted center of mass
        foreach (Rigidbody childRb in childRigidbodies)
        {
            totalMass += childRb.mass;

            // Accumulate center of mass weighted by mass
            combinedCenterOfMass += childRb.worldCenterOfMass * childRb.mass;

            // Sum up the drags (optionally weighted by mass for accuracy)
            totalDrag += childRb.drag;
            totalAngularDrag += childRb.angularDrag;
        }

        // Calculate the average center of mass
        combinedCenterOfMass /= totalMass;

        // Create a new Rigidbody for the parent object if it doesn't exist
        Rigidbody parentRb = gameObject.AddComponent<Rigidbody>();

        // Set the parent Rigidbody's mass and center of mass
        parentRb.mass = totalMass;
        parentRb.centerOfMass = transform.InverseTransformPoint(combinedCenterOfMass);

        // Optionally, set drag and angular drag based on combined values
        parentRb.drag = totalDrag / childRigidbodies.Length;           // Average drag
        parentRb.angularDrag = totalAngularDrag / childRigidbodies.Length;  // Average angular drag

        // Remove the Rigidbody components from the child objects
        foreach (Rigidbody childRb in childRigidbodies)
        {
            Destroy(childRb);
        }

        // Optionally, handle other properties (e.g., inertia tensors) or perform further setup
    }
}

