using Lab02.Data.Services;
using Lab02.App.Forms;
namespace Lab02.App
{
    public partial class Form1 : Form
    {
        private readonly ArchiveService _archiveService = new ArchiveService();
        private readonly Button btnAddResearcherToProject = new Button();
        private void LoadProjects()
        {
            dgvProjects.DataSource = _archiveService.GetProjects();

            dgvProjects.Columns["Id"].HeaderText = "ID";
            dgvProjects.Columns["Name"].HeaderText = "Назва проєкту";
            dgvProjects.Columns["Description"].HeaderText = "Опис";
        }

        private Dictionary<int, string> GetProjectOptions()
        {
            return _archiveService.GetProjects()
                .ToDictionary(p => p.Id, p => p.Name);
        }


        private void LoadDatasets()
        {
            dgvDatasets.DataSource = _archiveService.GetDatasets();

            dgvDatasets.Columns["Id"].HeaderText = "ID";
            dgvDatasets.Columns["Name"].HeaderText = "Назва набору";
            dgvDatasets.Columns["Description"].HeaderText = "Опис";
            dgvDatasets.Columns["ResearchProjectName"].HeaderText = "Назва проєкту";
            dgvDatasets.Columns["CreatedAt"].HeaderText = "Дата створення";
            dgvDatasets.Columns["IsPublic"].HeaderText = "Публічний";
            dgvDatasets.Columns["EmbargoUntil"].HeaderText = "Дата завершення ембарго";

            dgvDatasets.Columns["ResearchProjectId"].Visible = false;
        }

        private void LoadResearchers()
        {
            dgvResearchers.DataSource = _archiveService.GetResearchers();

            dgvResearchers.Columns["Id"].HeaderText = "ID";
            dgvResearchers.Columns["FirstName"].HeaderText = "Ім'я";
            dgvResearchers.Columns["LastName"].HeaderText = "Прізвище";
            dgvResearchers.Columns["Email"].HeaderText = "Електронна пошта";
            dgvResearchers.Columns["ProjectCount"].HeaderText = "Кількість проєктів";
            dgvResearchers.Columns["UploadedVersionCount"].HeaderText = "Завантажені версії";
        }
        public Form1()
        {
            InitializeComponent();
            btnAddResearcherToProject.Text = "Додати до проєкту";
            btnAddResearcherToProject.Location = new Point(430, 8);
            btnAddResearcherToProject.Size = new Size(160, 29);
            panel2.Controls.Add(btnAddResearcherToProject);
            btnAddResearcherToProject.Click += (s, e) => AddResearcherToProject();
            _archiveService.InitializeDatabase();
            btnRefreshProjects.Click += (s, e) => LoadProjects();
            btnRefreshDatasets.Click += (s, e) => LoadDatasets();
            btnRefreshResearchers.Click += (s, e) => LoadResearchers();
            LoadProjects();
            LoadDatasets();
            LoadResearchers();
            btnAddProject.Click += (s, e) => AddProject();
            btnEditProject.Click += (s, e) => EditProject();
            btnDeleteProject.Click += (s, e) => DeleteProject();

            btnAddDataset.Click += (s, e) => AddDataset();
            btnEditDataset.Click += (s, e) => EditDataset();
            btnDeleteDataset.Click += (s, e) => DeleteDataset();
            btnPublicDatasets.Click += (s, e) =>
            {
                dgvDatasets.DataSource = _archiveService.GetPublicDatasets();
                dgvDatasets.Columns["ResearchProjectId"].Visible = false;
            };
            btnAddResearcher.Click += (s, e) => AddResearcher();
            btnEditResearcher.Click += (s, e) => EditResearcher();
            btnDeleteResearcher.Click += (s, e) => DeleteResearcher();
        }

