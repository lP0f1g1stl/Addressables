using UnityEngine;
using System;

public class KeyboardInput : IInputHandler
{
    public bool IsPaused { get; set; }

    public event Action OnSpawnPlayerBtnClick;
    public event Action OnShopBtnClick;
    public event Action OnEscBtnClick;

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscBtnClick?.Invoke();
        }

        if (IsPaused) return;

        if (Input.GetKeyDown(KeyCode.X)) 
        {
            OnSpawnPlayerBtnClick?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnShopBtnClick?.Invoke();
        }
    }
}
