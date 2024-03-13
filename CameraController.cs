using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player; // Referencia al GameObject del jugador
    private Vector3 offset; // Distancia entre la cámara y el jugador

    void Start() {
        offset = transform.position - player.transform.position; // Calcular la posición inicial de la cámara en relación al jugador
    }

    void LateUpdate() {
        // Mantener la misma distancia entre la cámara y el jugador
        transform.position = player.transform.position + offset; // Actualizar la posición de la cámara basada en la posición del jugador
    }
}
