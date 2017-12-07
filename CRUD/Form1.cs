using CRUD.dao;
using CRUD.model;
using CRUD.util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            carregaDados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quarto u = new Quarto();
            u.N_quarto = int.Parse(n_quarto.Text);
            u.Andar = int.Parse(andar.Text);
            u.Estado = estado.Text;
            u.Preco = double.Parse(preco.Text);
            u.Capacidade = int.Parse(capacidade.Text);
            u.Checkin = Convert.ToDateTime(checkin.Text);
            u.Checkout = Convert.ToDateTime(checkout.Text);

            QuartoDAO udao = new QuartoDAO();
            udao.InserirDados(u);
            carregaDados();

        }

        private void carregaDados()
        {
            dataGridView1.Refresh();
            QuartoDAO udao = new QuartoDAO();
            dataGridView1.DataSource = udao.carregarTodosQuartos();
            n_quarto.Clear();
            andar.SelectedIndex = -1;
            estado.Clear();
            preco.Clear();
            capacidade.Clear();

        }

        private void cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["n_quarto"].Value.ToString());
            int andar = int.Parse(dataGridView1.CurrentRow.Cells["andar"].Value.ToString());
            string estado = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
            double preco = double.Parse(dataGridView1.CurrentRow.Cells["preco"].Value.ToString());
            int capacidade = int.Parse(dataGridView1.CurrentRow.Cells["capacidade"].Value.ToString());
            string checkin = dataGridView1.CurrentRow.Cells["checkin"].Value.ToString();
            string checkout = dataGridView1.CurrentRow.Cells["checkout"].Value.ToString();

            Quarto u = new Quarto();

            u.N_quarto = id;
            u.Andar = andar;
            u.Estado = estado;
            u.Preco = preco;
            u.Capacidade = capacidade;
            u.Checkin = Convert.ToDateTime(checkin);
            u.Checkout = Convert.ToDateTime(checkout);

            QuartoDAO udao = new QuartoDAO();
            udao.AtualizarDados(u);
            carregaDados();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["n_quarto"].Value.ToString());

            Quarto u = new Quarto();

            u.N_quarto = id;
         

            QuartoDAO udao = new QuartoDAO();
            udao.RemoverDados(u);
            carregaDados();
        }
    }
}