        private void AddProject()
        {
            using var dialog = new InputDialog("Новий проєкт",
                new[] { "Назва", "Опис" });

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (!ValidateProjectValues(dialog.Values))
                return;

            try
            {
                _archiveService.AddProject(dialog.Values[0].Trim(), dialog.Values[1].Trim());
                LoadProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void EditProject()
        {
            if (dgvProjects.CurrentRow?.DataBoundItem is not ProjectRow row)
                return;

            using var dialog = new InputDialog("Редагування проєкту",
                new[] { "Назва", "Опис" },
                new[] { row.Name, row.Description });

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (!ValidateProjectValues(dialog.Values))
                return;

            try
            {
                _archiveService.UpdateProject(row.Id, dialog.Values[0].Trim(), dialog.Values[1].Trim());
                LoadProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private bool ValidateProjectValues(string[] values)
        {
            if (string.IsNullOrWhiteSpace(values[0]) || string.IsNullOrWhiteSpace(values[1]))
            {
                MessageBox.Show("Заповніть назву та опис проєкту.");
                return false;
            }

            if (values[0].Trim().All(char.IsDigit))
            {
                MessageBox.Show("Назва проєкту не може складатися лише з цифр.");
                return false;
            }

            return true;
        }

        private void DeleteProject()
        {
            if (dgvProjects.CurrentRow?.DataBoundItem is not ProjectRow row)
                return;

            if (MessageBox.Show("Видалити цей проєкт?", "Підтвердження",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                _archiveService.DeleteProject(row.Id);
                LoadProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }


        private void AddDataset()
        {
            var projects = GetProjectOptions();

            if (projects.Count == 0)
            {
                MessageBox.Show("Спочатку додайте хоча б один проєкт.");
                return;
            }

            using var dialog = new InputDialog("Новий набір даних",
                new[] { "Назва", "Опис", "Публічний (так/ні)", "Дата завершення ембарго (yyyy-MM-dd або пусто)" },
                projects: projects);

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (dialog.SelectedProjectId == null)
            {
                MessageBox.Show("Оберіть проєкт.");
                return;
            }

            if (!TryParseDatasetValues(dialog.Values, out bool isPublic, out DateTime? embargo))
                return;

            try
            {
                _archiveService.AddDataset(dialog.SelectedProjectId.Value, dialog.Values[0], dialog.Values[1], isPublic, embargo);
                LoadDatasets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void EditDataset()
        {
            if (dgvDatasets.CurrentRow?.DataBoundItem is not DatasetRow row)
                return;

            var projects = GetProjectOptions();

            if (projects.Count == 0)
            {
                MessageBox.Show("Спочатку додайте хоча б один проєкт.");
                return;
            }

            using var dialog = new InputDialog("Редагування набору даних",
                new[] { "Назва", "Опис", "Публічний (так/ні)", "Дата завершення ембарго (yyyy-MM-dd або пусто)" },
                new[]
                {
            row.Name,
            row.Description,
            row.IsPublic ? "так" : "ні",
            row.EmbargoUntil?.ToString("yyyy-MM-dd") ?? ""
                },
                projects,
                row.ResearchProjectId);

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (dialog.SelectedProjectId == null)
            {
                MessageBox.Show("Оберіть проєкт.");
                return;
            }

            if (!TryParseDatasetValues(dialog.Values, out bool isPublic, out DateTime? embargo))
                return;

            try
            {
                _archiveService.UpdateDataset(row.Id, dialog.SelectedProjectId.Value, dialog.Values[0], dialog.Values[1], isPublic, embargo);
                LoadDatasets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private bool TryParseDatasetValues(string[] values, out bool isPublic, out DateTime? embargo)
        {
            isPublic = false;
            embargo = null;

            if (string.IsNullOrWhiteSpace(values[0]) || string.IsNullOrWhiteSpace(values[1]))
            {
                MessageBox.Show("Заповніть назву та опис набору даних.");
                return false;
            }

            if (values[0].All(char.IsDigit))
            {
                MessageBox.Show("Назва набору не може складатися лише з цифр.");
                return false;
            }

            if (values[2].Equals("так", StringComparison.OrdinalIgnoreCase))
                isPublic = true;
            else if (values[2].Equals("ні", StringComparison.OrdinalIgnoreCase))
                isPublic = false;
            else
            {
                MessageBox.Show("У полі «Публічний» введіть «так» або «ні».");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(values[3]))
            {
                if (!DateTime.TryParseExact(
                    values[3],
                    "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime date))
                {
                    MessageBox.Show("Введіть дату у форматі yyyy-MM-dd.");
                    return false;
                }

                embargo = date;
            }

            return true;
        }

        private void DeleteDataset()
        {
            if (dgvDatasets.CurrentRow?.DataBoundItem is not DatasetRow row)
                return;

            if (MessageBox.Show("Видалити цей набір даних?", "Підтвердження",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                _archiveService.DeleteDataset(row.Id);
                LoadDatasets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }


        private void AddResearcher()
        {
            using var dialog = new InputDialog("Новий дослідник",
                new[] { "Ім'я", "Прізвище", "Електронна пошта" });

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (!ValidateResearcherValues(dialog.Values))
                return;

            try
            {
                _archiveService.AddResearcher(dialog.Values[0].Trim(), dialog.Values[1].Trim(), dialog.Values[2].Trim());
                LoadResearchers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void EditResearcher()
        {
            if (dgvResearchers.CurrentRow?.DataBoundItem is not ResearcherRow row)
                return;

            using var dialog = new InputDialog("Редагування дослідника",
                new[] { "Ім'я", "Прізвище", "Електронна пошта" },
                new[] { row.FirstName, row.LastName, row.Email });

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (!ValidateResearcherValues(dialog.Values))
                return;

            try
            {
                _archiveService.UpdateResearcher(row.Id, dialog.Values[0].Trim(), dialog.Values[1].Trim(), dialog.Values[2].Trim());
                LoadResearchers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private bool ValidateResearcherValues(string[] values)
        {
            if (string.IsNullOrWhiteSpace(values[0]) ||
                string.IsNullOrWhiteSpace(values[1]) ||
                string.IsNullOrWhiteSpace(values[2]))
            {
                MessageBox.Show("Заповніть ім'я, прізвище та електронну пошту.");
                return false;
            }

            if (values[0].All(char.IsDigit) || values[1].All(char.IsDigit))
            {
                MessageBox.Show("Ім'я та прізвище не можуть складатися лише з цифр.");
                return false;
            }

            if (!System.Net.Mail.MailAddress.TryCreate(values[2].Trim(), out var email) ||
                email.Address != values[2].Trim())
            {
                MessageBox.Show("Введіть коректну електронну пошту.");
                return false;
            }

            return true;
        }


        private void DeleteResearcher()
        {
            if (dgvResearchers.CurrentRow?.DataBoundItem is not ResearcherRow row)
                return;

            if (MessageBox.Show("Видалити цього дослідника?", "Підтвердження",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                _archiveService.DeleteResearcher(row.Id);
                LoadResearchers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }
        private void AddResearcherToProject()
        {
            if (dgvResearchers.CurrentRow?.DataBoundItem is not ResearcherRow row)
            {
                MessageBox.Show("Оберіть дослідника.");
                return;
            }

            var projects = GetProjectOptions();

            if (projects.Count == 0)
            {
                MessageBox.Show("Спочатку додайте хоча б один проєкт.");
                return;
            }

            using var dialog = new InputDialog("Додавання до проєкту",
                new[] { "Роль", "Рівень доступу" },
                projects: projects);

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (dialog.SelectedProjectId == null)
            {
                MessageBox.Show("Оберіть проєкт.");
                return;
            }

            if (dialog.Values.Any(string.IsNullOrWhiteSpace))
            {
                MessageBox.Show("Заповніть роль та рівень доступу.");
                return;
            }

            try
            {
                _archiveService.AddResearcherToProject(
                    dialog.SelectedProjectId.Value,
                    row.Id,
                    dialog.Values[0],
                    dialog.Values[1]);

                LoadResearchers();
                MessageBox.Show("Дослідника успішно додано до проєкту.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }
    }
}
