using UnityEngine;

public class LimiteMovimientoNave : MonoBehaviour
{
    public float limiteIzquierdo = -5.2f; // Limite izquierdo
    public float limiteDerecho = 5.2f; // Limite derecho
    public float limiteSuperior = 4f; // Limite superior (si es necesario)
    public float limiteInferior = -4f; // Limite inferior (si es necesario)

    void Update()
    {
        // Limitar la posicion de la nave
        float x = Mathf.Clamp(transform.position.x, limiteIzquierdo, limiteDerecho);
        float y = Mathf.Clamp(transform.position.y, limiteInferior, limiteSuperior);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}