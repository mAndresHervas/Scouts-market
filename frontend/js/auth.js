document.getElementById("loginForm").addEventListener("submit", async (e) => {
  e.preventDefault();

  const email = document.getElementById("email").value;
  const password = document.getElementById("password").value;

  try {
    const response = await fetch("http://localhost:5000/api/auth/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ email, password }),
    });

    const data = await response.json();

    if (!response.ok) throw new Error(data.message || "Error al iniciar sesión");

    localStorage.setItem("token", data.token);
    window.location.href = "dashboard.html";
  } catch (err) {
    document.getElementById("errorMsg").textContent = err.message;
  }
});
