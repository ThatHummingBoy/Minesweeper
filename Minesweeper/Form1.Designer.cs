namespace Minesweeper
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel panneauPrincipal;
        private FlowLayoutPanel bandeauHaut;
        private Button boutonReinitialiser;

        private TableLayoutPanel grille10x10;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panneauPrincipal = new TableLayoutPanel();
            bandeauHaut = new FlowLayoutPanel();
            boutonReinitialiser = new Button();
            buttonAbandon = new Button();
            grille10x10 = new TableLayoutPanel();
            panneauPrincipal.SuspendLayout();
            bandeauHaut.SuspendLayout();
            SuspendLayout();
            // 
            // panneauPrincipal
            // 
            panneauPrincipal.ColumnCount = 1;
            panneauPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            panneauPrincipal.Controls.Add(bandeauHaut, 0, 0);
            panneauPrincipal.Controls.Add(grille10x10, 0, 1);
            panneauPrincipal.Dock = DockStyle.Fill;
            panneauPrincipal.Location = new Point(0, 0);
            panneauPrincipal.Name = "panneauPrincipal";
            panneauPrincipal.Padding = new Padding(10);
            panneauPrincipal.RowCount = 2;
            panneauPrincipal.RowStyles.Add(new RowStyle());
            panneauPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panneauPrincipal.Size = new Size(527, 504);
            panneauPrincipal.TabIndex = 0;
            // 
            // bandeauHaut
            // 
            bandeauHaut.AutoSize = true;
            bandeauHaut.Controls.Add(boutonReinitialiser);
            bandeauHaut.Controls.Add(buttonAbandon);
            bandeauHaut.Dock = DockStyle.Top;
            bandeauHaut.Location = new Point(13, 13);
            bandeauHaut.Name = "bandeauHaut";
            bandeauHaut.Padding = new Padding(0, 0, 0, 6);
            bandeauHaut.Size = new Size(501, 48);
            bandeauHaut.TabIndex = 0;
            bandeauHaut.WrapContents = false;
            // 
            // boutonReinitialiser
            // 
            boutonReinitialiser.AutoSize = true;
            boutonReinitialiser.Location = new Point(16, 0);
            boutonReinitialiser.Margin = new Padding(16, 0, 0, 0);
            boutonReinitialiser.Name = "boutonReinitialiser";
            boutonReinitialiser.Size = new Size(145, 42);
            boutonReinitialiser.TabIndex = 1;
            boutonReinitialiser.Text = "Réinitialiser";
            boutonReinitialiser.Click += boutonReinitialiser_Click;
            // 
            // buttonAbandon
            // 
            buttonAbandon.AutoSize = true;
            buttonAbandon.Location = new Point(177, 0);
            buttonAbandon.Margin = new Padding(16, 0, 0, 0);
            buttonAbandon.Name = "buttonAbandon";
            buttonAbandon.Size = new Size(148, 42);
            buttonAbandon.TabIndex = 3;
            buttonAbandon.Text = "Abandonné";
            buttonAbandon.Click += buttonAbandon_Click;
            // 
            // grille10x10
            // 
            grille10x10.BackColor = Color.Gainsboro;
            grille10x10.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            grille10x10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            grille10x10.Dock = DockStyle.Fill;
            grille10x10.Location = new Point(13, 67);
            grille10x10.Name = "grille10x10";
            grille10x10.Size = new Size(501, 424);
            grille10x10.TabIndex = 1;
            // 
            // Form1
            // 
            ClientSize = new Size(527, 504);
            Controls.Add(panneauPrincipal);
            MinimumSize = new Size(380, 460);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Jeu du Tic-Tac-Toe";
            panneauPrincipal.ResumeLayout(false);
            panneauPrincipal.PerformLayout();
            bandeauHaut.ResumeLayout(false);
            bandeauHaut.PerformLayout();
            ResumeLayout(false);
        }

        // Méthode utilitaire pour uniformiser l’apparence des cases
        private static Button CreerBoutonCase()
        {
            return new Button
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(4),
                Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point),
                TabStop = false,
                UseVisualStyleBackColor = false,
                BackColor = Color.White
            };
        }

        // Création dynamique de la grille de boutons
        private void CreerGrilleDynamique(int taille)
        {
            // Nettoyer l'ancienne grille si besoin
            grille10x10.Controls.Clear();
            grille10x10.RowStyles.Clear();
            grille10x10.ColumnStyles.Clear();

            grille10x10.RowCount = taille;
            grille10x10.ColumnCount = taille;

            float pourcentage = 100f / taille;

            // Ajouter les styles pour chaque ligne
            for (int i = 0; i < taille; i++)
                grille10x10.RowStyles.Add(new RowStyle(SizeType.Percent, pourcentage));
            // Ajouter les styles pour chaque colonne
            for (int i = 0; i < taille; i++)
                grille10x10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, pourcentage));

            for (int ligne = 0; ligne < taille; ligne++)
            {
                for (int col = 0; col < taille; col++)
                {
                    var bouton = CreerBoutonCase();
                    bouton.Tag = (ligne, col);
                    bouton.Click += BoutonGrille_Click;
                    grille10x10.Controls.Add(bouton, col, ligne);
                }
            }
        }
        private Button buttonAbandon;
    }
}
