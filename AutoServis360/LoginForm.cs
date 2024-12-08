using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoServis360
{
    public class LoginForm : Form
    {
        private Panel containerPanel;
        private TableLayoutPanel mainLayout;
        private Label lblTitle;
        private ComboBox cbRole;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        public LoginForm()
        {
            // Form properties
            this.Text = "Přihlášení - AutoServis360";
            this.MinimumSize = new Size(400, 500);
            this.Size = new Size(600, 600);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Container panel for max-width
            containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(containerPanel);

            // Main layout with max-width
            mainLayout = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.None,
                ColumnCount = 1,
                Padding = new Padding(20),
                BackColor = Color.White,
                MaximumSize = new Size(800, 0), // Max-width 800px
            };
            containerPanel.Controls.Add(mainLayout);
            containerPanel.Resize += (s, e) => CenterContent(); // Re-center on resize

            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            for (int i = 0; i < 5; i++)
                mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

            // Title
            lblTitle = new Label
            {
                Text = "Přihlášení",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.DodgerBlue,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            mainLayout.Controls.Add(lblTitle, 0, 0);

            // Role dropdown
            cbRole = new ComboBox
            {
                Font = new Font("Arial", 14),
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbRole.Items.AddRange(new string[] { "Recepční", "Mechanik" });
            mainLayout.Controls.Add(cbRole, 0, 1);

            // Username input
            txtUsername = CreateTextBox("Uživatelské jméno");
            mainLayout.Controls.Add(txtUsername, 0, 2);

            // Password input
            txtPassword = CreateTextBox("Heslo");
            txtPassword.PasswordChar = '*';
            mainLayout.Controls.Add(txtPassword, 0, 3);

            // Login button
            btnLogin = new Button
            {
                Text = "Přihlásit se",
                Dock = DockStyle.Fill,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 14)
            };
            btnLogin.Click += BtnLogin_Click;
            mainLayout.Controls.Add(btnLogin, 0, 4);

            CenterContent(); // Center content initially
        }

        private void CenterContent()
        {
            // Dynamically center the main layout
            mainLayout.Left = (containerPanel.ClientSize.Width - mainLayout.Width) / 2;
            mainLayout.Top = (containerPanel.ClientSize.Height - mainLayout.Height) / 2;
        }

        private TextBox CreateTextBox(string placeholder)
        {
            return new TextBox
            {
                PlaceholderText = placeholder,
                Font = new Font("Arial", 14),
                Dock = DockStyle.Fill,
                Margin = new Padding(5)
            };
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Přihlášení úspěšné.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

