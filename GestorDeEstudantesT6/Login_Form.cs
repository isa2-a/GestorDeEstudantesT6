﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeEstudantesT6
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonCancelar_Click(object sender, AccessibleEvents e) 
        {
            Close();
        }

        private void buttonLogin_Click_1(object sender, EventArgs e)
        {
            MeuBancoDeDados meuBancoDeDados = new MeuBancoDeDados();

            MySqlDataAdapter meuAdaptadorSql = new MySqlDataAdapter();
            DataTable minhaTabela = new DataTable();
            MySqlCommand meuComandoSql = new MySqlCommand("SELECT * FROM `usuários` WHERE `nome_de_usuario` = @usuario and `senha` = @senha", meuBancoDeDados.getConexao);


            meuComandoSql.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = textBoxUsuario.Text;
            meuComandoSql.Parameters.Add("@senha", MySqlDbType.VarChar).Value = textBoxSenha.Text;

            meuAdaptadorSql.SelectCommand = meuComandoSql;

            meuAdaptadorSql.Fill(minhaTabela);

            if (minhaTabela.Rows.Count > 0)
            {
                MessageBox.Show("Existem dados!");
            }
            else
            {
                MessageBox.Show("usário ou senha inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }   

      
}