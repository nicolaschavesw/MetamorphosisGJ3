using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    private void Awake() {
        var SavePlayerScenes = FindObjectsOfType<SavePlayer>();
        if (SavePlayerScenes.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
