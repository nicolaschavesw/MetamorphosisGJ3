using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPlayerScenes : MonoBehaviour
{
    public Transform startPoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
        MoveStartPoint();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
    }

    public void MoveStartPoint()
    {
        player.transform.position = startPoint.position;
    }

    public void ChangeScene()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(6);
            }
            else
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
