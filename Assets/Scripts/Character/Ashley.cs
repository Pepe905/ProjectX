using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashley : MonoBehaviour
{



                [SerializeField] float m_speed = 1.0f;
                [SerializeField] float m_jumpForce = 2.0f;
                [SerializeField] float Ammospeed = 500;

                private Animator m_animator;
                private Rigidbody2D m_body2d;
                private Ashley_Sensor m_groundSensor;
                private bool m_grounded = false;
                private SpriteRenderer characterSprite;
                private bool isAttacking = false;
                public GameObject AmmoPrefab;
                public Transform spawnPoint;
                public bool lookingleft = true;
                

                
                




    // Start is called before the first frame update
    void Start()
    {

               m_animator = GetComponent<Animator>();
               m_body2d = GetComponent<Rigidbody2D>();
               m_groundSensor = transform.Find("Ashley_GroundSensor").GetComponent<Ashley_Sensor>();
               characterSprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
                                        //Ground
                                        if (!m_grounded && m_groundSensor.State())
                                        {
                                            m_grounded = true;
                                            m_animator.SetBool("Grounded", m_grounded);
                                        }

                                        //Falling
                                        if (m_grounded && !m_groundSensor.State())
                                        {
                                            m_grounded = false;
                                            m_animator.SetBool("Grounded", m_grounded);
                                        }

                                        //Movement
                                        float inputX = Input.GetAxis("Horizontal");

                                        if ((inputX < 0 && !lookingleft) || (inputX > 0 && lookingleft))
                                        Flip();


                                        // Move
                                        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

                                        //Airspeed

                                        //m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);



                                        //Direction
                                        void Flip()


                                        {
                                            lookingleft = !lookingleft;
                                            Vector3 myScale = transform.localScale;
                                            myScale.x *= -1;
                                            transform.localScale = myScale;
                                        }

                                        

                                        //Gunfire

                                        if (Input.GetButtonDown("Fire1") && !isAttacking)
                                        isAttacking = true;

                                        if (isAttacking)
                                        {
                                            m_animator.SetTrigger("Attack");
                                            GameObject Ammo = (GameObject)Instantiate(AmmoPrefab, spawnPoint.position, Quaternion.identity);

                                            if (lookingleft)
                                                Ammo.GetComponent<Rigidbody2D>().AddForce(Vector3.left * Ammospeed);

                                            else
                                                Ammo.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Ammospeed);

                                            isAttacking = false;
                                        }


                                        //Jump

                                        else if (Input.GetKeyDown("space") && m_grounded)
                                        {

                                            m_animator.SetTrigger("Jump");
                                            m_grounded = false;
                                            m_animator.SetBool("Grounded", m_grounded);
                                            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                                            m_groundSensor.Disable(0.1f);
                                        }

                                        //Run
                                        else if (Mathf.Abs(inputX) > Mathf.Epsilon);
                                        //    m_animator.SetInteger("AnimState", 2);

                                        
                                        

                                      







    }

}  
    

      

      

    

