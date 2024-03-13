# Integración de Firebase en Roll a Ball Unity
Para integrar Firebase en el juego "Roll a Ball" de Unity, primero debemos crear una base de datos en Firebase y agregar datos que se utilizarán en el juego.

## Configuración de la Base de Datos en Firebase

Crear una Base de Datos en Firebase:

En la consola de Firebase, creé una base de datos Realtime Database en la que creé dos ramas, una con los prefabs y otra con los jugadores.

## Agregar Datos a la Base de Datos:

Dentro de la base de datos, creé una colección llamada "Prefabs" para almacenar la información de los objetos del juego, principalmente para almacenar su última posición. Todo esto con la intención de que al iniciar el juego cada objeto aparezca en su última posición conocida.
Cada objeto tiene una estructura como esta:

```
Prefabs
  |- p1
  |   |- x: ...
  |   |- y: 0.5
  |   |- z: ...
  |- p2
      |- x: ...
      |- y: 0.5
      |- z: ...
```

Además, creé una colección llamada "Jugadores" para almacenar los datos de los jugadores.
Cada jugador tendrá una estructura como esta:

```
Jugadores
  |- idJugador
  |   |- Puntos: ...
  |   |- Record: ...
  |   |- nombre: "x"
  |   |- posicion: [0, 0.5, 0]
```

## Funciones Agregadas al Juego Roll a Ball
Al integrar Firebase en el juego "Roll a Ball", he agregado nuevas funcionalidades a los scripts originales para manejar la recogida de elementos, actualizar los datos del jugador y gestionar la posición en tiempo real.

__TiempoReal.cs__
### Recoger y Posicionar Elementos:

Al iniciar el juego, recogemos las posiciones de los elementos desde la base de datos y los posicionamos en el juego.
```
void RecogerYPosicionarElementos() {
    // Obtener posiciones de elementos desde Firebase y posicionarlos en el juego
}
```

### Actualizar Puntos del Jugador:

Actualizo los puntos del jugador en la base de datos Firebase.

```
public void ActualizarPuntos(int puntos) {
    // Actualizar puntos del jugador en Firebase
}
```

### Actualizo la Posición en Tiempo Real:

Actualizo la posición del jugador en la base de datos en tiempo real.

```
void Update() {
    // Actualizar posición del jugador en Firebase en tiempo real
}
```

__PlayerController.cs__
### Recoger Elementos y Actualizar Puntos:
Cuando el jugador colisiona con un objeto recolectable, lo recoge y actualiza los puntos en Firebase.

```
void OnTriggerEnter(Collider other) {
    // Si el jugador colisiona con un objeto recolectable, recogerlo y actualizar puntos en Firebase
}
```

Con estas adiciones, el juego "Roll a Ball" ahora puede interactuar con Firebase para proporcionar nuevas funcionalidade y mejoras.
