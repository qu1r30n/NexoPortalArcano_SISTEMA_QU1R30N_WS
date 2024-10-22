<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Obteniendo IP del Cliente</title>
    <script>
        // Función para realizar la petición a la API de PHP
        function obtenerIP() {
            fetch("/dameip.php?user=user&pass=1234", { method: "POST" })
                .then(response => {
                    if (response.ok) {
                        console.log("IP obtenida y guardada exitosamente");
                    } else {
                        console.error("Error al obtener la IP");
                    }
                });
        }

        // Llamar a la función cada 5 minutos (300,000 milisegundos)
        setInterval(obtenerIP, 300000);

        // Llamar a la función inmediatamente cuando se carga la página
        window.onload = obtenerIP;
    </script>
</head>
<body>
    <h1>Obteniendo IP del cliente...</h1>
</body>
</html>
