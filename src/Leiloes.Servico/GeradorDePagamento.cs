namespace Leiloes.Servico
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Infra;
    using Leiloes.Dominio;

    public class GeradorDePagamento
    {
        private LeilaoDaoFalso leilaoDao;
        private Avaliador avalidaor;
        private PagamentoDao pagamentoDao;
        private Relogio relogio;

        public GeradorDePagamento(LeilaoDaoFalso leilaoDao, Avaliador avaliador, PagamentoDao pagamentoDao, Relogio relogio)
        {
            this.leilaoDao = leilaoDao;
            this.avalidaor = avaliador;
            this.pagamentoDao = pagamentoDao;
            this.relogio = relogio;
        }

        public GeradorDePagamento(LeilaoDaoFalso leilaoDao, Avaliador avaliador, PagamentoDao pagamentoDao)
            : this(leilaoDao, avaliador, pagamentoDao, new RelogioDoSistema())
        {
            
        }

        public virtual void Gera()
        {
            IList<Leilao> encerrados = leilaoDao.Encerrados();

            foreach (var l in encerrados)
            {
                this.avalidaor.Avalia(l);
                Pagamento pagamento = new Pagamento(this.avalidaor.maiorValor, this.ProximoDiaUtil());
                this.pagamentoDao.Salvar(pagamento);
            }
        }

        private DateTime ProximoDiaUtil()
        {
            DateTime data = this.relogio.Hoje();
            DayOfWeek diaDaSemana = data.DayOfWeek;

            if (diaDaSemana == DayOfWeek.Saturday)
            {
                data = data.AddDays(2);
            }
            else if (diaDaSemana == DayOfWeek.Sunday)
            {
                data = data.AddDays(1);
            }

            return data;
        }
    }
}