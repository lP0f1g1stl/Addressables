using UnityEngine;

public class Player : MonoBehaviour, IPausable
{

    public PlayerConfig PlayerConfig { get; set; }
    public bool IsPaused { get; set; }

    private void Update()
    {
        if (!IsPaused)
        {
            transform.position += transform.forward * PlayerConfig.StartingSpeed * Time.deltaTime;
        }
    }
}
