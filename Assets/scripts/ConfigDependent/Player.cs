using UnityEngine;

public class Player : MonoBehaviour, IPausable
{
    public float PlayerSpeed { get; set; }
    public bool IsPaused { get; set; }

    private void Update()
    {
        if (!IsPaused)
        {
            transform.position += transform.forward * PlayerSpeed * Time.deltaTime;
        }
    }
}
