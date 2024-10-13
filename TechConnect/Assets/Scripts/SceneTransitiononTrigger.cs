using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    public string nextSceneName; 
    public EventManager eventManager; 

    private bool eventCompleted = false;

    private void Start()
    {
        if (eventManager != null)
        {
            eventManager.OnBinsGone += UnlockSceneTransition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && eventCompleted)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void UnlockSceneTransition(object sender, System.EventArgs e)
    {
        eventCompleted = true; 
    }

    private void OnDestroy()
    {
        if (eventManager != null)
        {
            eventManager.OnBinsGone -= UnlockSceneTransition;
        }
    }
}
