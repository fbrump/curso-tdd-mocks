namespace Leiloes.Infra
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Dominio;

    public class LeilaoDaoFalso
    {
        public List<Leilao> Correntes()
        {
            return new List<Leilao>();
        }

        public void Atualiza(Leilao leilao)
        {

        }
    }
}