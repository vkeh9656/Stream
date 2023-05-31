using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConfigSet_Click(object sender, EventArgs e)
        {
            string strEnter = "\r\n";

            string strText = tboxData.Text;
            bool bChecked = cboxData.Checked;
            int iNumber = (int)numData.Value;

            StringBuilder sb = new StringBuilder();
            sb.Append(strText + strEnter);
            sb.Append(bChecked.ToString() + strEnter);
            sb.Append(iNumber.ToString() + strEnter);

            tboxConfigData.Text = sb.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;

            saveFileDialog.InitialDirectory = Application.StartupPath; // 프로그램 실행 파일 위치
            saveFileDialog.FileName = "*.txt";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = saveFileDialog.FileName;
                
                //StreamWriter swSaveFileDialog = new StreamWriter(strFilePath);

                //swSaveFileDialog.WriteLine(tboxConfigData.Text);
                //swSaveFileDialog.Close();

                File.WriteAllText(strFilePath, tboxData.Text); // 위 3줄 주석과 동일한 기능임.
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;

            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.FileName = "*.txt";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            StringBuilder sb = new StringBuilder();

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = openFileDialog.FileName;

                //StreamReader srOpenFileDialog = new StreamReader(strFilePath, Encoding.UTF8, true);

                //while(srOpenFileDialog.EndOfStream == false)
                //{
                //    sb.Append(srOpenFileDialog.ReadLine());
                //    sb.Append("\r\n");
                //}

                sb.Append(File.ReadAllText(strFilePath)); // 위 5줄과 동일한 기능

                tboxConfigData.Text = sb.ToString();
            }
        }

        private void btnConfigRead_Click(object sender, EventArgs e)
        {
            string[] strConfig = tboxConfigData.Text.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            tboxData.Text = strConfig[0];
            cboxData.Checked = bool.Parse(strConfig[1]);
            numData.Value = int.Parse(strConfig[2]);
        }
    }
}
