using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SharpKeys
{
    /// <summary>
    /// Summary description for Dialog_KeyItem.
    /// </summary>
    public class Dialog_KeyItem : System.Windows.Forms.Form
    {
        // passed into here so it can be pushed through to type key
        internal Hashtable m_hashKeys = null;
        private GroupBox groupBox1;
        internal ListBox lbFrom;
        private Button btnFrom;
        private Button btnOK;
        private GroupBox groupBox2;
        private Button btnTo;
        internal ListBox lbTo;
        private Button btnCancel;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Dialog_KeyItem()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbFrom = new System.Windows.Forms.ListBox();
            this.btnFrom = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTo = new System.Windows.Forms.Button();
            this.lbTo = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbFrom);
            this.groupBox1.Controls.Add(this.btnFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 320);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "매핑 할 키:";
            // 
            // lbFrom
            // 
            this.lbFrom.IntegralHeight = false;
            this.lbFrom.ItemHeight = 12;
            this.lbFrom.Location = new System.Drawing.Point(10, 18);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.ScrollAlwaysVisible = true;
            this.lbFrom.Size = new System.Drawing.Size(287, 255);
            this.lbFrom.TabIndex = 0;
            // 
            // btnFrom
            // 
            this.btnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrom.Location = new System.Drawing.Point(210, 279);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(87, 29);
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            this.btnFrom.TabIndex = 1;
            this.btnFrom.Text = "키 입력";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(462, 349);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "확인";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTo);
            this.groupBox2.Controls.Add(this.lbTo);
            this.groupBox2.Location = new System.Drawing.Point(331, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 320);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "이 키로 매핑:";
            // 
            // btnTo
            // 
            this.btnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTo.Location = new System.Drawing.Point(209, 279);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(87, 29);
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            this.btnTo.TabIndex = 0;
            this.btnTo.Text = "키 입력";
            // 
            // lbTo
            // 
            this.lbTo.IntegralHeight = false;
            this.lbTo.ItemHeight = 12;
            this.lbTo.Location = new System.Drawing.Point(10, 18);
            this.lbTo.Name = "lbTo";
            this.lbTo.ScrollAlwaysVisible = true;
            this.lbTo.Size = new System.Drawing.Size(286, 255);
            this.lbTo.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(555, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            // 
            // Dialog_KeyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 401);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog_KeyItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Resize += new System.EventHandler(this.Dialog_KeyItem_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void btnFrom_Click(object sender, System.EventArgs e)
        {
            // Pop open the "typing" form to collect keyboard input to get a valid code
            Dialog_KeyPress dlg = new Dialog_KeyPress();
            dlg.m_hashKeys = m_hashKeys;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (lbFrom.Items.Contains(dlg.m_strSelected))
                    lbFrom.SelectedItem = dlg.m_strSelected;
                else
                {
                    // probably an international keyboard code
                    MessageBox.Show("알 수 없는 키가 입력되었습니다.", "");
                }
            }
        }

        private void btnTo_Click(object sender, System.EventArgs e)
        {
            // Pop open the "typing" form to collect keyboard input to get a valid code
            Dialog_KeyPress dlg = new Dialog_KeyPress();
            dlg.m_hashKeys = m_hashKeys;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (lbTo.Items.Contains(dlg.m_strSelected))
                    lbTo.SelectedItem = dlg.m_strSelected;
                else
                {
                    // probably an international keyboard code
                    MessageBox.Show("알 수 없는 키가 입력되었습니다.", "");
                }
            }
        }

        private void Dialog_KeyItem_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
