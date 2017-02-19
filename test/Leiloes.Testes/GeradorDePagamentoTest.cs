namespace Leiloes.Testes
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Dominio;
    using Leiloes.Servico;
    using Leiloes.Infra;
    using Xunit;
    using Moq;

    public class GeradorDePagamentoTest
    {
        [Fact]
        public void Should_generator_payment_for_throw_fineshed()
        {
            //Given
            var leilaoDao = new Mock<LeilaoDaoFalso>();
            var avaliador = new Mock<Avaliador>();
            var pagaemntoDao = new Mock<PagamentoDao>();

            Leilao leilao1 = new Leilao("Playstation");
            leilao1.naData(new DateTime(1999, 5, 5));

            //When
            leilao1.propoe(new Lance(new Usuario("Renan"), 500));
            leilao1.propoe(new Lance(new Usuario("Felipe"), 600));

            List<Leilao> listaDeLeiloes = new List<Leilao>();

            listaDeLeiloes.Add(leilao1);
            
            leilaoDao.Setup(l => l.Encerrados())
                .Returns(listaDeLeiloes);
            
            avaliador.Setup(a => a.maiorValor)
                .Returns(600);

            Pagamento pagemntoCapturado = null;
            pagaemntoDao.Setup(p => p.Salvar(It.IsAny<Pagamento>()))
                .Callback<Pagamento>(r => pagemntoCapturado = r);
            
            GeradorDePagamento gerador = new GeradorDePagamento(leilaoDao.Object, new Avaliador(), pagaemntoDao.Object);
            gerador.Gera();

            //Then
            Assert.NotNull(pagemntoCapturado);
            Assert.Equal(600, pagemntoCapturado.valor);
        }

    }
}