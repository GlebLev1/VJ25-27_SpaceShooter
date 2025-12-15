using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private Player player;   
    [SerializeField] private TextMeshProUGUI livesText; 
    void Start()
    {
        UpdateLivesText();
    }

    void Update()
    {
        UpdateLivesText();
    }

    void UpdateLivesText()
    {
        if (player == null || livesText == null) return;

        livesText.text = "Vidas: " + player.CurrentLives;
    }
}
