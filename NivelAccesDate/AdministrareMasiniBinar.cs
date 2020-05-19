using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareMasiniBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareMasiniBinar(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddMasina(Masina s)
        {
            throw new Exception("Optiunea AddStudent nu este implementata");
        }

        public Masina[] GetMasina(out int nrMasini)
        {
            throw new Exception("Optiunea GetStudenti nu este implementata");
        }

        public Masina GetMasinaByIndex(int index)
        {
            throw new Exception("Optiunea GetStudentByIndex nu este implementata");
        }
    }
}
