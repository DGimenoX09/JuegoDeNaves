using UnityEngine;

public class DisparoNave : MonoBehaviour
{
    public ObjectPool pool; // Referencia al pool de objetos
    public float velocidadDisparo = 10f; // Velocidad del proyectil
    public float tiempoVida = 2f; // Tiempo de vida del proyectil

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Cambia la tecla si es necesario
        {
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject proyectil = pool.ObtenerObjeto();
        if (proyectil != null)
        {
            proyectil.transform.position = transform.position; // Posicionar el proyectil en la nave
            proyectil.transform.rotation = transform.rotation; // Asegurarse de que el proyectil tenga la misma rotacion

            // Iniciar el movimiento del proyectil
            proyectil.GetComponent<Proyectil>().Iniciar(velocidadDisparo, tiempoVida);
        }
    }
}