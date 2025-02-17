using UnityEngine;

public class NaveMovimiento : MonoBehaviour
{
    public float velocidad = 15f; 

    void Update()
    {
        
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float limiteIzquierdo = -8f; 
        float limiteDerecho = 8f; 

        
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, 0) * velocidad * Time.deltaTime;
        transform.position += movimiento;

       
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limiteIzquierdo, limiteDerecho),
            transform.position.y,
            transform.position.z
        );
    }
}