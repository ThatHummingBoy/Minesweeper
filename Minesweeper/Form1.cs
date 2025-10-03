//
//  Programmé par: Nathan Boudreau
//  Dernière modification: 2025-10-03
//  Description: Le programme c# suivant simule le jeu Démineur
//                  dans la difficulté pour les débutants.
//

using System;
using System.Net.Http.Headers;

using Tableau_jeux;

namespace Minesweeper
{
    public partial class FormDemineur : Form
    {
        Tableau tableau_jeux = new Tableau(10);
        Font indice_case = new Font("Segoe UI", 3f, FontStyle.Regular);

        public FormDemineur()
        {
            InitializeComponent();
            CreerGrilleDynamique(10, 10);
            tableau_jeux.Creer_jeux();
        }

        private void boutonReinitialiser_Click(object sender, EventArgs e)
        {
            tableau_jeux.Reinitialiser_val_cases();

            foreach (Control ctrl in grille_UI.Controls)
            {
                if (ctrl is Button bouton)
                {
                    bouton.BackColor = Color.White;
                    bouton.Text = "";
                    bouton.Enabled = true;
                }
            }
            tableau_jeux.Creer_jeux();
        }
        private void buttonAbandon_Click(object sender, EventArgs e)
        {
            tableau_jeux.Set_Grille_UI(grille_UI);
            tableau_jeux.Game_over(false);
        }

        private void BoutonGrille_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender is Button bouton && bouton.Tag is ValueTuple<int, int> position)
            {
                int ligne = position.Item1;
                int colonne = position.Item2;

                tableau_jeux.Set_Grille_UI(grille_UI);

                if (e.Button == MouseButtons.Right)
                {
                    if (bouton.Text == "🚩")
                    {
                        bouton.BackColor = Color.White;
                        bouton.Text = "";
                    }
                    else
                    {
                        bouton.BackColor = Color.FromArgb(192, 192, 192);
                        bouton.ForeColor = Color.Black;
                        bouton.Text = "🚩";
                    }
                }
                else if (e.Button == MouseButtons.Left)
                {
                    
                    tableau_jeux.Index_bouton(ligne, colonne, bouton, false);
                }

                tableau_jeux.Set_Grille_UI(grille_UI);

                if (tableau_jeux.Is_game_over())
                    tableau_jeux.Game_over(true);
            }
        }
    }
}
