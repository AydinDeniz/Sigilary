using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevelOnCollision : MonoBehaviour
{
    public GameObject deathTransition;
    public float loadDelay;
    public float transitionDelay;
    private JukeBox jukeBox;
    [Header("fadeIn")]
    public bool loop = false;
    public float secsIn;
    public float volume;
    public AudioClip clipIn;
    public float pitch = 1;

    private void Start()
    {
        jukeBox = GameObject.FindGameObjectWithTag("JukeBox").GetComponent<JukeBox>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<autoMover>())
        {
            collision.gameObject.GetComponent<Animator>().enabled = false;
            collision.rigidbody.bodyType = RigidbodyType2D.Static;
            collision.otherRigidbody.bodyType = RigidbodyType2D.Static;
            jukeBox.FadeIn(secsIn, volume, clipIn, pitch,loop);
            Invoke("Transition", transitionDelay);
            Invoke("Load", loadDelay);
        }
    }

    private void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Transition()
    {
        deathTransition.SetActive(true);
    }
}
