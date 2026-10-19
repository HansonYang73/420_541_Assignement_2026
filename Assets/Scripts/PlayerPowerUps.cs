using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] private float boostMultipleir = 1.5f;

    public float SpeedTimeLeft { get; private set; }

    private PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void ActivateSpeedBoost(float duration)
    {
        SpeedTimeLeft = duration;
        movement.SpeedMultiplier = boostMultipleir;
    }

    private void Update()
    {
        if (SpeedTimeLeft <= 0f) return;

        SpeedTimeLeft -= Time.deltaTime;

        if  (SpeedTimeLeft <= 0f)
        {
            movement.SpeedMultiplier = 1f;
        }
    }
}
