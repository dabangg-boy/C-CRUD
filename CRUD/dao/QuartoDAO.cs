using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CRUD.util;
using CRUD.model;
using System.Windows.Forms;

namespace CRUD.dao
{
    class QuartoDAO
    {
        private DBConnect db;
        private MySqlConnection con;

        public QuartoDAO() { }

        public void InserirDados(Quarto u)
        {
            con = new MySqlConnection();
            db = new DBConnect();
            con.ConnectionString = db.get();
            string query = "INSERT INTO Quarto values(?n_quarto, ?andar, ?estado, ?preco, ?capacidade, ?checkin, ?checkout)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?n_quarto", u.N_quarto);
                cmd.Parameters.AddWithValue("?andar", u.Andar);
                cmd.Parameters.AddWithValue("?estado", u.Estado);
                cmd.Parameters.AddWithValue("?preco", u.Preco);
                cmd.Parameters.AddWithValue("?capacidade", u.Capacidade);
                cmd.Parameters.AddWithValue("?checkin", u.Checkin);
                cmd.Parameters.AddWithValue("?checkout", u.Checkout);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void AtualizarDados(Quarto u)
        {
            con = new MySqlConnection();
            db = new DBConnect();
            con.ConnectionString = db.get();
            String query = "UPDATE Quarto SET andar=?andar, estado=?estado, preco=?preco, capacidade=?capacidade, "+
                "checkin=?checkin, checkout=?checkout WHERE n_quarto = ?n_quarto";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?andar", u.Andar);
                cmd.Parameters.AddWithValue("?estado", u.Estado);
                cmd.Parameters.AddWithValue("?preco", u.Preco);
                cmd.Parameters.AddWithValue("?capacidade", u.Capacidade);
                cmd.Parameters.AddWithValue("?checkin", u.Checkin);
                cmd.Parameters.AddWithValue("?checkout", u.Checkout);
                cmd.Parameters.AddWithValue("?n_quarto", u.N_quarto);

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Actualizado com Sucesso");
                }
                else
                {
                    MessageBox.Show("Falhou");
                }

                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void RemoverDados(Quarto u)
        {
            con = new MySqlConnection();
            db = new DBConnect();
            con.ConnectionString = db.get();
            String query = "DELETE FROM Quarto WHERE n_quarto = ?n_quarto";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?n_quarto", u.N_quarto);
                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Apagado com Sucesso");
                }
                else
                {
                    MessageBox.Show("Falhou");
                }

                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public List<Quarto> carregarTodosQuartos()
        {

            List<Quarto> us = new List<Quarto>();
            db = new DBConnect();

            string connectionString = db.get();

            string query = "SELECT * FROM Quarto";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Quarto u = new Quarto();

                            u.N_quarto = int.Parse(dataTable.Rows[i][0].ToString());
                            u.Andar = int.Parse(dataTable.Rows[i][1].ToString());
                            u.Estado = dataTable.Rows[i][2].ToString();
                            u.Preco = int.Parse(dataTable.Rows[i][3].ToString());
                            u.Capacidade = int.Parse(dataTable.Rows[i][4].ToString());
                            u.Checkin = Convert.ToDateTime(dataTable.Rows[i][5].ToString());
                            u.Checkout = Convert.ToDateTime(dataTable.Rows[i][6].ToString());
                  
                            us.Add(u);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            }
            return us;
        }
    }

}
