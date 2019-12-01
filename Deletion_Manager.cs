using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletion_Manager : MonoBehaviour
{
    public float timer, timer2;
    public bool noDelete = true;
    public bool startTimer2 = false;

    void Awake() {
        noDelete = false;
    }
   
    void Start()
    {
        noDelete = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 5f && noDelete == false)
        {
            Destroy(this.gameObject);
        }
    }
    
}
