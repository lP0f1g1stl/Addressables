using System;
public interface IInputHandler
{
    public bool IsPaused { get; set; }

    public event Action OnSpawnPlayerBtnClick;
    public event Action OnShopBtnClick;
    public event Action OnEscBtnClick;

    public void CheckInput();
}
