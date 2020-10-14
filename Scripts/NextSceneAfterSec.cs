using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextSceneAfterSec : MonoBehaviour
{
    private AsyncOperation async;
    public float secs;
    public string sceneName;
    private void Start()
    {
        Invoke("Load", 1);
        Invoke("Scene", secs);
    }

    private void Load()
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
    }

    private void Scene()
    {
        async.allowSceneActivation = true;
    }
}
