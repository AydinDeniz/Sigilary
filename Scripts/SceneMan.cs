using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMan : MonoBehaviour
{
    public GameObject[] objeler;
    public bool start;
    private bool started=false;
    public bool restart;
    public bool waitForCommand = false;
    public float waitSecs=0;
    private GameObject jukebox;
    public bool tuto1 = false;
    public bool tuto2 = false;
    public GameObject tutoObject;
    public void Start()
    {
        jukebox = GameObject.FindGameObjectWithTag("JukeBox");
        if (tuto1)
        {
            if (jukebox.GetComponent<CutsceneDepot>().tuto1 == false)
            {
                jukebox.GetComponent<CutsceneDepot>().tuto1 = true;
                Invoke("Normalize", waitSecs);
            }
            else
            {
                tutoObject.SetActive(false);
                waitForCommand = false;
            }
        }
        else if (tuto2)
        {
            if (jukebox.GetComponent<CutsceneDepot>().tuto2 == false)
            {
                jukebox.GetComponent<CutsceneDepot>().tuto2 = true;
                Invoke("Normalize", waitSecs);
            }
            else
            {
                tutoObject.SetActive(false);
                waitForCommand = false;
            }
        }
    }

    public void Normalize()
    {
        
        waitForCommand = false;
    }

    public void StartLevel()
    {
        foreach(GameObject obje in objeler)
        {
            
            foreach(MonoBehaviour script in obje.GetComponents<MonoBehaviour>())
            {
            
            
                script.enabled = true;
                
            }

            foreach (Collider2D script in obje.GetComponents<Collider2D>())
            {
                script.enabled = true;
                
            }

            if (obje.GetComponent<Rigidbody2D>() && obje.tag!="static")
            {
                obje.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }

            if (obje.GetComponent<RewindTime>())
            {
                obje.GetComponent<RewindTime>().frozen = true;
            }
        }
    }

    private void Update()
    {
        if (!waitForCommand)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (started == false)
                {
                    StartLevel();
                    started = true;
                }
                
            }
            else if (Input.GetMouseButtonUp(1))
            {
                RestartLevel();
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        if (start == true)
        {
            start = false;
            StartLevel();
        }
        if (restart == true)
        {
            restart = false;
            RestartLevel();
        }
    }
}
