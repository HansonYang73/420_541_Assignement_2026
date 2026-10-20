using System;
using UnityEngine;

enum PowerUp
{
    SPEED,
    JUMP,
    SCORE
};

public class PowerUpPickup : MonoBehaviour
{
    [SerializeField] private PowerUp powerUp;
    [SerializeField] private float duration = 10f;
    [SerializeField] private float respawnDelay = 5f;
    [SerializeField] private GameObject visuals;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPowerUps powerUps = other.GetComponent<PlayerPowerUps>();
        if (powerUps == null) return;

        if (powerUp == PowerUp.SPEED)
        {
            powerUps.ActivateSpeedBoost(duration);
        }
        else if (powerUp == PowerUp.JUMP)
        {
            powerUps.ActivateJumpBoost(duration);
        }
        else if (powerUp == PowerUp.SCORE)
        {
            powerUps.ActivateScoreBoost(duration);
        }

        GetComponent<AudioSource>().PlayOneShot(pickupSound);
        Instantiate(pickupEffect, transform.position, Quaternion.identity);

        visuals.SetActive(false);
        GetComponent<Collider>().enabled = false;
        Invoke(nameof(Reappear), respawnDelay);
    }

    private void Reappear()
    {
        visuals.SetActive(true);
        GetComponent<Collider>().enabled = true;
    }
}
