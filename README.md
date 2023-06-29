# Tp_Final_PA
Trabajo práctico final de la materia Programación Avanzada del Instituto Balseiro. 
Realizado por [Lucas Díaz](https://github.com/LucasD1az), [Lucas Andrés Sobehart](https://github.com/sobluc) y [Marco Madile Hjelt](https://github.com/MarcoMadile).

## Modo de uso 
Para ejecutar el programa se debe correr el archivo Sokoban\src\main\Program.fs con el comando "dotnet run". 

### Objetivo del juego 
El objetivo del juego es mover las cajas ("#") hacia los objetivos ("o"). Para mover las cajas se debe empujarlas con el personaje (">"). Cuando una caja está en un objetivo, ésta cambia de apariencia ("x") y cuando un personaje está sobre el objetivo cambia de apariencia ("^"). Un nivel termina cuando todas las cajas están sobre los objetivos.

### Comandos 
- "w" para moverse hacia arriba
- "s" para moverse hacia abajo
- "a" para moverse hacia la izquierda
- "d" para moverse hacia la derecha
- "q" para abandonar el juego
- "r" para reiniciar el nivel
- "c" para cambiar de nivel

### Niveles 
Los niveles se encuentran en la carpeta Sokoban\src\main\levels, en el menú inicial se puede elegir el nivel que se desea jugar. Esta versión del juego cuenta con 10 niveles y un nivel tutorial.
Para cada nivel, existe una tabla de puntuación que guarda los puntajes de los ganadores del juego. Se muestra al ganar el nivel, además de agregar el nuevo puntaje. Esta tabla es propia del dispositivo y no está ordenada de mayor a menor.
