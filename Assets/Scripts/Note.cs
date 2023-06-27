//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////public class GroundSpawer : MonoBehaviour
//{
//    public GameObject Ground1, Ground2, Ground3;
//    bool hasGround = true;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (!hasGround)
//        {
//            SpawnGround();
//            hasGround = true;
//        }

//    }
//    //private void SpawnGround()
//    {
//        int randomNum = Random.Range(1, 4);
//        if (randomNum == 1)
//        {
//            Instantiate(Ground1, new Vector3(transform.position.x + 3, -4.4f, 0), Quaternion.identity);
//        }
//        if (randomNum == 2)
//        {
//            Instantiate(Ground2, new Vector3(transform.position.x + 3, -2f, 0), Quaternion.identity);
//        }
//        if (randomNum == 3)
//        {
//            Instantiate(Ground3, new Vector3(transform.position.x + 3, -1f, 0), Quaternion.identity);
//        }
//    }
//    //private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            hasGround = true;
//        }
//    }
//    //private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            hasGround = false;
//        }
//    }


//}


//playercontroller
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] float moveSpeed = 5f;
//    [SerializeField] float jumptSpeed = 5f;
//    [SerializeField] int maxJumpCount = 2;
//    Rigidbody2D myRigibody2D;
//    Animator myAnimator;
//    BoxCollider2D myBoxCollider2D;
//    int jumpCount;


//    // Start is called before the first frame update
//    void Start()
//    {
//        myAnimator = GetComponent<Animator>();
//        myRigibody2D = GetComponent<Rigidbody2D>();
//        myBoxCollider2D = GetComponent<BoxCollider2D>();
//        jumpCount = 0;

//    }

    // Update is called once per frame
//    void Update()
//    {
//        Movement();
//        Jump();
//        FlipScale();
//    }

//    void Movement()
//    {
//        float move = Input.GetAxisRaw("Horizontal");
//        myRigibody2D.velocity = new Vector2(move * moveSpeed, myRigibody2D.velocity.y);
//        if (move == 0)
//        {
//            myAnimator.SetBool("Run", false);

//        }
//        else
//        {
//            myAnimator.SetBool("Run", true);
//        }
//    }
//    void Jump()
//    {
//        if (!myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) && jumpCount >= maxJumpCount)
//        {
//            return;
//        }
//        if (Input.GetButtonDown("Jump"))
//        {
//            Vector2 jump = new Vector2(0f, jumptSpeed);
//            myRigibody2D.velocity += jump;
//            jumpCount++;
//        }
//    }
//    void FlipScale()
//    {
//        bool scale = Mathf.Abs(myRigibody2D.velocity.x) > Mathf.Epsilon;
//        if (scale)
//        {
//            transform.localScale = new Vector2(Mathf.Sign(myRigibody2D.velocity.x), 1f);
//        }
//    }
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            jumpCount = 0;
//        }
//    }
//}

