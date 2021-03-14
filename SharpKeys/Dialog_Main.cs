using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;

namespace SharpKeys
{
    /// <summary>
    /// Summary description for Dialog_Main.
    /// </summary>
    public class Dialog_Main : System.Windows.Forms.Form
    {
        // Field for saving window position
        private Rectangle m_rcWindow;

        // Field for registy storage
        private string m_strRegKey = "Software\\RandyRants\\SharpKeys";

        // Hashtable for tracking text to scan codes
        private Hashtable m_hashKeys = null;

        // Dirty flag (to see track if mappings have been saved)
        private bool m_bDirty = false;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private System.Windows.Forms.MenuItem mniDeleteAll;
        private System.Windows.Forms.ContextMenu mnuPop;
        private Button btnSave;
        private Button btnDeleteAll;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private ListView lvKeys;
        private ColumnHeader lvcFrom;
        private ColumnHeader lvcTo;
        private Button btnSaveKeys;
        private Button btnLoadKeys;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Dialog_Main()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
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
            this.mnuPop = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mniDeleteAll = new System.Windows.Forms.MenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvKeys = new System.Windows.Forms.ListView();
            this.lvcFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvcTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSaveKeys = new System.Windows.Forms.Button();
            this.btnLoadKeys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mnuPop
            // 
            this.mnuPop.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniAdd,
            this.mniEdit,
            this.mniDelete,
            this.menuItem5,
            this.mniDeleteAll});
            this.mnuPop.Popup += new System.EventHandler(this.mnuPop_Popup);
            // 
            // mniAdd
            // 
            this.mniAdd.Index = 0;
            this.mniAdd.Text = "Add";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Index = 1;
            this.mniEdit.Text = "Edit";
            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Index = 2;
            this.mniDelete.Text = "Delete";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "-";
            // 
            // mniDeleteAll
            // 
            this.mniDeleteAll.Index = 4;
            this.mniDeleteAll.Text = "Delete All";
            this.mniDeleteAll.Click += new System.EventHandler(this.mniDeleteAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(460, 379);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 38);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "레지스트리에 쓰기";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAll.Location = new System.Drawing.Point(195, 379);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(74, 38);
            this.btnDeleteAll.TabIndex = 4;
            this.btnDeleteAll.Text = "전부 삭제";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(137, 379);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 38);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "삭제";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(76, 379);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 38);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "수정";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(13, 379);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 38);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "추가";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvKeys
            // 
            this.lvKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcFrom,
            this.lvcTo});
            this.lvKeys.ContextMenu = this.mnuPop;
            this.lvKeys.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvKeys.FullRowSelect = true;
            this.lvKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvKeys.HideSelection = false;
            this.lvKeys.Location = new System.Drawing.Point(13, 12);
            this.lvKeys.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvKeys.MultiSelect = false;
            this.lvKeys.Name = "lvKeys";
            this.lvKeys.Size = new System.Drawing.Size(701, 361);
            this.lvKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvKeys.TabIndex = 0;
            this.lvKeys.UseCompatibleStateImageBehavior = false;
            this.lvKeys.View = System.Windows.Forms.View.Details;
            this.lvKeys.SelectedIndexChanged += new System.EventHandler(this.lvKeys_SelectedIndexChanged);
            this.lvKeys.DoubleClick += new System.EventHandler(this.lvKeys_DoubleClick);
            // 
            // lvcFrom
            // 
            this.lvcFrom.Text = "매핑 할 키:";
            // 
            // lvcTo
            // 
            this.lvcTo.Text = "이 키로 매핑:";
            // 
            // btnSaveKeys
            // 
            this.btnSaveKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveKeys.Location = new System.Drawing.Point(657, 379);
            this.btnSaveKeys.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSaveKeys.Name = "btnSaveKeys";
            this.btnSaveKeys.Size = new System.Drawing.Size(57, 38);
            this.btnSaveKeys.TabIndex = 8;
            this.btnSaveKeys.Text = "키 저장";
            this.btnSaveKeys.Click += new System.EventHandler(this.btnSaveKeys_Click);
            // 
            // btnLoadKeys
            // 
            this.btnLoadKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadKeys.Location = new System.Drawing.Point(592, 379);
            this.btnLoadKeys.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadKeys.Name = "btnLoadKeys";
            this.btnLoadKeys.Size = new System.Drawing.Size(57, 38);
            this.btnLoadKeys.TabIndex = 7;
            this.btnLoadKeys.Text = "키 로드";
            this.btnLoadKeys.Click += new System.EventHandler(this.btnLoadKeys_Click);
            // 
            // Dialog_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 429);
            this.Controls.Add(this.btnSaveKeys);
            this.Controls.Add(this.btnLoadKeys);
            this.Controls.Add(this.lvKeys);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(743, 445);
            this.Name = "Dialog_Main";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Dialog_Main_Closing);
            this.Load += new System.EventHandler(this.Dialog_Main_Load);
            this.Resize += new System.EventHandler(this.Dialog_Main_Resize);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Dialog_Main());
        }

        private void LoadRegistrySettings()
        {
            // First load the window positions from registry
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(m_strRegKey);
            Rectangle rc = new Rectangle(10, 10, 750, 550);
            int nWinState = 0, nWarning = 0;

            if (regKey != null)
            {
                // Load Window Pos
                nWinState = (int)regKey.GetValue("MainWinState", 0);
                rc.X = (int)regKey.GetValue("MainX", 10);
                rc.Y = (int)regKey.GetValue("MainY", 10);
                rc.Width = (int)regKey.GetValue("MainCX", 750);
                rc.Height = (int)regKey.GetValue("MainCY", 550);

                nWarning = (int)regKey.GetValue("ShowWarning", 0);
                regKey.Close();
            }


            // Set the WinPos
            m_rcWindow = rc;
            DesktopBounds = m_rcWindow;
            WindowState = (FormWindowState)nWinState;

            // now load the scan code map
            RegistryKey regScanMapKey = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout");
            if (regScanMapKey != null)
            {
                byte[] bytes = (byte[])regScanMapKey.GetValue("Scancode Map");
                if (bytes == null)
                {
                    regScanMapKey.Close();
                    return;
                }

                LoadListWithKeys(bytes);

                regScanMapKey.Close();
            }
        }

        private void LoadListWithKeys(byte[] bytes)
        {
            // can skip the first 8 bytes as they are ALWAYS 0x00
            // the 9th byte is ALWAYS the total number of mappings (including the trailing null pointer)
            if (bytes.Length > 8)
            {
                int nTotal = Int32.Parse(bytes[8].ToString());
                for (int i = 0; i < nTotal - 1; i++)
                {
                    // scan codes are stored in ToHi ToLo FromHi FromLo
                    String strFrom, strFromCode, strTo, strToCode;
                    strFromCode = string.Format("{0,2:X}_{1,2:X}", bytes[(i * 4) + 12 + 3], bytes[(i * 4) + 12 + 2]);
                    strFromCode = strFromCode.Replace(" ", "0");
                    strFrom = string.Format("{0} ({1})", (string)m_hashKeys[strFromCode], strFromCode);

                    strToCode = string.Format("{0,2:X}_{1,2:X}", bytes[(i * 4) + 12 + 1], bytes[(i * 4) + 12 + 0]);
                    strToCode = strToCode.Replace(" ", "0");
                    strTo = string.Format("{0} ({1})", (string)m_hashKeys[strToCode], strToCode);

                    ListViewItem lvI = lvKeys.Items.Add(strFrom);
                    lvI.SubItems.Add(strTo);
                }
            }
        }

        private void SaveRegistrySettings()
        {
            // Only save the window position info on close; user is prompted to save mappings elsewhere
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(m_strRegKey);

            // Save Window Pos
            regKey.SetValue("MainWinState", (int)WindowState);
            regKey.SetValue("MainX", m_rcWindow.X);
            regKey.SetValue("MainY", m_rcWindow.Y);
            regKey.SetValue("MainCX", m_rcWindow.Width);
            regKey.SetValue("MainCY", m_rcWindow.Height);
            regKey.SetValue("ShowWarning", 1);
        }

        private void SaveMappingsToRegistry()
        {
            Cursor = Cursors.WaitCursor;

            // Open the key to save the scancodes
            RegistryKey regScanMapKey = Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout");
            if (regScanMapKey != null)
            {
                if (lvKeys.Items.Count <= 0)
                {
                    // the second param is required; this will throw an exception if the value isn't found,
                    // and it might not always be there (which is valid), so it's ok to ignore it
                    regScanMapKey.DeleteValue("Scancode Map", false);
                }
                else
                {
                    byte[] bytes = DefineScancodeMap();

                    // dump to the registry
                    regScanMapKey.SetValue("Scancode Map", bytes);
                }
                regScanMapKey.Close();
            }
            m_bDirty = false;
            Cursor = Cursors.Default;

            MessageBox.Show("세이브 완료되었습니다.\n\n로그아웃하거나 재부팅시 적용됩니다", "");
        }

        private byte[] DefineScancodeMap()
        {
            int nCount = lvKeys.Items.Count;

            // create a new byte array that is:
            //   8 bytes that are always 00 00 00 00 00 00 00 00 (as is required)
            // + 4 bytes that are used for the count nn 00 00 00 (as is required)
            // + 4 bytes per mapping
            // + 4 bytes for the last mapping (required)
            byte[] bytes = new byte[8 + 4 + (4 * nCount) + 4];

            // skip first 8 (0-7)

            // set 8 to the count, plus the trailing null
            bytes[8] = Convert.ToByte(nCount + 1);

            // skip 9, 10, 11

            // add up the list
            for (int i = 0; i < nCount; i++)
            {
                String str = lvKeys.Items[i].SubItems[1].Text; //Example: (E0_0020)
                int BinaryStartIndex = str.LastIndexOf("_") + 1;
                int BinaryLength = str.LastIndexOf(")") - str.LastIndexOf("_") - 1;
                String Binary = str.Substring(BinaryStartIndex, BinaryLength); //Example: 0020
                String Reg = str.Substring(str.LastIndexOf("(") + 1, 2); //Example: E0
                if (Binary.Length > 2)
                {
                    Binary = Binary.Substring(2);
                }

                bytes[(i * 4) + 12 + 0] = Convert.ToByte(Binary, 16);
                bytes[(i * 4) + 12 + 1] = Convert.ToByte(Reg, 16);

                str = lvKeys.Items[i].Text; //Example: (E0_0020)
                BinaryStartIndex = str.LastIndexOf("_") + 1;
                BinaryLength = str.LastIndexOf(")") - str.LastIndexOf("_") - 1;
                Binary = str.Substring(BinaryStartIndex, BinaryLength); //Example: 0020
                Reg = str.Substring(str.LastIndexOf("(") + 1, 2); //Example: E0
                if (Binary.Length > 2)
                {
                    Binary = Binary.Substring(2);
                }

                bytes[(i * 4) + 12 + 2] = Convert.ToByte(Binary, 16);
                bytes[(i * 4) + 12 + 3] = Convert.ToByte(Reg, 16);
            }

            // last 4 are 0's

            return bytes;
        }

        private void AddMapping()
        {
            // max out the mapping at 104
            if (lvKeys.Items.Count >= 104)
            {
                MessageBox.Show("최대 매핑 가능 키 갯수는 104개입니다.\n\n기존 매핑을 삭제한뒤에 추가하세요.", "");
                return;
            }

            // adding a new mapping, so prep the add dialog with all of the scancodes
            Dialog_KeyItem dlg = new Dialog_KeyItem();
            dlg.m_hashKeys = m_hashKeys; // passed into this dialog so it can go out to the next
            IDictionaryEnumerator iDic = m_hashKeys.GetEnumerator();
            while (iDic.MoveNext() == true)
            {
                string str = string.Format("{0} ({1})", iDic.Value, iDic.Key);
                dlg.lbFrom.Items.Add(str);
                dlg.lbTo.Items.Add(str);
            }

            // remove the null setting for "From" since you can never have a null key to map
            int nPos = 0;
            nPos = dlg.lbFrom.FindString("-- Turn Key Off (00_00)");
            if (nPos > -1)
                dlg.lbFrom.Items.RemoveAt(nPos);

            // Now remove any of the keys that have already been mapped in the list (can't double up on from's)
            for (int i = 0; i < lvKeys.Items.Count; i++)
            {
                nPos = dlg.lbFrom.FindString(lvKeys.Items[i].Text);
                if (nPos > -1)
                    dlg.lbFrom.Items.RemoveAt(nPos);
            }

            // let C# sort the lists
            dlg.lbFrom.Sorted = true;
            dlg.lbTo.Sorted = true;

            // UI stuff
            dlg.Text = "새 키 매핑";
            dlg.lbFrom.SelectedIndex = 0;
            dlg.lbTo.SelectedIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_bDirty = true;

                // Add the list, as it's past inspection.
                ListViewItem lvI = lvKeys.Items.Add(dlg.lbFrom.Text);
                lvI.SubItems.Add(dlg.lbTo.Text);
                lvI.Selected = true;
            }
            lvKeys.Focus();
        }

        private void EditMapping()
        {
            // make sure something was selecting
            if (lvKeys.SelectedItems.Count <= 0)
            {
                MessageBox.Show("수정할 키를 선택하세요!", "");
                return;
            }

            // built the drop down lists no matter what
            Dialog_KeyItem dlg = new Dialog_KeyItem();
            dlg.m_hashKeys = m_hashKeys; // passed into this dialog so it can go out to the next
            IDictionaryEnumerator iDic = m_hashKeys.GetEnumerator();
            while (iDic.MoveNext() == true)
            {
                string str = string.Format("{0} ({1})", iDic.Value, iDic.Key);
                dlg.lbFrom.Items.Add(str);
                dlg.lbTo.Items.Add(str);
            }

            // remove the null setting for "From" since you can never have a null key to map
            int nPos = 0;
            nPos = dlg.lbFrom.FindString("-- Turn Key Off (00_00)");
            if (nPos > -1)
                dlg.lbFrom.Items.RemoveAt(nPos);

            // remove any of the existing from key mappings however, leave in the one that has currently
            // been selected!
            for (int i = 0; i < lvKeys.Items.Count; i++)
            {
                nPos = dlg.lbFrom.FindString(lvKeys.Items[i].Text);
                if ((nPos > -1) && (lvKeys.Items[i].Text != lvKeys.SelectedItems[0].Text))
                {
                    dlg.lbFrom.Items.RemoveAt(nPos);
                }
            }

            // Let C# sort the lists
            dlg.lbFrom.Sorted = true;
            dlg.lbTo.Sorted = true;

            // as it's an edit, set the drop down lists to the current From value
            nPos = dlg.lbFrom.FindString(lvKeys.SelectedItems[0].Text);
            if (nPos > -1)
                dlg.lbFrom.SelectedIndex = nPos;
            else
                dlg.lbFrom.SelectedIndex = 0;

            // as it's an edit, set the drop down lists to the current To value
            nPos = dlg.lbTo.FindString(lvKeys.SelectedItems[0].SubItems[1].Text);
            if (nPos > -1)
                dlg.lbTo.SelectedIndex = nPos;
            else
                dlg.lbTo.SelectedIndex = 0;

            dlg.Text = "키 매핑 수정";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_bDirty = true;

                // update the select mapping item in the list view
                lvKeys.SelectedItems[0].Text = dlg.lbFrom.Text;
                lvKeys.SelectedItems[0].SubItems[1].Text = dlg.lbTo.Text;
            }
            lvKeys.Focus();
        }

        private void DeleteMapping()
        {
            // Pop a mapping out of the list view
            if (lvKeys.SelectedItems.Count <= 0)
            {
                MessageBox.Show("삭제할 키를 선택하세요!", "");
                return;
            }

            lvKeys.Items.Remove(lvKeys.SelectedItems[0]);

            m_bDirty = true;
        }

        private void DeleteAllMapping()
        {
            // Since removing all is a big step, get a confirmation
            DialogResult dlgRes = MessageBox.Show("전부 삭제시 리스트는 지워지지만 \"레지스트리에 쓰기\"버튼을 클릭하기 전까지는 적용되지 않습니다..\n\n키 리스트를 초기화하시겠습니까?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (dlgRes == DialogResult.No)
            {
                return;
            }

            CleanOutTheList();
        }

        private void CleanOutTheList()
        {
            // ...and then clean out the list
            m_bDirty = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = false;
            lvKeys.Items.Clear();
        }

        private void btnLoadKeys_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "키 리스트 (*.kls)|*.KLS";
            openFileDialog.Title = "키 리스트 불러오기";
            openFileDialog.DefaultExt = "KLS";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.CheckPathExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowHelp = false;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filename = openFileDialog.FileName;
            byte[] bytes = File.ReadAllBytes(filename);

            if (bytes.Length > 0)
            {
                try
                {
                    CleanOutTheList();
                    LoadListWithKeys(bytes);
                    m_bDirty = true;
                }
                catch
                {
                    MessageBox.Show("유효한 KLS파일이 아님!", "");
                }
            }
            else
            {
                MessageBox.Show("파일이 비어있음!", "");
            }
        }

        private void btnSaveKeys_Click(object sender, EventArgs e)
        {
            if (lvKeys.Items.Count <= 0)
            {
                MessageBox.Show("저장할 키가 없음!", "");
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "키 리스트 (*.kls)|*.KLS";
            saveDialog.Title = "키 리스트 저장";
            saveDialog.DefaultExt = "kls";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveDialog.CheckPathExists = true;
            saveDialog.RestoreDirectory = true;
            saveDialog.AddExtension = true;
            saveDialog.ShowHelp = false;
            saveDialog.FileName = "*.kls";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Grab the current bytes in the list
                byte[] bytes = DefineScancodeMap();
                string filename = saveDialog.FileName;
                using (FileStream writer = File.Create(filename))
                {
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void BuildParseTables()
        {
            if (m_hashKeys != null)
                return;

            // the hash table uses a string in the form of Hi_Lo scan code (in Hex values) 
            // that most sources say are scan codes.  The 00_00 will disable a key - everything else 
            // is pretty obvious.  There is a bit of a reverse lookup however, so labels changed here
            // need to be changed in a couple of other places
            m_hashKeys = new Hashtable();
            m_hashKeys.Add("E1_1D", "특수: Pause/Break");
            m_hashKeys.Add("00_00", "-- 키 없음");
            m_hashKeys.Add("00_01", "특수: ESC");
            m_hashKeys.Add("00_02", "키: 1 !");
            m_hashKeys.Add("00_03", "키: 2 @");
            m_hashKeys.Add("00_04", "키: 3 #");
            m_hashKeys.Add("00_05", "키: 4 $");
            m_hashKeys.Add("00_06", "키: 5 %");
            m_hashKeys.Add("00_07", "키: 6 ^");
            m_hashKeys.Add("00_08", "키: 7 &");
            m_hashKeys.Add("00_09", "키: 8 *");
            m_hashKeys.Add("00_0A", "키: 9 (");
            m_hashKeys.Add("00_0B", "키: 0 )");
            m_hashKeys.Add("00_0C", "키: - _");
            m_hashKeys.Add("00_0D", "키: = +");
            m_hashKeys.Add("00_0E", "특수: 백스페이스");
            m_hashKeys.Add("00_0F", "특수: 탭");
            m_hashKeys.Add("00_10", "키: Q");
            m_hashKeys.Add("00_11", "키: W");
            m_hashKeys.Add("00_12", "키: E");
            m_hashKeys.Add("00_13", "키: R");
            m_hashKeys.Add("00_14", "키: T");
            m_hashKeys.Add("00_15", "키: Y");
            m_hashKeys.Add("00_16", "키: U");
            m_hashKeys.Add("00_17", "키: I");
            m_hashKeys.Add("00_18", "키: O");
            m_hashKeys.Add("00_19", "키: P");
            m_hashKeys.Add("00_1A", "키: [ {");
            m_hashKeys.Add("00_1B", "키: ] }");
            m_hashKeys.Add("00_1C", "특수: 엔터");
            m_hashKeys.Add("00_1D", "특수: 왼쪽 컨트롤");
            m_hashKeys.Add("00_1E", "키: A");
            m_hashKeys.Add("00_1F", "키: S");
            m_hashKeys.Add("00_20", "키: D");
            m_hashKeys.Add("00_21", "키: F");
            m_hashKeys.Add("00_22", "키: G");
            m_hashKeys.Add("00_23", "키: H");
            m_hashKeys.Add("00_24", "키: J");
            m_hashKeys.Add("00_25", "키: K");
            m_hashKeys.Add("00_26", "키: L");
            m_hashKeys.Add("00_27", "키: ; :");
            m_hashKeys.Add("00_28", "키: ' \"");
            m_hashKeys.Add("00_29", "키: ` ~");
            m_hashKeys.Add("00_2A", "특수: 왼쪽 쉬프트");
            m_hashKeys.Add("00_2B", "키: \\ |");
            m_hashKeys.Add("00_2C", "키: Z");
            m_hashKeys.Add("00_2D", "키: X");
            m_hashKeys.Add("00_2E", "키: C");
            m_hashKeys.Add("00_2F", "키: V");
            m_hashKeys.Add("00_30", "키: B");
            m_hashKeys.Add("00_31", "키: N");
            m_hashKeys.Add("00_32", "키: M");
            m_hashKeys.Add("00_33", "키: , <");
            m_hashKeys.Add("00_34", "키: . >");
            m_hashKeys.Add("00_35", "키: / ?");
            m_hashKeys.Add("00_36", "특수: 오른쪽 쉬프트");
            m_hashKeys.Add("00_37", "숫자 패드: *");
            m_hashKeys.Add("00_38", "특수: 왼쪽 알트");
            m_hashKeys.Add("00_39", "특수: 스페이스");
            m_hashKeys.Add("00_3A", "특수: 캡스 락");
            m_hashKeys.Add("00_3B", "기능: F1");
            m_hashKeys.Add("00_3C", "기능: F2");
            m_hashKeys.Add("00_3D", "기능: F3");
            m_hashKeys.Add("00_3E", "기능: F4");
            m_hashKeys.Add("00_3F", "기능: F5");
            m_hashKeys.Add("00_40", "기능: F6");
            m_hashKeys.Add("00_41", "기능: F7");
            m_hashKeys.Add("00_42", "기능: F8");
            m_hashKeys.Add("00_43", "기능: F9");
            m_hashKeys.Add("00_44", "기능: F10");
            m_hashKeys.Add("00_45", "특수: 넘버 락");
            m_hashKeys.Add("00_46", "특수: 스크롤 락");
            m_hashKeys.Add("00_47", "숫자 패드: 7");
            m_hashKeys.Add("00_48", "숫자 패드: 8");
            m_hashKeys.Add("00_49", "숫자 패드: 9");
            m_hashKeys.Add("00_4A", "숫자 패드: -");
            m_hashKeys.Add("00_4B", "숫자 패드: 4");
            m_hashKeys.Add("00_4C", "숫자 패드: 5");
            m_hashKeys.Add("00_4D", "숫자 패드: 6");
            m_hashKeys.Add("00_4E", "숫자 패드: +");
            m_hashKeys.Add("00_4F", "숫자 패드: 1");
            m_hashKeys.Add("00_50", "숫자 패드: 2");
            m_hashKeys.Add("00_51", "숫자 패드: 3");
            m_hashKeys.Add("00_52", "숫자 패드: 0");
            m_hashKeys.Add("00_53", "숫자 패드: .");
            m_hashKeys.Add("00_54", "알 수 없는: 0x0054");
            m_hashKeys.Add("00_55", "알 수 없는: 0x0055");
            m_hashKeys.Add("00_56", "특수: ISO 추가 키");
            m_hashKeys.Add("00_57", "기능: F11");
            m_hashKeys.Add("00_58", "기능: F12");
            m_hashKeys.Add("00_59", "알 수 없는: 0x0059");
            m_hashKeys.Add("00_5A", "알 수 없는: 0x005A");
            m_hashKeys.Add("00_5B", "알 수 없는: 0x005B");
            m_hashKeys.Add("00_5C", "알 수 없는: 0x005C");
            m_hashKeys.Add("00_5D", "알 수 없는: 0x005D");
            m_hashKeys.Add("00_5E", "알 수 없는: 0x005E");
            m_hashKeys.Add("00_5F", "알 수 없는: 0x005F");
            m_hashKeys.Add("00_60", "알 수 없는: 0x0060");
            m_hashKeys.Add("00_61", "알 수 없는: 0x0061");
            m_hashKeys.Add("00_62", "알 수 없는: 0x0062");
            m_hashKeys.Add("00_63", "알 수 없는: 0x0063");
            m_hashKeys.Add("00_64", "기능: F13");
            m_hashKeys.Add("00_65", "기능: F14");
            m_hashKeys.Add("00_66", "기능: F15");
            m_hashKeys.Add("00_67", "기능: F16");   // Mac keyboard 
            m_hashKeys.Add("00_68", "기능: F17");   // Mac keyboard
            m_hashKeys.Add("00_69", "기능: F18");   // Mac keyboard
            m_hashKeys.Add("00_6A", "기능: F19");   // Mac keyboard
            m_hashKeys.Add("00_6B", "기능: F20");   // IBM Model F 122-keys
            m_hashKeys.Add("00_6C", "기능: F21");   // IBM Model F 122-keys
            m_hashKeys.Add("00_6D", "기능: F22");   // IBM Model F 122-keys
            m_hashKeys.Add("00_6E", "기능: F23");   // IBM Model F 122-keys
            m_hashKeys.Add("00_6F", "기능: F24");   // IBM Model F 122-keys
            m_hashKeys.Add("00_70", "알 수 없는: 0x0070");
            m_hashKeys.Add("00_71", "알 수 없는: 0x0071");
            m_hashKeys.Add("00_72", "알 수 없는: 0x0072");
            m_hashKeys.Add("00_73", "알 수 없는: 0x0073");
            m_hashKeys.Add("00_74", "알 수 없는: 0x0074");
            m_hashKeys.Add("00_75", "알 수 없는: 0x0075");
            m_hashKeys.Add("00_76", "알 수 없는: 0x0076");
            m_hashKeys.Add("00_77", "알 수 없는: 0x0077");
            m_hashKeys.Add("00_78", "알 수 없는: 0x0078");
            m_hashKeys.Add("00_79", "특수: Henkan(변환)");
            m_hashKeys.Add("00_7A", "알 수 없는: 0x007A");
            m_hashKeys.Add("00_7B", "특수: Muhenkan(무변환)");
            m_hashKeys.Add("00_7C", "알 수 없는: 0x007C");
            m_hashKeys.Add("00_7D", "특수: ¥ -");
            m_hashKeys.Add("00_7E", "알 수 없는: 0x007E");
            m_hashKeys.Add("00_7F", "알 수 없는: 0x007F");
            m_hashKeys.Add("E0_01", "알 수 없는: 0xE001");
            m_hashKeys.Add("E0_02", "알 수 없는: 0xE002");
            m_hashKeys.Add("E0_03", "알 수 없는: 0xE003");
            m_hashKeys.Add("E0_04", "알 수 없는: 0xE004");
            m_hashKeys.Add("E0_05", "알 수 없는: 0xE005");
            m_hashKeys.Add("E0_06", "알 수 없는: 0xE006");
            m_hashKeys.Add("E0_07", "기능키 잠금(F-Lock): 다시 실행");
            m_hashKeys.Add("E0_08", "기능키 잠금(F-Lock): 실행 취소");
            m_hashKeys.Add("E0_09", "알 수 없는: 0xE009");
            m_hashKeys.Add("E0_0A", "알 수 없는: 0xE00A");
            m_hashKeys.Add("E0_0B", "알 수 없는: 0xE00B");
            m_hashKeys.Add("E0_0C", "알 수 없는: 0xE00C");
            m_hashKeys.Add("E0_0D", "알 수 없는: 0xE00D");
            m_hashKeys.Add("E0_0E", "알 수 없는: 0xE00E");
            m_hashKeys.Add("E0_0F", "알 수 없는: 0xE00F");
            m_hashKeys.Add("E0_10", "미디어: 이전 트랙");
            m_hashKeys.Add("E0_11", "앱: 메신저");
            m_hashKeys.Add("E0_12", "로지텍: 웹캠");
            m_hashKeys.Add("E0_13", "로지텍: iTouch");
            m_hashKeys.Add("E0_14", "로지텍: 쇼핑");
            m_hashKeys.Add("E0_15", "알 수 없는: 0xE015");
            m_hashKeys.Add("E0_16", "알 수 없는: 0xE016");
            m_hashKeys.Add("E0_17", "알 수 없는: 0xE017");
            m_hashKeys.Add("E0_18", "알 수 없는: 0xE018");
            m_hashKeys.Add("E0_19", "미디어: 다음 트랙");
            m_hashKeys.Add("E0_1A", "알 수 없는: 0xE01A");
            m_hashKeys.Add("E0_1B", "알 수 없는: 0xE01B");
            m_hashKeys.Add("E0_1C", "숫자 패드: 엔터");
            m_hashKeys.Add("E0_1D", "특수: 오른쪽 컨트롤");
            m_hashKeys.Add("E0_1E", "알 수 없는: 0xE01E");
            m_hashKeys.Add("E0_1F", "알 수 없는: 0xE01F");
            m_hashKeys.Add("E0_20", "미디어: 음소거");
            m_hashKeys.Add("E0_2038", "특수: Alt Gr");
            m_hashKeys.Add("E0_21", "앱: 계산기");
            m_hashKeys.Add("E0_22", "미디어: 재생/일시정지");
            m_hashKeys.Add("E0_23", "기능키 잠금(F-Lock): Spell");
            m_hashKeys.Add("E0_24", "미디어: 정지");
            m_hashKeys.Add("E0_25", "알 수 없는: 0xE025");
            m_hashKeys.Add("E0_26", "알 수 없는: 0xE026");
            m_hashKeys.Add("E0_27", "알 수 없는: 0xE027");
            m_hashKeys.Add("E0_28", "알 수 없는: 0xE028");
            m_hashKeys.Add("E0_29", "알 수 없는: 0xE029");
            m_hashKeys.Add("E0_2A", "알 수 없는: 0xE02A");
            m_hashKeys.Add("E0_2B", "알 수 없는: 0xE02B");
            m_hashKeys.Add("E0_2C", "알 수 없는: 0xE02C");
            m_hashKeys.Add("E0_2D", "알 수 없는: 0xE02D");
            m_hashKeys.Add("E0_2E", "미디어: 볼륨 다운");
            m_hashKeys.Add("E0_2F", "알 수 없는: 0xE02F");
            m_hashKeys.Add("E0_30", "미디어: 볼륨 업");
            m_hashKeys.Add("E0_31", "알 수 없는: 0xE031");
            m_hashKeys.Add("E0_32", "웹: 홈페이지");
            m_hashKeys.Add("E0_33", "알 수 없는: 0xE033");
            m_hashKeys.Add("E0_34", "알 수 없는: 0xE034");
            m_hashKeys.Add("E0_35", "숫자 패드: /");
            m_hashKeys.Add("E0_36", "알 수 없는: 0xE036");
            m_hashKeys.Add("E0_37", "특수: 프린트 스크린");
            m_hashKeys.Add("E0_38", "특수: 오른쪽 알트");
            m_hashKeys.Add("E0_39", "알 수 없는: 0xE039");
            m_hashKeys.Add("E0_3A", "알 수 없는: 0xE03A");
            m_hashKeys.Add("E0_3B", "기능키 잠금(F-Lock): 도움말");
            m_hashKeys.Add("E0_3C", "기능키 잠금(F-Lock): Office Home");
            m_hashKeys.Add("E0_3D", "기능키 잠금(F-Lock): Task Pane");
            m_hashKeys.Add("E0_3E", "기능키 잠금(F-Lock): New");
            m_hashKeys.Add("E0_3F", "기능키 잠금(F-Lock): 오픈");
            m_hashKeys.Add("E0_40", "기능키 잠금(F-Lock): 닫기");
            m_hashKeys.Add("E0_41", "기능키 잠금(F-Lock): 답장");
            m_hashKeys.Add("E0_42", "기능키 잠금(F-Lock): Fwd");
            m_hashKeys.Add("E0_43", "기능키 잠금(F-Lock): 전송");
            m_hashKeys.Add("E0_44", "알 수 없는: 0xE044");
            m_hashKeys.Add("E0_45", "특수: €");
            m_hashKeys.Add("E0_46", "특수: Break");
            m_hashKeys.Add("E0_47", "특수: 홈");
            m_hashKeys.Add("E0_48", "방향: 위");
            m_hashKeys.Add("E0_49", "특수: 페이지 업");
            m_hashKeys.Add("E0_4A", "알 수 없는: 0xE04A");
            m_hashKeys.Add("E0_4B", "방향: 왼쪽");
            m_hashKeys.Add("E0_4C", "알 수 없는: 0xE04C");
            m_hashKeys.Add("E0_4D", "방향: 오른쪽");
            m_hashKeys.Add("E0_4E", "알 수 없는: 0xE04E");
            m_hashKeys.Add("E0_4F", "특수: 끝");
            m_hashKeys.Add("E0_50", "방향: 아래");
            m_hashKeys.Add("E0_51", "특수: 페이지 다운");
            m_hashKeys.Add("E0_52", "특수: 인서트");
            m_hashKeys.Add("E0_53", "특수: 삭제");
            m_hashKeys.Add("E0_54", "알 수 없는: 0xE054");
            m_hashKeys.Add("E0_55", "알 수 없는: 0xE055");
            m_hashKeys.Add("E0_56", "특수: < > |");
            m_hashKeys.Add("E0_57", "기능키 잠금(F-Lock): 저장");
            m_hashKeys.Add("E0_58", "기능키 잠금(F-Lock): 인쇄");
            m_hashKeys.Add("E0_59", "알 수 없는: 0xE059");
            m_hashKeys.Add("E0_5A", "알 수 없는: 0xE05A");
            m_hashKeys.Add("E0_5B", "특수: 왼쪽 윈도우키");
            m_hashKeys.Add("E0_5C", "특수: 오른쪽 윈도우키");
            m_hashKeys.Add("E0_5D", "특수: 애플리케이션");
            m_hashKeys.Add("E0_5E", "특수: 전원");
            m_hashKeys.Add("E0_5F", "특수: 절전");
            m_hashKeys.Add("E0_60", "알 수 없는: 0xE060");
            m_hashKeys.Add("E0_61", "알 수 없는: 0xE061");
            m_hashKeys.Add("E0_62", "알 수 없는: 0xE062");
            m_hashKeys.Add("E0_63", "특수: 웨이크 (또는 Fn)");
            m_hashKeys.Add("E0_64", "알 수 없는: 0xE064");
            m_hashKeys.Add("E0_65", "웹: 검색");
            m_hashKeys.Add("E0_66", "웹: 즐겨찾기");
            m_hashKeys.Add("E0_67", "웹: 새로 고침");
            m_hashKeys.Add("E0_68", "웹: 정지");
            m_hashKeys.Add("E0_69", "웹: 앞으로");
            m_hashKeys.Add("E0_6A", "웹: 뒤로");
            m_hashKeys.Add("E0_6B", "앱: 내 컴퓨터");
            m_hashKeys.Add("E0_6C", "앱: 메일");
            m_hashKeys.Add("E0_6D", "앱: 미디어 선택");
            m_hashKeys.Add("E0_6E", "알 수 없는: 0xE06E");
            m_hashKeys.Add("E0_6F", "알 수 없는: 0xE06F");
            m_hashKeys.Add("E0_70", "알 수 없는: 0xE070");
            m_hashKeys.Add("E0_71", "알 수 없는: 0xE071");
            m_hashKeys.Add("E0_72", "알 수 없는: 0xE072");
            m_hashKeys.Add("E0_73", "알 수 없는: 0xE073");
            m_hashKeys.Add("E0_74", "알 수 없는: 0xE074");
            m_hashKeys.Add("E0_75", "알 수 없는: 0xE075");
            m_hashKeys.Add("E0_76", "알 수 없는: 0xE076");
            m_hashKeys.Add("E0_77", "알 수 없는: 0xE077");
            m_hashKeys.Add("E0_78", "알 수 없는: 0xE078");
            m_hashKeys.Add("E0_79", "알 수 없는: 0xE079");
            m_hashKeys.Add("E0_7A", "알 수 없는: 0xE07A");
            m_hashKeys.Add("E0_7B", "알 수 없는: 0xE07B");
            m_hashKeys.Add("E0_7C", "알 수 없는: 0xE07C");
            m_hashKeys.Add("E0_7D", "알 수 없는: 0xE07D");
            m_hashKeys.Add("E0_7E", "알 수 없는: 0xE07E");
            m_hashKeys.Add("E0_7F", "알 수 없는: 0xE07F");
            m_hashKeys.Add("E0_A4", "알 수 없는: 0xE0A4"); // Possibly Left MENU key
            m_hashKeys.Add("E0_A5", "알 수 없는: 0xE0A5"); // Possibly Right MENU key
            m_hashKeys.Add("E0_A6", "알 수 없는: 0xE0A6"); // Possibly Browser Back key
            m_hashKeys.Add("E0_A7", "알 수 없는: 0xE0A7"); // Possibly Browser Forward key
            m_hashKeys.Add("E0_A8", "알 수 없는: 0xE0A8"); // Possibly Browser Refresh key
            m_hashKeys.Add("E0_A9", "알 수 없는: 0xE0A9"); // Possibly Browser Stop key
            m_hashKeys.Add("E0_AA", "알 수 없는: 0xE0AA"); // Possibly Browser Search key
            m_hashKeys.Add("E0_AB", "알 수 없는: 0xE0AB"); // Possibly Browser Favorites key
            m_hashKeys.Add("E0_AC", "알 수 없는: 0xE0AC"); // Possibly Browser Start and Home key
            m_hashKeys.Add("E0_AD", "알 수 없는: 0xE0AD"); // Possibly Volume Mute key
            m_hashKeys.Add("E0_AE", "알 수 없는: 0xE0AE"); // Possibly Volume Down key
            m_hashKeys.Add("E0_AF", "알 수 없는: 0xE0AF"); // Possibly Volume Up key
            m_hashKeys.Add("E0_B0", "알 수 없는: 0xE0B0"); // Media: Next track (alternate)
            m_hashKeys.Add("E0_B1", "알 수 없는: 0xE0B1"); // Media: Previous track (alternate)
            m_hashKeys.Add("E0_B2", "알 수 없는: 0xE0B2"); // Media: Stop (alternate)
            m_hashKeys.Add("E0_B3", "알 수 없는: 0xE0B3"); // Media: Play/Pause (alternate)
            m_hashKeys.Add("E0_B4", "알 수 없는: 0xE0B4"); // App: Mail (alternate)
            m_hashKeys.Add("E0_B5", "알 수 없는: 0xE0B5"); // App: Select Media key
            m_hashKeys.Add("E0_B6", "알 수 없는: 0xE0B6"); // Start Application 1 key
            m_hashKeys.Add("E0_B7", "알 수 없는: 0xE0B7"); // Start Application 2 key
            m_hashKeys.Add("E0_B8", "알 수 없는: 0xE0B8"); // Reserved
            m_hashKeys.Add("E0_B9", "알 수 없는: 0xE0B9"); // Reserved
            m_hashKeys.Add("E0_BA", "알 수 없는: 0xE0BA"); // Used for miscellaneous characters; it can vary by keyboard.
            m_hashKeys.Add("E0_BB", "알 수 없는: 0xE0BB"); // For any country/region, the '+' key
            m_hashKeys.Add("E0_BC", "알 수 없는: 0xE0BC"); // For any country/region, the ',' key
            m_hashKeys.Add("E0_BD", "알 수 없는: 0xE0BD"); // For any country/region, the '-' key
            m_hashKeys.Add("E0_BE", "알 수 없는: 0xE0BE"); // For any country/region, the '.' key
            m_hashKeys.Add("E0_BF", "알 수 없는: 0xE0BF"); // Varies by keyboard
            m_hashKeys.Add("E0_C0", "알 수 없는: 0xE0C0"); // Unknown key
            m_hashKeys.Add("E0_DB", "알 수 없는: 0xE0BB"); // Varies by keyboard
            m_hashKeys.Add("E0_DC", "알 수 없는: 0xE0BC"); // Varies by keyboard
            m_hashKeys.Add("E0_DD", "알 수 없는: 0xE0BD"); // Varies by keyboard
            m_hashKeys.Add("E0_DE", "알 수 없는: 0xE0BE"); // Varies by keyboard
            m_hashKeys.Add("E0_DF", "알 수 없는: 0xE0BF"); // Varies by keyboard
            m_hashKeys.Add("E0_E1", "알 수 없는: 0xE0B1"); // Varies by keyboard
            m_hashKeys.Add("E0_E2", "알 수 없는: 0xE0B2"); // Varies by keyboard
            m_hashKeys.Add("E0_E3", "알 수 없는: 0xE0B3"); // Varies by keyboard
            m_hashKeys.Add("E0_E4", "알 수 없는: 0xE0B4"); // Varies by keyboard
            m_hashKeys.Add("E0_F1", "특수: Hanja Key(한자 키)");
            m_hashKeys.Add("E0_F2", "특수: Hangul Key(한글 키)");
        }

        // Dialog related events and overrides
        private void Dialog_Main_Load(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Set up the hashtable and load the registy settings
            BuildParseTables();
            LoadRegistrySettings();

            // UI tweaking
            if (lvKeys.Items.Count > 0)
            {
                lvKeys.Items[0].Selected = true;
            }
            Cursor = Cursors.Default;
        }

        private void Dialog_Main_Closing(object sender, CancelEventArgs e)
        {
            // if anything has been added, edit'd or delete'd, ask if a save to the registry should be performed
            if (m_bDirty)
            {
                DialogResult dlgRes = MessageBox.Show("변경사항이 있습니다.\n\n레지스트리에 쓰시겠습니까?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button3);
                if (dlgRes == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (dlgRes == DialogResult.Yes)
                {
                    // update the registry
                    SaveMappingsToRegistry();
                }
            }
            SaveRegistrySettings();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);

            // save the current window position/size whenever moved
            if (WindowState == FormWindowState.Normal)
            {
                m_rcWindow = DesktopBounds;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // resize the listview columns whenever sizeds
            lvcFrom.Width = lvKeys.Width / 2 - 2;
            lvcTo.Width = lvcFrom.Width - 2;

            // save the current window position/size whenever moved
            if (WindowState == FormWindowState.Normal)
            {
                m_rcWindow = DesktopBounds;
            }
        }


        // Other Events
        private void lvKeys_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // UI stuff (to prevent editing or deleting a non-item
            if (lvKeys.SelectedItems.Count <= 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void mnuPop_Popup(object sender, System.EventArgs e)
        {
            // UI stuff (to prevent editing or deleting a non-item
            if (lvKeys.SelectedItems.Count <= 0)
            {
                mniEdit.Enabled = false;
                mniDelete.Enabled = false;
            }
            else
            {
                mniEdit.Enabled = true;
                mniDelete.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            AddMapping();
        }

        private void mniAdd_Click(object sender, System.EventArgs e)
        {
            AddMapping();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            EditMapping();
        }

        private void mniEdit_Click(object sender, System.EventArgs e)
        {
            EditMapping();
        }

        private void lvKeys_DoubleClick(object sender, System.EventArgs e)
        {
            EditMapping();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DeleteMapping();
        }

        private void mniDelete_Click(object sender, System.EventArgs e)
        {
            DeleteMapping();
        }

        private void btnDeleteAll_Click(object sender, System.EventArgs e)
        {
            DeleteAllMapping();
        }

        private void mniDeleteAll_Click(object sender, System.EventArgs e)
        {
            DeleteAllMapping();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveMappingsToRegistry();
        }

        private void urlMain_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // open the home page
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void Dialog_Main_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

    }
}
