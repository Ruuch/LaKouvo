using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float walk_speed, walkb_speed, olw_speed, sprn_speed, rot_speed;
    public bool walking;
    public bool running;
    // tsekkaa ett� onko running true, jos on niin silloin vaikka
    // vaihtaisi W to A esim. niin ei vaihda triggeri� animaatiosta run to walk vaan pysyy run
    //eli tsekkaa ett� aina WASD painaessa onko shifti p��ll� eli pysyt��nk� juoksemisessa
    public Transform playerTrans;


    [Header("AttackPoint Properties")]

    [SerializeField] private Transform _attackPoint;
    [SerializeField] float _attackRange;
    [SerializeField] LayerMask _attackMask;


    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse1;
    public float throwForce;
    public float throwUpwaedForce;

    [Header("Salary")]
    public float highscore;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] ScoreSO scoreManager;

    bool readyToThrow;

    //RahinaRiku rahinaScript;
    //public GameObject rahinaRiku;
    //public RahinaRiku RahinaRiku;


    private void Start()
    {
        //RahinaRiku = rahinaRiku.GetComponent<RahinaRiku>();


        if (Input.GetKeyDown(throwKey)) //&& readyToThrow && totalThrows > 0)
        {
            Debug.Log("mmm");
            ThrowFunction();
        }
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //walkb_speed = 200;
            //walkb_speed = +sprn_speed;
            playerRigid.velocity = transform.forward * walk_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * walkb_speed * Time.deltaTime;
        }

    }

    void Update()
    {
        PlayerControls();

        if (Input.GetKeyDown(throwKey)) //&& readyToThrow && totalThrows > 0)
        {
            Debug.Log("mmm");
            ThrowFunction();
        }

    }

    //===== PLAYER CONTROLS =====
    private void PlayerControls()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("run");
            playerAnim.ResetTrigger("idle");
            walking = true;
            // footstepsounds jos ne halutaan            
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("idle");
            walking = false;
            // footstepsounds jos ne halutaan 
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("run");
            playerAnim.ResetTrigger("idle");
            // footstepsounds jos ne halutaan 
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("idle");
            // footstepsounds jos ne halutaan 
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerTrans.Rotate(0, -rot_speed * Time.deltaTime, 0);
            playerAnim.SetTrigger("run");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            //playerTrans.Rotate(0, -rot_speed * Time.deltaTime, 0);
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("idle");
            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerTrans.Rotate(0, rot_speed * Time.deltaTime, 0);
            playerAnim.SetTrigger("run");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("idle");
            walking = false;
        }

        /*if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walk_speed = +sprn_speed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("run");
                playerAnim.ResetTrigger("idle");
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walk_speed = olw_speed;
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("run");
        }*/
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnim.SetTrigger("punch");

            playerAnim.ResetTrigger("run");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            playerAnim.ResetTrigger("punch");
            playerAnim.SetTrigger("idle");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.SetTrigger("death");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            playerAnim.ResetTrigger("death");
            playerAnim.SetTrigger("idle");
        }
    }

    //==== ATTACKPOINT YRITYS =====
    /* private void Attack()
     {
         Collider[] objs = Physics.OverlapSphere(_attackPoint.position, _attackRange, _attackMask);
         foreach (var obj in objs) 
         {
             if (obj.TryGetComponent(out IDamageable hit))
             {
                 hit.Damage();
                 //EnableRagdoll();
             }
         }
     }*/

    /*public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            T_anim.SetTrigger(_deathAnimHash);
            //Destroy(gameObject);
        }
        else
            _anim.SetTrigger(_hitAnimHash);
    }*/

    //===== KARVARAUTA THROW =====
    private void ThrowFunction()
    {
        Debug.Log("AA");
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projecyileRb = projectile.GetComponent<Rigidbody>();
        Debug.Log("BB");

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwaedForce;

        projecyileRb.AddForce(forceToAdd, ForceMode.Impulse);
        Debug.Log(cam.transform.rotation.ToString());

        //jotenki pit�s muuttaa ett� spawnattu item l�htee oikeeseen suuntaan

        ScoreManager.instance.AddSalary();
        PlayerPrefs.SetFloat("score", highscore);
        Debug.Log("Rautabonarit");

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
        Debug.Log("CC");
    }


    private void ResetThrow()
    {
        readyToThrow = true;
    }

    // === EI TOIMI COLLISIONIT ===
    /* private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("onControllerColliderHIt alku");
        if (CompareTag("Enemy").Equals(true))
        {
            GetComponent<ControllerColliderHit>();
            Collider.Destroy(hit.collider);
            transform.position = Vector3.forward * 10f;
        }
    }

    */

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") == true)
        {

        }
    }

    /* IEnumerator Punch()
    {
        GameObject.Find("FistCollider").SetActive(true);
        yield return new WaitForSeconds(1);
        GameObject.Find("FistCollider").SetActive(false);

    }*/
}
