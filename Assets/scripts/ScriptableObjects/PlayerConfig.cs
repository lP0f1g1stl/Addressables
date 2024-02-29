using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 2)]
public class PlayerConfig : ScriptableObject, IConfig
{
    [ShowInInspector][ProgressBar(0, 10, 1, 0, 0, Segmented = true)] private float startingHP;
    [ShowInInspector][ProgressBar(0, 10, 0, 1, 0, Segmented = true)] private float startingSpeed;
    [ShowInInspector][ProgressBar(0, 10, 1, 0, 1, Segmented = true)] private float startingAttack;

    public float StartingHP => startingHP;
    public float StartingSpeed => startingSpeed;
    public float StartingAttack => startingAttack;
}
