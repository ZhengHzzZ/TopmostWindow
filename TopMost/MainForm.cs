using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopMost
{
    public partial class MainForm : Form
    {
        private List<FormInfo> m_FormInfo_List;
        public MainForm()
        {
            InitializeComponent();
            m_FormInfo_List = WindowsMethod.GetHandleList(this.Handle.ToInt32());
            RefreshListBox();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            m_FormInfo_List = WindowsMethod.GetHandleList(this.Handle.ToInt32());
            RefreshListBox();
        }

        private void btnTopMost_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                SetTopMost((this.listBox1.SelectedItem as FormInfo).Handle, true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                SetTopMost((this.listBox1.SelectedItem as FormInfo).Handle, false);
            }
        }

        private void RefreshListBox()
        {
            if (m_FormInfo_List != null)
            {
                foreach (FormInfo fi in m_FormInfo_List)
                {
                    this.listBox1.Items.Add(fi);
                }
            }
        }

        private void SetTopMost(int handle, bool isTopMost)
        {

            WindowsMethod.SetTopMost(handle, isTopMost);
        }
    }
}
