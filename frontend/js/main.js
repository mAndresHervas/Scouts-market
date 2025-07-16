document.addEventListener("DOMContentLoaded", () => {
  loadComponent("navbar");
  loadComponent("footer");
});

function loadComponent(id) {
  fetch(`components/${id}.html`)
    .then((res) => res.text())
    .then((html) => {
      document.getElementById(id).innerHTML = html;
    });
}
const usuario = {
    nombre: "Juan",
    correo: "juan@mail.com",
    contraseña: "123456"
};

fetch("http://localhost:5200/api/usuarios/register", {
    method: "POST",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify(usuario)
})
.then(response => response.json())
.then(data => console.log(data))
.catch(error => console.error("Error:", error));