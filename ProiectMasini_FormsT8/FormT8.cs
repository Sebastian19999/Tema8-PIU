using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using LibrarieModele;
using NivelAccesDate;
using ManagerM;

namespace ProiectMasini_FormsT8
{
    public partial class FormT8 : Form
    {

        IStocareData adminMasini;
        ArrayList optiuniSelectate = new ArrayList();

        public int idMasina { get; set; }

        public FormT8()
        {
            InitializeComponent();
            adminMasini = ManagerMasini.GetAdministratorStocare();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optiuniGrpBox_Enter(object sender, EventArgs e)
        {

        }

        private void ckbOptiuni_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox; 

            string optiuneSelectata = checkBoxControl.Text;

            if (checkBoxControl.Checked == true)
                optiuniSelectate.Add(optiuneSelectata);
            else
                optiuniSelectate.Remove(optiuneSelectata);
        }

        private void adaugaBtn_Click(object sender, EventArgs e)
        {
            Masina masina;

            firmaLbl.ForeColor = Color.Black;
            modelLbl.ForeColor = Color.Black;
            anFLbl.ForeColor = Color.Black;
            culoareLbl.ForeColor = Color.Black;
            numeVanzatorLbl.ForeColor = Color.Black;
            numeCumparatorLbl.ForeColor = Color.Black;
            dataLbl.ForeColor = Color.Black;
            pretLbl.ForeColor = Color.Black;
            optiuniLbl.ForeColor = Color.Black;

            firmaTxt.ForeColor = Color.Black;
            modelTxt.ForeColor = Color.Black;
            anFTxt.ForeColor = Color.Black;
            //culoareTxt.ForeColor = Color.Black;
            numeVanzatorTxt.ForeColor = Color.Black;
            numeCumparatorTxt.ForeColor = Color.Black;
            dataTxt.ForeColor = Color.Black;
            pretTxt.ForeColor = Color.Black;
            //optiuniTxt.ForeColor = Color.Black;
            CodEroare valideaza = Validare(firmaTxt.Text, modelTxt.Text,
                //culoareTxt.Text,
                anFTxt.Text, numeVanzatorTxt.Text, numeCumparatorTxt.Text, dataTxt.Text, pretTxt.Text
                //, optiuniTxt.Text
                );
            if (GetCuloareSelectata() == Culori.culoare_inexistenta)
            {
                culoareLbl.ForeColor = Color.Red;
            }else
            if (validareOptiuni() == 0)
            {
                optiuniLbl.ForeColor = Color.Red;
            }else
            if (valideaza != CodEroare.CORECT)
            {
                switch (valideaza)
                {
                    case CodEroare.FIRMA_INCORECTA:
                        firmaTxt.ForeColor = Color.Red;
                        if (firmaTxt.Text == string.Empty)
                            firmaLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.MODEL_INCORECT:
                        modelTxt.ForeColor = Color.Red;
                        if (modelTxt.Text == string.Empty)
                            modelLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.AN_FABRICATIE_INCORECT:
                        anFTxt.ForeColor = Color.Red;
                        if (anFTxt.Text == string.Empty)
                            anFLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.NUME_VANZATOR_INCORECT:
                        numeVanzatorTxt.ForeColor = Color.Red;
                        if (numeVanzatorTxt.Text == string.Empty)
                            numeVanzatorLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.NUME_CUMPARATOR_INCORECT:
                        numeCumparatorTxt.ForeColor = Color.Red;
                        if (numeCumparatorTxt.Text == string.Empty)
                            numeCumparatorLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.DATA_INCORECTA:
                        dataTxt.ForeColor = Color.Red;
                        if (dataTxt.Text == string.Empty)
                            dataLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.PRET_INCORECT:
                        pretTxt.ForeColor = Color.Red;
                        if (pretTxt.Text == string.Empty)
                            pretLbl.ForeColor = Color.Red;
                        break;
                }
            }
            else
            {
                string optiuniMasinaForm = OptiuniAsString();
                masina = new Masina(numeVanzatorTxt.Text.ToString(), numeCumparatorTxt.Text.ToString()
                , firmaTxt.Text.ToString(), modelTxt.Text.ToString(), Convert.ToInt32(anFTxt.Text.ToString()),
                "rosu",optiuniMasinaForm, dataTxt.Text.ToString(), Convert.ToDouble(pretTxt.Text.ToString()),"Sedan",DateTime.Now);


                masina.CuloareMasina = GetCuloareSelectata();
                masina.identificaCuloare();


                masina.Optiuni = new ArrayList();
                masina.Optiuni.AddRange(optiuniSelectate);

                ManagerMasini.addMasina(masina);
                afisareLbl.Text = "Masina a fost adaugata";

                //ResetareControale();
            }
            ResetareControale();
        }

