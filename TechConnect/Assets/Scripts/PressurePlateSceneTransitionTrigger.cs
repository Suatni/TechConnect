using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlateSceneTransitionTrigger : MonoBehaviour
{
    public string nextSceneName;
    public PressurePlateEventManager pressurePlateEventManager;

    private bool weightRequirementMet = false;

    private void Start()
    {
        if (pressurePlateEventManager != null)
        {
            pressurePlateEventManager.OnWeightMet += UnlockSceneTransition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && weightRequirementMet)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void UnlockSceneTransition(object sender, System.EventArgs e)
    {
        weightRequirementMet = true;
        Debug.Log("Pressure plate condition met, you can now proceed.");
    }

    private void OnDestroy()
    {
        if (pressurePlateEventManager != null)
        {
            pressurePlateEventManager.OnWeightMet -= UnlockSceneTransition;
        }
    }
}
