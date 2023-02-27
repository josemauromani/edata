namespace Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string DataNascimento1 { get; }

        public User(string nome, string sobrenome, string cpf, DateTime dataNascimento)
        {
        }

        public User(string nome, string sobrenome, string cpf, string dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento1 = dataNascimento;
        }
    }
}
