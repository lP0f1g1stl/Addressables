using UnityEngine;

public class PlayerSummoner : MonoBehaviour
{
    [SerializeField] private Player prefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(prefab);
        }
    }
}
