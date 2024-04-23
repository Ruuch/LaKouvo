using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows = 3;
    public float throwCooldown = 2;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse1;
    public float throwForce;
    public float throwUpwaedForce;


    bool readyToThrow;

    private void Start()
    {


        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Debug.Log("mmm");
            ThrowFunction();
        }

    }
    private void Update()
    {
        GetComponent<ScoreManager>();
        ScoreManager.instance.scoreText.ToString();

    }



    private void ThrowFunction()
    {
        Debug.Log("AA");
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projecyileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwaedForce;

        projecyileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);


    }


    private void ResetThrow()
    {
        readyToThrow = true;
    }

}
