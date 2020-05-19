using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LibrarieModele
{
    public class Masina
    {
        private const bool SUCCES = true;
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';
        private const char SEPARATOR_OPTIUNI = ',';

        public static int idM;
        private int idMasina;
        private string nume_vanzator;
        private string nume_cumparator;
        private string firma, model;
        private int an_fabricatie;
        private string culoare;
        private string optiuni;
        private string data_tranzactie;
        private double pret;

        private string[] optiuniMasina;

        private const int ID = 0;
        private const int FIRMA = 1;
        private const int MODEL = 2;
        private const int CULOARE = 3;
        private const int ANF = 4;
        private const int NUMEV = 5;
        private const int NUMEC = 6;
        private const int DATAT = 7;
        private const int PRET = 8;
        private const int OPTIUNI = 9;
        private const int TIP = 10;
        private const int DATE_TIME = 11;


        private int numarCautari = 0;

        public int idMasinaPropp { get; set; }

        public static int idMasinaProp { get; set; } = 0;
        public int idMasinaFin { get; set; }
        public string numeVanzator { get; set; }
        public string numeCumparator { get; set; }
        public string firmaProp { get; set; }
        public string modelProp { get; set; }
        public int anFabricatie { get; set; }
        public string culoareProp { get; set; }
        public string optiuniProp { get; set; }
        public string dataTranzactie { get; set; }
        public double pretProp { get; set; }

        public string tipMasina { get; set; }

        public Culori CuloareMasina { get; set; }

        public ArrayList Optiuni { get; set; }

        public DateTime dataActualizare { get; set; }

        public string OptiuniAsString
        {
            get
            {
                string strOptiuni = string.Empty;

                foreach (string optiune in optiuniMasina)
                {
                    if (strOptiuni != string.Empty)
                    {
                        strOptiuni += SEPARATOR_OPTIUNI;
                    }
                    strOptiuni += optiune;
                }

                return strOptiuni;
            }
        }


        public Masina()
        {
            this.nume_vanzator = string.Empty;
            this.nume_cumparator = string.Empty;
            this.firma = string.Empty;
            this.model = string.Empty;
            this.an_fabricatie = 0;
            this.culoare = string.Empty;
            this.optiuni = string.Empty;
            this.data_tranzactie = string.Empty;
            this.pret = 0;

            idM++;
            setIdMasina(idM);

        }
        ///
        public Masina(string nv, string nc, string firma, string model, int anf, string dt, double pret)
        {
            numeVanzator = nv;
            numeCumparator = nc;
            firmaProp = firma;
            modelProp = model;
            anFabricatie = anf;
            culoareProp = culoare;
            //optiuniMasina = optiuni.Split(',');
            dataTranzactie = dt;
            pretProp = pret;

            idM++;
            setIdMasina(idM);
        }

        string opt;

        public Masina(string nv, string nc, string firma, string model, int anf, string culoare, string optiuni, string dt, double pret,string tipM,DateTime dateT)
        {
            numeVanzator = nv;
            numeCumparator = nc;
            firmaProp = firma;
            modelProp = model;
            anFabricatie = anf;
            culoareProp = culoare;

            optiuniMasina = optiuni.Split(',');
            dataTranzactie = dt;
            pretProp = pret;

            tipMasina = tipM;
            dataActualizare = dateT;

            idM++;
            setIdMasina(idM);
            idMasinaPropp = idM;
        }

        public int comparaCuAltObiect(Masina obiect, int nr)
        {
            int rez = 0;
            if (nr == 1)
            {
                if (anFabricatie < obiect.anFabricatie)
                    rez = -1;
                else if (anFabricatie == obiect.anFabricatie)
                    rez = 0;
                else if (anFabricatie > obiect.anFabricatie)
                    rez = 1;
            }
            else if (nr == 2)
            {
                if (pretProp < obiect.pretProp)
                    rez = -1;
                else if (pretProp == obiect.pretProp)
                    rez = 0;
                else if (pretProp > obiect.pretProp)
                    rez = 1;

            }

            return rez;

        }

        public Masina(string linieFisier, int nr)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ToString()
            idMasinaFin = Convert.ToInt32(dateFisier[ID]);
            firmaProp = dateFisier[FIRMA];
            modelProp = dateFisier[MODEL];
            culoareProp = dateFisier[CULOARE];
            anFabricatie = Convert.ToInt32(dateFisier[ANF]);
            numeVanzator = dateFisier[NUMEV];
            numeCumparator = dateFisier[NUMEC];
            dataTranzactie = dateFisier[DATAT];
            pretProp = Convert.ToDouble(dateFisier[PRET]);
            optiuniMasina = dateFisier[OPTIUNI].Split(',');
            tipMasina = dateFisier[TIP];
            dataActualizare = Convert.ToDateTime(dateFisier[DATE_TIME]);

            idMasinaProp = idMasinaFin;

            idM++;
            setIdMasina(idM);
        }

        public Masina(string nume1)
        {
            string[] buff = nume1.Split(';');
            numeVanzator = buff[0];
            numeCumparator = buff[1];
            firmaProp = buff[2];
            modelProp = buff[3];
            anFabricatie = Convert.ToInt32(buff[4]);
            culoareProp = buff[5];
            dataTranzactie = buff[6];
            pretProp = Convert.ToDouble(buff[7]);
            optiuniMasina = buff[8].Split(',');
            tipMasina = buff[9];

            idM++;
            setIdMasina(idM);
        }



        

        public string toString()
        {
            return idMasina + ". " + firmaProp + " " + modelProp + ", " + culoareProp + ", an: " + anFabricatie + ", Vanzator: " + numeVanzator +
                ", cumparator: " + numeCumparator + ", pret: " + pretProp + " euro";
        }

        public string ConversieLaSir_PentruFisier()
        {
            string sNote = string.Empty;

            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}",
                SEPARATOR_PRINCIPAL_FISIER, (idMasina.ToString()), (firmaProp ?? "NECUNOSCUTA"), (modelProp ?? "NECUNOSCUT"),
                            (culoareProp ?? "NECUNOSCUTA"), (anFabricatie.ToString() ?? "NECUNOSCUT"), (numeVanzator ?? " NECUNOSCUT "),
                            (numeCumparator ?? " NECUNOSCUT "), (dataTranzactie ?? " NECUNOSCUTA "), (pretProp.ToString() ?? "NECUNOSCUT"),
                            OptiuniAsString,tipMasina,dataActualizare.ToString());

            return s;
        }



        ///////////////////////////Forms/////////////////////
        ///

        public void identificaCuloare()
        {
            if (CuloareMasina == Culori.alb)
                culoareProp = "alb";
            else
                if (CuloareMasina == Culori.negru)
                culoareProp = "negru";
            if (CuloareMasina == Culori.rosu)
                culoareProp = "rosu";
            if (CuloareMasina == Culori.galben)
                culoareProp = "galben";
            if (CuloareMasina == Culori.albastru)
                culoareProp = "albastru";
            if (CuloareMasina == Culori.verde)
                culoareProp = "verde";
            if (CuloareMasina == Culori.mov)
                culoareProp = "mov";
            if (CuloareMasina == Culori.portocaliu)
                culoareProp = "portocaliu";
            if (CuloareMasina == Culori.maro)
                culoareProp = "maro";

        }


        ///////////////////////////////////////////



        /// <summary>
        /// /////////////GETTERI SI SETTERI
        /// </summary>
        /// <returns></returns>

        public int getIdMasina()
        {
            return this.idMasina;
        }

        public void setIdMasina(int id)
        {
            this.idMasina = id;
        }

        public int getNumarCautari()
        {
            return numarCautari;
        }

        public double getPret()
        {
            return pretProp;
        }

        public void setOptiuni(string optiuniSc)
        {
            optiuniMasina = optiuniSc.Split(',');
        }

        
    }

    

}
