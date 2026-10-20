using UnityEngine;
using TMPro;
using UnityEngine.UI; // TMP_Text

// Updates the HUD every frame from the ScoreManager and PlayerPowerUps.
public class HUDController : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TMP_Text scoreText;
    [Header("Health")]
    [SerializeField] private Image[] healths;
    private int healthsLeft;
 
    private void Update()
    {
        UpdateScore();
        UpdateHealth();
    }
 
    private void UpdateScore()
    {
        // The Score property from Lab 4: anyone can read it
        scoreText.text = "Score: " + ScoreManager.Instance.Score;
    }

    private void UpdateHealth()
    {
        healthsLeft = HealthManager.Instance.healthLeft;
        
        foreach (Image health in healths)
        {
            health.enabled = false;
        }
        for (int i = 0; i < healthsLeft; i++)
        {
            healths[i].enabled = true;
        }
    }
 
}
