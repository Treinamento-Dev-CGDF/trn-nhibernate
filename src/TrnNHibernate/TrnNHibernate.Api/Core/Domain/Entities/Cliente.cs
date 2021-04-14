using System;

namespace TrnDotnetDataAccess.Entidades
{
    public class Cliente
    {
       
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public Cliente(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        public void Atualizar(string nome,string email)
        {          
            Nome = nome;
            Email = email;
        }

    }
}
