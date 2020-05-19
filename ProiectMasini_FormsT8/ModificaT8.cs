using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectMasini_FormsT8
{
    public partial class ModificaT8 : Form
    {
        public ModificaT8()
        {
            InitializeComponent();
        }

        private void ModificaT8_Load(object sender, EventArgs e)
        {

        }

        public string getId()
        {
            return idTxt.Text;
        }


        private void okBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTxt.Text);
            getId();
            this.Close();
        }
    }
}
