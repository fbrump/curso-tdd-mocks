namespace Leiloes.Servico
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Infra;
    using Leiloes.Dominio;

    public class Avaliador
    {
        public virtual double maiorValor { get; private set; }
        public virtual double menorValor { get; private set; }
        private List<Lance> maiores;

        public Avaliador()
        {
            maiorValor = Double.MinValue;
            menorValor = Double.MaxValue;
        }

        public void Avalia(Leilao leilao)
        {
            if (leilao.lances.Count == 0)
            {
                throw new Exception("O leilao nao possui lances");
            }

            foreach (var l in leilao.lances)
            {
                if (l.valor > maiorValor)
                {
                    maiorValor = l.valor;
                }
                if (l.valor < menorValor)
                {
                    menorValor = l.valor;
                }
            }

            tresMaiores(leilao);
        }

        private void tresMaiores(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.lances.OrderByDescending(x => x.valor));
            maiores = maiores.GetRange(0, maiores.Count < 3 ? maiores.Count : 3);

        }

    }
}