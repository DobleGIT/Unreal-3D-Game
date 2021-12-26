using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataEnemigo : MonoBehaviour  
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float velocidad = 2f;

    private float tiempoEspera;

    private int i;
    private Vector2 posicionActual;

    public Transform[] movimientos; 

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(comprobamosDireccionEnemigo()); //iniciamos la corrutina 
        //esta funcion nos permite mover a nuestro enemigo hasta cierto punto
        transform.position = Vector2.MoveTowards(transform.position,movimientos[i].transform.position,velocidad* Time.deltaTime);

        if (Vector2.Distance(transform.position, movimientos[i].transform.position) < 0.5f) //comprobamos que la distancia sea menor que 0.2f
        {
          
                if(movimientos[i]!=movimientos[movimientos.Length - 1]) //si tenemos mas puntos a los que ir vamos
                {
                    i++;
                }
                else //si no tenemos vamos al primero
                {
                    i = 0;
                }
         
        }
        comprobamosDireccionEnemigo();
    
        
    }

   

    IEnumerator comprobamosDireccionEnemigo() //corrutina
    {
        posicionActual = transform.position;
        //utlizamos esta función en vez de update para que no esté continuamente comprobando cual es la dirección del enemigo y ahorrar recursos
        yield return new  WaitForSeconds(0.5f); //hacemos que se haga cada 0.5 segundos la consulta

        if(transform.position.x > posicionActual.x) //si la posicion recogida es mayor que la actual significa que se tiene que dar la vuelta 

        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }


    }
}
