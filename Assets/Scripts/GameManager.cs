using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 60f;
    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            uiManager.UpdateTimer(timer);
        }
        else
        {
            timer = 0;
        }
    }
}