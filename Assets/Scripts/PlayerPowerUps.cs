using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] private float boostMultipleir = 1.5f;

    public float SpeedTimeLeft { get; private set; }
    public float DoubleJumpTimeLeft { get; private set; }
    public float ScoreTimeLeft { get; private set; }

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

    public void CheckSpeedBoost()
    {
        if (SpeedTimeLeft <= 0f) return;

        SpeedTimeLeft -= Time.deltaTime;

        if  (SpeedTimeLeft <= 0f)
        {
            movement.SpeedMultiplier = 1f;
        }
    }

    public void ActivateJumpBoost(float duration)
    {
        DoubleJumpTimeLeft = duration;
        movement.CanDoubleJump = true;
    }

    public void CheckJumpBoost()
    {
        if (DoubleJumpTimeLeft <= 0f) return;

        DoubleJumpTimeLeft -= Time.deltaTime;

        if  (DoubleJumpTimeLeft <= 0f)
        {
            movement.CanDoubleJump = false;
        }
    }

    public void ActivateScoreBoost(float duration)
    {
        ScoreTimeLeft = duration;
        ScorePickup.PointsMultiplier = 2;
    }

    public void CheckScoreBoost()
    {
        if (ScoreTimeLeft <= 0f) return;

        ScoreTimeLeft -= Time.deltaTime;

        if  (ScoreTimeLeft <= 0f)
        {
            ScorePickup.PointsMultiplier = 1;
        }
    }

    private void Update()
    {
        CheckSpeedBoost();
        CheckJumpBoost();
        CheckScoreBoost();
    }
}
