using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbavizsgaTesztApp
{
    public partial class Form1 : Form
    {
        Image[] pontKepek = new Image[4];

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++)
            {
                pontKepek[i] = Image.FromFile("Pont" + i + ".jpg");
            }

            Beolvasas();
            UjErtekelesek("asdf");
        }

        void Beolvasas()
        {
            string tartalom = File.ReadAllText("konferencia.txt");
            string[] eloadasok = tartalom.Split(
                new string[] { "\n\n", "\r\n\r\n" },
                StringSplitOptions.RemoveEmptyEntries
            );

            foreach (string eloadas in eloadasok)
            {
                string[] sorok = eloadas.Split(
                    new string[] { "\n", "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries
                );

                string cim = sorok[0];
                string[] meret = sorok[1].Split(';');
                int sorDb = int.Parse(meret[0]);
                int helyDb = int.Parse(meret[1]);
                int[,] ertekelesek = new int[sorDb, helyDb];

                for (int i = 0; i < sorDb; i++)
                {
                    string sor = sorok[i + 2];
                    string[] helyek = sor.Split(';');
                    for (int j = 0; j < helyDb; j++)
                    {
                        int ertekeles = int.Parse(helyek[j]);
                        ertekelesek[i, j] = ertekeles;
                    }
                }
            }
        }

        void UjErtekelesek(string eloadas)
        {
            int sorDb = 3;
            int helyDb = 4;
            int[,] ertekeles = {
                { 1, 0, 1, 0 },
                { 1, 2, 1, 3 },
                { 0, 2, 3, 0 },
            };

            kepekPanel.Controls.Clear();
            for (int i = 0; i < sorDb; i++)
            {
                for (int j = 0; j < helyDb; j++)
                {
                    var pb = new PictureBox();
                    pb.Bounds = new Rectangle(j * 100, i * 100, 100, 100);
                    pb.Image = pontKepek[ ertekeles[i,j] ];
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;

                    int i1 = i, j1 = j;
                    pb.Click += (sender, e) =>
                    {
                        ertekeles[i1, j1]++;
                        if (ertekeles[i1, j1] > 3)
                        {
                            ertekeles[i1, j1] = 1;
                        }
                        else if (ertekeles[i1, j1] > 0) {
                            MessageBox.Show("Itten e nem ült senki se!");
                            ertekeles[i1, j1] = 0;
                        }
                        pb.Image = pontKepek[ertekeles[i1, j1]];
                    };

                    kepekPanel.Controls.Add(pb);
                }
            }

        }
    }
}
