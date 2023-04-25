using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaruSneaker.Object
{
    public partial class Revenue_co : UserControl
    {
        Bill_logic bl = new Bill_logic();
        public Revenue_co()
        {
            InitializeComponent();
        }

        private void load()
        {
            dgv_Bill.DataSource = bl.load();

        }

        private void Revenue_co_Load(object sender, EventArgs e)
        {

        }

        private void btn_Bind_Click(object sender, EventArgs e)
        {
            load();
            txt_TotalCash.Text = bl.getTotalCash().ToString();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (bl.removeAll())
            {
                MessageBox.Show("Thành công!");
                load();
            }
            else
            {
                MessageBox.Show("Thất bại!");
                return;
            }
        }
    }
}
