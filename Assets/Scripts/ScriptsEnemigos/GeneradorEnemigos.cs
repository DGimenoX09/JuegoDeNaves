using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public EnemyPool enemyPool; // Referencia al pool de enemigos
    public float tiempoGeneracion = 2f; // Tiempo entre generaciones
    public Vector2 rangoGeneracion; // Rango de generación en el eje X

    private void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0f, tiempoGeneracion);
    }

    void GenerarEnemigo()
    {
        GameObject enemigo = enemyPool.ObtenerEnemigo();
        if (enemigo != null)
        {
            // Establecer la posición de generación aleatoria en el rango especificado
            float x = Random.Range(rangoGeneracion.x, rangoGeneracion.y);
            enemigo.transform.position = new Vector3(x, transform.position.y, 0);
            enemigo.SetActive(true); // Asegúrate de activar el enemigo
        }
    }
}