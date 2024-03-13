using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb; // Referencia al componente Rigidbody del jugador
    private float movementX; // Almacena la entrada de movimiento horizontal
    private float movementY; // Almacena la entrada de movimiento vertical
    public float movementSpeed = 0; // Velocidad de movimiento del jugador

    private int scoreCount; // Contador de puntuación
    private TiempoReal tiempoReal; // Referencia al script de tiempo real

    void Start() {
        rb = GetComponent<Rigidbody>(); // Obtener el Rigidbody del jugador
        scoreCount = 0; // Inicializar el contador de puntuación
        tiempoReal = GameObject.Find("TiempoReal").GetComponent<TiempoReal>(); // Obtener el script de tiempo real
    }

    void FixedUpdate() {
        // Aplicar la fuerza de movimiento al jugador
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); // Calcular el vector de movimiento
        rb.AddForce(movement * movementSpeed); // Aplicar la fuerza de movimiento al jugador
    }

    // Método para manejar la entrada de movimiento
    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>(); // Obtener el vector de movimiento desde la entrada
        movementX = movementVector.x; // Actualizar la entrada de movimiento horizontal
        movementY = movementVector.y; // Actualizar la entrada de movimiento vertical
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) { // Verificar si el jugador colisiona con un objeto recolectable
            other.gameObject.SetActive(false); // Desactivar el objeto recolectable
            scoreCount++; // Incrementar la puntuación
            tiempoReal.ActualizarPuntos(scoreCount); // Enviar la nueva puntuación al servidor
        }
    }
}
