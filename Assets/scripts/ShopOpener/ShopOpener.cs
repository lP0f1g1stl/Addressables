using UnityEngine;
using Zenject;

public class ShopOpener : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    private IInputHandler inputHandler;

    [Inject]
    public void Construct(IInputHandler inputHandler) 
    {
        this.inputHandler = inputHandler;

        AddListener();
    }

    private void AddListener() 
    {
        inputHandler.OnShopBtnClick += OpenCloseShop;
    }
    private void OnDisable()
    {
        inputHandler.OnShopBtnClick -= OpenCloseShop;
    }

    private void OpenCloseShop()
    {
        shop.SetActive(!shop.activeSelf);
    }
}
