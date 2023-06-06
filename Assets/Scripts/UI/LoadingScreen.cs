using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void Loading(string name)
    {
        loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync(name));
    }

    IEnumerator LoadAsync(string name)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(name);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(1f); // задержка 1 секунда
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
