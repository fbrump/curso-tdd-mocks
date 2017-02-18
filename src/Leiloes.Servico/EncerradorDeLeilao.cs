namespace Leiloes.Servico
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Infra;
    using Leiloes.Dominio;

    /// <summary>
    /// CLasse that container all business of the fineshed of auctions.
    /// </summary>
    public class EncerradorDeLeilao
    {
        /// <summary>
        /// Variable for repository of auctions.
        /// </summary>
        private RepositorioDeLeiloes dao;
        /// <summary>
        /// Variable for mail service.
        /// </summary>
        private Carteiro carteiro;

        /// <summary>
        /// Total
        /// </summary>
        /// <returns>Total</returns>
        public int Total { get; set; }

        /// <summary>
        /// Constructor for class.
        /// <paramref name="dao">Repository will work in service.</paramref>
        /// <paramref name="carteiro">Mail serivce will used in service.</paramref>
        /// </summary>
        public EncerradorDeLeilao(RepositorioDeLeiloes dao, Carteiro carteiro)
        {
            Total = 0;
            this.dao = dao;
            this.carteiro = carteiro;
        }

        /// <summary>
        /// Method for fineshed Aucton
        /// </summary>
        public void Encerra()
        {
            List<Leilao> todosLeiloesCorrentes = dao.Correntes();

            foreach (var l in todosLeiloesCorrentes)
            {
                if (ComecouSemanaPassada(l)){
                    try
                    {
                        l.encerra();
                        Total++;
                        dao.Atualiza(l);
                    }
                    catch (Exception e)
                    {
                        // Save one log
                        Console.WriteLine(e);
                        //throw;
                    }
                }
            }

        }

        /// <summary>
        /// Method verify if starting last week.
        /// </summary>
        /// <param name="leilao">Aucton</param>
        /// <returns>Starting last week true; else false</returns>
        private bool ComecouSemanaPassada(Leilao leilao)
        {
            return DiasEntre(leilao.data, DateTime.Now) >= 7;
        }

        /// <summary>
        /// Method return count days between start and end range date.
        /// </summary>
        /// <param name="inicio">Start date</param>
        /// <param name="fim">End date</param>
        /// <returns>Count days</returns>
        private int DiasEntre(DateTime inicio, DateTime fim)
        {
            /// Quantidade de dias.
            int dias = (int)(fim - inicio).TotalDays;

            return dias;
        }
    }
}