using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Threading.Tasks;

public class TiempoReal : MonoBehaviour {
    private FirebaseApp app; // Instancia de la aplicación de Firebase
    private FirebaseDatabase db; // Instancia de la base de datos de Firebase
    private DatabaseReference refClientes; // Referencia a la colección de jugadores
    private DatabaseReference refPickUp; // Referencia a la colección de PickUps
    private string userId; // ID único del jugador
    private DatabaseReference refUser; // Referencia al nodo del jugador
    private bool refUserCreated = false; // Indica si el nodo del jugador ha sido creado

    // Inicialización
    void Start() {
        app = Conexion(); // Realizar la conexión a Firebase
        db = FirebaseDatabase.DefaultInstance; // Obtener la instancia de la base de datos
        refClientes = db.GetReference("Jugadores"); // Obtener la referencia a la colección de jugadores
        refPickUp = db.GetReference("Prefabs"); // Obtener la referencia a la colección de PickUps
        AltaDevice(); // Dar de alta el dispositivo del jugador en la base de datos
        refUser = db.GetReference("Jugadores").Child(userId); // Obtener la referencia al nodo del jugador
        
        // Recoger las posiciones de los elementos y posicionarlos en el juego al inicio
        RecogerYPosicionarElementos();
    }
    
    // Método para recoger posiciones de elementos y posicionarlos en el juego
    void RecogerYPosicionarElementos() {
        refPickUp.GetValueAsync().ContinueWithOnMainThread(task => {
            if(task.IsFaulted) {
                // Manejar error
            } else if(task.IsCompleted) {
                DataSnapshot snapshot = task.Result;
                AñadirPrefabs(snapshot);
            }
        });
    }

    // Métodos para actualizar datos en la base de datos según avance el juego
    public void ActualizarPuntos(int puntos) {
        refUser.Child("Puntos").SetValueAsync(puntos);
    }

    // Actualizar en tiempo real lo que ocurre en el juego
    void Update() {
        // Actualizar la posición del jugador en la base de datos
        Vector3 position = transform.position; // Obtener la posición actual del jugador
        refUser.Child("posicion").SetValueAsync(position);
    }

    // Métodos para la conexión a Firebase y dar de alta el dispositivo del jugador
    FirebaseApp Conexion() {
        // Implementación de la conexión...
    }

    async void AltaDevice() {
        // Implementación de la alta del dispositivo...
    }

    // Otros métodos...

}
