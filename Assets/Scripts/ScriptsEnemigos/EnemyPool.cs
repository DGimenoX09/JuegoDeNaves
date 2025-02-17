using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemigoPrefab; // Prefab del enemigo a poolar
    public int cantidadInicial = 10; // Cantidad inicial de enemigos en el pool

    private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();

        // Inicializar el pool
        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject obj = Instantiate(enemigoPrefab);
            obj.SetActive(false); // Desactivar el objeto al inicio
            pool.Add(obj);
        }
    }

    public GameObject ObtenerEnemigo()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Si no hay enemigos disponibles, puedes optar por crear mas
        GameObject nuevoEnemigo = Instantiate(enemigoPrefab);
        pool.Add(nuevoEnemigo);
        return nuevoEnemigo;
    }

    public void DevolverEnemigo(GameObject obj)
    {
        obj.SetActive(false);
    }
}