using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace csharp_mini_game
{
    public partial class Join : Form
    {
        Login login;
        
        string _server = "155.230.235.248";
        int _port = 54036;
        string _database = "mydb";
        string _id = "swUser01";
        string _pw = "swdbUser01";
        string _connectionAddress = "";

        bool check_id = false;
        bool check_nn = false;

        public Join()
        {
            InitializeComponent();     
        }

        public Join(Login form1)
        {
            InitializeComponent();
            
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
            this.login = form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Join_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)


        {
            string newid = textBox1.Text;
            string newpw = textBox2.Text;
            string newpw2 = textBox3.Text;
            string newnickname = textBox4.Text;
            //int pwcheck = 0;
            if (newpw != newpw2)
            {
               // pwcheck = 1;
            }
            
            if (check_id ||check_nn)
            {
              

                try
                {
                    using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                    {
                        mysql.Open();
                        string insertQuery = string.Format("INSERT INTO ksg (name, pw, nickname) VALUES ('{0}', '{1}', '{2}');",
                                                                                             textBox1.Text, textBox2.Text, textBox3.Text);
                        MySqlCommand command = new MySqlCommand(insertQuery, mysql);
                        if (command.ExecuteNonQuery() != 1)
                            MessageBox.Show("Failed to insert data.");
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("아이디 혹은 닉네임 중복 체크를 해주세요");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            check_id = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            check_nn = true;
        }
    }
}
