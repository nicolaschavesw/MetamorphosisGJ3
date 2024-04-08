using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public Player player;
    public int saveLevel, saveSelectedMaterial;
    public float saveHP, saveMaxHP, saveSpeed, saveAttack, saveDefence;
    public Vector3 saveSize;
    public Material saveActualMaterial;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        saveLevel = player.level;
        saveHP = player.HP;
        saveMaxHP = player.MaxHP;
        saveSpeed = player.speed;
        saveAttack = player.attack;
        saveDefence = player.defense;
        saveSize = player.size;
        saveActualMaterial = player.actualMaterial;
        saveSelectedMaterial = player.selectedMaterial;
        
        DontDestroyOnLoad(gameObject); 
    }
    void Start() {
       
    }
    void Update() {
        if(player.isWin)
        {
            saveLevel = player.level;
            saveHP = player.HP;
            saveMaxHP = player.MaxHP;
            saveSpeed = player.speed;
            saveAttack = player.attack;
            saveDefence = player.defense;
            saveSize = player.size;
            saveActualMaterial = player.actualMaterial;
            saveSelectedMaterial = player.selectedMaterial;
        }
    }
}
