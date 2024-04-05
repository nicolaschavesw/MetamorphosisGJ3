using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int level = 1;
    [SerializeField] public float HP = 100;
    [SerializeField] public float speed = 10;
    [SerializeField] public float attack = 5;
    [SerializeField] public float defense = 2;
    [SerializeField] public float size = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        Debug.Log("¡El personaje ha subido al nivel: " + level);
        LevelUpStats();
        ShowStats();
    }

    public void LevelUpStats()
    {
        float levelMultiplier = Random.Range(1.1f,1.4f);
        HP =Mathf.RoundToInt(HP * levelMultiplier);
        speed =Mathf.RoundToInt(speed * levelMultiplier);
        attack =Mathf.RoundToInt(attack * levelMultiplier);
        defense = Mathf.RoundToInt(defense * levelMultiplier);
        size =Mathf.RoundToInt(size * levelMultiplier);
        }

    public void ShowStats()
    {
        Debug.Log("Level: " + level + "\nLife: " + HP + "\nSpeed: " + speed + "\nAttack: " + attack + "\nDefense: " + defense +"\nSize: " + size);
    }

    public float Attack(GameObject Objective)
    {
        //float = GetComponent<Objective.player>();
        float damage = attack;

        return damage;
    }
    public float TakeDamage(float damage)
    {
        float CurrentHP = HP - damage;    
        return CurrentHP;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player"))
        {
            
        }
        if(other.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
