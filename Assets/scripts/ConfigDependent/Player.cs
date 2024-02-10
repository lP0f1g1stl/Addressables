using UnityEngine;

public class Player : MonoBehaviour
{
    private float startingSpeed;

    public float StartingSpeed { set => startingSpeed = value;}

    private void Update()
    {
        transform.position += transform.forward * startingSpeed * Time.deltaTime;
    }
}
