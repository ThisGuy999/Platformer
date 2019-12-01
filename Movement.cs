using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce;
    public GameObject slideObject;
    public GameObject normalObject;
    public GameObject rayCastManager;
    private PlayerRaycastManager rayScript;

    private Rigidbody2D thisRB;
    
    private bool hasJumped = true;
    private float currentX = 0;
    private float previousX;
    private float timer = 0f;
    private int colNum = 0;
    private bool grounded;
    public int lives = 3;
    GameObject colObject;
    Animator thisAnimator;



    void Awake()
    {
        SpriteRenderer sprRend = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        thisAnimator = GetComponent<Animator>();
        thisRB = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        thisRB.bodyType = RigidbodyType2D.Dynamic;
        thisRB.freezeRotation = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("football");
        gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
        rayScript = rayCastManager.GetComponent<PlayerRaycastManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        hasJumped = false;

        if (col.gameObject.tag == "spike")
        {
            if (lives > 1)
            {
                lives -= 1;
                thisRB.transform.position = new Vector2(0, 1);
                currentX = 0;
                previousX = -1;
                hasJumped = true;
                var fireballs = GameObject.FindGameObjectsWithTag("fire");
                foreach (var fire in fireballs)
                {
                    Destroy(fire);
                }
            }
            else{
                this.GetComponent<SceneManagerScript>().LoadScene();
            }
        }
        

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        Transform parentObj = col.transform.parent;

        if (col.gameObject.tag == "Death" || col.gameObject.tag == "fire")
        {
            if (lives > 1)
            {
                lives -= 1;
                thisRB.transform.position = new Vector2(0, 1);
                currentX = 0;
                previousX = -1;
                hasJumped = true;
                var fireballs = GameObject.FindGameObjectsWithTag("fire");
                foreach (var fire in fireballs)
                {
                    Destroy(fire);
                }
            }
            else
            {
                this.GetComponent<SceneManagerScript>().LoadScene();
            }
        }
        else
        {
            parentObj.GetComponent<Deletion_Manager>().timer = 0f;
            parentObj.GetComponent<Deletion_Manager>().noDelete = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {

        Transform parentObj = col.transform.parent;

        if (!(col.gameObject.tag == "Death") && (col.gameObject.tag == "PlayerRaycastManager"))
        {
 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisRB.velocity = new Vector2(8.0f, thisRB.velocity.y);
        thisRB.AddForce(new Vector2(0, -.5f), ForceMode2D.Impulse);
        if(thisRB.velocity.y >12f)
        {
            thisRB.velocity = new Vector2(thisRB.velocity.x, 12f);
        }
        previousX = currentX;
        currentX = thisRB.position.x;
        timer = timer + Time.deltaTime;

        if (currentX == previousX)
        {
            if (lives > 1)
            {
                thisRB.transform.position = new Vector2(0, 1);
                currentX = 0;
                previousX = -1;
                hasJumped = true;
                var fireballs = GameObject.FindGameObjectsWithTag("fire");
                foreach (var fire in fireballs)
                {
                    Destroy(fire);
                }

            }
            else
            {
                this.GetComponent<SceneManagerScript>().LoadScene();
            }
        }

        if (Input.GetKey(KeyCode.Space) && (hasJumped == false) && (colNum == 0))
        {
            if(rayScript.isGrounded() == true)
            {
                thisRB.velocity = new Vector2(thisRB.velocity.x, 0f);
                thisRB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                hasJumped = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Stylin'");
            float newTimer = 0f;
            thisAnimator.SetBool("StopAnim", false);
            thisAnimator.SetBool("PressF", true);
            thisAnimator.Play("Style");
            thisAnimator.StopPlayback();
            thisAnimator.SetBool("PressF", false);
            thisAnimator.SetBool("StopAnim", true);
            Debug.Log(thisAnimator.GetBool("PressF")) ;
            Debug.Log("Stop Stylin'");
            
        }

        //Code controlling sliding
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && (colNum == 0))
        {
            colNum = 1;
            DestroyImmediate(gameObject.GetComponent<CircleCollider2D>());
            DestroyImmediate(gameObject.GetComponent<SpriteRenderer>());
            thisRB.freezeRotation = true;
            thisRB.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            gameObject.AddComponent<CapsuleCollider2D>();
            gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(5.9f, 10.8f);
            gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(-1.8f, 0f);
           
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SquashedFootball");
            gameObject.GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(0f, 0f, 90f); ;
            timer = 0.0f;
        }

        if((timer > .5f) && (gameObject.GetComponent<CapsuleCollider2D>() == true) && ((!Input.GetKey(KeyCode.DownArrow)) || (!Input.GetKey(KeyCode.S)))){
            DestroyImmediate(gameObject.GetComponent<CapsuleCollider2D>());
            DestroyImmediate(gameObject.GetComponent<SpriteRenderer>());
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.AddComponent<CircleCollider2D>();
            gameObject.GetComponent<SpriteRenderer>().sprite = normalObject.GetComponent<SpriteRenderer>().sprite;
            gameObject.GetComponent<CircleCollider2D>().radius = normalObject.GetComponent<CircleCollider2D>().radius;
            timer = 0.0f;
            colNum = 0;
            thisRB.freezeRotation = false;
        }

        if(this.transform.position.y < -1000)
        {
            thisRB.transform.position = new Vector2(0, 1);
        }
        
    }


}
