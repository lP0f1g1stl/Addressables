using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingHandler : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;

    public void Loading(int sceneIndex) 
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    private IEnumerator LoadAsync(int sceneIndex) 
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loadingOperation.isDone) 
        {
            loadingBar.value = loadingOperation.progress;
            yield return null;
        }
    }

    
}

