using System;
using System.Net.Http.Headers;

using Tableau_jeux;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Tableau tableau_jeux = new Tableau(10);
        Font indice_case = new Font("Segoe UI", 3f, FontStyle.Regular);

        public Form1()
        {
            InitializeComponent();
            CreerGrilleDynamique(10);
            tableau_jeux.Creer_jeux();
        }

        private void boutonReinitialiser_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in grille10x10.Controls)
            {
                if (ctrl is Button bouton)
                {
                    bouton.BackColor = Color.White; 
                    bouton.Text = "";               
                    bouton.Enabled = true;
                    bouton.Font = indice_case;
                }
            }
        }
        private void CouleurBouton(Button bouton, int ligne, int colonne)
        {
            switch (tableau_jeux.Retour_case(colonne,ligne))
            {
                case 1:
                    bouton.ForeColor = Color.FromArgb(0, 0, 255);
                    bouton.Text = "1";
                    break;

                case 2:
                    bouton.BackColor = Color.FromArgb(0, 128, 0);
                    bouton.Text = "2";
                    break;

                case 3:
                    bouton.BackColor = Color.FromArgb(255, 0, 0);
                    break;

                case 4:
                    bouton.BackColor = Color.FromArgb(0, 0, 128);
                    break;

                case 5:
                    bouton.BackColor = Color.FromArgb(128, 0, 0);
                    break;

                case 6:
                    bouton.BackColor = Color.FromArgb(0, 128, 128);
                    break;

                case 7:
                    bouton.BackColor = Color.FromArgb(0, 0, 0);
                    break;

                case 8:
                    bouton.BackColor = Color.FromArgb(128, 128, 128);
                    break;

                case 10:
                    bouton.BackColor = Color.FromArgb(255, 255, 0);
                    break;
            }
        }
        private void BoutonGrille_Click(object? sender, EventArgs e)
        {
            if (sender is Button bouton && bouton.Tag is ValueTuple<int, int> position)
            {
                int ligne = position.Item1;
                int colonne = position.Item2;
                bouton.BackColor = Color.FromArgb(192, 192, 192);
                CouleurBouton(bouton, ligne, colonne);
            }
        }

        private void buttonAbandon_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < tableau_jeux.Get_grandeur_tab(); i++)
            {
                for (int j = 0; j < tableau_jeux.Get_grandeur_tab(); j++)
                {
                    
                }
            }
        }
    }
}
