using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text textoPuntos;
    public TMP_Text textoVidas;
    public Transform monedas;

    private int puntos;
    private int vidas;
    void Start()
    {
        puntos = //transform.GetComponentInChildren<monedas.GetComponent("monedas")>().text;
        vidas = 3;
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
