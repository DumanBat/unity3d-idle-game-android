using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static bool isLoading = false;


    public void ChangeScene()
    {
        LoadNextLevel();
    }

    public void ChangeSceneToNewGame()
    {
        LoadNextLevel();
    }

    public void ChangeSceneToLoadGame()
    {
        isLoading = true;
        LoadNextLevel();
    }


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
