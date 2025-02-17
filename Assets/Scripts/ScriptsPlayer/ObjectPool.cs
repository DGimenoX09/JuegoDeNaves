using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objetoPrefab; // Prefab del objeto a poolar
    public int cantidadInicial = 10; // Cantidad inicial de objetos en el pool

    private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();

        // Inicializar el pool
        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject obj = Instantiate(objetoPrefab);
            obj.SetActive(false); // Desactivar el objeto al inicio
            pool.Add(obj);
        }
    }

    public GameObject ObtenerObjeto()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Si no hay objetos disponibles, puedes optar por crear mas
        GameObject nuevoObj = Instantiate(objetoPrefab);
        pool.Add(nuevoObj);
        return nuevoObj;
    }

    public void DevolverObjeto(GameObject obj)
    {
        obj.SetActive(false);
    }
}
