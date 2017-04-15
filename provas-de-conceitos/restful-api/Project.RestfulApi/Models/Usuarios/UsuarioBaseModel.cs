namespace Project.RestfulApi.Models.Usuarios
{
    public abstract class UsuarioBaseModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}