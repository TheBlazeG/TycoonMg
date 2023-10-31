using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel, playerUI;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        CursorState(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseInput();
    }
    void PauseInput()
    { if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        { 
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }; }

    //funcion para pausar
    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        playerUI.SetActive(false);
        CursorState(true);
        Time.timeScale = 0f;
    }

    //funcion para reanudar el juego
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        playerUI.SetActive(true);
        CursorState(false);
        Time.timeScale = 1f;
    }

    //activar y desactivar cursor
    public void CursorState(bool _state)
    {
        Cursor.visible = _state;
        if (_state)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        { Cursor.lockState = CursorLockMode.Locked; }
    }
}
