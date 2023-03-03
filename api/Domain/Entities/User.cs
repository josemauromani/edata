namespace Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cpf { get; private set; }
        public string DataNascimento { get; private set; }

        public User(string nome, string sobrenome, string cpf, string dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }


        public void Update(string nome, string sobrenome, string cpf, string dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
    }
}
