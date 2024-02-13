using UnityEngine;

public class Player : MonoBehaviour
{
    public float PlayerSpeed { get; set; }

    private void Update()
    {
        transform.position += transform.forward * PlayerSpeed * Time.deltaTime;
    }
}
