using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{

    public partial class EditorForm : Form
    {

        private const int CELL = 16;

        public EditorForm()
        {
            InitializeComponent();
            this.CategoryBox.SelectedIndex = 0;
        }


        private void MapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {

                Button sqr = new Button();
                sqr.Location = new Point((e.Location.X/CELL)* CELL, (e.Location.Y / CELL) * CELL);

                switch (this.CategoryBox.SelectedItem)
                {
                    case "Grass":
                        sqr.Size = new Size(CELL, CELL);
                        sqr.BackColor = Color.Green;
                        
                        break;
                    case "Dirt":
                        sqr.Size = new Size(CELL, CELL);
                        sqr.BackColor = Color.Brown;
                        break;
                    case "Rock":
                        sqr.Size = new Size(CELL, CELL);
                        sqr.BackColor = Color.Gray;
                        break;
                    case "Tree":
                        sqr.Size = new Size(CELL, CELL);
                        sqr.BackColor = Color.DarkGreen;
                        break;
                    case "Sand":
                        sqr.Size = new Size(CELL, CELL);
                        sqr.BackColor = Color.Yellow;
                        break;
                    case "Water":
                        sqr.Size = new Size(CELL, CELL);
                        sqr.BackColor = Color.Blue;
                        break;
                    default:
                        break;
                }

                sqr.Name = this.CategoryBox.SelectedItem.ToString();
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
                if (this.ReplaceCheck.Checked) {
                    if (!MapPanel.Controls.OfType<Button>().Any((item) => new Rectangle(item.Location, item.Size).IntersectsWith(new Rectangle(sqr.Location, sqr.Size)) && item.Name == sqr.Name)
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
            if ((this.EraseCheck.Checked) && e.Button == MouseButtons.Left) {
                this.MapPanel.Controls.Remove(sender as Control);
            }
            if (this.ReplaceCheck.Checked && e.Button == MouseButtons.Left && (sender as Button).Name != this.CategoryBox.SelectedItem.ToString()) {
                this.MapPanel.Controls.Remove(sender as Control);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.MapPanel.Controls.Clear();
        }

        private void ReplaceCheck_CheckedChanged(object sender, EventArgs e)
        {
           


        }

        private void EraseCheck_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void ReplaceCheck_Click(object sender, EventArgs e)
        {
            this.EraseCheck.Checked = !this.ReplaceCheck.Checked;

            if (!this.ReplaceCheck.Checked)
            {
                this.EraseCheck.Checked = false;
            }
        }

        private void EraseCheck_Click(object sender, EventArgs e)
        {

            this.ReplaceCheck.Checked = !this.EraseCheck.Checked;

            if (!this.EraseCheck.Checked)
            {
                this.ReplaceCheck.Checked = false;
            }
        }

        private void FillBtn_Click(object sender, EventArgs e)
        {

            this.MapPanel.Controls.Clear();

            for (int i = 0; i < this.MapPanel.Height/CELL;i++) {
                for (int j = 0; j < this.MapPanel.Width/CELL; j++)
                {

                   


                    Button sqr = new Button();


                    sqr.Location = new Point(j*CELL, i*CELL);


                    switch (this.CategoryBox.SelectedItem)
                    {
                        case "Grass":
                            sqr.Size = new Size(CELL, CELL);
                            sqr.BackColor = Color.Green;

                            break;
                        case "Dirt":
                            sqr.Size = new Size(CELL, CELL);
                            sqr.BackColor = Color.Brown;
                            break;
                        case "Rock":
                            sqr.Size = new Size(CELL, CELL);
                            sqr.BackColor = Color.Gray;
                            break;
                        case "Tree":
                            sqr.Size = new Size(CELL, CELL);
                            sqr.BackColor = Color.DarkGreen;
                            break;
                        case "Sand":
                            sqr.Size = new Size(CELL, CELL);
                            sqr.BackColor = Color.Yellow;
                            break;
                        case "Water":
                            sqr.Size = new Size(CELL, CELL);
                            sqr.BackColor = Color.Blue;
                            break;
                        default:
                            break;
                    }

                    sqr.Name = this.CategoryBox.SelectedItem.ToString();
                    sqr.MouseMove += Sqr_MouseMove;
                    sqr.FlatStyle = FlatStyle.Flat;
                    sqr.FlatAppearance.BorderSize = 0;

                            this.MapPanel.Controls.Add(sqr);

                   

                }
            }

            this.Text = this.MapPanel.Controls.Count.ToString();

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.MapPanel.Controls.Count != (this.MapPanel.Width * this.MapPanel.Height) / (CELL * CELL))
            {
                MessageBox.Show("You need to fill all cells!");
            }
            else {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "(AGE OF EMIRES MAP)|*.aoemap";
                    dialog.DefaultExt = "(AGE OF EMIRES MAP)|*.aoemap";
                    dialog.FileName = "NewMap";
                    if (dialog.ShowDialog() == DialogResult.OK) {

                        List<Cell> field = new List<Cell>(); 

                        foreach (var item in this.MapPanel.Controls.OfType<Button>())
                        {
                            field.Add(new Cell()
                            {
                                Size = item.Width,
                                Type = item.Name,
                                X = item.Location.X,
                                Y = item.Location.Y
                            });
                        }



                        

                        File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(field));
                    }

                }
            }
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "(AGE OF EMIRES MAP)|*.aoemap";
                if (dialog.ShowDialog() == DialogResult.OK) {

                    var field = JsonConvert.DeserializeObject<List<Cell>>(File.ReadAllText(dialog.FileName));
                    foreach (var item in field)
                    {

                        Button sqr = new Button();


                        sqr.Location = new Point(item.X,item.Y);


                        switch (item.Type)
                        {
                            case "Grass":
                                sqr.Size = new Size(item.Size, item.Size);
                                sqr.BackColor = Color.Green;

                                break;
                            case "Dirt":
                                sqr.Size = new Size(item.Size, item.Size);
                                sqr.BackColor = Color.Brown;
                                break;
                            case "Rock":
                                sqr.Size = new Size(item.Size, item.Size);
                                sqr.BackColor = Color.Gray;
                                break;
                            case "Tree":
                                sqr.Size = new Size(item.Size, item.Size);
                                sqr.BackColor = Color.DarkGreen;
                                break;
                            case "Sand":
                                sqr.Size = new Size(item.Size, item.Size);
                                sqr.BackColor = Color.Yellow;
                                break;
                            case "Water":
                                sqr.Size = new Size(item.Size, item.Size);
                                sqr.BackColor = Color.Blue;
                                break;
                            default:
                                break;
                        }

                        sqr.Name = this.CategoryBox.SelectedItem.ToString();
                        sqr.MouseMove += Sqr_MouseMove;
                        sqr.FlatStyle = FlatStyle.Flat;
                        sqr.FlatAppearance.BorderSize = 0;


                        this.MapPanel.Controls.Add(sqr);
                    }

                }

            }
        }
    }
}
