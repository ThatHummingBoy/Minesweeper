using System;
using static System.Windows.Forms.LinkLabel;

namespace Tableau_jeux
{
    public class Tableau
    {
        private int _grandeur_tab;
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

        public void Creer_jeux()
        {
            Random random = new Random();
            int nbr_mines = (_grandeur_tab * _grandeur_tab) / 10;

            /*for (int i = 0; i < nbr_mines; i++)
            {
                int ligne_new = random.Next(0, _grandeur_tab);
                int colonne_new = random.Next(0, _grandeur_tab);

                if (_tableau[colonne_new][ligne_new] == 10)
                    ++nbr_mines;

                _tableau[colonne_new][ligne_new] = 10;
            }*/

            _tableau[0][0] = 10;
            _tableau[2][1] = 10;
            _tableau[3][1] = 10;
            _tableau[4][1] = 10;
            _tableau[2][2] = 10;
            _tableau[4][2] = 10;
            _tableau[2][3] = 10;
            _tableau[3][3] = 10;
            _tableau[4][3] = 10;
            _tableau[9][0] = 10;

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
    }
}