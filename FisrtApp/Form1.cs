using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisrtApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog openfiledialog;
        List<String> FilePaths = new List<string>();
        List<String> FileNames = new List<string>();

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            
            if(listBox1.SelectedIndex != -1)
            {
               String[] FP = FilePaths.ToArray();
               String[] FN = FileNames.ToArray();
               int Choose = listBox1.SelectedIndex;
               axWindowsMediaPlayer1.URL = FP[Choose];
               this.textBox1.Text = "Đang phát: " + FN[Choose];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "MP3 files, MP4 files, M4V files, MKV files (*.mp3; *.mp4; *.m4v; *.mkv)| *.mp*; *.m4v; *.mkv";
            openfiledialog.Multiselect = true;
            openfiledialog.Title = "Open";

            if(openfiledialog.ShowDialog() == DialogResult.OK)
            {
                String [] a = openfiledialog.FileNames;
                String [] b = openfiledialog.SafeFileNames;
                foreach (var i in a)
                {
                    FilePaths.Add(i);   //lay duong dan file
                } 

                foreach(var i in b)
                {
                    FileNames.Add(i);    //luu ten file
                    listBox1.Items.Add(i);  //luu ten file vao listbox
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(res == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            
        }
    }
}
