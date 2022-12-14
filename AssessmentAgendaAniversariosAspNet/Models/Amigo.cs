namespace AssessmentAgendaAniversariosAspNet.Models
{
    public class Amigo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime Aniversario { get; set; }

        public Amigo() { }

        public Amigo(int id, string nome, string sobrenome, DateTime aniversario)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Aniversario = aniversario;
        }

        public static List<Amigo> ListaAniversariantes = new List<Amigo>();

        public int DiasAteAniversario()
        {
            DateTime hoje = DateTime.Today;

            DateTime proximoAniversario = new DateTime(hoje.Year, (int)Aniversario.Month, (int)Aniversario.Day);

            if (proximoAniversario < hoje)
            {
                proximoAniversario = proximoAniversario.AddYears(1);
            }

            return proximoAniversario.Subtract(hoje).Days;
        }
    }
}
