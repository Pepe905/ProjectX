using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] EnemyHealth enemyHealth;

    Animator enemyAC;

    private SpriteRenderer enemy;
    public bool flipSprite;

    public float enemyAccel;
    public float maxSpeed = 20f;

    public float chargeTime;
    float startChargeTime;
    public bool charging = false;
    Rigidbody2D enemyRB;

    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;
    Transform enemyTransform;

    // Use this for initialization

    private void Awake()
    {
        if (!enemyHealth)
        {
            Debug.LogError("enemyHealth reference not set");
            Destroy(this);
            return;
        }
    }

    void Start()
    {
        enemyTransform = GetComponent<Transform>();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAC = GetComponentInChildren<Animator>();

        enemy = GetComponentInChildren<SpriteRenderer>();

    }
    private void OnValidate()
    {
        enemy = GetComponentInChildren<SpriteRenderer>();
        if (flipSprite)
        {
            enemy.flipX = true;
        }
        else
        {
            enemy.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.hasDied)
            return;

        //Debug.LogWarning("A");

        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5)
                flipFacing();
            nextFlipChance = Time.time + flipTime;
        }

        if (charging && Time.time > startChargeTime && enemyRB.velocity.x < maxSpeed)
        {
#if OBSOLETE
            if (!facingRight)
                enemyRB.velocity += new Vector2(-1f, 0f) * enemyAccel * Time.deltaTime;
            //enemyRB.AddForce(new Vector2(-1f, 0f) * enemyAccel * Time.deltaTime);
            else
                enemyRB.velocity += new Vector2(1f, 0f) * enemyAccel * Time.deltaTime;
            //enemyRB.AddForce(new Vector2(1f, 0f) * enemyAccel * Time.deltaTime);
#endif
            //Schönerer und besser maintainbare Variante: 
            enemyRB.velocity += new Vector2(facingRight ? 1f : -1f, 0f) * enemyAccel * Time.deltaTime;

            enemyAC.SetBool("isCharging", charging);
        }

        //Debug.LogWarning("C");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            /*asdfhasölfasf*/
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            charging = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAC.SetBool("isCharging", charging);
        }
    }

    void flipFacing()
    {
        if (!canFlip)
            return;
        float facingX = enemyTransform.localScale.x;
        facingX *= -1;
        enemyTransform.localScale = new Vector3(facingX, enemyTransform.localScale.y, enemyTransform.localScale.z);
        facingRight = !facingRight;

    }

}
