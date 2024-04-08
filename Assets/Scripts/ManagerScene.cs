using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public Transform startPoint;
    public GameObject player;
    //public Player playerCs;
    private bool ChangeScene;

    // Start is called before the first frame update
    void Start()
    {
        //playerCs = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
        MoveStartPoint();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
// -----------------------------------------------------------------------------------------    

    public void Play(){
        // Carga la escena para Jugar
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
// -----------------------------------------------------------------------------------------    

     public void PlayCurrentLevel(){
        // Carga la escena para Jugar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        
        
        Debug.Log("Cambio Nivel");
    }
// -----------------------------------------------------------------------------------------    

    public void PlayLevel2(){
        Debug.Log("Scene 2 Loaded");
        // Carga la escena para Jugar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        
        Debug.Log("Cambio Nivel");
    }
// -----------------------------------------------------------------------------------------    

    public void MenuInicio(){
        Debug.Log("Inicio");
        SceneManager.LoadScene(0);
    }

    public void MoveStartPoint()
    {
        player.transform.position = startPoint.position;
    }
}
