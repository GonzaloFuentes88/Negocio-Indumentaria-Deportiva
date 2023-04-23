/*!
    * Start Bootstrap - SB Admin v7.0.7 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2023 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }


    // Selecciona todas las filas seleccionables
    const filasSeleccionables = document.querySelectorAll('.fila-seleccionable');

    // Itera sobre cada fila seleccionable
    filasSeleccionables.forEach((fila) => {
        // Agrega un evento de clic a cada fila
        fila.addEventListener('click', () => {
            // Remueve la clase "fila-seleccionada" de todas las filas seleccionables
            filasSeleccionables.forEach((fila) => {
                fila.classList.remove('fila-seleccionada');
            });

            // Agrega la clase "fila-seleccionada" a la fila seleccionada
            fila.classList.add('fila-seleccionada');
        });
    });

});
