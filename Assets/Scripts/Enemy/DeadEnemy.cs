using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    public float food;
    public GameObject enemy;

    private int puntos;
    public GameManager puntajeEnviar;
// -----------------------------------------------------------------------------------------    
    void Start()
    {
        /* puntajeEnviar = FindObjectOfType<GameManager>(); */
    }
// -----------------------------------------------------------------------------------------    
    public void Disapear()
    {
        enemy.SetActive(false);
        puntajeEnviar.ActualizarPuntaje(1);
    }
// -----------------------------------------------------------------------------------------    
    void Update()
    {
        
    }
}
