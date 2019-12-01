using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastManager : MonoBehaviour
{

    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up * -1, -Vector2.up);
        if(hit == true && hit.distance < .01f)
        {
            Debug.Log("Hello");
            Debug.Log(hit.transform.gameObject);
            if (hit.transform.gameObject.tag == "wood")
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Player.transform.position;
    }
}
