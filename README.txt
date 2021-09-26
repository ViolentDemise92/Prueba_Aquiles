1. Asegurarse de que Docker Desktop está abierto.
2. Abrir PowerShell e ir a la ruta donde se encuentra el proyecto. Ejemplo:
	D:/Proyectos/Prueba/Prueba
3. docker build -t prueba . 
	Esperar a que haga build
4. docker run -p 8080:80 prueba
	No cerrar la terminal
5. Acceder a un navegador e ir a localhost:8080/app
6. Para probar los ejercicios, simplemente hay que poner una cadena en el input del recuadro de ejercicio correspondiente y clicar a calcular. El resultado aparece en el recuadro de respuesta de cada ejercicio.