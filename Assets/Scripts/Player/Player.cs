using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int level = 1;
    public float HP = 0;
    public float MaxHP = 100;
    public float speed = 10;
    public float attack = 5;
    public float defense = 2;
    public Vector3 size = new Vector3(1,1,1);

    public Animator animator;
    public bool isAttacking = false;
    public bool isEating = false;
    public bool oneAttack = true;
    //public Slider slider;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public List<Material> materialList;
    private Material actualMaterial;
    private int selectedMaterial = 0;
    public float timer;


    void Start()
    {
        actualMaterial = materialList[selectedMaterial];
        skinnedMeshRenderer.material = actualMaterial;
        HP = MaxHP;
        oneAttack = true;
        isAttacking = false;
        isEating = false;
        //slider.value = HP;
        //slider.minValue = 0;
        //slider.maxValue = MaxHP;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            DecreaseHP();
            timer = 0.0f;
            Debug.Log("Vida: " + HP);
        }
        //Player Attack when LeftClick is down
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
            animator.SetBool("Attack",true);
            StartCoroutine(AttackEnemy());
        }
        //Player Eat when RightClick is down
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            isEating = true;
            animator.SetBool("IsEating",true);
            StartCoroutine(Eat());
        }
        if(HP > MaxHP)
        {
            LevelUp();
            Debug.Log("La vida supero la vida maxima \n Spider subio al nivel: " + level);
        }
    }
    //Player LevelUp
    //All stats up, the material changes, generates a random multiplier to add to the stats
    public void LevelUp()
    {
        level++;
        ChangeMaterial();
        float levelMultiplier = Random.Range(1.1f,1.4f);
        LevelUpHP(levelMultiplier);
        LevelUpSpeed(levelMultiplier);
        LevelUpAttack(levelMultiplier);
        LevelUpDefense(levelMultiplier);
        LevelUpSize(levelMultiplier);
    }
    //Changes the material with the list of materials of the player, changes the skinnedMeshRenderer
    public void ChangeMaterial()
    {
        if(selectedMaterial >= materialList.Count - 1)
        {
            selectedMaterial = materialList.Count - 1;
        }
        else
        {
            selectedMaterial++;
        }
        actualMaterial = materialList[selectedMaterial];
        skinnedMeshRenderer.material = actualMaterial;
    }
    public void UpdateHP(float foodToAdd, GameObject food)
    {
        DeadEnemy deadEnemy = food.gameObject.GetComponent<DeadEnemy>();
        deadEnemy.Disapear();
        HP += foodToAdd;
        Debug.Log("Vida actual: "+ HP);
        if(HP > MaxHP)
        {
            LevelUp();
            Debug.Log("La vida supero la vida maxima \n Spider subio al nivel: " + level);
        }
    }

    public void DecreaseHP()
    {
        HP --;
    }
    // Improve the max health adding the multiplier 10 times, set the actual HP
    public void LevelUpHP(float Multiplier)
    {
        float HPMultiplier = Multiplier * 10;
        MaxHP = Mathf.RoundToInt(MaxHP + HPMultiplier);
        HP = Mathf.RoundToInt(MaxHP * 0.75f);
    }
    // Improve the speed adding the multiplier until 25 max speed
    public void LevelUpSpeed(float Multiplier)
    {
        speed = Mathf.RoundToInt(speed + Multiplier);
        if(speed >= 25)
        {
            speed = 25;
        }
    }
    // Improve the attack by multiplying with the multiplier
    public void LevelUpAttack(float Multiplier)
    {  
        attack = Mathf.RoundToInt(attack * Multiplier);
    }
    // Improve the defense by multiplying with the multiplier
    public void LevelUpDefense(float Multiplier)
    {
        defense = Mathf.RoundToInt(defense * Multiplier);
    }
    // makes the size of the player bigger by adding one tenth of the multiplier until 3 max size
    public void LevelUpSize(float Multiplier)
    {
        float sizeMultiplier = Multiplier / 10;
        size.x += sizeMultiplier;
        size.y += sizeMultiplier;
        size.z += sizeMultiplier;
        if(size.x >= 3 || size.y >= 3 || size.z >= 3)
        {
            size = new Vector3(3,3,3);
        }
        transform.localScale = size;
    }
    // Corutine of attack, set the animations
    IEnumerator AttackEnemy()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Attack",false);
        isAttacking = false;
    }
    // Corutine of eat, set the animations
    IEnumerator Eat()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("IsEating",false);
        isEating = false;
    }
    // Take Damage
    public void TakeDamage(float damage)
    {
        HP = HP - damage;
        if(HP <=0)
        {
            HP = 0;
        }
        Debug.Log("Vida del player: " + HP);
    }
    ////////////////////////////// Evaluates if can do a attack with trigger detection and verify if the object of the trigger collision has a enemy script
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
        if(isEating & oneAttack & other.gameObject.CompareTag("DeadEnemy"))
        {
            DeadEnemy deadEnemy = other.gameObject.GetComponent<DeadEnemy>();
            float foodToAdd = deadEnemy.food;
            UpdateHP(foodToAdd,other.gameObject);
            oneAttack = false;
            Debug.Log("Colisionó");
        }

    }
    private void OnTriggerExit(Collider other) {
        oneAttack = true;
    }
    //////////////////////////////
}
