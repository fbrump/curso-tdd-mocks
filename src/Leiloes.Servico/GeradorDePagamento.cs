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

        public GeradorDePagamento(LeilaoDaoFalso leilaoDao, Avaliador avaliador, PagamentoDao pagamentoDao)
        {
            this.leilaoDao = leilaoDao;
            this.avalidaor = avaliador;
            this.pagamentoDao = pagamentoDao;
        }

        public virtual void Gera()
        {
            IList<Leilao> encerrados = leilaoDao.Encerrados();

            foreach (var l in encerrados)
            {
                this.avalidaor.Avalia(l);
                Pagamento pagamento = new Pagamento(this.avalidaor.maiorValor, DateTime.Today);
                this.pagamentoDao.Salvar(pagamento);
            }
        }
    }
}