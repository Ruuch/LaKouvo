using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnPunch : MonoBehaviour
{
    private Animator animator;
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();

        // Initially disable ragdoll physics
        ToggleRagdoll(false);
    }

    void ToggleRagdoll(bool isRagdoll)
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = !isRagdoll;
        }
        foreach (var col in colliders)
        {
            col.enabled = isRagdoll;
        }
        animator.enabled = !isRagdoll;
    }

    // Call this method when a punch is detected
    public void GetPunched()
    {
        ToggleRagdoll(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Assume the punching object has a tag "Fist"
        if (collision.collider.tag == "Player")
        {
            GetPunched();
        }
    }
}
