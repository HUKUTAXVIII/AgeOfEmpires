using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
            this.CategoryBox.SelectedIndex = 0;
        }

     

        private void MapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Button sqr = new Button();
                sqr.Location = new Point((e.Location.X/12)*12, (e.Location.Y / 12) * 12);
                switch (this.CategoryBox.SelectedItem)
                {
                    case "Grass":
                        sqr.Size = new Size(12, 12);
                        sqr.BackColor = Color.Green;
                        break;
                    case "Dirt":
                        sqr.Size = new Size(12, 12);
                        sqr.BackColor = Color.Brown;
                        break;
                    case "Rock":
                        sqr.Size = new Size(12, 12);
                        sqr.BackColor = Color.Gray;
                        break;
                    case "Tree":
                        sqr.Size = new Size(12, 12);
                        sqr.BackColor = Color.DarkGreen;
                        break;
                    case "Sand":
                        sqr.Size = new Size(12, 12);
                        sqr.BackColor = Color.Yellow;
                        break;
                    case "Water":
                        sqr.Size = new Size(12, 12);
                        sqr.BackColor = Color.Blue;
                        break;
                    default:
                        break;
                }
                sqr.MouseMove += Sqr_MouseMove;
                sqr.FlatStyle = FlatStyle.Flat;
                sqr.FlatAppearance.BorderSize = 0;

                if (!this.EraseCheck.Checked)
                {
                    if (!MapPanel.Controls.OfType<Button>().Any((item) => new Rectangle(item.Location, item.Size).IntersectsWith(new Rectangle(sqr.Location, sqr.Size)))
                                        && (sqr.Location.X >= 0 && ((sqr.Location.X - sqr.Size.Width) < this.MapPanel.Width))
                                        && (sqr.Location.Y >= 0 && ((sqr.Location.Y - sqr.Size.Height) < this.MapPanel.Height))
                        )
                    {
                        this.MapPanel.Controls.Add(sqr);
                        this.Text = this.MapPanel.Controls.Count.ToString();

                    }
                }
            }
        }

        private void Sqr_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.EraseCheck.Checked && e.Button == MouseButtons.Left) {
                this.MapPanel.Controls.Remove(sender as Control);
            }
        }
    }
}
