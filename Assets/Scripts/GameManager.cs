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

    public GameObject perder, ganar, pausar;
    public bool pausedGame = false;

    public Player player;
    public PlayerController playerController;
    public GameObject PlayerSpider;

// -----------------------------------------------------------------------------------------    
    void Start()
    {
        PlayerSpider = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

// -----------------------------------------------------------------------------------------    
    void Update()
    {
        if (puntaje >= puntajePasar.puntajeRequired){
            Debug.Log("Pasaste de escena");
            ganar.SetActive(true);
            player.isWin = true;
            puntaje = 0;
        }
        // -----------------------------------------------------------------------------------------    
        // Pause and unpause game
        if (Input.GetKeyDown(KeyCode.Escape) && pausedGame == false){
            Debug.Log("Paused");
            pausedGame = true;
            pausar.SetActive(true);
            Time.timeScale = 0f;
            player.isPaused = true;
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && pausedGame == true){
            Debug.Log("Unpaused");
            pausedGame = false;
            pausar.SetActive(false);
            Time.timeScale = 1f;
            player.isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

       /* if (pausedGame == true){
            pausar.SetActive(true);
        }else if (pausedGame == false){
            pausar.SetActive(false);
        } */

        if (player.isDead){
            perder.SetActive(true);
        } 
        // -----------------------------------------------------------------------------------------    
    }
// -----------------------------------------------------------------------------------------
    public void Reanudar (){
        Debug.Log("Unpaused");
        pausedGame = false;
        pausar.SetActive(false);
        Time.timeScale = 1f;
        player.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Inicio (){
        SceneManager.LoadScene(1);
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
/*     public void playLevel1(){
        // Carga la escena para Jugar
        SceneManager.LoadScene(1);
    }     */
// -----------------------------------------------------------------------------------------    
// -----------------------------------------------------------------------------------------    
// -----------------------------------------------------------------------------------------    

}
