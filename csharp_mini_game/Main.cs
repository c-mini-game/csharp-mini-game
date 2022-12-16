using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_mini_game
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
            
               
        }

        


        private void button1_Click(object sender, EventArgs e)
        {

            Login login = new Login();
            login.ShowDialog();
            if (Login.login_status == 1)
            {
                button4.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                button4.Enabled = false;
                button1.Enabled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login.login_status = 0;
            Login.logininfo = "";
            MessageBox.Show("로그아웃되었습니다.");
            button4.Enabled = false;
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Login.login_status.ToString());
            
        }
    }
}
