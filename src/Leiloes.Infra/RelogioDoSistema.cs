namespace Leiloes.Infra
{
    using System;
    public class RelogioDoSistema : Relogio
    {
        public DateTime Hoje()
        {
            return DateTime.Today;
        }
    }
}