using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour
{
    // Day 3 -------------------------------------------
    public GameObject FadePanel;

    // Day 3 -------------------------------------------
    private void Start()
    {
        FadePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        // Day 3 ----------------------------------------------------------------------
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(FadeEffect(SceneManager.GetActiveScene().buildIndex));
    }

    public void NextLevel()
    {
        // Day 3 ----------------------------------------------------------------------
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        StartCoroutine(FadeEffect(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Day 3 -------------------------------------------
    IEnumerator FadeEffect(int SceneToLoad)
    {
        FadePanel.SetActive(true);
        for (int i = 0; i < 100; i++)
        {
            FadePanel.GetComponent<CanvasGroup>().alpha = (float)i * 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }


        SceneManager.LoadScene(SceneToLoad);
    }

}
