using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartScene()
    {
        StartCoroutine(RestartSceneCoroutine());
    }
    public IEnumerator RestartSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        LoadScene(GetActiveSceneIndex());
    }

    public void NextLevel()
    {
        LoadScene(GetActiveSceneIndex() + 1);
    }

    private void LoadScene(int buildIndexxx)
    {
        SceneManager.LoadScene(buildIndexxx);
    }

    public int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void GotoMenuScene()
    {
        LoadScene(0);
    }
}
