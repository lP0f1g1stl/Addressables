using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class LoadingHandler: MonoBehaviour
{
    [SerializeField] private Slider loadingBar;

    public void ChangeProgress(float value) 
    {
        Debug.Log(value);
        loadingBar.value = value;
    }
}

