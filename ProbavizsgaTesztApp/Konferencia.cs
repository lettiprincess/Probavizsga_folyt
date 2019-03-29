using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbavizsgaTesztApp
{
    class Konferencia
    {
        private List<Eloadas> eloadasok = new List<Eloadas>();

        public List<Eloadas> getEloadasok() {
            return this.eloadasok;
        }

        public Konferencia(string fajl) {
            try
            {
                StreamReader sr = new StreamReader(fajl);

                while (!sr.EndOfStream) {
                    string cim = sr.ReadLine();
                    string[] meret = sr.ReadLine().Split(';');
                    int sorDB = Convert.ToInt32(meret[0]);
                    int helyDB = Convert.ToInt32(meret[1]);

                    int[,] ertekelesek = new int[sorDB, helyDB];

                    for (int i = 0; i < sorDB; i++)
                    {
                        string[] sor = sr.ReadLine().Split(';');

                        for (int j = 0; j < helyDB; j++)
                        {
                            ertekelesek[i, j] = Convert.ToInt32(sor[j]);
                        }
                    }

                }

                sr.Close();
            }
            catch (Exception e) {
                Console.WriteLine("Hiba: " + e);
            }
        }
    }
}
