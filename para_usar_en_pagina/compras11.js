const listaDeProductos = document.getElementById('listaDeProductos');

let productos = [];

// Esperar a que el contenido del DOM esté cargado
document.addEventListener("DOMContentLoaded", function() {
  // Inicializar productos con datos de prueba
  for (let i = 0; i < productos_a_mover.length; i++) {
    agregarProducto(productos_a_mover[i].id + "|" + productos_a_mover[i].nombre + "|" + productos_a_mover[i].imagen + "|" + productos_a_mover[i].cantidad + "|" + productos_a_mover[i].precio + "|" + productos_a_mover[i].extra + "|" + productos_a_mover[i].provedor);
  }
  renderizarProductos(productos);
});

function actualizarCantidad(idProducto, cantidad) {
  const producto = buscarProductoPorId(productos, idProducto);
  if (producto) {
    let es_mayor_a_cero = producto.cantidad + cantidad;
    if (es_mayor_a_cero >= 0) {
      producto.cantidad += cantidad;
      producto.total = producto.cantidad * producto.precio; // Actualizar el precio total del producto
      limpiarListaDeProductos();
      fila = document.createElement('div');
      renderizarProductos(productos);
      actualizarPrecioTotal(); // Llamar a la función para actualizar el precio total
    } else {
      producto.cantidad = 0;
      producto.total = producto.cantidad * producto.precio; // Actualizar el precio total del producto
      limpiarListaDeProductos();
      fila = document.createElement('div');
      renderizarProductos(productos);
      actualizarPrecioTotal(); // Llamar a la función para actualizar el precio total
    }
  }
}

function buscarProductoPorId(productos, idProducto) {
  return productos.find(producto => producto.id == idProducto) || null;
}

function limpiarListaDeProductos() {
  while (listaDeProductos.firstChild) {
    listaDeProductos.removeChild(listaDeProductos.firstChild);
  }
  fila = document.createElement('div');
}

function renderizarProductos(productos) {
  listaDeProductos.innerHTML = '';
  let j = 0;
  for (let i = 0; i < productos.length; i++) {
    const { id, nombre, imagen, cantidad, precio, extra, total, provedor } = productos[i];
    if (j > 1) {
      renderizarProducto(id, nombre, imagen, cantidad, precio, extra, total, provedor, true);
      j = 0;
    } else {
      renderizarProducto(id, nombre, imagen, cantidad, precio, extra, total, provedor, false);
    }
    j++;
  }
}

let fila = document.createElement('div');
function renderizarProducto(id, nombre, imagen, cantidad, precio, extra, total, provedor, hacerNuevoDiv = false) {
  fila.style.display = 'flex';
  if (hacerNuevoDiv) {
    fila = document.createElement('div');
    fila.style.display = 'flex';
  }

  const productoDiv = document.createElement('div');
  productoDiv.classList.add('producto');

  const img = document.createElement('img');
  img.src = imagen;
  img.addEventListener('click', () => {
    img.classList.toggle('enlarged');
  });
  productoDiv.appendChild(img);

  const nombreElemento = document.createElement('p');
  nombreElemento.textContent = nombre;
  productoDiv.appendChild(nombreElemento);

  const provedorElemento = document.createElement('p');
  provedorElemento.textContent = provedor;
  productoDiv.appendChild(provedorElemento);

  const precioElemento = document.createElement('p');
  precioElemento.textContent = `Precio: $${precio.toFixed(2)}`;
  productoDiv.appendChild(precioElemento);

  const botonMenos = document.createElement('button');
  botonMenos.textContent = '-';
  botonMenos.style.height = '40px';
  botonMenos.style.width = '80px';
  botonMenos.addEventListener('click', () => actualizarCantidad(id, -1));
  productoDiv.appendChild(botonMenos);

  const inputCantidad = document.createElement('input');
  inputCantidad.type = 'number';
  inputCantidad.value = cantidad;
  inputCantidad.addEventListener('input', (event) => {
    const nuevaCantidad = parseInt(event.target.value);
    const producto = buscarProductoPorId(productos, id);
    if (!isNaN(nuevaCantidad) && producto) {
      let res = producto.cantidad + nuevaCantidad;
      if (res > 0) {
        producto.cantidad = nuevaCantidad;
        producto.total = nuevaCantidad * precio;
        actualizarPrecioTotal();
      }
    }
  });
  productoDiv.appendChild(inputCantidad);

  const botonMas = document.createElement('button');
  botonMas.textContent = '+';
  botonMas.style.height = '40px';
  botonMas.style.width = '80px';
  botonMas.addEventListener('click', () => actualizarCantidad(id, 1));
  productoDiv.appendChild(botonMas);

  const inputextra = document.createElement('input');
  inputextra.type = 'text';
  inputextra.value = extra;
  inputextra.addEventListener('input', (event) => {
    const nuevoValorExtra = event.target.value;
    const producto = buscarProductoPorId(productos, id);
    if (producto) {
      producto.extra = nuevoValorExtra;
    }
  });
  productoDiv.appendChild(inputextra);

  const totalElemento = document.createElement('p');
  totalElemento.textContent = `Total: $${total.toFixed(2)}`;
  productoDiv.appendChild(totalElemento);

  fila.appendChild(productoDiv);
  listaDeProductos.appendChild(fila);
}

