using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [SerializeField] private int score;

    void OnDestroy()
    {
        GameObject.Find("UIManager").GetComponent<UIManager>().AddScore(score);
    }
}
