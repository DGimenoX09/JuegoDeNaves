using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private float velocidad;
    private float tiempoVida;

    public void Iniciar(float velocidadDisparo, float tiempoVidaProyectil)
    {
        velocidad = velocidadDisparo;
        tiempoVida = tiempoVidaProyectil;
        Invoke("Destruir", tiempoVida); // Destruir el proyectil después de un tiempo
    }

    void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime); // Mover el proyectil hacia arriba
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemigo")) // Asegúrate de que tus enemigos tengan la etiqueta "Enemigo"
        {
            Debug.Log("Impacto con enemigo: " + col.gameObject.name);
        // Devolver el proyectil al pool
            // Devolver el proyectil al pool
            FindObjectOfType<ObjectPool>().DevolverObjeto(gameObject);

            // Devolver el enemigo al pool
            FindObjectOfType<EnemyPool>().DevolverEnemigo(col.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // Devolver el proyectil al pool si sale de la cámara
        FindObjectOfType<ObjectPool>().DevolverObjeto(gameObject);
    }

    void Destruir()
    {
        // Devolver el proyectil al pool
        FindObjectOfType<ObjectPool>().DevolverObjeto(gameObject);
    }
}