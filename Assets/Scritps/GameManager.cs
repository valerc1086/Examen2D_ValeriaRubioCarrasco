using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class GameManager : MonoBehaviour
{
    public TMP_Text textoPuntos;
    public TMP_Text textoVidas;
    public Transform monedas;

    private int contVidas = 3;

    private int puntos;
    private int vidas;
    void Start()
    {
        puntos = 0;
        vidas = contVidas;
        textoPuntos.text = "0";
        textoVidas.text = "3";
    }

    public void SumaPuntos()
    {
        puntos++;
        textoPuntos.text = puntos.ToString();
    }

    public void RestaVida()
    {
        contVidas--;
        if(vidas > 0)
        {
            vidas--;
            textoVidas.text = vidas.ToString();
        }
        else
        {
            SceneManager.LoadScene("EscenaDerrota");
        }
        
    }
}
