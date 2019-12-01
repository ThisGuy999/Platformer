using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject m_SceneObjects;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Pause()
    {
        isPaused = true;
        m_SceneObjects.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        isPaused = false;
        m_SceneObjects.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (isPaused == false))
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && (isPaused == true))
        {
            Unpause();
        }
    }
}
