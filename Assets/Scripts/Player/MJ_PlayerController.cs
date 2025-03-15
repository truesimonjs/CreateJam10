using System.Collections;
using Player;
using UnityEngine;

public class MJ_PlayerController : MonoBehaviour, IDamageable
{
    [Header("player properties")] 
    [SerializeField] private float speed, leashSpeed, leashAbilityTime, timeSinceLeash;
    private Rigidbody2D rb;
    [SerializeField] bool loopRunning;

    private GameObject john;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        john = GameObject.Find("John");
    }

    public void DamageDeduction(float damage)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        Vector2 inputDir = new Vector3(horizontal, vertical);
        inputDir.Normalize();
        rb.linearVelocity = inputDir * speed;

        if (Input.GetKeyDown(KeyCode.Alpha1) && !loopRunning)
        {
            loopRunning = true;
            timeSinceLeash = 0;
        }

        if (loopRunning)
        {
            if (timeSinceLeash < leashAbilityTime)
            {
                speed = leashSpeed;
                timeSinceLeash += Time.deltaTime;
                Debug.Log(timeSinceLeash);
            }
            else
            {
                loopRunning = false;
                speed = 5;
            }
        }
    }
}
