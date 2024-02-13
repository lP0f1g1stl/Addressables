using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerConfig PlayerConfig { get; set; }

    private void Update()
    {
        transform.position += transform.forward * PlayerConfig.StartingSpeed * Time.deltaTime;
    }
}
