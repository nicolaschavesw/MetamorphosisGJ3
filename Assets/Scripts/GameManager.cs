using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // variable que guarda el puntaje
    public int puntaje;
    // 
    public Puntaje puntajePasar;

    public GameObject perder;

    public Player player;
// -----------------------------------------------------------------------------------------    
    void Start()
    {

    }

// -----------------------------------------------------------------------------------------    
    void Update()
    {
        if (puntaje >= puntajePasar.puntajeRequired){
            Debug.Log("Pasaste de escena");
        }

        if (Input.GetKey(KeyCode.Escape)){
            Debug.Log("Paused");
        }

        if (player.isDead){
            perder.SetActive(true);
        }

    }
// -----------------------------------------------------------------------------------------
    // Metodo para actualizar la variable del puntaje
    public int ActualizarPuntaje(int puntajeActualizado){

        // Lee el puntaje y lo actualiza
        puntaje += puntajeActualizado;
        // Devuelve el valor de puntaje
        return puntaje;
    }    
// -----------------------------------------------------------------------------------------
    public void playLevel1(){
        // Carga la escena para Jugar
        SceneManager.LoadScene(1);
    }    
// -----------------------------------------------------------------------------------------    
// -----------------------------------------------------------------------------------------    
// -----------------------------------------------------------------------------------------    

}
