using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   [SerializeField] GameObject telaGameOver;
   void Start()
    {
        if (telaGameOver != null)
        {
            telaGameOver.SetActive(false); 
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f; 
        if (telaGameOver != null)
        {
            telaGameOver.SetActive(true); 
        }
    }
    void ResumeTime()
    {
        Time.timeScale = 1;
    }


    public void Restart()
    {   
        ResumeTime();

        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
