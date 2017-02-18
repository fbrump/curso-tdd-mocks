namespace Leiloes.Servico
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Infra;
    using Leiloes.Dominio;

    public class EncerradorDeLeilao
    {
        /// <summary>
        /// Total
        /// </summary>
        /// <returns>Total</returns>
        public int Total { get; set; }

        /// <summary>
        /// Constructor for class.
        /// </summary>
        public EncerradorDeLeilao()
        {
            Total = 0;
        }

        /// <summary>
        /// Method for fineshed Aucton
        /// </summary>
        public void Encerra()
        {
            LeilaoDaoFalso dao = new LeilaoDaoFalso();
            List<Leilao> todosLeiloesCorrentes = dao.Correntes();

            foreach (var l in todosLeiloesCorrentes)
            {
                if (ComecouSemanaPassada(l)){
                    l.encerra();
                    Total++;
                    dao.Atualiza(l);
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