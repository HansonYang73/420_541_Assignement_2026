using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    [SerializeField] private float duration = 10f;
    [SerializeField] private float respawDelay = 5f;
    [SerializeField] private GameObject visuals;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPowerUps powerUps = other.GetComponent<PlayerPowerUps>();
        if (powerUps == null) return;

        powerUps.ActivateSpeedBoost(duration);

        GetComponent<AudioSource>().PlayOneShot(pickupSound);
        Instantiate(pickupEffect, transform.position, Quaternion.identity);

        visuals.SetActive(false);
        GetComponent<Collider>().enabled = false;
        Invoke(nameof(Reappear), respawDelay);
    }

    private void Reappear()
    {
        visuals.SetActive(true);
        GetComponent<Collider>().enabled = true;
    }
}
