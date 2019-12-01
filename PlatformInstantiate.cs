using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInstantiate : MonoBehaviour
{
    public Transform platform;
    public Transform spike;
   
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Instantiate(platform, new Vector2(i * 12.5f, -1.04f), Quaternion.identity);
        }

        for (int i = 1; i < 5; i++)
        {
            Instantiate(spike, new Vector2(i * 11.65f, 0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