function agregarProducto(datos) {
  const datosSeparados = datos.split('|');
  
  const nuevoProducto = {
    id: datosSeparados[0],
    nombre: datosSeparados[1],
    imagen: datosSeparados[2],
    cantidad: parseInt(datosSeparados[3]),
    precio: parseFloat(datosSeparados[4]),
    extra: datosSeparados[5],
    total: 0, // Inicializar el precio total en 0
    provedor: datosSeparados[6],
  };

  productos.push(nuevoProducto);
}

let textoPedido = '';
function procesarPedido() 
{
  
  let textoDescripcion = '';
  let precioTotalPedido = 0; // Inicializar el precio total del pedido

  
  for (let i = 0; i < productos.length; i++) {
    const { id, nombre, extra, precio,cantidad, total } = productos[i];
    if (cantidad > 0) {
      //COMP:COD_BAR1&1&200&2&NOM_PRODUCTO_SI_NO_ESTA#COD_BAR1&1&200&2&NOM_PRODUCTO_SI_NO_ESTA:PROVEDOR1
      if(textoPedido==""){
        textoPedido += `${id}&${cantidad}&${precio}&&nom_produc_no_esta`;  
      }
      else{

        textoPedido += `#${id}&${cantidad}&${precio}&&nom_produc_no_esta`;

      }
      
      textoDescripcion += `${id}|${nombre}|${cantidad}|${total}\n`;
      if (extra) {
        textoPedido += `extra: ${extra}~`;
        textoDescripcion += `extra: ${extra}\n`;
      }
      precioTotalPedido += total; // Sumar el precio total del producto al precio total del pedido
    }
  }

  let prov_comp = prompt(`Provedor:`);
  textoPedido = `comp:`+textoPedido+`:`+prov_comp+`:`+`suc12`;
  var elementoUbicacion = document.getElementById("ubicacion");
  var textoUbicacion = elementoUbicacion.value;
  if (textoUbicacion != "") {
    textoPedido = textoPedido + "~ubi:" + textoUbicacion;
  }
  
  // Mostrar el texto del pedido y el precio total en el contenedor de contenido
  document.getElementById('contenido').innerText = textoPedido;
  document.getElementById('infoProducto').innerText = textoDescripcion;
  document.getElementById('precioTotal').innerText = `Precio Total: $${precioTotalPedido.toFixed(2)}`;
}

function copiarContenido() 
{
  var contenidoDiv = document.getElementById('contenido');
  var rangoSeleccion = document.createRange();
  rangoSeleccion.selectNode(contenidoDiv);
  window.getSelection().removeAllRanges();
  window.getSelection().addRange(rangoSeleccion);
  document.execCommand('copy');
  window.getSelection().removeAllRanges();
  textoDescripcion = '';
  alert('Contenido copiado al portapapeles.');
}

