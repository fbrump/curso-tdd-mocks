namespace Leiloes.Infra
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Leiloes.Dominio;

    /// <summary>
    /// Repository of auctions DAO
    /// </summary>
    public interface RepositorioDeLeiloes
    {
        /// <summary>
        /// Save new item
        /// </summary>
        /// <param name="leilao">Auction</param>
         void Salva(Leilao leilao);

         /// <summary>
         /// Return all auctions fineshed.
         /// </summary>
         /// <returns>List of auctions.</returns>
         List<Leilao> Encerrados();

         /// <summary>
         /// Return all auctions actives
         /// </summary>
         /// <returns>List of auctions</returns>
         List<Leilao> Correntes();

         /// <summary>
         /// Update informations for auction.
         /// </summary>
         /// <param name="leilao">Auction for update.</param>
         void Atualiza(Leilao leilao);

    }
}