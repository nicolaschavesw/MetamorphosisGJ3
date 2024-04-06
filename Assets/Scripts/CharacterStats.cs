using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] public int level = 1;
    [SerializeField] public float HP = 100;
    [SerializeField] public float speed = 10;
    [SerializeField] public float attack = 5;
    [SerializeField] public float defense = 2;
    [SerializeField] public float size = 1;
    [SerializeField] public bool isPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
