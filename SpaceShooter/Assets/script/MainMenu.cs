using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject telaInicial;

    void Start()
    {
        Time.timeScale = 0f;

        if (telaInicial != null)
        {
            telaInicial.SetActive(true);
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        if (telaInicial != null)
        {
            telaInicial.SetActive(false);
        }
    }
}
