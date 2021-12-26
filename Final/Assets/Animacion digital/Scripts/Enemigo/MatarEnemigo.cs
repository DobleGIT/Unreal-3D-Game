using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //lo utilizamos para el sonido


public class MatarEnemigo : MonoBehaviour
{
    public AudioSource audioMuerte;

    public Animator animator;

    public SpriteRenderer spriteRenderer;


    public float fuerzaSalto = 2.5f;

    public int vidas = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Jugador")) //comprobamos que la colision que ha ocurrido sea de nuestro jugador
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * fuerzaSalto);
            audioMuerte.Play();
            animator.SetBool("Murio", true);
            Invoke("MuereEnemigo", 0.4f); //con el invoke hacemos que tarde más en llamar al metetodo
        }
    }

  
    public void MuereEnemigo()
    {
        spriteRenderer.enabled = false; //desaparece nuestro enemigo
        Destroy(gameObject);
    }
}
