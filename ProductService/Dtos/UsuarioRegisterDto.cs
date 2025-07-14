namespace ProductService.Dtos
{
    public class UsuarioRegisterDto
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }  // En texto plano, se hashea en backend
        public string TipoUsuario { get; set; } // 'Individual', 'Grupo', 'Rama'
    }
}
