
namespace Lab02.App.Forms;

public class InputDialog : Form
{
    private readonly List<TextBox> textBoxes = new();
    private ComboBox projectComboBox;

    public string[] Values => textBoxes.Select(t => t.Text.Trim()).ToArray();

    public int? SelectedProjectId => projectComboBox?.SelectedValue is int id ? id : null;

    public InputDialog(string title, string[] labels, string[] values = null, Dictionary<int, string> projects = null, int? selectedProjectId = null)
    {
        Text = title;
        Width = 420;
        Height = 120 + labels.Length * 65 + (projects != null ? 65 : 0);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        for (int i = 0; i < labels.Length; i++)
        {
            var label = new Label
            {
                Text = labels[i],
                Left = 20,
                Top = 20 + i * 65,
                Width = 150
            };

            var textBox = new TextBox
            {
                Left = 180,
                Top = 17 + i * 65,
                Width = 200,
                Text = values != null && i < values.Length ? values[i] : ""
            };

            Controls.Add(label);
            Controls.Add(textBox);
            textBoxes.Add(textBox);
        }

        if (projects != null)
        {
            var label = new Label
            {
                Text = "Проєкт",
                Left = 20,
                Top = 20 + labels.Length * 65,
                Width = 150
            };

            projectComboBox = new ComboBox
            {
                Left = 180,
                Top = 17 + labels.Length * 65,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = projects.Select(p => new { Id = p.Key, Name = p.Value }).ToList(),
                DisplayMember = "Name",
                ValueMember = "Id"
            };

            if (selectedProjectId.HasValue)
                projectComboBox.SelectedValue = selectedProjectId.Value;

            Controls.Add(label);
            Controls.Add(projectComboBox);
        }

        var btnSave = new Button
        {
            Text = "Зберегти",
            Left = 180,
            Top = 30 + labels.Length * 65 + (projects != null ? 65 : 0),
            Width = 95,
            DialogResult = DialogResult.OK
        };

        var btnCancel = new Button
        {
            Text = "Скасувати",
            Left = 285,
            Top = 30 + labels.Length * 65 + (projects != null ? 65 : 0),
            Width = 95,
            DialogResult = DialogResult.Cancel
        };

        Controls.Add(btnSave);
        Controls.Add(btnCancel);

        AcceptButton = btnSave;
        CancelButton = btnCancel;
    }
}
