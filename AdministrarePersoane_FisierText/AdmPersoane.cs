using System;
using APersoana;
using System.IO;

namespace AdministrarePersoane_FisierText
{
    public class AdmPersoane
    { 
    private const int NR_MAX_PERSOANE = 500;
    private string numeFisier;

    public AdmPersoane(string numeFisier)
    {
        this.numeFisier = numeFisier;
        // se incearca deschiderea fisierului in modul OpenOrCreate
        // astfel incat sa fie creat daca nu exista
        Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
        streamFisierText.Close();
    }

    public void AddPersoana(Persoana persoana)
    {
        // instructiunea 'using' va apela la final streamWriterFisierText.Close();
        // al doilea parametru setat la 'true' al constructorului StreamWriter indica
        // modul 'append' de deschidere al fisierului
        using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
        {
            streamWriterFisierText.WriteLine(persoana.ConversieLaSir_PentruFisier());
        }
    }

    public Persoana[] GetPersoane(out int nrPersoane)
    {
        Persoana[] persoane = new Persoana[NR_MAX_PERSOANE];

        // instructiunea 'using' va apela streamReader.Close()
        using (StreamReader streamReader = new StreamReader(numeFisier))
        {
            string linieFisier;
            nrPersoane = 0;

            // citeste cate o linie si creaza un obiect de tip Student
            // pe baza datelor din linia citita
            while ((linieFisier = streamReader.ReadLine()) != null)
            {
                persoane[nrPersoane++] = new Persoana(linieFisier);
            }
        }

        return persoane;
    }
}
}
