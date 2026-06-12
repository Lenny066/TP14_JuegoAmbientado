using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    // NUEVO: Estas variables guardan los paneles que creamos antes
    public GameObject panelWin;
    public GameObject panelGameOver;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimer(float timer)
    {
        timerText.text = "00:" + Mathf.CeilToInt(timer).ToString("D2");
    }

    public void MostrarPantallaWin()
    {
        panelWin.SetActive(true);
    }

  
    public void MostrarPantallaGameOver()
    {
        panelGameOver.SetActive(true);
    }
}