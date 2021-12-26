using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRecogido : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador")) //comprobamos que la colision que ha ocurrido sea de nuestro jugador
        {
            GetComponent<SpriteRenderer>().enabled = false; //desactivamos el sprite renderer del item
            gameObject.transform.GetChild(0).gameObject.SetActive(true); //y activamos el sprite renderer del hijo, que es la animación de recoger

            Destroy(gameObject, 0.5f); //destruimos el gameObject después de la animación
        }
    }

}
