using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect.Aplicatii
{
    class MesajeAvertizare
    {
        public static void mesajEroareNumarInvalid()
        {
            MessageBox.Show("Numere invalide.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void mesajEroareString(string Mesaj)
        {
            MessageBox.Show(Mesaj, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void mesajDirectorInexistent(string director) 
        {
            MessageBox.Show("Directorul \"" + director + "\" nu există.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void mesajAtentie(string mesaj) 
        {
            MessageBox.Show(mesaj, "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void structuraProblema(string mesaj)
        {
            MessageBox.Show(mesaj, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void mesajSuccess(string mesaj)
        {
            MessageBox.Show(mesaj, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
