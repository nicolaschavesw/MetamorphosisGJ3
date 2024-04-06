using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    public float food;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Disapear()
    {
        enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
