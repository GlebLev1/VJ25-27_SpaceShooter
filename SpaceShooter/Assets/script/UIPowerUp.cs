using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI timerText;

    void Update()
    {
        if (player == null || timerText == null) return;

        if (player.powerupTimeLeft > 0f)
        {
            timerText.gameObject.SetActive(true);
            timerText.text = "Power Up: " + Mathf.CeilToInt(player.powerupTimeLeft) + "s";
        }
        else
        {
            timerText.gameObject.SetActive(false);
        }
    }
}
