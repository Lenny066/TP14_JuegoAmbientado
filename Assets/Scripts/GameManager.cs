using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // NUEVO: Para poder reiniciar escenas

public class GameManager : MonoBehaviour
{
    public float timer = 60f;
    private UIManager uiManager;
    private bool juegoTerminado = false; // NUEVO: Para saber si el juego ya terminó

    void Start()
    {
        Time.timeScale = 1f; // CRUCIAL: Restablece la velocidad del juego al iniciar
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        // NUEVO: Si el juego terminó, escuchamos si presiona la R
        if (juegoTerminado)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena
            }
            return; // Frena el Update acá para que no siga bajando el tiempo
        }

        // Tu lógica original del tiempo modificada para llamar a la derrota
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            uiManager.UpdateTimer(timer);
        }
        else
        {
            timer = 0;
            CalculoGameOver(); // NUEVO: Llama a la derrota si el tiempo llega a cero
        }
    }

    // NUEVO: Método para congelar por Derrota
    public void CalculoGameOver()
    {
        if (!juegoTerminado)
        {
            juegoTerminado = true;
            Time.timeScale = 0f; // Congela el juego por completo
            uiManager.MostrarPantallaGameOver(); // Muestra el cartel en el Canvas
        }
    }

    // NUEVO: Método para congelar por Victoria
    public void CalculoVictoria()
    {
        if (!juegoTerminado)
        {
            juegoTerminado = true;
            Time.timeScale = 0f; // Congela el juego por completo
            uiManager.MostrarPantallaWin(); // Muestra el cartel en el Canvas
        }
    }
}