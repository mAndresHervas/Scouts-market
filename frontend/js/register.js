document.getElementById("registerForm").addEventListener("submit", async (e) => {
  e.preventDefault();

  const nombre = document.getElementById("nombre").value;
  const email = document.getElementById("email").value;
  const password = document.getElementById("password").value;
  const tipoUsuario = document.getElementById("tipoUsuario").value;

  try {
    const response = await fetch("http://localhost:8000/frontend/register.html", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ nombre, email, password, tipoUsuario }),
    });

    const data = await response.json();

    if (!response.ok) throw new Error(data.message || "Error al registrar");

    alert("Registro exitoso, ahora inicia sesión");
    window.location.href = "login.html";
  } catch (err) {
    document.getElementById("errorMsg").textContent = err.message;
  }
});
