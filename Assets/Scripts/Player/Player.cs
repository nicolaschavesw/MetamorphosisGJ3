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

    public Animator animator;
    public bool isAttacking = false;
    public bool oneAttack = true;

    void Start()
    {
        oneAttack = true;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
            animator.SetBool("Attack",true);
            StartCoroutine(AttackEnemy());
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        Debug.Log("¡El <b>personaje</b> ha subido al nivel: " + "<b>" + level.ToString() + "</b>");
        LevelUpStats();
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
    IEnumerator AttackEnemy()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Attack",false);
        isAttacking = false;
    }
    public void TakeDamage(float damage)
    {
        HP = HP - damage; 
        if(HP <=0)
        {
            HP = 0;
        }
        Debug.Log("Vida del player: " + HP);
    }
    
    private void OnTriggerEnter(Collider other) {
        oneAttack = true;
    }
    private void OnTriggerStay(Collider other) {
        if(isAttacking & oneAttack & other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            StartCoroutine(enemy.TakeDamage(attack));
            oneAttack = false;
        }
    }
    private void OnTriggerExit(Collider other) {
        oneAttack = true;
    }
}
