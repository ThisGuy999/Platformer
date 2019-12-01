using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballInstantiate02 : MonoBehaviour
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
            GameObject currentFireball = Instantiate(fireball, new Vector2(thisX + 20f, thisY - 5.32f), Quaternion.identity);
            currentFireball.AddComponent<FireballDeletion>();
            currentFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0f);
            currentFireball.GetComponent<Rigidbody2D>().freezeRotation = true;
            currentFireball.tag = "fire";
            currentFireball = Instantiate(currentFireball, new Vector2(thisX + 20f, thisY - 6.73f), Quaternion.identity);
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
