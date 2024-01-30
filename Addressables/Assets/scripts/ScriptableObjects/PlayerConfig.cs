using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 2)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField, Range(0f, 100f)] private float startingHP;
    [SerializeField, Range(0f, 10f)] private float startingSpeed;
    [SerializeField, Range(0f, 1f)] private float startingAttack;

    public float StartingHP => startingHP;
    public float StartingSpeed => startingSpeed;
    public float StartingAttack => startingAttack;


}
