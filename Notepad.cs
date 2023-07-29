using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiapp
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String txt;
            openFileDialog1.ShowDialog();
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
            txt = file.ReadToEnd();
            TextBox.Text = txt.ToString();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Sin Titulo";
            var sv = saveFileDialog1.ShowDialog();

            if (sv == DialogResult.OK){

                using (var sv_file = new System.IO.StreamWriter(saveFileDialog1.FileName)) {
                    sv_file.WriteLine(TextBox.Text);
                }
            }   
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Undo();
        }

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Redo();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Cut();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Paste();
        }

        private void seleccionartodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.SelectAll();
        }

        private void suprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.DeselectAll();
        }

        private void formatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formato = fontDialog1.ShowDialog();
            if (formato == DialogResult.OK)
            {
                TextBox.Font = fontDialog1.Font;
            }
           
        }
    }
}
