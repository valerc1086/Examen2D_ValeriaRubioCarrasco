using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBotones : MonoBehaviour
{
    
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("EscenaJuego");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
