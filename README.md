Hola Raúl,
te cuento un poco qué he implementado.

Tengo 1 arma, disparo automático. La forma de programarla permite crear otras fácilmente con un script propio que las identifique (por si tuviesen algun comportamiento extra a parte del general de Weapon) y con un sriptable object que le da propiedades.


Tengo tamibén un objeto de habilidad, solo que no se puede obtener mediante gameplay porque no lo he programado. Pero si se lo asignas a la lista de AbilityItems del playerStats en el player, se incrementa la velocidad del jugador.


He hecho un prop de una caja que se rompe y te da el objeto que le digas en el dropRateManager.

He hecho 2 tipos de enemigos con dos "niveles". 

Hay un gestor de hordas que:
 - spawnea un enemigo de cada tipo si es posible
 - se generan cada X tiempo (cada oleada es configurable)
 - tiene un límite de enemigos en pantalla
 - perdí mucho tiempo intentando hacer pooling para reutilizar en vez de spawnear y destruir, pero me puse con el nuevo sistema de ObjectPooling (https://docs.unity3d.com/ScriptReference/Pool.ObjectPool_1-ctor.html) y perdí un día :')
 - Si ya se han spawneado todos los enemigos de una horda, hace que empiece la siguiente con el tiempo de spawn de la siguiente. Así    no spawnean de golpe los últimos de la anterior y los de la que estás ahora.

Los enemigos te quitan vida, pero no se refleja.

Los enemigos al morir también dropean objetos de experiencia o vida. Los dos funcionan.

La UI es algo simple pero también refleja el arma que tienes. Debería reflejarse la habilidad también pero no he llegado a probarlo.

Todos los elementos de juego son configurables via ScriptableObjects

Solo he usado inputs de movimiento con WASD. Está un input de testeo que es la barra espaciadora, pero no hace nada.

Y hoy lunes 21, he usado el día entero para un sistema de leveleo de las habilidades. Es lo que peor está hecho, pero funciona. Quería hacer algo rápido pero al final se me ha ido el día entero.

Diría que eso es todo.

Gracias por la oportunidad y me lo he pasado muy bien haciendo la prueba. Tengo ganas de seguir haciendo el juego y a ver si consigo darle cara y ojos para algo de porfolio.

Saludos!
Ian Dorado.

