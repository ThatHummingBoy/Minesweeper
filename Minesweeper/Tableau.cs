using Minesweeper;
using System;
using System.ComponentModel;
using static System.Windows.Forms.LinkLabel;

namespace Tableau_jeux
{
    public class Tableau
    {
        private int _grandeur_tab;
        private TableLayoutPanel _grille_UI;
        protected int[][] _tableau;

        public Tableau(int grandeur_tab)
        {
            _grandeur_tab = grandeur_tab;
            _tableau = new int[_grandeur_tab][];
            for (int i = 0; i < _grandeur_tab; i++)
            {
                _tableau[i] = new int[_grandeur_tab];
            }
        }

        ~Tableau() { }

        private int Mines_adj(int i, int j)
        {
            int mines_autour = 0;

            for (int y = i - 1; y <= i + 1; y++)
            {
                for (int x = j - 1; x <= j + 1; x++)
                {
                    if ((x >= _grandeur_tab || y >= _grandeur_tab)
                        || (x < 0 || y < 0))
                        continue;
                    else if (_tableau[y][x] == 10)
                        ++mines_autour;
                }
            }

            return mines_autour;
        }

        private void Creer_typo()
        {
            for (int i = 0; i < _grandeur_tab; i++)
            {
                for (int j = 0; j < _grandeur_tab; j++)
                {
                    if (_tableau[i][j] == 10)
                        continue;

                    _tableau[i][j] = Mines_adj(i, j);
                }
            }
        }
        public void Reinitialiser_val_cases()
        {
            for (int y = 0; y < _grandeur_tab; y++)
            {
                for (int x = 0; x < _grandeur_tab; x++)
                {
                    _tableau[y][x] = 0;
                }
            }
        }

        public void Creer_jeux()
        {
            Random random = new Random();
            int nbr_mines = (_grandeur_tab * _grandeur_tab) / 10;

            for (int i = 0; i < nbr_mines; i++)
            {
                int ligne_new = random.Next(0, _grandeur_tab);
                int colonne_new = random.Next(0, _grandeur_tab);

                if (_tableau[colonne_new][ligne_new] == 10)
                    ++nbr_mines;

                _tableau[colonne_new][ligne_new] = 10;
            }

            Creer_typo();
        }

        public int Retour_case(int colonne, int ligne)
        {
            return _tableau[colonne][ligne];
        }
        
        public void Changer_grandeur_tab(int nouv_grandeur)
        {
            _grandeur_tab = nouv_grandeur;            
        }

        public int Get_grandeur_tab()
        {
            return _grandeur_tab;
        }

        public void Cas_zero(int ligne, int colonne, Button bouton, HashSet<(int, int)> visited)
        {
            if (!visited.Add((ligne, colonne)))
                return; // déjà traité

            for (int y = colonne - 1; y <= colonne + 1; y++)
            {
                for (int x = ligne - 1; x <= ligne + 1; x++)
                {
                    if ((x >= _grandeur_tab || y >= _grandeur_tab) || (x < 0 || y < 0))
                        continue;

                    var btn = Get_buton(y, x);

                    if (btn.Text == " ")
                        continue;

                    Index_bouton(x, y, btn, true, visited);

                    if (Retour_case(y, x) == 0)
                        Cas_zero(x, y, btn, visited);
                }
            }
        }

        public void Index_bouton(int ligne, int colonne, Button bouton, bool is_cas_zero_in, HashSet<(int, int)>? visited = null)
        {
            bouton = Get_buton(colonne, ligne);
            bouton.BackColor = Color.FromArgb(192, 192, 192);

            if (Is_game_over())
                Game_over(true);

            switch (Retour_case(colonne, ligne))
            {
                case 0:
                    bouton.Text = " ";
                    if (!is_cas_zero_in)
                    {
                        if (visited == null)
                            visited = new HashSet<(int, int)>();
                        Cas_zero(ligne, colonne, bouton, visited);
                    }
                    break;
                case 1:
                    bouton.ForeColor = Color.FromArgb(0, 0, 255);
                    bouton.Text = "1";
                    break;

                case 2:
                    bouton.ForeColor = Color.FromArgb(0, 128, 0);
                    bouton.Text = "2";
                    break;

                case 3:
                    bouton.ForeColor = Color.FromArgb(255, 0, 0);
                    bouton.Text = "3";
                    break;

                case 4:
                    bouton.ForeColor = Color.FromArgb(0, 0, 128);
                    bouton.Text = "4";
                    break;

                case 5:
                    bouton.ForeColor = Color.FromArgb(128, 0, 0);
                    bouton.Text = "5";
                    break;

                case 6:
                    bouton.ForeColor = Color.FromArgb(0, 128, 128);
                    bouton.Text = "6";
                    break;

                case 7:
                    bouton.ForeColor = Color.FromArgb(0, 0, 0);
                    bouton.Text = "7";
                    break;

                case 8:
                    bouton.ForeColor = Color.FromArgb(128, 128, 128);
                    bouton.Text = "8";
                    break;

                case 10:
                    bouton.Text = "💣";

                    if(!is_cas_zero_in)
                        Game_over(false);
                    break;
            }

            return;
        }

        private Button Get_buton(int colonne, int ligne)
        {
            return _grille_UI.GetControlFromPosition(colonne, ligne) as Button;
        }

        public void Set_Grille_UI(TableLayoutPanel grille_UI)
        {
            _grille_UI = grille_UI;

            return;
        }
        public void Game_over(bool is_victoire)
        {
            for (int i = 0; i < _grandeur_tab; i++)
            {
                for (int j = 0; j < _grandeur_tab; j++)
                {
                    Button bouton = Get_buton(j, i);

                    Index_bouton(i, j, bouton, true);
                    bouton.BackColor = is_victoire ? Color.Green : Color.Red;
                    bouton.Enabled = false;
                }
            }
        }

        public bool Is_game_over()
        {
            int nbr_cases_cacher = _grandeur_tab * _grandeur_tab;
            Button bouton;

            for (int i = 0; i < _grandeur_tab; i++)
            {
                for (int j = 0; j < _grandeur_tab; j++)
                {
                    bouton = Get_buton(j, i);

                    if (bouton == null)
                        continue;
                    else if (bouton.Text != "" || bouton.Text == "🚩")
                        --nbr_cases_cacher;
                }
            }

            if (((_grandeur_tab * _grandeur_tab) / 10) == nbr_cases_cacher)
                return true;

            return false;
        }
    }
}