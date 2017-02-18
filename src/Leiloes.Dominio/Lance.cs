namespace Leiloes.Dominio
{
    using System;
    public class Lance
    {
        public Usuario usuario {get ; private set; }
        public double valor {get; private set;}
        public int id {get; private set;}


        public Lance(Usuario usuario, double valor)
        {
            this.usuario = usuario;
            this.valor = valor;
        }
    }
}