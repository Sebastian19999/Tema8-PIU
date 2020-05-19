using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public enum CodEroare
    {
        CORECT = 0,
        FIRMA_INCORECTA = 1,
        MODEL_INCORECT = 2,
        CULOARE_INCORECTA = 3,
        AN_FABRICATIE_INCORECT = 4,
        NUME_VANZATOR_INCORECT = 5,
        NUME_CUMPARATOR_INCORECT = 6,
        DATA_INCORECTA = 7,
        PRET_INCORECT = 8,
        OPTIUNI_INCORECTE = 9
    }

    public enum Culori
    {
        culoare_inexistenta = 0,
        alb = 1,
        negru = 2,
        rosu = 3,
        galben = 4,
        albastru = 5,
        verde = 6,
        mov = 7,
        portocaliu = 8,
        maro = 9
    }

    public enum OptiuniMasina
    {
        optiune_inexistenta = 0,
        ABS = 1,
        Airbaguri_laterale = 2,
        CruiseControl = 3,
        ConectivitateBluetooth = 4,
        ProiectoareCeata = 5,
        SolarRoof = 6,
        PilotAutomat = 7,
        ScauneMasaj = 8,
        FullLeather = 9
    }
}
