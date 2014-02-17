using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proiect.Aplicatii.Informatica.Evaluator
{
    public partial class Rezultate : Form
    {
        private Dictionary<string, Dictionary<int, Dictionary<string, long>>> RezultateEvaluare = new Dictionary<string, Dictionary<int, Dictionary<string, long>>>();
        
        public Rezultate(Dictionary<string, Dictionary<int, Dictionary<string, long>>> rez)
        {
            InitializeComponent();
            RezultateEvaluare = rez;

            if (RezultateEvaluare.Count > 0)
            {
                selectExe.Items.Clear();
                foreach(var key in RezultateEvaluare.Keys)
                {                   
                    selectExe.Items.Add(key);
                }
                selectExe.SelectedIndex = 0;
            }
        }

        private void populeazaGridView(string exe)
        {
            DataTable tabelRezultate = new DataTable();
            
            // adaug coloanele in tabel
            tabelRezultate.Columns.Add("Test", typeof(string));
            tabelRezultate.Columns.Add("Timp", typeof(string));
            tabelRezultate.Columns.Add("Memorie", typeof(string));
            tabelRezultate.Columns.Add("Puncte", typeof(string));
            tabelRezultate.Columns.Add("Mesaj", typeof(string));

            // adaug randuri in tabel
            long total = 0; string mesaj = string.Empty;

            for (int i = 0; i < RezultateEvaluare[exe].Count; i++)
            {
                switch (RezultateEvaluare[exe][i]["Mesaj"])
                { 
                    default:
                        mesaj = "Eroare";
                        break;
                    case -1:
                        mesaj = "Timp depăsit";
                        break;
                    case 0:
                        mesaj = "Corect";
                        break;
                    case 1:
                        mesaj = "Fișier inexistent";
                        break;
                    case 3:
                        mesaj = "Memorie depașită";
                        break;
                    case 4:
                        mesaj = "Incorect";
                        break;
                }

                tabelRezultate.Rows.Add("Test " + i.ToString(),
                                        RezultateEvaluare[exe][i]["Timp"].ToString() + "ms",
                                        ConvertBytesToKilobytes(RezultateEvaluare[exe][i]["Memorie"]).ToString() + "KB",
                                        RezultateEvaluare[exe][i]["Puncte"].ToString(),
                                        mesaj);

                total += RezultateEvaluare[exe][i]["Puncte"];
                //MessageBox.Show(RezultateEvaluare["alee.exe"][i]["Timp"].ToString());
            }

            // adaug randul cu total
            tabelRezultate.Rows.Add("", "", "Total", total.ToString());

            gridRezultate.DataSource = tabelRezultate;

        }

        private double ConvertBytesToKilobytes(long bytes)
        {
            return bytes / 1024f;
        }

        private void selectExe_SelectedIndexChanged(object sender, EventArgs e)
        {
            populeazaGridView(selectExe.SelectedItem.ToString());
        }
    }
}
