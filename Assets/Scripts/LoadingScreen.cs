using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private Slider loading;
    public void LoadScene(int ind)
    {
        loadingScreen.SetActive(true);
        
        StartCoroutine(LoadSceneAsync(ind));
    }

    IEnumerator LoadSceneAsync(int ind)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(ind);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            loading.value = progress;

            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
