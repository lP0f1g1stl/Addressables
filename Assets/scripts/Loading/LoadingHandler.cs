using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class LoadingHandler: MonoBehaviour
{
    [SerializeField] private Slider loadingBar;

    public async UniTask LoadAsync(int sceneIndex) 
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loadingOperation.isDone) 
        {
            loadingBar.value = loadingOperation.progress;
            await UniTask.Yield();
        }
    }
}

