using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    // Obtiene la variable puntaje del GameManajer
    public GameManager puntajeUI;
    // variable que actualiza el puntaje en UI
    private TextMeshProUGUI textMesh;
    // Puntaje para pasar
    public int puntajeRequired = 12;
// -----------------------------------------------------------------------------------------    
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

// -----------------------------------------------------------------------------------------    
    void Update()
    {
        textMesh.text = (puntajeUI.puntaje.ToString() + "/" + puntajeRequired.ToString());
    }
// -----------------------------------------------------------------------------------------    
// -----------------------------------------------------------------------------------------    
// -----------------------------------------------------------------------------------------    

}
