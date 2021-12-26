using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class muerteCaida : MonoBehaviour
{
    public float fuerzaSalto = 2.5f; 

    private void OnCollisionEnter2D(Collision2D collision) //si entra en una collision con el box collider
    {

        if (collision.transform.CompareTag("Jugador")) //si esa colision es con el jugador
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * fuerzaSalto); //dentro de rigidBody del jugador se hace un salto
            collision.transform.GetComponent<Respawn>().MurioJugador(); //llamamos a la funcion murioJugador para hacer el respawn y la animación
        }
    }
}
