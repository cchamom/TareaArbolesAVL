# Tarea Arboles AVL

<p>
El objetivo de la tarea es implementar el algoritmo de busqueda AVL a la anterior tarea de busqueda por BST

El término AVL hace referencia al árbol AVL (Adelson-Velsky y Landis), que es un tipo de árbol binario de búsqueda auto-balanceado.
</p>
## Características principales de los árboles AVL
### Balance de altura

En un árbol AVL, la diferencia de alturas entre los subárboles izquierdo y derecho de cualquier nodo (conocida como el factor de balance) no puede ser mayor que 1. Si esta diferencia excede 1 después de insertar o eliminar un nodo, el árbol aplica rotaciones para restaurar el balance.

### Operaciones

Las operaciones de búsqueda, inserción y eliminación tienen una complejidad de tiempo porque el árbol siempre se mantiene balanceado.

### Rotaciones

Las rotaciones (**RR, LL, LR, RL**) se utilizan para reequilibrar el árbol cuando hay desbalances. Estas operaciones aseguran que el árbol conserve su eficiencia.

### Ventajas
- Mantiene una alta eficiencia en búsquedas, incluso con grandes conjuntos de datos desordenados.

- Es útil en aplicaciones donde se requiere un acceso rápido y ordenado a los datos.

### Desventajas:
- Puede ser más costoso computacionalmente que un árbol binario de búsqueda simple debido a la necesidad de verificar y realizar rotaciones al insertar o eliminar nodos.

## Diferencias de AVL y BST
BST no asegura el balance del árbol. Puede llegar a desbalancearse, especialmente si los datos se insertan en orden ascendente o descendente, formando una estructura similar a una lista enlazada, en cambio AVL siempre se mantiene balanceado. Garantiza que la diferencia de altura entre los subárboles izquierdo y derecho de cualquier nodo sea como máximo 1.

## Estructura del programa arbolesAVL
- Program.cs
- ArbolAVL.cs
- Nodo.cs


------------

El programa sigue contando con la busqueda InOrden, PortOrden y PreOrden, calcular la altura y el grado del arbol y tambien como quedaria de manera grafica.

#### balance_factor
El factor de equilibrio o balance factor es una medida utilizada en los árboles AVL para determinar si un nodo está balanceado. Este factor indica la diferencia entre la altura del subárbol izquierdo y el subárbol derecho de un nodo. Es crucial para mantener la propiedad de balance del árbol AVL.

### Rotaciones
- LL (Izquierda-Izquierda)
- Rotación RR (Derecha-Derecha)
- Rotación LR (Izquierda-Derecha)
-Rotación RL (Derecha-Izquierda)

### Elminar
Se implementa un metodo para poder eliminar un nodo y el arbol se autobance

El arvol AVL sigue funcionando correctamente para operaciones básicas: inserción, búsqueda y eliminación. Depues de implmentar los metodos requeridos el porgrama corre perfecramente.

## Capturas del la Ejecución
[![Imagen-de-Whats-App-2025-04-04-a-las-15-18-42-ac8f5798.jpg](https://i.postimg.cc/PxJ0WgM1/Imagen-de-Whats-App-2025-04-04-a-las-15-18-42-ac8f5798.jpg)](https://postimg.cc/ygqfBrtN)

[![Imagen-de-Whats-App-2025-04-04-a-las-15-43-58-9cbbde14.jpg](https://i.postimg.cc/6Qt8p0fk/Imagen-de-Whats-App-2025-04-04-a-las-15-43-58-9cbbde14.jpg)](https://postimg.cc/RWpSPw8d)

[![Imagen-de-Whats-App-2025-04-04-a-las-15-45-36-ff15df18.jpg](https://i.postimg.cc/bvyvhvz8/Imagen-de-Whats-App-2025-04-04-a-las-15-45-36-ff15df18.jpg)](https://postimg.cc/4Y0Gvs7F)

[![Imagen-de-Whats-App-2025-04-04-a-las-15-47-14-a188bca4.jpg](https://i.postimg.cc/Y0Wr3GxN/Imagen-de-Whats-App-2025-04-04-a-las-15-47-14-a188bca4.jpg)](https://postimg.cc/CnwpMKXd)

[![Imagen-de-Whats-App-2025-04-04-a-las-15-56-28-f342de0e.jpg](https://i.postimg.cc/fTMWXL9d/Imagen-de-Whats-App-2025-04-04-a-las-15-56-28-f342de0e.jpg)](https://postimg.cc/s10RC3Kf)

------------

# Medición de Tiempos
Para hacer la segunda serie cree una nueva solucion donde usando Stopwatch cree un objeto del mismo nombre para medir cuato duraba cada algoritmo en buscar un dato metido en Ticks. Tambien suse Random para generar 10,000 elementos usando un ciclo for.

Luego usando un foreach insertamos los elementos generados aleatoriamente en un array que alamacenara elemnetos de 1 a 10,000

### Estructura de programa
- Program.cs
- Nodo.cs
- arbolAVL.cs
- arbolBST.cs

Se utiliza la clase Stopwatch para medir el tiempo que toma cada operación:
**Inserción**: Los datos se insertan en un árbol AVL y en un BST, y se mide el tiempo para cada uno.
**Búsqueda**: Se busca un elemento al principio, uno en el medio y uno al final del arreglo en ambos árboles.
**Eliminación**: Se elimina el primer elemento del arreglo y se mide el tiempo que toma en cada árbol.

El programa imprime el tiempo en ticks para cada operación (inserción, búsqueda y eliminación) en ambos tipos de árboles.

La clase Nodo define dos clases principales: Nodo y NodoBST.

En la clase arbolAVL se encuentra el algoritmo para hacer la busqueda AVL y lo mismo pasa en la clase arbolBST con la busqueda binaria.

### Imagenes de la ejecucion
[![Imagen-de-Whats-App-2025-04-04-a-las-16-09-01-09711b4d.jpg](https://i.postimg.cc/nLrsZVJy/Imagen-de-Whats-App-2025-04-04-a-las-16-09-01-09711b4d.jpg)](https://postimg.cc/WDRpwvt8)


------------

# Analisis de Resultados
#### Expliquen con sus propias palabras por qué el árbol AVL tiende a ser más rápido en operaciones de búsqueda, especialmente con grandes volúmenes de datos.

- A diferencia del BST, el AVL garantiza que la diferencia de alturas entre los subárboles izquierdo y derecho de cada nodo nunca sea mayor que 1. Esto asegura que el árbol se mantenga balanceado y las búsquedas tengan una complejidad constante de O(log n).

#### ¿En qué casos notaron más diferencia?
- Cuando hay varios datos a analizar como en este caso fueron 10,000 el AVL es mucho mas eficiente que BST por mantener un balanceo de manera automatica.

####  ¿Hubo operaciones donde el BST fue más rápido? ¿Por qué podría haber ocurrido?
- Se podria usar cuando los datos ya estan ordenados o con una cantidad mucho menor que la vista ya que no seria necesario de operaciones mas complejas.
