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
