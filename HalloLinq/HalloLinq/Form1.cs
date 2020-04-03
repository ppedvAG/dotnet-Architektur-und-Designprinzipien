using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloLinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter
                {
                    Id = i + 1,
                    Name = $"Fred #{i:000}",
                    GebDatum = DateTime.Now.AddYears(-100).AddDays(i * 133)
                };

                liste.Add(m);
            }
        }

        List<Mitarbeiter> liste = new List<Mitarbeiter>();

        private void AlleAnzeigen_button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = liste;
        }

        private void Ab6anzeigen_button_Click(object sender, EventArgs e)
        {
            //linq query / linq expression
            var query = from m in liste
                        where m.GebDatum.Month >= 6
                        orderby m.GebDatum.Day, m.GebDatum.Month
                        select m;

            dataGridView1.DataSource = query.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //LAMBDA
            dataGridView1.DataSource = liste.Where(x => x.GebDatum.Month >= 6)
                                            .OrderBy(x => x.GebDatum.Day)
                                            .ThenBy(x => x.GebDatum.Month)
                                            .ToList();
        }
    }

    class Mitarbeiter
    {
        //private int feld = 6;

        //public int GetFeld()
        //{
        //    return feld;
        //}

        //internal void SetFeld(int value)
        //{
        //    //todo value verifaction
        //    this.feld = value;
        //}

        //private int feld2;

        //public int MyProperty
        //{
        //    get { return feld2; }
        //    set { feld2 = value; }
        //}



        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime GebDatum { get; set; }
    }

}
