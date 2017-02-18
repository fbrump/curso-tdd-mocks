namespace Leiloes.Infra
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Dominio;

    public class LeilaoDaoFalso
    {
        private static List<Leilao> leiloes = new List<Leilao>();

        public void Salva(Leilao leilao)
        {
            leiloes.Add(leilao);
        }

        public virtual List<Leilao> Encerrados()
        {
            List<Leilao> filtrados = new List<Leilao>();
            foreach (var l in leiloes)
            {
                if (l.encerrado) filtrados.Add(l);
            }

            return filtrados;
        }

        public virtual List<Leilao> Correntes()
        {
            List<Leilao> correntes = new List<Leilao>();
            foreach (var l in leiloes)
            {
                if (!l.encerrado) correntes.Add(l);
            }

            return correntes;
        }

        public virtual void Atualiza(Leilao leilao) { }
    }
}