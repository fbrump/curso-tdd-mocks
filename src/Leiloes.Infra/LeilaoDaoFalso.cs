namespace Leiloes.Infra
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Dominio;

    /// <summary>
    /// Class that implement all methods for auctions repository (DAL)
    /// </summary>
    public class LeilaoDaoFalso : RepositorioDeLeiloes
    {
        /// <summary>
        /// database fake
        /// </summary>
        private static List<Leilao> leiloes = new List<Leilao>();
        
        /// <inheritdoc/>
        public void Salva(Leilao leilao)
        {
            leiloes.Add(leilao);
        }

        /// <inheritdoc/>
        public virtual List<Leilao> Encerrados()
        {
            List<Leilao> filtrados = new List<Leilao>();
            foreach (var l in leiloes)
            {
                if (l.encerrado) filtrados.Add(l);
            }

            return filtrados;
        }

        /// <inheritdoc/>
        public virtual List<Leilao> Correntes()
        {
            List<Leilao> correntes = new List<Leilao>();
            foreach (var l in leiloes)
            {
                if (!l.encerrado) correntes.Add(l);
            }

            return correntes;
        }

        /// <inheritdoc/>
        public virtual void Atualiza(Leilao leilao) { }
    }
}