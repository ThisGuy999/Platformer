using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float xSize;
    public float ySize;

    void Awake()
    {
        BoxCollider2D thisBoxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        thisBoxCollider2D.size = new Vector2(xSize, ySize);
        thisBoxCollider2D.offset = new Vector2(xPos, yPos);

        SpriteRenderer sprRend = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Wood");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
