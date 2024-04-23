using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class valoHeiluri : MonoBehaviour
{

    private float timer = 0.0f;
    private float rotateTime = 2.0f;
    [SerializeField] GameObject spotLight;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > rotateTime)
        {
            GetComponent<SpotLight>();
            spotLight.transform.transform.rotation = Quaternion.Euler(1, 0, 0);
        }
        

    }
}
