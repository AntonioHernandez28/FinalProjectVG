using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardia : MonoBehaviour
{

    // Prefab para inicializar bombas

    public GameObject bombPrefab;


    // Velocidad del guardia 

    public float speed = 1f;


    // Distancia limite para que el guardia cambie de direccion

    public float leftAndRightEdge = 10f;

    // Probabilidad de que el guardia cambie de direccion

    public float chanceToChangeDirections = 0.1f;

    // Frecuencia para soltar bombas

    public float secondsBetweenBombDrops = 1f;


    void Start()
    {
       // Soltar bombas cada segundo
        Invoke("SoltarBomba", 2f);
    }

    void SoltarBomba()
    {                                                  

        GameObject bomb = Instantiate<GameObject>(bombPrefab);      

        bomb.transform.position = transform.position;                  

        Invoke("SoltarBomba", secondsBetweenBombDrops);                

    }

    void Update()
    {

        // Movimiento basico
        Vector3 pos = transform.position;                  

        pos.x += speed * Time.deltaTime;                   

        transform.position = pos;                          

        // LLegano a los limites cambiar
        if (pos.x < -leftAndRightEdge)                     
        {
            speed = Mathf.Abs(speed); // Mover derecha        
        }
        else if (pos.x > leftAndRightEdge)                 
        {
            speed = -Mathf.Abs(speed); // Mover izquierda      
        }

        // Cambiando la direccion
        if (Random.value < chanceToChangeDirections)       
        {                     
            speed *= -1; // Cambiar direccion
        }

    }


}
