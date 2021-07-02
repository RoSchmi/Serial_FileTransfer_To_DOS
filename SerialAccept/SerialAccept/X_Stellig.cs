using System;
//using Microsoft.SPOT;

namespace SerialAccept
{
    class X_Stellig
    {
        public static string Zahl(string pZahlString, int pStellen)
        {
            string ZahlString = pZahlString;
            while (ZahlString.Length < pStellen)
            {
                ZahlString = "0" + ZahlString;
            }
            return ZahlString;

        }
    }
}
