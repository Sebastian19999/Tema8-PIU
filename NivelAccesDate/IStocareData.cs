using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddMasina(Masina masina);
        Masina[] GetMasina(out int nrMasini);

        Masina GetMasinaByIndex(int index);
    }
}
