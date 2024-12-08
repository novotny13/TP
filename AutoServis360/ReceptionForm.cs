using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoServis360
{
    public class ReceptionForm : Form
    {
        private Panel containerPanel;
        private TableLayoutPanel mainLayout;
        private Button btnSubmit;

        public ReceptionForm()
        {
            // Form properties
            this.Text = "Recepce - AutoServis360";
            this.MinimumSize = new Size(800, 600);
            this.Size = new Size(1000, 700);
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
                MaximumSize = new Size(1000, 0) // Max-width 1000px
            };
            containerPanel.Controls.Add(mainLayout);
            containerPanel.Resize += (s, e) => CenterContent(); // Re-center on resize

            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10));

            // Sections
            mainLayout.Controls.Add(CreateSection("Zákazník", new string[] { "Jméno", "Příjmení", "E-mail", "Telefon" }));
            mainLayout.Controls.Add(CreateSection("Auto", new string[] { "SPZ auta", "Značka auta", "Model auta" }));

            // Submit button
            btnSubmit = new Button
            {
                Text = "Odeslat",
                Dock = DockStyle.Fill,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 14)
            };
            mainLayout.Controls.Add(btnSubmit);
        }

        private void CenterContent()
        {
            mainLayout.Left = (containerPanel.ClientSize.Width - mainLayout.Width) / 2;
            mainLayout.Top = (containerPanel.ClientSize.Height - mainLayout.Height) / 2;
        }

        private Panel CreateSection(string title, string[] fields)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.DodgerBlue,
                Dock = DockStyle.Top,
                Height = 40
            };

            panel.Controls.Add(titleLabel);

            foreach (var field in fields)
            {
                var textBox = new TextBox
                {
                    PlaceholderText = field,
                    Dock = DockStyle.Top,
                    Font = new Font("Arial", 14),
                    Margin = new Padding(5),
                    Height = 40
                };
                panel.Controls.Add(textBox);
            }

            return panel;
        }
    }
}
