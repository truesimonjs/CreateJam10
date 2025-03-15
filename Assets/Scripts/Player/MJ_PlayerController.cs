using System.Collections;
using Player;
using UnityEngine;

public static class betweenSceneLoadSaver
{
    
} 

public class MJ_PlayerController : MonoBehaviour, IDamageable
{
    [Header("player properties")]
    [SerializeField] private float speed,baseHP, leashSpeed,healthPotionCooldown, leashAbilityTime, timeSinceLeash, hp, leashCooldown, leashDistance, rubberbandCooldown, canCauseCrashCooldown;
    private Rigidbody2D rb;
    [SerializeField] private bool leashing, canLeash, canRubberband, canHealthPotion, canCauseCrash, johnPosFreeze;
    private GameObject john;
    private Transform lockJohnPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseHP = hp;
        canLeash = true;
        rb = GetComponent<Rigidbody2D>();
        john = GameObject.Find("John");

        canLeash = true;
        rb = GetComponent<Rigidbody2D>();
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
            if (Vector2.Distance(transform.position, john.transform.position) < leashDistance)
            {
                hp = baseHP;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && canRubberband)
        {
            canRubberband = false;
            StartCoroutine(Rubberbanding());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && canCauseCrash)
        {
            canCauseCrash = false;
            StartCoroutine(CrashJohn());
        }

        if (johnPosFreeze)
        {
            PositionLocker(john, lockJohnPos);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && canHealthPotion)
        {
            canHealthPotion = false;
            StartCoroutine(DrinkHealthPotion());
        }
    }

    IEnumerator DrinkHealthPotion()
    {
        hp += baseHP * 0.7f;
        yield return new WaitForSeconds(healthPotionCooldown);
    }

    void PositionLocker(GameObject targetObject, Transform targetPosition)
    {
        targetObject.transform.position = targetPosition.position;
    }
    
    //Make John Crash
    private IEnumerator CrashJohn()
    {
        lockJohnPos.position = john.transform.position;
        yield return new WaitForSeconds(Random.Range(Random.Range(Random.Range(1,30),Random.Range(1,40)),Random.Range(Random.Range(1,20),Random.Range(1,40*2))));
        johnPosFreeze = true;
        yield return new WaitForSeconds(canCauseCrashCooldown);
        canCauseCrash = true;
        johnPosFreeze = false;
    }
    
    //Rubberbanding
    private IEnumerator Rubberbanding()
    {
        Transform prePos = new GameObject().transform;
        Transform tmp = new GameObject().transform;
        
        prePos.position = john.transform.position;
        
        yield return new WaitForSeconds(Random.Range(1 , 3));
        
        tmp.position = john.transform.position;
        john.transform.position = prePos.position;
        prePos.position = tmp.position;
        
        yield return new WaitForSeconds(Random.Range(1 , 3));
        
        tmp.position = john.transform.position;
        john.transform.position = prePos.position;
        prePos.position = tmp.position;
        
        yield return new WaitForSeconds(Random.Range(1 , 3));
        
        tmp.position = john.transform.position;
        john.transform.position = prePos.position;
        
        
        yield return new WaitForSeconds(rubberbandCooldown);
        canRubberband = true;
        Debug.Log("Rubberbanding cooldown has completed!");
    }
    
    //Leash
    private IEnumerator Leash()
    {
        canLeash = false;
        leashing = true;
        speed = leashSpeed;
        yield return new WaitForSeconds(leashAbilityTime);
        RageBar.instance.AddToRageSlider(40);
        leashing = false;
        speed = 5;
        yield return new WaitForSeconds(leashCooldown);
        canLeash = true;
    }
}

