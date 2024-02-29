using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;

public class SceneLoadingManager
{
    public Action<float> OnProgressChange;
    public async UniTask LoadAsync(int sceneIndex)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loadingOperation.isDone)
        {
            OnProgressChange?.Invoke(loadingOperation.progress);
            await UniTask.Yield();
        }
    }
}