        private CodEroare Validare(string firma, string model,
            //string culoare,
            string anFabricatie,
                      string numeVanzator, string numeCumparator, string dataTranzactie, string pret
            //, string optiuni
            )
        {

            if (firma == string.Empty)
            {
                return CodEroare.FIRMA_INCORECTA;
            }
            else if (model == string.Empty)
            {
                return CodEroare.MODEL_INCORECT;
            }
            //else if (culoare == string.Empty)
            //{
            //    return CodEroare.CULOARE_INCORECTA;
            //}
            else if (anFabricatie == string.Empty)
            {
                return CodEroare.AN_FABRICATIE_INCORECT;
            }
            else if (numeVanzator == string.Empty)
            {
                return CodEroare.NUME_VANZATOR_INCORECT;
            }
            else if (numeCumparator == string.Empty)
            {
                return CodEroare.NUME_CUMPARATOR_INCORECT;
            }
            else if (dataTranzactie == string.Empty)
            {
                return CodEroare.DATA_INCORECTA;
            }
            else if (pret == string.Empty)
            {
                return CodEroare.PRET_INCORECT;
            }
            //else if (optiuni == string.Empty)
            //{
            //    return CodEroare.OPTIUNI_INCORECTE;
            //}


            return CodEroare.CORECT;
        }

        public string OptiuniAsString()
        {

            string strOptiuni = string.Empty;

            foreach (string optiune in optiuniSelectate)
            {
                if (strOptiuni != string.Empty)
                {
                    strOptiuni += ", ";
                }
                strOptiuni += optiune;
            }

            return strOptiuni;

        }

        private void afisareBtn_Click(object sender, EventArgs e)
        {
            List<Masina> masini = new List<Masina>(ManagerMasini.getMasiniList());
            File.WriteAllText(@"C:\Users\sebyg\source\repos\ProiectMasiniPIU\ProiectMasiniPIU\MasiniSalvate.txt", String.Empty);

            afisareRichTextBox.Clear();
            var antetTabel = String.Format("{0,-8}{1,-30}{2,-30}{3,-20}{4,-15}{5,-15}{6,-14}{7,-20}{8,-10}\n", "Id", "Nume vanzator", "Nume cumparator", "Data tranzactie", "Firma", "Model", "Culoare", "An fabricatie", "Pret");
            afisareRichTextBox.AppendText(antetTabel);
       
            foreach (Masina m in masini)
            {
                int calculId = -8 - m.getIdMasina().ToString().Length + 1;
                int calculNumeVanzator = -30 - m.numeVanzator.Length + 10;
                int calculNumeCumparator = -30 - m.numeCumparator.Length + 7;
                int calculData = -20 - m.dataTranzactie.Length + 6;
                int calculFirma = -15 - m.firmaProp.Length + 4;
                int calculModel = -15 - m.modelProp.Length + 3;
                int calculCuloare = -14 - m.culoareProp.Length + 4;
                int calculAn = -20 - m.anFabricatie.ToString().Length + 2;
                int calculPret = -10 - m.pretProp.ToString().Length + 1;

                var mAfisare = String.Format("\n{0," + calculId.ToString() + "}{1," + calculNumeVanzator.ToString() + "}{2," + calculNumeCumparator.ToString() + "}{3," + calculData.ToString() + "}{4," + calculFirma.ToString() + "}{5," + calculModel.ToString() + "}{6," + calculCuloare.ToString() + "}{7," + calculAn.ToString() + "}{8," + calculPret.ToString() + "}\n",
                    m.getIdMasina().ToString(), m.numeVanzator, m.numeCumparator, m.dataTranzactie, m.firmaProp, m.modelProp, m.culoareProp, m.anFabricatie.ToString(), m.pretProp.ToString());
                afisareRichTextBox.AppendText(mAfisare);
                afisareRichTextBox.AppendText("\t\t" + m.OptiuniAsString);
                afisareRichTextBox.AppendText(Environment.NewLine);
                adminMasini.AddMasina(m);
            }
            afisareLbl.Text = "Lista cu masini a fost afisata";
        }

