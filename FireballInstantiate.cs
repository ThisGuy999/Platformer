using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballInstantiate : MonoBehaviour
{
    public GameObject fireball;
    public float thisX;
    public float thisY;

    // Start is called before the first frame update
    void Start()
    {
        thisX = this.transform.position.x;
        thisY = this.transform.position.y;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerCharacter")
        {
            GameObject currentFireball = Instantiate(fireball, new Vector2(thisX + 13f, thisY - 3f), Quaternion.identity);
            currentFireball.AddComponent<FireballDeletion>();
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 15.5f, thisY - .5f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 18f, thisY - .5f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 18f, thisY - 2.8f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 33f, thisY - 3f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 25.5f, thisY - .8f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 48f, thisY - 3f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 50.5f, thisY - .5f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 55.5f, thisY - 3f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 58f, thisY - .5f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 61.75f, thisY - 2.8f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 61.75f, thisY - .5f), Quaternion.identity);
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
