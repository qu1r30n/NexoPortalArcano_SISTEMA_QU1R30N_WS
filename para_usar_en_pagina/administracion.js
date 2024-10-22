document.addEventListener('DOMContentLoaded', function () {
    const tabs = document.querySelectorAll('.tab-button');
    const panes = document.querySelectorAll('.tab-pane');

    tabs.forEach(tab => {
        tab.addEventListener('click', function () {
            tabs.forEach(t => t.classList.remove('active'));
            this.classList.add('active');

            const targetPane = document.getElementById(this.dataset.tab);
            panes.forEach(pane => pane.classList.remove('active'));
            if (targetPane) {
                targetPane.classList.add('active');
            } else {
                console.error('No se encontró el pane con el ID: ' + this.dataset.tab);
            }
        });
    });
});



document.addEventListener('DOMContentLoaded', function () {

    const listbox = document.getElementById('listbox');
    const texbox_tex_a_copiar = document.getElementById('texto_a_copiar');




    document.getElementById('boton_agregar').addEventListener('click', function () {
        // Obtener la pestaña activa
        const activeTab = document.querySelector('.tab-pane.active');
        let iframe = null;
    
        // Verificar cuál iframe está en la pestaña activa
        if (activeTab.querySelector('#iframe1')) {
            iframe = document.getElementById('iframe1');
        } else if (activeTab.querySelector('#iframe2')) {
            iframe = document.getElementById('iframe2');
        } else if (activeTab.querySelector('#iframe3')) {
            iframe = document.getElementById('iframe3');
        }
    
        let newOption;
        if (iframe) {
            // Obtener el documento del iframe
            const iframeDocument = iframe.contentDocument || iframe.contentWindow.document;
    
            // Buscar el contenido dentro del iframe
            const contenido = iframeDocument.getElementById('contenido');
            if (contenido) {
                // Si se encuentra el contenido, lo agregamos al listbox
                newOption = contenido.innerText || contenido.textContent;
            } else {
                // Si no se encuentra el contenido, solicitamos al usuario que ingrese manualmente
                newOption = prompt('No se encontró el contenido en el iframe. Ingresa el nuevo valor para agregar:');
            }
        } else {
            // Si no hay iframe en la pestaña activa, pedimos el valor manualmente
            newOption = prompt('No hay un iframe en la pestaña activa. Ingresa el nuevo valor para agregar:');
        }
    
        // Si se ha obtenido un valor (del iframe o del usuario), lo agregamos al listbox
        if (newOption) {
            const option = document.createElement('option');
            option.value = newOption;
            option.textContent = newOption;
            document.getElementById('listbox').appendChild(option);
        }
    });
    






    document.getElementById('boton_eliminar_seleccionado').addEventListener('click', function () {
        Array.from(listbox.selectedOptions).forEach(option => option.remove());
    });

    document.getElementById('boton_eliminar_todos').addEventListener('click', function () {
        listbox.innerHTML = '';
    });

    document.getElementById('boton_eliminar_ultimo').addEventListener('click', function () {
        if (listbox.options.length > 0) {
            listbox.remove(listbox.options.length - 1);
        }
    });

    document.getElementById('boton_copiar').addEventListener('click', function () 
    {
        const options = Array.from(listbox.options).map(option => option.text).join('\n');
                
        // Copia el texto al portapapeles
        navigator.clipboard.writeText(options)
        .then(() => alert('Texto copiado al portapapeles')) // Notifica al usuario que el texto se ha copiado
        .catch(err => alert('Error al copiar texto: ' + err)); // Notifica al usuario si hubo un error


    });




});