        private Culori GetCuloareSelectata()
        {
            if (albRdb.Checked)
                return Culori.alb;
            if (albastruRdb.Checked)
                return Culori.albastru;
            if (movRdb.Checked)
                return Culori.mov;
            if (maroRdb.Checked)
                return Culori.maro;
            if (portocaliuRdb.Checked)
                return Culori.portocaliu;
            if (negruRdb.Checked)
                return Culori.negru;
            if (galbenRdb.Checked)
                return Culori.galben;
            if (verdeRdb.Checked)
                return Culori.verde;
            if (rosuRdb.Checked)
                return Culori.rosu;

            return Culori.culoare_inexistenta;
        }

        private int validareOptiuni()
        {
            if (absCheck.Checked == false && airbagCheck.Checked == false && cruiseCheck.Checked == false &&
                solarCheck.Checked == false && bluetoothCheck.Checked == false && proiectoareCheck.Checked == false &&
                pilotCheck.Checked == false && masajCheck.Checked == false && leatherCheck.Checked == false)
                return 0;
            return 1;
        }

        private void ResetareControale()
        {
            firmaTxt.Text = string.Empty;
            modelTxt.Text = string.Empty;
            anFTxt.Text = string.Empty;
            numeVanzatorTxt.Text = string.Empty;
            numeCumparatorTxt.Text = string.Empty;
            dataTxt.Text = string.Empty;
            pretTxt.Text = string.Empty;
            albRdb.Checked = false;
            albastruRdb.Checked = false;
            rosuRdb.Checked = false;
            portocaliuRdb.Checked = false;
            negruRdb.Checked = false;
            verdeRdb.Checked = false;
            maroRdb.Checked = false;
            movRdb.Checked = false;
            galbenRdb.Checked = false;
            absCheck.Checked = false;
            airbagCheck.Checked = false;
            cruiseCheck.Checked = false;
            solarCheck.Checked = false;
            bluetoothCheck.Checked = false;
            proiectoareCheck.Checked = false;
            pilotCheck.Checked = false;
            masajCheck.Checked = false;
            leatherCheck.Checked = false;
            optiuniSelectate.Clear();
            //lblMesaj.Text = string.Empty;
        }

        private string getCuloareCautata()
        {
            if (albRdb.Checked == true)
                return "alb";
            if (albastruRdb.Checked == true)
                return "albastru";
            if (movRdb.Checked == true)
                return "mov";
            if (galbenRdb.Checked == true)
                return "galben";
            if (portocaliuRdb.Checked == true)
                return "portocaliu";
            if (rosuRdb.Checked == true)
                return "rosu";
            if (verdeRdb.Checked == true)
                return "verde";
            if (maroRdb.Checked == true)
                return "maro";
            if (negruRdb.Checked == true)
                return "negru";
            return string.Empty;
        }



