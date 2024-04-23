using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class RahinaRiku : MonoBehaviour
{

    [SerializeField] AudioSource rahinaBreakingSound;
    private enum RahinaState
    {
        Walking,
        Ragdoll
    }

    [SerializeField] private Camera _camera;

    private Rigidbody[] ragdollRigidbodies;
    private RahinaState currentState = RahinaState.Walking;
    private Animator animator;
    private CharacterController characterController;
    [SerializeField] public float THRUSTFORCE = 10f;

    void Awake()
    {
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        rahinaBreakingSound = GetComponent<AudioSource>();

        DisableRagdoll();


    }


    void Update()
    {

        switch (currentState)
        {
            case RahinaState.Walking:
                WalkingBehaviour();
                break;


            case RahinaState.Ragdoll:
                RagdollBehaviour();
                break;
        }

        GetComponent<Rigidbody>();

        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * THRUSTFORCE);
        }


    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }

        animator.enabled = true;
        characterController.enabled = true;
    }

    public void EnableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }

        animator.enabled = false;
        characterController.enabled = false;

        GameObject.Destroy(gameObject, 4);

    }

    private void WalkingBehaviour()
    {
        //Vector3 direction = _camera.transform.position - transform.position;
        Vector3 direction = new Vector3();
        direction = transform.forward;
        direction.y = 0;
        direction.Normalize();

        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 20 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.H))
        {
            EnableRagdoll();
            currentState = RahinaState.Ragdoll;
        }
    }

    [SerializeField] Vector3 attackPoint;
    private void RagdollBehaviour()
    {

        //GetComponent<Rigidbody>().AddForce(transform.forward * THRUSTFORCE);
        GetComponent<Rigidbody>().AddExplosionForce(20, attackPoint, 20f, 40f, ForceMode.Impulse);
        //GetComponentInChildren<Rigidbody>().AddExplosionForce(20, attackPoint, 20f, 40f, ForceMode.Impulse);

        rahinaBreakingSound.volume = Random.Range(0.8f, 1.5f);
        rahinaBreakingSound.pitch = Random.Range(0.7f, 1.2f);
        rahinaBreakingSound.Play();
        //Destroy( rahinaBreakingSound );

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fist")
        {
            Debug.Log("�hh");
            EnableRagdoll();
        }
    }



}
