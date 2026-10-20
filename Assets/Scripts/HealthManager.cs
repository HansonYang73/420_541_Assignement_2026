using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    // The single shared instance that any script can reach.
    // "static" means it belongs to the class, not to one object.
    public static HealthManager Instance { get; private set; }

    // Anyone can read the score, only ScoreManager can change it
    public int healthLeft = 3;


    // Awake runs before any Start(), so Instance is ready before coins need it
    private void Awake()
    {
        // If a ScoreManager already exists, remove this extra component
        // (only the script, not the whole Player)
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }


        // Otherwise, this is the one and only ScoreManager
        Instance = this;
    }


    // Called by coins when they're collected
    public void TakeDamage()
    {
        healthLeft -= 1;

        if (healthLeft == 0)
        {
            RestartScene();
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
