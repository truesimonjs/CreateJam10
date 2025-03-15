using System.Collections;
using Player;
using UnityEngine;

public class MJ_PlayerController : MonoBehaviour, IDamageable
{
    [Header("player properties")]
    [SerializeField] private float speed,baseHP, leashSpeed, leashAbilityTime, timeSinceLeash, hp, leashDelayTime, leashDistance;
    private Rigidbody2D rb;
    [SerializeField] private bool leashing, canLeash;
    private GameObject john;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseHP = hp;
        canLeash = true;
        rb = GetComponent<Rigidbody2D>();
        john = GameObject.Find("John");
    }

    public void DamageDeduction(float damage)
    {
        hp -= damage;
        Debug.Log("SOMETHING HIT YOU.. RUN!");

        if (hp <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("You Died");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get move input
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        //apply move
        Vector2 inputDir = new Vector3(horizontal, vertical);
        inputDir.Normalize();
        rb.linearVelocity = inputDir * speed;
        
        //Activate Leash
        if (Input.GetKeyDown(KeyCode.Alpha1) && canLeash)
        {
            StartCoroutine(Leash());
            canLeash = false;
        }

        if (leashing)
        {
            if(Vector2.Distance(transform.position,john.transform.position) < leashDistance)
            {
                hp = baseHP;
            }
        }
    }

    private IEnumerator Leash()
    {
        canLeash = false;
        leashing = true;
        speed = leashSpeed;
        yield return new WaitForSeconds(leashAbilityTime);
        RageBar.instance.AddToRageSlider(40);
        leashing = false;
        speed = 5;
        yield return new WaitForSeconds(leashDelayTime);
        canLeash = true;
    }
}

