using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.model
{
    class Quarto
    {
        private int n_quarto;
        private int andar;
        private string estado;
        private double preco;
        private int capacidade;
        private DateTime checkin;
        private DateTime checkout;

        public Quarto() { }
        //sets e gets
        public int N_quarto
        {
            get
            {
                return n_quarto;
            }

            set
            {
                n_quarto = value;
            }
        }
        public int Andar
        {
            get
            {
                return andar;
            }

            set
            {
                andar = value;
            }
        }
        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
        public double Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }
        public int Capacidade
        {
            get
            {
                return capacidade;
            }

            set
            {
                capacidade = value;
            }
        }
        public DateTime Checkin
        {
            get
            {
                return checkin;
            }

            set
            {
                checkin = value;
            }
        }
        public DateTime Checkout
        {
            get
            {
                return checkout;
            }

            set
            {
                checkout = value;
            }
        }

    }
}
