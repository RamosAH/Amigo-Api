namespace Amigos_Api.Models {
    public class Amigo {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Dtaniversario { get; set; }

        public Amigo() { }

        public Amigo(string nome,string sobrenome, string email, string telefone, DateTime dtaniversario) {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Telefone = telefone;
            Dtaniversario = dtaniversario;
        }
    }
}
