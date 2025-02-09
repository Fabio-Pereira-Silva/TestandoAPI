namespace TestandoAPI.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Sex { get; set; }
        public object Email { get; internal set; }
    }
}
