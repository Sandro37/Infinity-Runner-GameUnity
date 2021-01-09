using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerGame : MonoBehaviour
{
    public GameObject fimJogo;

    public static ControllerGame controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = this;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fimDeJogo()
    {
        fimJogo.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    public void reiniciarJogo()
    {
        SceneManager.LoadScene(1);
        
    }
}
