namespace Leiloes.Testes
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Xunit;
    using Moq;
    using Leiloes.Dominio;
    using Leiloes.Servico;
    using Leiloes.Infra;

    public class EncerradorDeLeilaoTest
    {
        [Fact]
        public void Should_fineshed_aoction_that_started_one_week()
        {
            //Given
            DateTime diaDaSemanaPassada = new DateTime(1999, 05, 05);
            
            
            Leilao leilao1 = new Leilao("Tv de plasma");
            leilao1.naData(diaDaSemanaPassada);

            Leilao leilao2 = new Leilao("Playstation");
            leilao2.naData(diaDaSemanaPassada);

            List<Leilao> ListaDeLeiloes = new List<Leilao>();
            ListaDeLeiloes.Add(leilao1);
            ListaDeLeiloes.Add(leilao2);

            var dao = new Mock<RepositorioDeLeiloes>();

            dao.Setup(d => d.Correntes())
                .Returns(ListaDeLeiloes);
            //When
            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object);
            encerrador.Encerra();
            
            //Then
            Assert.Equal(2, encerrador.Total);
            Assert.True(leilao1.encerrado);
            Assert.True(leilao2.encerrado);
        }

        [Fact]
        public void Should_fineshed_aoction_that_started_today()
        {
            //Given
            DateTime diaDaSemanaPassada = DateTime.Now;
            
            Leilao leilao1 = new Leilao("Tv de plasma");
            leilao1.naData(diaDaSemanaPassada);

            Leilao leilao2 = new Leilao("Playstation");
            leilao2.naData(diaDaSemanaPassada);

            List<Leilao> ListaDeLeiloes = new List<Leilao>();
            ListaDeLeiloes.Add(leilao1);
            ListaDeLeiloes.Add(leilao2);

            var dao = new Mock<RepositorioDeLeiloes>();

            dao.Setup(d => d.Correntes())
                .Returns(ListaDeLeiloes);
            //When
            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object);
            encerrador.Encerra();
            
            //Then
            Assert.Equal(0, encerrador.Total);
            Assert.False(leilao1.encerrado);
            Assert.False(leilao2.encerrado);
        }

        [Fact]
        public void Should_return_nothing_when_dont_have_auction()
        {
            //Given
            var dao = new Mock<RepositorioDeLeiloes>();

            dao.Setup(d => d.Correntes())
                .Returns(new List<Leilao>());
            //When
            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object);
            encerrador.Encerra();
            
            //Then
            Assert.Equal(0, encerrador.Total);
        }
        
    }
}