        private void cautareBtn_Click(object sender, EventArgs e)
        {
            if (firmaTxt.Text == string.Empty && modelTxt.Text == string.Empty && numeVanzatorTxt.Text == string.Empty && numeCumparatorTxt.Text == string.Empty && GetCuloareSelectata()==Culori.culoare_inexistenta && dataTxt.Text == string.Empty && anFTxt.Text == string.Empty && pretTxt.Text == string.Empty && validareOptiuni()==0)
            {
                afisareLbl.Text = "Introduceti datele corespunzatoare cautarii...";
            }
            else
            {
                afisareRichTextBox.Clear();
                List<Masina> cautari = new List<Masina>(ManagerMasini.CautareMasiniForms(firmaTxt.Text, modelTxt.Text,
                                        getCuloareCautata(), anFTxt.Text, numeVanzatorTxt.Text, numeCumparatorTxt.Text,
                                        dataTxt.Text, pretTxt.Text, "ABS"));

                var antetTabel = String.Format("{0,-8}{1,-30}{2,-30}{3,-20}{4,-15}{5,-15}{6,-14}{7,-20}{8,-10}\n", "Id", "Nume vanzator", "Nume cumparator", "Data tranzactie", "Firma", "Model", "Culoare", "An fabricatie", "Pret");
                afisareRichTextBox.AppendText(antetTabel);

                foreach (Masina m in cautari)
                {
                    int calculId = -8 - m.getIdMasina().ToString().Length + 1;
                    int calculNumeVanzator = -30 - m.numeVanzator.Length + 1;
                    int calculNumeCumparator = -30 - m.numeCumparator.Length + 15;
                    int calculData = -20 - m.dataTranzactie.Length + 9;
                    int calculFirma = -15 - m.firmaProp.Length + 4;
                    int calculModel = -15 - m.modelProp.Length + 6;
                    int calculCuloare = -14 - m.culoareProp.Length + 4;
                    int calculAn = -20 - m.anFabricatie.ToString().Length + 2;
                    int calculPret = -10 - m.pretProp.ToString().Length + 1;

                    var mAfisare = String.Format("\n{0," + calculId.ToString() + "}{1," + calculNumeVanzator.ToString() + "}{2," + calculNumeCumparator.ToString() + "}{3," + calculData.ToString() + "}{4," + calculFirma.ToString() + "}{5," + calculModel.ToString() + "}{6," + calculCuloare.ToString() + "}{7," + calculAn.ToString() + "}{8," + calculPret.ToString() + "}\n",
                        m.getIdMasina().ToString(), m.numeVanzator, m.numeCumparator, m.dataTranzactie, m.firmaProp, m.modelProp, m.culoareProp, m.anFabricatie.ToString(), m.pretProp.ToString());
                    afisareRichTextBox.AppendText(mAfisare);
                    afisareRichTextBox.AppendText("\t\t" + m.OptiuniAsString);
                    afisareRichTextBox.AppendText(Environment.NewLine);
                }
                afisareLbl.Text = "Cautarile au fost efectuate";
                ResetareControale();
            }
        }

        private void FormT8_Load(object sender, EventArgs e)
        {

        }

        private int nrC { get; set; }

