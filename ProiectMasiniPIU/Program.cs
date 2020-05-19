using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;
using ManagerM;

using ProiectMasini_FormsT8;


namespace ProiectMasiniPIU
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            Masina masina;
            

            Masina[] masini;
            IStocareData adminMasini = ManagerMasini.GetAdministratorStocare();
            int nrMasini;
            masini = adminMasini.GetMasina(out nrMasini);
            Masina.idMasinaProp = nrMasini;
            for (int i = 0; i < nrMasini; i++)
            {
                ManagerMasini.addMasina(masini[i]);
            }




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormT8());





            //string c;

            //Test();

            //do
            //{
            //    Console.Clear();
            //    Console.WriteLine("0. Comparare doua masini");
            //    Console.WriteLine("1. Adaugare masina");
            //    Console.WriteLine("2. Editare masina");
            //    Console.WriteLine("3. Stergere masina");
            //    Console.WriteLine("4. Cea mai cautata masina");
            //    Console.WriteLine("5. Grafic al preturilor");
            //    Console.WriteLine("6. Tranzactii");
            //    Console.WriteLine("7. Afisare lista masini");
            //    Console.WriteLine("8. Cautare masina");
            //    Console.WriteLine("9. Exit");


            //    switch (Convert.ToChar(c = (Console.ReadLine())))
            //    {
            //        case '0':
            //            Console.WriteLine("COMPARARE DOUA MASINI");
            //            Console.WriteLine();
            //            Console.WriteLine("Lista masini: ");
            //            comparareDupa();
            //            Console.ReadLine();
            //            break;
            //        case '1':
            //            Console.WriteLine("ADAUGARE MASINA");
            //            Console.WriteLine();
            //            Console.Write("Introduceti numele complet al vanzatorului: ");
            //            string numev = Console.ReadLine();
            //            Console.Write("Introduceti numele complet al cumparatorului: ");
            //            string numec = Console.ReadLine();
            //            Console.Write("Introduceti firma masinii: ");
            //            string numef = Console.ReadLine();
            //            Console.Write("Introduceti modelul masinii: ");
            //            string numem = Console.ReadLine();
            //            Console.Write("Introduceti anul fabricatiei: ");
            //            int anf = Convert.ToInt32(Console.ReadLine());
            //            Console.Write("Introduceti culoarea masinii: ");
            //            string culoare = Console.ReadLine();
            //            Console.Write("Introduceti optiunile masinii, separate printr-o virgula: ");
            //            string optiuni = Console.ReadLine();
            //            Console.Write("Introduceti data tranzactiei [dd.mm.aaaa]: ");
            //            string datat = Console.ReadLine();
            //            Console.Write("Introduceti pretul masinii: ");
            //            double pret = Convert.ToDouble(Console.ReadLine());

            //            //masina = new Masina(numev, numec, numef, numem, anf, culoare, optiuni, datat, pret);
            //            ManagerMasini.addMasina(new Masina(numev, numec, numef, numem, anf, culoare, optiuni, datat, pret,"Sedan",DateTime.Now));
            //            Console.ReadLine();
            //            break;
            //        case '2':
            //            Console.WriteLine("2. EDITARE MASINA");
            //            Console.WriteLine("Lista disponibila cu masini este: \n");
            //            ManagerMasini.getMasini();
            //            Console.WriteLine();
            //            Console.WriteLine("Introduceti ID-ul masinii pe care doriti sa o editati");
            //            int idEdit = Convert.ToInt32(Console.ReadLine());
            //            masina = ManagerMasini.getMasina(idEdit);
            //            Console.WriteLine();
            //            Console.WriteLine(" \t a. Nume cumparator");
            //            Console.WriteLine(" \t b. Nume vanzator");
            //            Console.WriteLine(" \t c. Firma");
            //            Console.WriteLine(" \t d. Model");
            //            Console.WriteLine(" \t e. An fabricatie");
            //            Console.WriteLine(" \t f. Culoare");
            //            Console.WriteLine(" \t g. Optiuni");
            //            Console.WriteLine(" \t h. Data tranzactiei");
            //            Console.WriteLine(" \t i. Pret");
            //            Console.WriteLine();
            //            alegeOptiuni(masina);
            //            Console.ReadLine();
            //            break;
            //        case '3':
            //            Console.WriteLine("STERGERE MASINA \n");
            //            Console.WriteLine("Lista disponibila cu masini este: \n");
            //            ManagerMasini.getMasini();
            //            Console.Write("\n Introduceti ID-ul masinii pe care doriti sa o stergeti: ");
            //            int id = Convert.ToInt32(Console.ReadLine());
            //            ManagerMasini.removeMasina(id);
            //            Console.ReadLine();
            //            break;
            //        case '4':
            //            Console.WriteLine("CEA MAI CAUTATA MASINA");

            //            Console.WriteLine("Cea mai cautata masina este: ");
            //            int idMax = ManagerMasini.numarCautariMax();

            //            Console.WriteLine(ManagerMasini.getMasina(idMax).toString());
            //            Console.ReadLine();
            //            break;
            //        case '5':
            //            Console.WriteLine("GRAFIC AL PRETURILOR");
            //            ManagerMasini.getMasini();
            //            Console.WriteLine();
            //            Console.Write("Doriti sa ordonati lista in ordine crescatoare sau descrescatoare? [crescator / descrescator]");
            //            int nr;
            //            int[] idL;
            //            string optiuneCr = Console.ReadLine();
            //            if (optiuneCr.Equals("crescator"))
            //            {
            //                nr = 0;
            //                idL = ManagerMasini.getListaPreturi(nr);
            //                for (int i = 0; i < Masina.idM; i++)
            //                {
            //                    Console.WriteLine(ManagerMasini.getMasina(idL[i]));
            //                }
            //            }
            //            else if (optiuneCr.Equals("descrescator"))
            //            {
            //                nr = 1;
            //                idL = ManagerMasini.getListaPreturi(nr);
            //                for (int i = 0; i < Masina.idM; i++)
            //                {
            //                    Console.WriteLine(ManagerMasini.getMasina(idL[i]));
            //                }
            //            }
            //            Console.ReadLine();
            //            break;
            //        case '6':
            //            Console.WriteLine("Optiunea 6");
            //            Console.ReadLine();
            //            break;
            //        case '7':
            //            Console.WriteLine("Lista masini: ");
            //            ManagerMasini.getMasini();
            //            Console.WriteLine();
            //            Console.WriteLine("Doriti sa vedeti optiunile pentru o masina? [y/n]");
            //            string opt = Console.ReadLine();
            //            if (opt.Equals("y"))
            //            {
            //                Console.WriteLine("Introduceti ID-ul masinii careia doriti sa ii vizionati optiunile... ");
            //                int idOpt = Convert.ToInt32(Console.ReadLine());
            //                Masina masOpt = ManagerMasini.getMasina(idOpt);
            //                Console.WriteLine("Optiunile masinii sunt: ");
            //                for (int i = 0; i < masOpt.getOptiuni().Length; i++)
            //                    Console.WriteLine("\t" + masOpt.getOptiuni().GetValue(i));

            //            }

            //            File.WriteAllText(@"C:\Users\sebyg\source\repos\ProiectMasiniPIU\ProiectMasiniPIU\MasiniSalvate.txt", String.Empty);
            //            foreach (var mas in ManagerMasini.listaMasini)
            //                adminMasini.AddMasina(mas);
            //            Console.ReadLine();
            //            break;
            //        case '8':
            //            cautare();
            //            Console.ReadLine();
            //            break;
            //        case '9': return;

            //        default:
            //            Console.WriteLine("Optiune invalida");
            //            Console.ReadLine();
            //            break;

            //    }
            //} while (true);



        }

        //private static void Test()
        //{
        //    Masina masinaInit = new Masina("Popescu;Ionescu;Ford;Mondeo;2008;rosu;16.02.2019;6500;"+ "ABS, Cruise Control, Conectivitate Bluetooth, Proiectoare Ceata;Sedan");
        //    //masinaInit.idTipMasina = 0;
        //    ManagerMasini.addMasina(masinaInit);

        //}

        //private static void alegeOptiuni(Masina masina)
        //{
        //    Console.Write("Alegeti o optiune... ");
        //    string optiune;
        //    switch (Convert.ToChar(optiune = (Console.ReadLine())))
        //    {
        //        case 'a':
        //            Console.Write("Introduceti noul nume al cumparatorului: ");
        //            string cump = Console.ReadLine();
        //            masina.numeCumparator = cump;
        //            Console.ReadLine();
        //            break;
        //        case 'b':
        //            Console.Write("Introduceti noul nume al vanzatorului: ");
        //            string vanz = Console.ReadLine();
        //            masina.numeVanzator = vanz;
        //            Console.ReadLine();
        //            break;
        //        case 'c':
        //            Console.Write("Introduceti noua firma: ");
        //            string firma = Console.ReadLine();
        //            masina.firmaProp = firma;
        //            Console.ReadLine();
        //            break;
        //        case 'd':
        //            Console.Write("Introduceti noul model: ");
        //            string model = Console.ReadLine();
        //            masina.modelProp = model;
        //            Console.ReadLine();
        //            break;
        //        case 'e':
        //            Console.Write("Introduceti noul an al fabricatiei: ");
        //            int anf = Convert.ToInt32(Console.ReadLine());
        //            masina.anFabricatie = anf;
        //            Console.ReadLine();
        //            break;
        //        case 'f':
        //            Console.Write("Introduceti noua culoare: ");
        //            string culoare = Console.ReadLine();
        //            masina.culoareProp = culoare;
        //            Console.ReadLine();
        //            break;
        //        case 'g':
        //            Console.Write("Introduceti noile optiuni: ");
        //            string optiuni = Console.ReadLine();
        //            masina.optiuniProp = optiuni;
        //            Console.ReadLine();
        //            break;
        //        case 'h':
        //            Console.Write("Introduceti noua data a tranzactiei: ");
        //            string datat = Console.ReadLine();
        //            masina.dataTranzactie = datat;
        //            Console.ReadLine();
        //            break;
        //        case 'i':
        //            Console.Write("Introduceti noul pret: ");
        //            double pret = Convert.ToDouble(Console.ReadLine());
        //            masina.pretProp = pret;
        //            Console.ReadLine();
        //            break;
        //    }
        //}

        //public static void cautare()
        //{
        //    int nr;
        //    int[] masini;
        //    Masina masinaC;
        //    Console.WriteLine("Cautati dupa: ");
        //    Console.WriteLine(" \t a. Nume cumparator");
        //    Console.WriteLine(" \t b. Nume vanzator");
        //    Console.WriteLine(" \t c. Firma");
        //    Console.WriteLine(" \t d. Model");
        //    Console.WriteLine(" \t e. An fabricatie");
        //    Console.WriteLine(" \t f. Culoare");
        //    Console.WriteLine(" \t g. Data tranzactiei");
        //    Console.WriteLine(" \t h. Pret");
        //    Console.WriteLine();
        //    Console.WriteLine("Alegeti o optiune...");
        //    string optiune;
        //    switch (Convert.ToChar(optiune = (Console.ReadLine())))
        //    {
        //        case 'a':
        //            nr = 0;
        //            Console.WriteLine("Cautare dupa nume cumparator... ");
        //            masini = ManagerMasini.cautare(nr);
        //            for (int i = 0; i < 1; i++)
        //            {

        //                masinaC = ManagerMasini.getMasina(masini[i]);
        //                //Console.WriteLine(masinaC.toString());
        //            }
        //            Console.ReadLine();
        //            break;
        //        case 'b':
        //            nr = 1;
        //            Console.WriteLine("Cautare dupa nume vanzator... ");
        //            masini = ManagerMasini.cautare(nr);
        //            for (int i = 0; i < 1; i++)
        //            {

        //                masinaC = ManagerMasini.getMasina(masini[i]);
        //                //Console.WriteLine(masinaC.toString());
        //            }
        //            Console.ReadLine();
        //            break;
        //        case 'c':
        //            nr = 2;
        //            Console.WriteLine("Cautare dupa firma... ");
        //            masini = ManagerMasini.cautare(nr);
        //            for (int i = 0; i < 1; i++)
        //            {

        //                masinaC = ManagerMasini.getMasina(masini[i]);
        //                //Console.WriteLine(masinaC.toString());
        //            }
        //            Console.ReadLine();
        //            break;
        //        case 'd':
        //            nr = 3;
        //            Console.WriteLine("Cautare dupa model... ");
        //            masini = ManagerMasini.cautare(nr);
        //            for (int i = 0; i < 1; i++)
        //            {

        //                masinaC = ManagerMasini.getMasina(masini[i]);
        //                //Console.WriteLine(masinaC.toString());
        //            }
        //            Console.ReadLine();
        //            break;
        //        case 'e':
        //            nr = 4;
        //            Console.WriteLine("Cautare dupa an fabricatie... ");
        //            masini = ManagerMasini.cautare(nr);
        //            for (int i = 0; i < 1; i++)
        //            {

        //                masinaC = ManagerMasini.getMasina(masini[i]);
        //                //Console.WriteLine(masinaC.toString());
        //            }
        //            Console.ReadLine();
        //            break;
        //        case 'f':
        //            nr = 5;
        //            Console.WriteLine("Cautare dupa culoare... ");
        //            masini = ManagerMasini.cautare(nr);
        //            for (int i = 0; i < 1; i++)
        //            {

        //                masinaC = ManagerMasini.getMasina(masini[i]);
        //                //Console.WriteLine(masinaC.toString());
        //            }
        //            Console.ReadLine();
        //            break;
        //        case 'g':
        //            nr = 6;
        //            Console.WriteLine("Cautare dupa data tranzactie... ");
        //            masini = ManagerMasini.cautare(nr);
        //            for (int i = 0; i < 1; i++)
        //            {

        //                masinaC = ManagerMasini.getMasina(masini[i]);
        //                //Console.WriteLine(masinaC.toString());
        //            }
        //            Console.ReadLine();
        //            break;
        //        case 'h':
        //            nr = 7;
        //            Console.WriteLine("Cautare dupa pret... ");
        //            masini = ManagerMasini.cautare(nr);
        //            for (int i = 0; i < 1; i++)
        //            {

        //                masinaC = ManagerMasini.getMasina(masini[i]);
        //                //Console.WriteLine(masinaC.toString());
        //            }
        //            Console.ReadLine();
        //            break;
        //        default:
        //            nr = 10;
        //            masini = ManagerMasini.cautare(nr);

        //            Console.ReadLine();
        //            break;



        //    }




        //}

        //public static void comparareDupa()
        //{
        //    int nr;
        //    Masina mas1, mas2;

        //    ManagerMasini.getMasini();
        //    Console.WriteLine();

        //    Console.Write("Introduceti id-ul masinii pe care doriti sa o comparati: ");
        //    int id1 = Convert.ToInt32(Console.ReadLine());
        //    Console.Write("Introduceti id-ul masinii pe care doriti sa o comparati cu prima aleasa: ");
        //    int id2 = Convert.ToInt32(Console.ReadLine());
        //    mas1 = ManagerMasini.getMasina(id1);
        //    mas2 = ManagerMasini.getMasina(id2);
        //    Console.WriteLine("Cautati dupa: ");

        //    Console.WriteLine(" \t a. An fabricatie");
        //    Console.WriteLine(" \t b. Pret");
        //    Console.WriteLine();
        //    Console.WriteLine("Alegeti o optiune...");
        //    string optiune;
        //    switch (Convert.ToChar(optiune = (Console.ReadLine())))
        //    {

        //        case 'a':
        //            nr = 1;
        //            Console.WriteLine("Comparare dupa an fabricatie... ");
        //            int rez1 = mas1.comparaCuAltObiect(mas2, 1);
        //            if (rez1 == -1)
        //                Console.WriteLine("Anul de fabricatie primei masini este mai mic decat anul de fabricatie al masinii secunde. ");
        //            if (rez1 == 0)
        //                Console.WriteLine("Anul de fabricatie primei masini este egal cu anul de fabricatie al masinii secunde. ");
        //            if (rez1 == 1)
        //                Console.WriteLine("Anul de fabricatie primei masini este mai mare decat anul de fabricatie al masinii secunde. ");
        //            Console.ReadLine();
        //            break;
        //        case 'b':
        //            nr = 2;
        //            Console.WriteLine("Comparare dupa pret... ");
        //            int rez = mas1.comparaCuAltObiect(mas2, 2);
        //            if (rez == -1)
        //                Console.WriteLine("Pretul primei masini este mai mic decat pretul masinii secunde. ");
        //            if (rez == 0)
        //                Console.WriteLine("Pretul primei masini este egal cu pretul masinii secunde. ");
        //            if (rez == 1)
        //                Console.WriteLine("Pretul primei masini este mai mare decat pretul masinii secunde. ");
        //            Console.ReadLine();
        //            break;
        //        default:
        //            Console.WriteLine("Optiune inexistenta...");

        //            Console.ReadLine();
        //            break;



        //    }
        //}
    }
}
