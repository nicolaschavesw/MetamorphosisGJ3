using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int level = 1;
    [SerializeField] public float enemyHP = 100;
    [SerializeField] public float speed = 5;
    [SerializeField] public float attack = 2;
    [SerializeField] public float defense = 2;
    void Start()
    {
        
    }
    public IEnumerator TakeDamage(float damage)
    {
        yield return new WaitForSeconds(1f);
        enemyHP = enemyHP - damage; 
        if(enemyHP <=0)
        {
            enemyHP = 0;
        }
        Debug.Log("Vida del enemigo: " + enemyHP);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHP <=0)
        {
            Debug.Log("isDead");
        }
    }
}
