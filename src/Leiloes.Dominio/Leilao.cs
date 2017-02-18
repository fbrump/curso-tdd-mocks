namespace Leiloes.Dominio
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    public class Leilao
    {
        public string descricao { get; private set; }
        public DateTime data {get; private set;}
        public List<Lance> lances {get; private set;}
        public bool encerrado {get; private set;}
        private int id;

        public Leilao(string descricao)
        {
            this.descricao = descricao;
            lances = new List<Lance>();
            data = DateTime.Today;
        }

        public void propoe(Lance lance)
        {
            if (lances.Count == 0 || podeDarLance(lance.usuario))
            {
                lances.Add(lance);
            }

        }

        private bool podeDarLance(Usuario usuario)
        {

            return !ultimoLance().usuario.Equals(usuario) && qtdDeLancesDo(usuario) < 5;
        }

        private int qtdDeLancesDo(Usuario usuario)
        {
            int total = 0;
            foreach(var l in lances) {
                if(l.usuario.Equals(usuario)) {
                    total++;
                }
            }
            return total;
            
        }

        private Lance ultimoLance()
        {
            return lances[lances.Count - 1];
        }

        public void encerra()
        {
            this.encerrado = true;
        }

        public void naData(DateTime data)
        {
            this.data = data;
        }
    }
}