        private void editareBtn_Click(object sender, EventArgs e)
        {
            albRdb.Checked = false;
            if (firmaTxt.Text == string.Empty && modelTxt.Text == string.Empty && numeVanzatorTxt.Text == string.Empty && numeCumparatorTxt.Text == string.Empty && GetCuloareSelectata() == Culori.culoare_inexistenta && dataTxt.Text == string.Empty && anFTxt.Text == string.Empty && pretTxt.Text == string.Empty && validareOptiuni() == 0&&nrC!=1)
            {
                nrC = 1;
                afisareRichTextBox.Clear();
                List<Masina> listaMasini = new List<Masina>(ManagerMasini.getMasiniList());
                

                foreach (Masina m in listaMasini)
                {
                    afisareRichTextBox.AppendText(m.toString());
                    afisareRichTextBox.AppendText(Environment.NewLine);
                }
                afisareLbl.Text = "Introduceti noile modificari";

                ModificaT8 modificaForm = new ModificaT8();
                modificaForm.ShowDialog();
                int id = Convert.ToInt32(modificaForm.getId());
                Masina masina = ManagerMasini.getMasina(id);
                firmaTxt.Text = masina.firmaProp;
                modelTxt.Text = masina.modelProp;
                anFTxt.Text = masina.anFabricatie.ToString();
                if (masina.culoareProp.Trim().Equals("alb"))
                    albRdb.Checked = true;
                else if (masina.culoareProp.Trim().Equals("albastru"))
                    albastruRdb.Checked = true;
                else if (masina.culoareProp.Trim().Equals("mov"))
                    movRdb.Checked = true;
                else if (masina.culoareProp.Trim().Equals("galben"))
                    galbenRdb.Checked = true;
                else if (masina.culoareProp.Trim().Equals("portocaliu"))
                    portocaliuRdb.Checked = true;
                else if (masina.culoareProp.Trim().Equals("rosu"))
                    rosuRdb.Checked = true;
                else if (masina.culoareProp.Trim().Equals("verde"))
                    verdeRdb.Checked = true;
                else if (masina.culoareProp.Trim().Equals("maro"))
                    maroRdb.Checked = true;
                else if (masina.culoareProp.Trim().Equals("negru"))
                    negruRdb.Checked = true;

                //culoareTxt.Text = masina.culoareProp;
                numeCumparatorTxt.Text = masina.numeCumparator;
                numeVanzatorTxt.Text = masina.numeVanzator;
                pretTxt.Text = masina.pretProp.ToString();
                dataTxt.Text = masina.dataTranzactie;

                string[] optiuniMasinaCautata = masina.OptiuniAsString.Split(',');
                foreach (string opt in optiuniMasinaCautata)
                {
                    if (opt.Trim().Equals("ABS"))
                        absCheck.Checked = true;
                    if (opt.Trim().Equals("Airbaguri laterale"))
                        airbagCheck.Checked = true;
                    if (opt.Trim().Equals("Cruise Control"))
                        cruiseCheck.Checked = true;
                    if (opt.Trim().Equals("Solar Roof"))
                        solarCheck.Checked = true;
                    if (opt.Trim().Equals("Conectivitate Bluetooth"))
                        bluetoothCheck.Checked = true;
                    if (opt.Trim().Equals("Proiectoare Ceata"))
                        proiectoareCheck.Checked = true;
                    if (opt.Trim().Equals("Pilot automat"))
                        pilotCheck.Checked = true;
                    if (opt.Trim().Equals("Scaune masaj"))
                        masajCheck.Checked = true;
                    if (opt.Trim().Equals("Full Leather"))
                        leatherCheck.Checked = true;

                }
                //optiuniTxt.Text = masina.optiuniProp;

                idMasina = id;
            }
            else
            {
                nrC = 2;
                Masina masina = ManagerMasini.getMasina(idMasina);
                masina.firmaProp = firmaTxt.Text;
                masina.modelProp = modelTxt.Text;
                masina.anFabricatie = Convert.ToInt32(anFTxt.Text);
                masina.CuloareMasina = GetCuloareSelectata();
                masina.identificaCuloare();
                masina.numeVanzator = numeVanzatorTxt.Text;
                masina.numeCumparator = numeCumparatorTxt.Text;
                masina.dataTranzactie = dataTxt.Text;
                masina.pretProp = Convert.ToDouble(pretTxt.Text);
                if (OptiuniAsString() != string.Empty)
                    masina.setOptiuni(OptiuniAsString());

                afisareRichTextBox.Clear();
                afisareRichTextBox.AppendText(masina.toString());
                ResetareControale();
            }
        }

        private void firmaLbl_Click(object sender, EventArgs e)
        {

        }

        private void modelLbl_Click(object sender, EventArgs e)
        {

        }

        private void anFLbl_Click(object sender, EventArgs e)
        {

        }

        private void culoareLbl_Click(object sender, EventArgs e)
        {

        }

        private void afisareRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
