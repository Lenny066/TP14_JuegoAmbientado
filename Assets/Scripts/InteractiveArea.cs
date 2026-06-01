using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    private int score = 0; 
    private UIManager uiManager; 

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager == null)
        {
            Debug.LogError("¡Atención! No se encontró el UIManager en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.CompareTag("Coleccionable"))
        {
            score++; 

            if (uiManager != null)
            {
                uiManager.UpdateScore(score); 
            }

            Destroy(other.gameObject); 
        }
    }
}