document.addEventListener("DOMContentLoaded", function() {
  // Obtener los elementos del DOM
  const buscarProducto = document.getElementById('buscarProducto');
  const buscarPorNombre = document.getElementById('buscarPorNombre');
  const buscarPorProvedor = document.getElementById('buscarPorProvedor');
  const ingresarCantidad = document.getElementById('ingresarCantidad');

  // Filtro por ID de producto
  buscarProducto.addEventListener('input', function(event) {
    limpiarListaDeProductos();

    const idBuscado = parseInt(event.target.value);
    if (!isNaN(idBuscado)) {
      const productosFiltrados = productos.filter(producto => producto.id == idBuscado);
      renderizarProductos(productosFiltrados);
    } else {
      renderizarProductos(productos);
    }
  });

  // Filtro por nombre de producto
  buscarPorNombre.addEventListener('input', function(event) {
    limpiarListaDeProductos();

    const nombreBuscado = event.target.value.toLowerCase();
    const productosFiltrados = productos.filter(producto => producto.nombre.toLowerCase().includes(nombreBuscado));
    renderizarProductos(productosFiltrados);
  });

  // Filtro por proveedor
  buscarPorProvedor.addEventListener('input', function(event) {
    limpiarListaDeProductos();

    const provedorBuscado = event.target.value.toLowerCase();
    const productosFiltrados = productos.filter(producto => producto.provedor.toLowerCase().includes(provedorBuscado));
    renderizarProductos(productosFiltrados);
  });


  // Agregar evento al presionar la tecla "Enter" en el campo de ingresar cantidad
  ingresarCantidad.addEventListener('keydown', function(event) {
    if (event.key === 'Enter') {
      const idProducto = ingresarCantidad.value;
      if (idProducto !== "" && idProducto !== null) {
        const productoEncontrado = buscarProductoPorId(productos, idProducto);
        if (productoEncontrado) {
          const nombreProducto = productoEncontrado.nombre;
          const cantidadProducto = productoEncontrado.cantidad + 1; // Incrementar la cantidad
          
          productoEncontrado.precio = parseFloat(prompt(`Producto: ${productoEncontrado.nombre}\nIntroduce el nuevo PRECIO POR PRODDUCTO para este producto:`));
          
          actualizarCantidad(idProducto, 1); // Incrementar la cantidad del producto correspondiente
          ingresarCantidad.value = ''; // Limpiar el campo de entrada después de incrementar la cantidad
        } else {
                alert('El producto no está en la lista.'); // Mensaje si el producto no está en la lista] if (!productoEncontrado) {
                let nombreProducto = prompt("El código de barras no existe. Ingresa el nombre del producto:");
                let cantidad_contenido = prompt("Ingresa la cantidad contenido:");
                let tipoMedida = prompt("Ingresa el tipo de medida (ej. kg, litros):");
                let cantidad_comprada = prompt("Ingresa la cantidada de productos:");
                let precio_unidad = prompt("Ingresa la precio:");
                
                
                
                
                //COMP:COD_BAR1&1&200&2&NOM_PRODUCTO_SI_NO_ESTA#COD_BAR1&1&200&2&NOM_PRODUCTO_SI_NO_ESTA:PROVEDOR1
                if(textoPedido=="")
                {
                  textoPedido += `${idProducto}&${cantidad_comprada}&${precio_unidad}&&${nombreProducto}&${cantidad_contenido}&${tipoMedida}`;
                }
                else
                {
        
                  textoPedido += `#${idProducto}&${cantidad_comprada}&${precio_unidad}&&${nombreProducto}&${cantidad_contenido}&${tipoMedida}`;
        
                }
                
                
                
                
                
          ingresarCantidad.value = ''; // Limpiar el campo de entrada si el producto no está en la lista
        }
      }
    }
  });

  

});
//localisacion------------------------------------------------------------------------------------------------
async function obtenerUbicacion() {
  if (navigator.geolocation) {
      try {
          const position = await new Promise((resolve, reject) => {
              navigator.geolocation.getCurrentPosition(resolve, reject);
          });
          return `${position.coords.latitude}, ${position.coords.longitude}`;
      } catch (error) {
          console.error("Error al obtener la ubicación:", error);
          throw error;
      }
  } else {
      console.error("La geolocalización no es compatible en este navegador.");
      throw new Error("La geolocalización no es compatible en este navegador.");
  }
}

async function obtenerYMostrarUbicacion() {
  try {
      const ubicacion = await obtenerUbicacion();
      document.getElementById("ubicacion").value = `${ubicacion}`;
  } catch (error) {
      document.getElementById("ubicacion").value = "Error al obtener la ubicación";
  }
}

document.getElementById("obtenerUbicacionBtn").addEventListener("click", obtenerYMostrarUbicacion);

document.getElementById("cargarInventario").addEventListener("click", function() {
  const input = document.createElement('input');
  input.type = 'file';
  input.accept = '.txt'; // Puedes filtrar por tipo de archivo si es necesario
  input.style.display = 'none';

  input.addEventListener('change', function(event) {
      const archivo = event.target.files[0];
      if (archivo) {
          const lector = new FileReader();
          lector.onload = function(e) {
              const contenido = e.target.result;
              procesarInventario(contenido);
          };
          lector.readAsText(archivo);
      }
  });

  document.body.appendChild(input);
  input.click();
  document.body.removeChild(input);
});

function procesarInventario(contenido) {
  const lineas = contenido.split('\n');

  limpiarListaDeProductos();
  for (let i = 1; i < lineas.length; i++) {
      const linea = lineas[i];
      const datos = linea.split('|');
      if (datos.length >= 24) {  // Asegura que la línea tenga el número correcto de campos
          const nuevoProducto = {
              id: datos[5], // cod_barras
              nombre: datos[1], // nombre_producto
              imagen: datos[21], // dir_img_inter
              cantidad: 0, // cantidad
              precio: parseFloat(datos[4]), // precio_venta
              extra: "", // info_extra
              total: 0 // Inicializar el precio total en 0
          };
          productos.push(nuevoProducto);
      }
  }
  renderizarProductos(productos);
}



//fin-localisacion------------------------------------------------------------------------------------------------
function actualizarPrecioTotal() {
  let precioTotal = 0;
  productos.forEach(producto => {
    precioTotal += producto.total;
  });
  document.getElementById('precioTotal').innerText = `Precio Total: $${precioTotal.toFixed(2)}`;
}