﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace FaruSneaker.Object
{
    public partial class Service_co : UserControl
    {
        Service_logic sl = new Service_logic();
        public Service_co()
        {
            InitializeComponent();
        }

        private void load()
        {
            dgv_service.DataSource = sl.load();
        }

        private void setEditingMode(bool enable)
        {
            if (!enable)
            {
                dgv_service.ClearSelection();
            }
            btn_Add.Enabled = !enable;
            btn_Remove.Enabled = enable;
            btn_Update.Enabled = enable;
            btn_Clear.Enabled = enable;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Price.Text == "" || rtx_Description.Text == "")
            {
                MessageBox.Show("Hãy đảm bảo đầy đủ nội dung trước khi thực hiện!");
                return;
            }
            else
            {
                string id = txt_ID.Text;
                string name = txt_Name.Text;
                int price = Convert.ToInt32(txt_Price.Text);
                string des = rtx_Description.Text;
                if (sl.add(id, name, price, des))
                {
                    btn_Clear_Click(sender, e);
                    load();
                }
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            string id = txt_ID.Text;
            if (sl.remove(id))
            {
                btn_Clear_Click(sender, e);
                load();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string id = txt_ID.Text;
            string name = txt_Name.Text;
            int price = Convert.ToInt32(txt_Price.Text);
            string des = rtx_Description.Text;
            if (sl.update(id, name, price, des))
            {
                btn_Clear_Click(sender, e);
                load();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            setEditingMode(false);
            dgv_service.ClearSelection();
            txt_ID.Text = "";
            txt_Name.Text = "";
            txt_Price.Text = "";
            rtx_Description.Text = "";
        }

        private bool isRowNullOrEmpty(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null || cell.Value == DBNull.Value)
                {
                    return true;
                }

                if (cell.Value is string str && string.IsNullOrEmpty(str))
                {
                    return true;
                }
            }

            return false;
        }

        private void dgv_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setEditingMode(true);
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !isRowNullOrEmpty(dgv_service.Rows[e.RowIndex]))
            {
                DataGridViewRow row = dgv_service.Rows[e.RowIndex];

                txt_ID.Text = row.Cells[0].Value.ToString();
                txt_Name.Text = row.Cells[1].Value.ToString();
                txt_Price.Text = row.Cells[2].Value.ToString();
                rtx_Description.Text = row.Cells[3].Value.ToString();
            }
        }

        private void Service_co_Load(object sender, EventArgs e)
        {
            txt_ID.ReadOnly = true;
            load();
            setEditingMode(false);
        }
    }
}
