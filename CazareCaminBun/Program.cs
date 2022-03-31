using System;
using System.Configuration;
using ACamera;
using ACamin;
using APersoana;
using AdministrarePersoane_FisierText;
using System.IO;

namespace CazareCaminBun
{
    internal class Program
    {
        static void Main()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdmPersoane adminPersoane = new AdmPersoane(numeFisier);
            int nrPersoane = 0;
 
            Persoana persoanaNoua = new Persoana();
            Camera cameraNoua = new Camera();
            Camin caminNou = new Camin();
            adminPersoane.GetPersoane(out nrPersoane);
            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii persoana de la tastatura");
                Console.WriteLine("A. Afisarea ultimei persoane introduse");
                Console.WriteLine("F. Afisare persoane din fisier");
                Console.WriteLine("S. Salvare persoana in fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "C":
                        persoanaNoua = CitirePersoanaTastatura();
                        caminNou = CitireCaminTastatura();
                        cameraNoua = CitireCameraTastatura();

                        break;
                    case "A":
                        AfisarePersoana(persoanaNoua);
                        AfisareCamin(caminNou);
                        AfisareCamera(cameraNoua);

                        break;
                    case "F":

                        Persoana[] persoane = adminPersoane.GetPersoane(out nrPersoane);
                        AfisarePersoane(persoane, nrPersoane);
                        break;
                    case "S":
                        int idPersoana = nrPersoane + 1;
                        persoanaNoua.SetIdPersoana(idPersoana);
                     
                        adminPersoane.AddPersoana(persoanaNoua);

                        nrPersoane = nrPersoane + 1;
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
      
        public static void AfisarePersoana(Persoana persoana)
        {
            string infoPersoana = string.Format("Persoana cu id-ul #{0} are numele: {1} {2}",
                   persoana.GetIdPersoana(),
                   persoana.GetNume() ?? " NECUNOSCUT ",
                   persoana.GetPrenume() ?? " NECUNOSCUT ");

            Console.WriteLine(infoPersoana);
        }
        
        public static void AfisarePersoane(Persoana[] persoane, int nrPersoane)
        {
            Console.WriteLine("Persoanele cazate sunt:");
            for (int contor = 0; contor < nrPersoane; contor++)
            {
                AfisarePersoana(persoane[contor]);
            }
        }
        public static Persoana CitirePersoanaTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Persoana persoana = new Persoana(0, nume, prenume);

            return persoana;
        }

        public static void AfisareCamera(Camera camera)
        {
            string infoCamera = string.Format("si este cazata in camera cu nr{0} de tip: {1} {2}",
                   camera.GetNrCamera() ,
                   camera.GetTipCamera() ?? " NECUNOSCUT ",
                   camera.GetFacilitatiCamera() ?? " NECUNOSCUT ");

            Console.WriteLine(infoCamera);
        }

        public static void AfisareCamere(Camera[] camere, int nrCamere)
        {
            Console.WriteLine("Camerele sunt:");
            for (int contor = 0; contor < nrCamere; contor++)
            {
                AfisareCamera(camere[contor]);
            }
        }

        public static Camera CitireCameraTastatura()
        {
            Console.WriteLine("Introduceti numarul camerei");
            string nrCam = Console.ReadLine();
            int nr = Convert.ToInt32(nrCam);
            Console.WriteLine("Introduceti tipul camerei");
            string tip = Console.ReadLine();

            Console.WriteLine("Introduceti facilitatile (cu/fara baie)");
            string facilitati = Console.ReadLine();

            Camera camera = new Camera(nr, tip, facilitati);

            return camera;
        }
        public static Camin CitireCaminTastatura()
        {
            Console.WriteLine("Introduceti nume camin");
            string numeCamin = Console.ReadLine();

            Console.WriteLine("Introduceti adresa");
            string adresa = Console.ReadLine();

            Console.WriteLine("Introduceti administratorul");
            string administrator = Console.ReadLine();

            Camin camin = new Camin(numeCamin, adresa, administrator);

            return camin;
        }
        public static void AfisareCamin(Camin camin)
        {
            string infoCamin = string.Format("este cazata in caminul {0} la adresa: {1}, cu administrator: {2}",
                   camin.GetNumeCamin() ,
                   camin.GetAdresa() ?? " NECUNOSCUT ",
                   camin.GetAdministrator() ?? " NECUNOSCUT ");

            Console.WriteLine(infoCamin);
        }
    }
}

    


