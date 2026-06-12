using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    private int score = 0; 
    private UIManager uiManager; 
    private GameManager gameManager; // NUEVO: Para poder avisarle que ganamos

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>(); // NUEVO: Busca el GameManager en la escena

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

            // NUEVO: Si juntás 3 tuppers (o la cantidad que vos quieras), ganás
            // Si en tu mapa hay más de 3, cambias este "3" por el número que necesites
            if (score >= 3 && gameManager != null)
            {
                gameManager.CalculoVictoria(); // Llama a la pantalla de ganar y congela el juego
            }

            Destroy(other.gameObject); 
        }
    }
}