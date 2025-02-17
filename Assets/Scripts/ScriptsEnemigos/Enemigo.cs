using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento del enemigo
    public float tiempoVida = 5f; // Tiempo de vida del enemigo
    

    private void OnEnable()
    {
        // Reiniciar el tiempo de vida del enemigo
        Invoke("Destruir", tiempoVida);
    }

    void Update()
    {
        // Mover el enemigo hacia abajo
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Proyectil")) // Asegúrate de que tus proyectiles tengan la etiqueta "Proyectil"
        {
            // Devolver el enemigo al pool
            FindObjectOfType<EnemyPool>().DevolverEnemigo(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // Devolver el enemigo al pool si sale de la cámara
        FindObjectOfType<EnemyPool>().DevolverEnemigo(gameObject);
    }

    void Destruir()
    {
        // Devolver el enemigo al pool
        FindObjectOfType<EnemyPool>().DevolverEnemigo(gameObject);
    }
}