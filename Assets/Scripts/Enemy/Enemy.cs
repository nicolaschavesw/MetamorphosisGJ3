using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level = 1;
    public float enemyHP = 100;
    public float speed = 5;
    public float attack = 2;
    public float defense = 2;
    public GameObject triggerCorpse;
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

    public void IsDead()
    {
        triggerCorpse.SetActive(true);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHP <=0)
        {
            IsDead();
            Debug.Log("isDead");
        }
    }
}
