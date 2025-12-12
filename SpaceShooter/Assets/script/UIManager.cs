using System.Data;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]private int totalScore;
    [SerializeField]private TextMeshProUGUI scoreDisplay;
    
    public void AddScore(int scoreToAdd)
    
    {
      totalScore += scoreToAdd;
      scoreDisplay.text = totalScore.ToString();  
    }
}
