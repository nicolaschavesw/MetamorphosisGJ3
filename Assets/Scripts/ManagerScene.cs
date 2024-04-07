using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayLevel1(){
        // Carga la escena para Jugar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayLevel2(){
        Debug.Log("Scene 2 Loaded");
        // Carga la escena para Jugar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MenuInicio(){
        Debug.Log("Inicio");
        SceneManager.LoadScene(0);
    }
}
