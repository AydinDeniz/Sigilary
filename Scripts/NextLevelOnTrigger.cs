using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelOnTrigger : MonoBehaviour
{
    public GameObject transition;
    public string sceneName;

    public void LoadPublic()
    {
            transition.SetActive(true);
            Invoke("Load", 1);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<autoMover>())
        {
            transition.SetActive(true);
            Invoke("Load", 1);
        }
    }

    private void Load()
    {
        SceneManager.LoadScene(sceneName) ;
    }


}
