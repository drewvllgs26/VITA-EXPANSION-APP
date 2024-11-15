// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class ChangeScene : MonoBehaviour
// {

//     public void MoveToScene(int sceneID)
//     {
//         SceneManager.LoadScene(sceneID);
//     }
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class ChangeScene : MonoBehaviour
// {
//     private int targetSceneID;

//     public void MoveToScene(int sceneID)
//     {
//         targetSceneID = sceneID;
//         SceneManager.LoadScene(sceneID);
//         SceneManager.sceneLoaded += OnSceneLoaded;
//     }

//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         if (scene.buildIndex == 0)
//         {
//             DisableAnimators(scene);
//         }

//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }

//     private void DisableAnimators(Scene scene)
//     {
//         Animator[] animators = FindObjectsOfType<Animator>();
//         foreach (Animator animator in animators)
//         {
//             animator.enabled = false;
//         }
//     }

// }

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private int targetSceneID;

    public void MoveToScene(int sceneID)
    {
        targetSceneID = sceneID;
        StartCoroutine(LoadSceneWithDelay(sceneID, 0.5f));
    }

    // Coroutine to handle the delay before loading the scene
    private IEnumerator LoadSceneWithDelay(int sceneID, float delayTime)
    {
        yield return new WaitForSeconds(delayTime); 
        SceneManager.LoadScene(sceneID);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            DisableAnimators(scene);
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void DisableAnimators(Scene scene)
    {
        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators)
        {
            animator.enabled = false;
        }
    }
}




