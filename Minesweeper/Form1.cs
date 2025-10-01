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
            foreach (Control ctrl in grille_UI.Controls)
            {
                if (ctrl is Button bouton)
                {
                    bouton.BackColor = Color.White; 
                    bouton.Text = "";               
                    bouton.Enabled = true;
                }
            }
        }
        private void BoutonGrille_Click(object? sender, EventArgs e)
        {
            if (sender is Button bouton && bouton.Tag is ValueTuple<int, int> position)
            {
                int ligne = position.Item1;
                int colonne = position.Item2;

                tableau_jeux.Index_bouton(ligne, colonne, bouton);
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
