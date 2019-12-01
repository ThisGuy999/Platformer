using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_Instantiate : MonoBehaviour
{

    public Transform objectOne;
    public Transform objectTwo;
    public Transform objectThree;
    public Transform objectFour;
    public Transform objectFive;
    public Transform newTrigger;

    private float randomNum;
    public float instantiationPointX = 58.21f;
    public float instantiationPointY = -6.25f;
    private bool activated = false;
    public bool immune;
    private float timer;
    private float timer2;
    private float currentX;
    private float currentY;
    private Vector2 triggerInstance;
    public bool initialTrigger = false;

    void Awake()
    {
        triggerInstance = this.transform.position;
        if (initialTrigger)
        {
            instantiationPointX = 75.35f;
            instantiationPointY = -3.9f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        randomNum = Random.Range(0, 5);
        if ((!this.activated) && (col.tag == "PlayerCharacter"))
        {
            this.activated = true;
            if ((randomNum >= 0) && (randomNum < 1))
            {
                Debug.Log("ONE");
                instantiationPointX -= 5.75f;
                instantiationPointY -= 5.3f;
                Transform newObstacle = Instantiate(objectOne, new Vector2(instantiationPointX, instantiationPointY), Quaternion.identity);
                Procedural_Instantiate newObject = newObstacle.GetComponent<Procedural_Instantiate>();
                newObject.SetXInstantiate(instantiationPointX + 58.19f);
                newObject.SetYInstantiate(instantiationPointY + 5.33f);
                ClearUp();

            }
            else if ((randomNum >=1) && (randomNum < 2))
            {
                Debug.Log("TWO");
                Transform newObstacle = Instantiate(objectTwo, new Vector2(instantiationPointX, instantiationPointY), Quaternion.identity);
                Procedural_Instantiate newObject = newObstacle.GetComponent<Procedural_Instantiate>();
                newObject.SetXInstantiate(instantiationPointX + 27.1f);
                newObject.SetYInstantiate(instantiationPointY - 5.8f);
                ClearUp();

            }
            else if ((randomNum >= 2) && (randomNum < 3))
            {
                Debug.Log("THREE");
                SetXInstantiate(instantiationPointX + 20.5f);
                SetYInstantiate(instantiationPointY + 7.4f);
                Transform newObstacle = Instantiate(objectThree, new Vector2(instantiationPointX, instantiationPointY), Quaternion.identity);
                Procedural_Instantiate newObject = newObstacle.GetComponent<Procedural_Instantiate>();
                newObject.SetXInstantiate(instantiationPointX + 26.2f);
                newObject.SetYInstantiate(instantiationPointY - 7.3f);
                ClearUp();

            }
            else if ((randomNum >= 3) && (randomNum < 4))
            {
                Debug.Log("FOUR");
                SetXInstantiate(instantiationPointX + 15.73f);
                SetYInstantiate(instantiationPointY + .62f);
                Transform newObstacle = Instantiate(objectFour, new Vector2(instantiationPointX, instantiationPointY), Quaternion.identity);
                Procedural_Instantiate newObject = newObstacle.GetComponent<Procedural_Instantiate>();
                newObject.SetXInstantiate(instantiationPointX + 20.28f);
                newObject.SetYInstantiate(instantiationPointY - 12.45f);
                ClearUp();
            }
            else if ((randomNum >= 4) && (randomNum < 5))
            {
                Debug.Log("FIVE");
                SetXInstantiate(instantiationPointX + 14.18f);
                SetYInstantiate(instantiationPointY + 7.08f);
                Transform newObstacle = Instantiate(objectFive, new Vector2(instantiationPointX, instantiationPointY), Quaternion.identity);
                Procedural_Instantiate newObject = newObstacle.GetComponent<Procedural_Instantiate>();
                newObject.SetXInstantiate(instantiationPointX + 14f);
                newObject.SetYInstantiate(instantiationPointY - 6.73f);
                ClearUp();
            }

        }
        else if (col.tag == "Death")
        {
            Destroy(col.gameObject);
        }
    }

    public void DeleteThis()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Destroy(this.gameObject);
    }

    public void SetXInstantiate(float newX)
    {
        instantiationPointX = newX;
    }

    public void SetYInstantiate(float newY)
    {
        instantiationPointY = newY;
    }

    void ClearUp()
    {
        Debug.Log(immune);
        if (timer > 2f)
        {
            Debug.Log(immune);
            if (immune)
            {
                Debug.Log("Refreshing Trigger");
                Instantiate(newTrigger, triggerInstance, Quaternion.identity);
                activated = false;
                Destroy(this.gameObject);
            }

            else
            {
                Destroy(this.gameObject);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

        timer2 += Time.deltaTime;
        if (activated)
        {
            timer += Time.deltaTime;
            if(timer > 5f)
            {
                Debug.Log("IS IT IMMUNE: " + immune);
                ClearUp();
            }
        }       

    }
}
