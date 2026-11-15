namespace Lab02.App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProjects = new DataGridView();
            lblTitle = new Label();
            tabMain = new TabControl();
            Проєкти = new TabPage();
            panelProjects = new Panel();
            btnEditProject = new Button();
            btnDeleteProject = new Button();
            btnAddProject = new Button();
            btnRefreshProjects = new Button();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            btnPublicDatasets = new Button();
            btnEditDataset = new Button();
            btnDeleteDataset = new Button();
            btnAddDataset = new Button();
            btnRefreshDatasets = new Button();
            dgvDatasets = new DataGridView();
            tabPage1 = new TabPage();
            panel2 = new Panel();
            btnDeleteResearcher = new Button();
            btnEditResearcher = new Button();
            btnAddResearcher = new Button();
            btnRefreshResearchers = new Button();
            dgvResearchers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            tabMain.SuspendLayout();
            Проєкти.SuspendLayout();
            panelProjects.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatasets).BeginInit();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResearchers).BeginInit();
            SuspendLayout();
            // 
            // dgvProjects
            // 
            dgvProjects.AllowUserToAddRows = false;
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Location = new Point(-4, 46);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.ReadOnly = true;
            dgvProjects.RowHeadersWidth = 51;
            dgvProjects.Size = new Size(800, 314);
            dgvProjects.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F);
            lblTitle.Location = new Point(5, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(284, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Архів наукових даних";
            // 
            // tabMain
            // 
            tabMain.Controls.Add(Проєкти);
            tabMain.Controls.Add(tabPage2);
            tabMain.Controls.Add(tabPage1);
            tabMain.Location = new Point(1, 59);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(810, 396);
            tabMain.TabIndex = 4;
            // 
            // Проєкти
            // 
            Проєкти.Controls.Add(panelProjects);
            Проєкти.Controls.Add(dgvProjects);
            Проєкти.Location = new Point(4, 29);
            Проєкти.Name = "Проєкти";
            Проєкти.Padding = new Padding(3);
            Проєкти.Size = new Size(802, 363);
            Проєкти.TabIndex = 0;
            Проєкти.Text = "Проєкти";
            Проєкти.UseVisualStyleBackColor = true;
            // 
            // panelProjects
            // 
            panelProjects.Controls.Add(btnEditProject);
            panelProjects.Controls.Add(btnDeleteProject);
            panelProjects.Controls.Add(btnAddProject);
            panelProjects.Controls.Add(btnRefreshProjects);
            panelProjects.Dock = DockStyle.Top;
            panelProjects.Location = new Point(3, 3);
            panelProjects.Name = "panelProjects";
            panelProjects.Size = new Size(796, 45);
            panelProjects.TabIndex = 3;
            // 
            // btnEditProject
            // 
            btnEditProject.Location = new Point(236, 8);
            btnEditProject.Name = "btnEditProject";
            btnEditProject.Size = new Size(94, 29);
            btnEditProject.TabIndex = 4;
            btnEditProject.Text = "Редагувати";
            btnEditProject.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProject
            // 
            btnDeleteProject.Location = new Point(350, 8);
            btnDeleteProject.Name = "btnDeleteProject";
            btnDeleteProject.Size = new Size(94, 29);
            btnDeleteProject.TabIndex = 3;
            btnDeleteProject.Text = "Видалити";
            btnDeleteProject.UseVisualStyleBackColor = true;
            // 
            // btnAddProject
            // 
            btnAddProject.Location = new Point(124, 8);
            btnAddProject.Name = "btnAddProject";
            btnAddProject.Size = new Size(94, 29);
            btnAddProject.TabIndex = 1;
            btnAddProject.Text = "Додати";
            btnAddProject.UseVisualStyleBackColor = true;
            // 
            // btnRefreshProjects
            // 
            btnRefreshProjects.Location = new Point(15, 8);
            btnRefreshProjects.Name = "btnRefreshProjects";
            btnRefreshProjects.Size = new Size(94, 29);
            btnRefreshProjects.TabIndex = 0;
            btnRefreshProjects.Text = "Оновити";
            btnRefreshProjects.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(dgvDatasets);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(802, 363);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Набори даних";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPublicDatasets);
            panel1.Controls.Add(btnEditDataset);
            panel1.Controls.Add(btnDeleteDataset);
            panel1.Controls.Add(btnAddDataset);
            panel1.Controls.Add(btnRefreshDatasets);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(796, 45);
            panel1.TabIndex = 4;
            // 
            // btnPublicDatasets
            // 
            btnPublicDatasets.Location = new Point(466, 8);
            btnPublicDatasets.Name = "btnPublicDatasets";
            btnPublicDatasets.Size = new Size(158, 29);
            btnPublicDatasets.TabIndex = 5;
            btnPublicDatasets.Text = "Лише публічні";
            btnPublicDatasets.UseVisualStyleBackColor = true;
            // 
            // btnEditDataset
            // 
            btnEditDataset.Location = new Point(240, 8);
            btnEditDataset.Name = "btnEditDataset";
            btnEditDataset.Size = new Size(94, 29);
            btnEditDataset.TabIndex = 4;
            btnEditDataset.Text = "Редагувати";
            btnEditDataset.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDataset
            // 
            btnDeleteDataset.Location = new Point(353, 8);
            btnDeleteDataset.Name = "btnDeleteDataset";
            btnDeleteDataset.Size = new Size(94, 29);
            btnDeleteDataset.TabIndex = 3;
            btnDeleteDataset.Text = "Видалити";
            btnDeleteDataset.UseVisualStyleBackColor = true;
            // 
            // btnAddDataset
            // 
            btnAddDataset.Location = new Point(130, 8);
            btnAddDataset.Name = "btnAddDataset";
            btnAddDataset.Size = new Size(94, 29);
            btnAddDataset.TabIndex = 1;
            btnAddDataset.Text = "Додати";
            btnAddDataset.UseVisualStyleBackColor = true;
            // 
            // btnRefreshDatasets
            // 
            btnRefreshDatasets.Location = new Point(17, 8);
            btnRefreshDatasets.Name = "btnRefreshDatasets";
            btnRefreshDatasets.Size = new Size(94, 29);
            btnRefreshDatasets.TabIndex = 0;
            btnRefreshDatasets.Text = "Оновити";
            btnRefreshDatasets.UseVisualStyleBackColor = true;
            // 
            // dgvDatasets
            // 
            dgvDatasets.AllowUserToAddRows = false;
            dgvDatasets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatasets.Location = new Point(3, 46);
            dgvDatasets.Name = "dgvDatasets";
            dgvDatasets.ReadOnly = true;
            dgvDatasets.RowHeadersWidth = 51;
            dgvDatasets.Size = new Size(796, 314);
            dgvDatasets.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(dgvResearchers);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(802, 363);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Дослідники";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDeleteResearcher);
            panel2.Controls.Add(btnEditResearcher);
            panel2.Controls.Add(btnAddResearcher);
            panel2.Controls.Add(btnRefreshResearchers);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(796, 45);
            panel2.TabIndex = 4;
            // 
            // btnDeleteResearcher
            // 
            btnDeleteResearcher.Location = new Point(324, 8);
            btnDeleteResearcher.Name = "btnDeleteResearcher";
            btnDeleteResearcher.Size = new Size(94, 29);
            btnDeleteResearcher.TabIndex = 3;
            btnDeleteResearcher.Text = "Видалити";
            btnDeleteResearcher.UseVisualStyleBackColor = true;
            // 
            // btnEditResearcher
            // 
            btnEditResearcher.Location = new Point(224, 8);
            btnEditResearcher.Name = "btnEditResearcher";
            btnEditResearcher.Size = new Size(94, 29);
            btnEditResearcher.TabIndex = 2;
            btnEditResearcher.Text = "Редагувати";
            btnEditResearcher.UseVisualStyleBackColor = true;
            // 
            // btnAddResearcher
            // 
            btnAddResearcher.Location = new Point(124, 8);
            btnAddResearcher.Name = "btnAddResearcher";
            btnAddResearcher.Size = new Size(94, 29);
            btnAddResearcher.TabIndex = 1;
            btnAddResearcher.Text = "Додати";
            btnAddResearcher.UseVisualStyleBackColor = true;
            // 
            // btnRefreshResearchers
            // 
            btnRefreshResearchers.Location = new Point(24, 8);
            btnRefreshResearchers.Name = "btnRefreshResearchers";
            btnRefreshResearchers.Size = new Size(94, 29);
            btnRefreshResearchers.TabIndex = 0;
            btnRefreshResearchers.Text = "Оновити";
            btnRefreshResearchers.UseVisualStyleBackColor = true;
            // 
            // dgvResearchers
            // 
            dgvResearchers.AllowUserToAddRows = false;
            dgvResearchers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResearchers.Location = new Point(3, 46);
            dgvResearchers.Name = "dgvResearchers";
            dgvResearchers.ReadOnly = true;
            dgvResearchers.RowHeadersWidth = 51;
            dgvResearchers.Size = new Size(796, 314);
            dgvResearchers.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabMain);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            tabMain.ResumeLayout(false);
            Проєкти.ResumeLayout(false);
            panelProjects.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatasets).EndInit();
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResearchers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvProjects;
        private Label lblTitle;
        private TabControl tabMain;
        private TabPage Проєкти;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private DataGridView dgvDatasets;
        private DataGridView dgvResearchers;
        private Panel panelProjects;
        private Panel panel1;
        private Panel panel2;
        private Button btnAddProject;
        private Button btnRefreshProjects;
        private Button btnAddDataset;
        private Button btnRefreshDatasets;
        private Button btnAddResearcher;
        private Button btnRefreshResearchers;
        private Button btnEditDataset;
        private Button btnDeleteDataset;
        private Button btnDeleteResearcher;
        private Button btnEditResearcher;
        private Button btnEditProject;
        private Button btnDeleteProject;
        private Button button1;
        private Button btnPublicDatasets;
    }
}
