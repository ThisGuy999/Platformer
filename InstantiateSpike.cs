using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpike : MonoBehaviour
{
    public Transform prefab;
    public float xPos;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            Instantiate(prefab, new Vector2(i * 11.5f, 0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
