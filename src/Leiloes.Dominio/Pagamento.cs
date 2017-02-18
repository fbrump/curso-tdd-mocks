namespace Leiloes.Dominio
{
    using System;
    public class Pagamento
    {
        public double valor { get; private set; }
        public DateTime data { get; private set; }

        public Pagamento(double valor, DateTime data)
        {
            this.valor = valor;
            this.data = data;
        }
    }
}