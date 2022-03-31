using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APersoana
{
    public class Persoana
    {//constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;

        //proprietati auto-implemented
        private int idPersoana; //identificator unic student
        private string nume;
        private string prenume;

        //contructor implicit
        public Persoana()
        {
            nume = prenume = string.Empty;
        }

        //constructor cu parametri
        public Persoana(int idPersoana, string nume, string prenume)
        {
            this.idPersoana = idPersoana;
            this.nume = nume;
            this.prenume = prenume;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Persoana(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idPersoana = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            prenume = dateFisier[PRENUME];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectPersoanaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idPersoana.ToString(),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "));

            return obiectPersoanaPentruFisier;
        }

        public int GetIdPersoana()
        {
            return idPersoana;
        }

        public string GetNume()
        {
            return nume;
        }

        public string GetPrenume()
        {
            return prenume;
        }
        public void SetIdPersoana(int idPersoana)
        {
            this.idPersoana = idPersoana;
        }
       /* public static Persoana cautarePersoana(Persoana[] persoane,string _nume, string prenume, int nrPersoane)
        {

            for (int idPersoana = 0; idPersoana < nrPersoane; idPersoana++)
            {
                if ((nume[idPersoana] == _nume)&& (prenume[idPersoana] == _prenume))
                    
                     Console.WriteLine("Persoana a fost gasita");
                
                    else
                {
                    Console.WriteLine("Persoana nu a fost gasita");
                }

            }
          */ 

        }
    }


