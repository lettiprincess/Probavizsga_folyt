using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbavizsgaTesztApp
{
    class Eloadas
    {
        private string cim;

        private int sorDB;

        private int helyDB;

        private int[,] ertekeles;



        public string Cim

        {

            get

            {

                return cim;

            }



            set

            {

                cim = value;

            }

        }



        public int SorDB

        {

            get

            {

                return sorDB;

            }



            set

            {

                sorDB = value;

            }

        }



        public int HelyDB

        {

            get

            {

                return helyDB;

            }



            set

            {

                helyDB = value;

            }

        }



        public int[,] Ertekeles

        {

            get

            {

                return ertekeles;

            }



            set

            {

                ertekeles = value;

            }

        }



        public Eloadas(string cim, int sorDB, int helyDB, int[,] ertekeles)

        {

            this.cim = cim;

            this.sorDB = sorDB;

            this.helyDB = helyDB;

            this.ertekeles = ertekeles;

        }
    }
}
