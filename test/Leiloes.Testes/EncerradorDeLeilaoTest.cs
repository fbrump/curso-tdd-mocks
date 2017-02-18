namespace Leiloes.Testes
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Xunit;
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

            LeilaoDaoFalso dao = new LeilaoDaoFalso();
            dao.Salva(leilao1);
            dao.Salva(leilao2);

            //When
            EncerradorDeLeilao encerrador = new EncerradorDeLeilao();
            encerrador.Encerra();
            
            //Then
            Assert.Equal(2, encerrador.Total);
            Assert.True(leilao1.encerrado);
            Assert.True(leilao2.encerrado);
        }
        
    }
}