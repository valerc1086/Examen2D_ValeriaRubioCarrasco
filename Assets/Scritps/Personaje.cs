using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 2;
    private float movimientoX;
    public Rigidbody2D rb2d;

    [Header("Salto")]
    public float fuerzaSalto = 2;
    private bool estaEnSuelo;
    public LayerMask layerSuelo;
    public float radioEsferaTocaSuelo = 0.2f;
    public Transform compruebaSuelo;

    [Header("Animaciones")]
    Animator animator;

    [Header("Sonido")]
    public AudioSource audioSource;
    public AudioClip getMoneda;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        rb2d.linearVelocity = new Vector2(movimientoX * velocidad, rb2d.linearVelocity.y);
        if(movimientoX == 0)
        {
            animator.SetBool("estaCorriendo",false);
        }
    }

    void FixedUpdate() { 
    
        estaEnSuelo = Physics2D.OverlapCircle(compruebaSuelo.position, radioEsferaTocaSuelo, layerSuelo);
    }

    private void OnMove(InputValue inputMovimiento)
    {
        movimientoX = inputMovimiento.Get<Vector2>().x;
        animator.SetBool("estaCorriendo",true);

        if(movimientoX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimientoX), 1, 1);
        }
    }

    private void OnJump(InputValue inputSalto)
    {
        if (estaEnSuelo)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, fuerzaSalto);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemigo"))
        {
            FindAnyObjectByType<GameManager>().RestaVida();
            StartCoroutine(ReiniciarNivel());
            
        }
        if (collision.transform.CompareTag("SueloMorir"))
        {
            FindAnyObjectByType<GameManager>().RestaVida();
            StartCoroutine(ReiniciarNivel());
            
        }
        if (collision.transform.CompareTag("Moneda"))
        {

            Destroy(collision.gameObject);
            FindAnyObjectByType<GameManager>().SumaPuntos();
            audioSource.PlayOneShot(getMoneda);
        }
    }

    IEnumerator ReiniciarNivel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
