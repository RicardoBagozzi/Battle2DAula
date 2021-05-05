using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Vector2 posicaoDoJogador;

    public string nomeJogador = "Pilula";
    public float velocidade = 0.01f;
    public float deslocamento = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        posicaoDoJogador = GameObject.Find(nomeJogador).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, 
                                                            posicaoDoJogador, 
                                                            velocidade);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && 
            collision.collider.transform.position.y > (gameObject.transform.position.y + deslocamento))
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
