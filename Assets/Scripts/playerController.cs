using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float movimentoX;

    [Header("Visual do jogador")]
    public Color corDoJogador = Color.green;

    [Header("Física do Jogador")]
    [Range(1, 30)]
    public float forcaDoPulo = 2.0f;
    [Range(1, 30)]
    public float velocidade = 5.0f;
    public float deslocamento = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        sr.color = corDoJogador;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnPular()
    {
        rb.AddForce(forcaDoPulo * Vector2.up, ForceMode2D.Impulse);
    }

    void OnMove(InputValue inputValue)
    {
        movimentoX = inputValue.Get<Vector2>().x;
    }

    private void FixedUpdate()
    {
        rb.AddForce(velocidade * movimentoX * Vector2.right, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Inimigo") &&
            collision.collider.transform.position.y < (gameObject.transform.position.y + deslocamento))
        {
            Morrer();
            Debug.Log("Morri!");
        }
    }

    public void Morrer()
    {
        // Animação de morte
        Destroy(gameObject);
    }
}
