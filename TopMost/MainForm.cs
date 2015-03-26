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
    /// <summary>
    /// MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// List of FormInfos about all the windows
        /// </summary>
        private List<FormInfo> m_FormInfo_List;

        /// <summary>
        /// Constructors
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            m_FormInfo_List = WindowsMethod.GetHandleList(this.Handle.ToInt32());
            RefreshListBox();
        }

        /// <summary>
        /// Check other windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            m_FormInfo_List = WindowsMethod.GetHandleList(this.Handle.ToInt32());
            RefreshListBox();
        }

        /// <summary>
        /// Set the select window topmost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTopMost_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                SetTopMost((this.listBox1.SelectedItem as FormInfo).Handle, true);
            }
        }

        /// <summary>
        /// Cancel the select window topmost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                SetTopMost((this.listBox1.SelectedItem as FormInfo).Handle, false);
            }
        }

        /// <summary>
        /// Refresh ListBox
        /// </summary>
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

        /// <summary>
        /// Call user32.dll
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="isTopMost"></param>
        private void SetTopMost(int handle, bool isTopMost)
        {
            WindowsMethod.SetTopMost(handle, isTopMost);
        }
    }
}
