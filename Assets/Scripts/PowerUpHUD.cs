using TMPro;
using UnityEngine;

public class PowerUpHUD : MonoBehaviour
{
    [SerializeField] private PlayerPowerUps powerUps;
    [SerializeField] private GameObject speedIndicator; // icon + time
    [SerializeField] private TMP_Text speedTimeText;

    private void Update()
    {
        float timeLeft = powerUps.SpeedTimeLeft;

        speedIndicator.SetActive(timeLeft > 0f);

        speedTimeText.text = Mathf.CeilToInt(timeLeft) + "s";
    }
}
