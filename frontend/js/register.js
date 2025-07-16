document.getElementById("registerForm").addEventListener("submit", async (e) => {
  e.preventDefault();

  const Nombre = document.getElementById("nombre").value;
  const Email = document.getElementById("email").value;
  const Contrasena = document.getElementById("ContrasenaHash").value;
  const TipoUsuario = document.getElementById("TipoUsuario").value;

  try {
    const response = await fetch("http://localhost:5200/api/usuarios/register", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        Nombre,
        Email,
        Contrasena,
        TipoUsuario
      }),
    });

    const data = await response.text(); // Puede no ser JSON

    if (!response.ok) throw new Error("Error al registrar");

    alert("Registro exitoso, ahora inicia sesión");
    window.location.href = "login.html";
  } catch (err) {
    document.getElementById("errorMsg").textContent = err.message;
  }
});
