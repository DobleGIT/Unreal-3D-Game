using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //esto lo usamos para resetear la escena
using UnityEngine.Audio; //lo utilizamos para el sonido


public class Respawn : MonoBehaviour
{
    private float posX = -6.76f; //estas variables es donde queremos que el jugador respawne
    private float posY = -1.09f;
    public Animator animator;
    public AudioSource audioMuerte;
    // Start is called before the first frame update
    void Start()
    {
  
        transform.position = (new Vector2(posX,posY));
    }

    public void MurioJugador()
    {
        audioMuerte.Play();
        animator.Play("hurt");
        StartCoroutine(retardoMuerte()); //iniciamos la corrutina 
        retardoMuerte();
        
    }
    IEnumerator retardoMuerte() //forma que he visto en google para hacer un wait 
    {
        yield return new WaitForSeconds(0.3f); //hacemos que la muerte tarde para poder ver la animacion del daño
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //con esto reseteamos la escena al morir

    }

}
