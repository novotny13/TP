using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoServis360
{
    public class MechanicForm : Form
    {
        private DataGridView dgvCars;
        private Label lblTitle;

        public MechanicForm()
        {
            // Form properties
            this.Text = "Mechanik - AutoServis360";
            this.Size = new Size(900, 600);
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title
            lblTitle = new Label
            {
                Text = "Seznam aut k opravě",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.DodgerBlue,
                AutoSize = true,
                Location = new Point(20, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            this.Controls.Add(lblTitle);

            // DataGridView
            dgvCars = new DataGridView
            {
                Location = new Point(20, 70),
                Size = new Size(850, 450),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.DodgerBlue,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                },
                EnableHeadersVisualStyles = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvCars.Columns.Add("SPZ", "SPZ");
            dgvCars.Columns.Add("Brand", "Značka");
            dgvCars.Columns.Add("Model", "Model");
            dgvCars.Columns.Add("Description", "Popis problému");
            dgvCars.Rows.Add("1A2B3C", "Škoda", "Octavia", "Výměna oleje");
            this.Controls.Add(dgvCars);
        }
    }
}
