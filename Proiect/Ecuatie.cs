using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Ecuatie : Form
    {
        public Ecuatie()
        {
            InitializeComponent();
        }
        //string xecuatie = "";
        //int nr1 = -1, poz = -1, xtotal = 0, uyt1 = 0;
        //int[] adunaPanelEcuatie = new int[40];
        string ecuatie = "", ecuatii1 = "", ecuatii2 = "";
        int uyt9 = 0;//sa stiu cat scad din ecuatie

        private void button1_ClickEcuatie(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzcvbnm";
            for (int o = 0; o < textBox1.Text.Length; o++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (textBox1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            if (tr == true)
            {
                MessageBox.Show("Introduceti numai numere!");
            }
            
            if(tr==false)
            if (textBox1.Text != "")
            {


                stergeSpatiiEcuatie();
                //ecuatie = textBox1.Text;
                //label3.Text = ecuatie;
                if (textBox1.Text != "")
                {
                    bool sePoate = false;
                    string[] ecuatii = textBox1.Text.Split('=');
                    //verifica daca exista egal
                    if (textBox1.Text.IndexOf('=') != -1)
                    {
                        ecuatii1 = ecuatii[0];
                        ecuatie = ecuatii1;
                        ecuatii2 = ecuatii[1];
                        sePoate = true;
                    }
                    else
                    {
                        sePoate = false;
                    }
                    if (sePoate == true)
                    {
                        string eec = ecuatii1;
                        string sss = ecuatii1;
                        int uyt = 0;
                        //verifica daca gaseste paranteza sau pe x, sa ii puna 1* inainte pentru orice eventualitate
                        for (int i = 0; i < eec.Length; i++)
                        {
                            if (eec[i] == '(' || eec[i] == '[' || eec[i] == '{' || eec[i] == 'x')
                            {
                                sss = sss.Insert(i + uyt, "1*");
                                uyt++;
                                uyt++;
                            }
                        }
                        ecuatii1 = sss;

                        eec = ecuatii2;
                        sss = ecuatii2;
                        uyt = 0;
                        for (int i = 0; i < eec.Length; i++)
                        {
                            if (eec[i] == '(' || eec[i] == '[' || eec[i] == '{' || eec[i] == 'x')
                            {
                                sss = sss.Insert(i + uyt, "1*");
                                uyt++;
                                uyt++;
                            }
                        }
                        ecuatii2 = sss;


                        //aduc la acelasi numitor
                        /*string intermediar="";
                        int[] numitori = new int[40];//va retine toti numitorii, pentru a stii care sunt
                                                //cand voi aduce la acelasi numitor
                        int[] numitorri = new int[40];//va retine numitorii care nu se repeta, pentru
                                                //a putea calcula numitorul comun
                        int k = 0, g = 0;//k=numarul total de numitori
                                         //g=numarul de numitori care nu se repeta
                        
                        //caut si notez care sunt numitorii
                        for (int i = 0; i < ecuatii1.Length; i++)
                        {
                            if (ecuatii1[i] == '/')
                            {
                                int j = i + 1;
                                while (j<ecuatii1.Length && (ecuatii1[j] == '0' || ecuatii1[j] == '1' || 
                                    ecuatii1[j] == '2' || ecuatii1[j] == '3' || ecuatii1[j] == '4' || 
                                    ecuatii1[j] == '5' || ecuatii1[j] == '6' || ecuatii1[j] == '7' || 
                                    ecuatii1[j] == '8' || ecuatii1[j] == '9'))
                                {
                                    intermediar += ecuatii1[j];
                                    j++;
                                }
                                
                                //daca este primul numitor, atunci il retine, pentru ca altfel nu
                                //va intra in urmatorul for
                                if (g == 0)
                                {
                                    numitorri[0] = Convert.ToInt32(intermediar);
                                    g++;
                                }
                                
                                bool salal = false;
                                //salal va retine daca numitorul a mai existat pana acum
                                for (int h = 0; h < g; h++)
                                {
                                    if (numitorri[h] == Convert.ToInt32(intermediar))
                                    {
                                        salal = true;
                                    }
                                }
                                //daca numitorul nu a mai aparut atunci o sa il notez
                                if (salal == false)
                                {
                                    numitorri[g] = Convert.ToInt32(intermediar);
                                    g++;
                                }
                                numitori[k] = Convert.ToInt32(intermediar);
                                k++;
                                intermediar = "";
                            }
                        }
                        
                        for (int i = 0; i < ecuatii2.Length; i++)
                        {
                            if (ecuatii2[i] == '/')
                            {
                                int j = i + 1;
                                while (j < ecuatii2.Length && (ecuatii2[j] == '0' || ecuatii2[j] == '1' ||
                                    ecuatii2[j] == '2' || ecuatii2[j] == '3' || ecuatii2[j] == '4' ||
                                    ecuatii2[j] == '5' || ecuatii2[j] == '6' || ecuatii2[j] == '7' ||
                                    ecuatii2[j] == '8' || ecuatii2[j] == '9'))
                                {
                                    intermediar += ecuatii2[j];
                                    j++;
                                }
                                
                                //daca este primul numitor, atunci il retine, pentru ca altfel nu
                                //va intra in urmatorul for
                                if (g == 0)
                                {
                                    numitorri[0] = Convert.ToInt32(intermediar);
                                    g++;
                                }
                                
                                bool salal = false;
                                //salal va retine daca numitorul a mai existat pana acum
                                for (int h = 0; h < g; h++)
                                {
                                    if (numitorri[h] == Convert.ToInt32(intermediar))
                                    {
                                        salal = true;
                                    }
                                    else
                                        if (numitorri[h] % Convert.ToInt32(intermediar) == 0)
                                        {
                                            salal = true;
                                        }
                                        else
                                            if (Convert.ToInt32(intermediar) % numitorri[h] == 0)
                                            {
                                                salal = true;
                                                numitorri[h] = Convert.ToInt32(intermediar);
                                            }
                                }
                                //daca numitorul nu a mai aparut atunci o sa il notez
                                if (salal == false)
                                {
                                    numitorri[g] = Convert.ToInt32(intermediar);
                                    g++;
                                }
                                numitori[k] = Convert.ToInt32(intermediar);
                                k++;
                                intermediar = "";
                            }
                        }
                        //calculez numitorul comun
                        int numitor = 1;
                        for (int i = 0; i < g; i++)
                        {
                            numitor *= numitorri[i];
                        }

                        string sd = ecuatii1;
                        int uy = 0, sterse = 0, f = 0;
                        //f va retine numarul numitorului corespunzator fiecarui "/"
                        for (int i = 0; i < ecuatii1.Length; i++)
                        {
                            if (ecuatii1[i] == '/')
                            {
                                int j = i + 1;
                                while (j < ecuatii1.Length)
                                {
                                    if (sd[j - uy] == '0' || sd[j - uy] == '1' ||
                                        sd[j - uy] == '2' || sd[j - uy] == '3' || sd[j - uy] == '4' ||
                                        sd[j - uy] == '5' || sd[j - uy] == '6' || sd[j - uy] == '7' ||
                                        sd[j - uy] == '8' || sd[j - uy] == '9')
                                    {
                                        sterse++;
                                        j++;
                                    }
                                    else
                                        break;
                                }
                                int nr1 = numitori[f], nr2;
                                nr2 = numitor/numitori[f];
                                sd = sd.Remove(i - uy, numitori[f].ToString().Length + 1);
                                sd = sd.Insert(i - uy, "*" + nr2.ToString());
                                uy += sterse;
                                uy -= nr2.ToString().Length;
                                sterse = 0;
                                f++;
                            }
                        }
                        ecuatii1 = sd;


                        sd = ecuatii2;
                        uy = 0;
                        sterse = 0;
                        f = 0;
                        //f va retine numarul numitorului corespunzator fiecarui "/"
                        for (int i = 0; i < ecuatii2.Length; i++)
                        {
                            if (ecuatii2[i] == '/')
                            {
                                int j = i + 1;
                                while (j < ecuatii2.Length)
                                {
                                    if (sd[j - uy] == '0' || sd[j - uy] == '1' ||
                                        sd[j - uy] == '2' || sd[j - uy] == '3' || sd[j - uy] == '4' ||
                                        sd[j - uy] == '5' || sd[j - uy] == '6' || sd[j - uy] == '7' ||
                                        sd[j - uy] == '8' || sd[j - uy] == '9')
                                    {
                                        sterse++;
                                        j++;
                                    }
                                    else
                                        break;
                                }
                                int nr1 = numitori[f], nr2;
                                nr2 = numitor / numitori[f];
                                sd = sd.Remove(i - uy, numitori[f].ToString().Length + 1);
                                sd = sd.Insert(i - uy, "*" + nr2.ToString());
                                uy += sterse;
                                uy -= nr2.ToString().Length;
                                sterse = 0;
                                f++;
                            }
                        }
                        ecuatii2 = sd;
                        
                        


                        //MessageBox.Show("ecuatia este ecuatii    " + ecuatii1+'\n'+ecuatii2);
                        */
                        
                        //ecuatie ia valoarea membrului stang
                        //se calculeaza membrul stang
                        ecuatie = ecuatii1;
                        calculeazaMembreEcuatie(ecuatii1);
                        //label2.Text = ecuatie;
                        string membruStang = ecuatie;

                        //se calculeaza membrul drept
                        ecuatie = ecuatii2;
                        calculeazaMembreEcuatie(ecuatii2);
                        //label3.Text = ecuatie;
                        string membruDrept = ecuatie;


                        string membru = "";
                        //pun + inainte pentru ca sa fac calcule corect mai tarziu
                        if (membruDrept[0] != '-')
                        {
                            membruDrept = membruDrept.Insert(0, "+");
                        }

                        //fiind in membrul drept voi schimba semnele pentru a le trece in membrul stang
                        membruDrept = ReverseSemnEcuatie(membruDrept);

                        string cop;
                        string s = membruStang + membruDrept; uyt9 = 0; ecuatie = s;
                        cop = s;
                        //calculeaza dupa ce a trecut membrul drept in partea stanga
                        calculeazaMembreEcuatie(s);
                        //label1.Text = ecuatie;

                        string cope = ecuatie, s5 = "", s6 = "";
                        for (int i = cope.Length - 1; i >= 0; i--)
                        {
                            if (ecuatie[i] == 'x')
                            {
                                int j = i - 2;
                                while (j >= 0 && ecuatie[j] != '+' && ecuatie[j] != '-' &&
                                    ecuatie[j] != '(' && ecuatie[j] != '[' && ecuatie[j] != '{')
                                {
                                    s5 += ecuatie[j];
                                    j--;
                                }
                                s5 += ecuatie[j];
                                i = j;
                            }
                            else
                            {
                                s6 += ecuatie[i];
                            }
                        }
                        s5 = ReverseStringEcuatie(s5);
                        s6 = ReverseStringEcuatie(s6);
                        double raspuns = 0;
                        //MessageBox.Show(s5 + "     " + s6);
                        try
                        {
                            
                            raspuns = (Convert.ToDouble(s6) * (-1)) / Convert.ToDouble(s5);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                        LabelX1.Show();
                        LabelX1.Text = raspuns.ToString();
                        uyt9 = 0;
                        //label4.Text = raspuns.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Introduceti ecuatia!");
                    }
                }
                else
                {
                    MessageBox.Show("Introduceti ecuatia!");
                }
            }
            else
            {
                MessageBox.Show("Introduceti ecuatia!");
            }
        }

        public void inmultesteTermeniIEcuatie(int poz11, int ii)
        {
            //desfac parantezele care pot, 
            string s = ecuatie;
            if (inmultiriParantezeEcuatie(poz11, ii) != "")
            {
                //falala va contine operatiile din jurul parantezelor : 3*2(1+2x)/4*5 ( 3*2/4*5)
                string falala = inmultiriParantezeEcuatie(poz11, ii);
                //fala1=pozitia cea mai la stanga a termenului cu care se inmuleteste : 3*2*(1+2x) (pozitia lui 3)
                string fala1 = falala.Substring(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                falala = falala.Remove(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                //fala2=pozitia cea mai la dreapta a termenului cu care se inmulteste : (1+2x)*3*2 (pozitia lui 2)
                string fala2 = falala.Substring(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));

                falala = falala.Remove(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));

                int uy = 0, sterse = 1;
                string sd = falala, dupa = "";
                

                if (sd == "")
                {
                    sd = "1";
                }
                if (sd[0] == '/')
                {
                    sd = sd.Insert(0, "1");
                }
                string calculll = "";
                //calculele termenilor de langa paranteze + semnul de dinaintea parantezei + paranteza
                calculll = faCalculeEcuatie(sd) + '*' + s.Substring(poz11, ii - poz11 + 1);// +dupa;

                
                int po1 = Convert.ToInt32(fala1), po2 = Convert.ToInt32(fala2);
                string asd = s.Substring(poz11, ii - poz11 + 1);
                
                ecuatie = ecuatie.Remove(po1, po2 - po1 + 1);
                uyt9 += po2 - po1 + 1;
                ecuatie = ecuatie.Insert(po1, calculll);
                uyt9 -= calculll.Length;
            }
        }

        public void calculeazaParantezeIEcuatie(int poz11, int ii)
        {
            string s = ecuatie.Substring(poz11, ii - poz11 + 1);
            bool skip = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == 'x')
                {
                    skip = true;
                    break;
                }
            }
            //daca nu a gasit pe x atunci poate face calculele in paranteza
            if (skip == false)
            {
                s = faCalculeEcuatie(s);
                ecuatie = ecuatie.Remove(poz11, ii - poz11 + 1);
                uyt9 += ii - poz11 + 1;
                ecuatie = ecuatie.Insert(poz11, s);
                uyt9 -= s.Length;
            }
        }

        public void calculeazaMembreEcuatie(string falala)
        {
            uyt9 = 0;

            int poz1 = -1, poz2 = -1, poz3 = -1;//poz1=( poz2=[ poz3={
            string s = falala;
            //salvez pozitiile unde gaseste inceputul de paranteze si dupa aceea fac calculele de unde gaseste sfarsitul
            //parantezei face calculele pana la pozitia memorata
            for (int i = 0; i < falala.Length; i++)
            {

                if (s[i] == '(')
                {
                    poz1 = i - uyt9;
                }

                if (s[i] == '[')
                {
                    poz2 = i - uyt9;
                }

                if (s[i] == '{')
                {
                    poz3 = i - uyt9;
                }


                if (s[i] == '}')
                {
                    calculeazaParantezeIEcuatie(poz3, i - uyt9);
                }

                if (s[i] == ']')
                {
                    calculeazaParantezeIEcuatie(poz2, i - uyt9);
                }

                if (s[i] == ')')
                {
                    calculeazaParantezeIEcuatie(poz1, i - uyt9);
                }
            }

            falala = ecuatie;
            uyt9 = 0;
            s = falala;

            for (int i = 0; i < falala.Length; i++)
            {
                if (s[i] == 'x')
                {
                    inmultesteTermeniIEcuatie(i - uyt9, i - uyt9);
                }

                if (s[i] == '(')
                {
                    poz1 = i - uyt9;
                }

                if (s[i] == '[')
                {
                    poz2 = i - uyt9;
                }

                if (s[i] == '{')
                {
                    poz3 = i - uyt9;
                }


                if (s[i] == '}')
                {
                    inmultesteTermeniIEcuatie(poz3, i - uyt9);
                }

                if (s[i] == ']')
                {
                    inmultesteTermeniIEcuatie(poz2, i - uyt9);
                }

                if (s[i] == ')')
                {
                    inmultesteTermeniIEcuatie(poz1, i - uyt9);
                }
            }

            falala = ecuatie;
            uyt9 = 0;
            s = falala;

            for (int i = 0; i < falala.Length; i++)
            {

                if (s[i] == '(')
                {
                    poz1 = i - uyt9;
                }

                if (s[i] == '[')
                {
                    poz2 = i - uyt9;
                }

                if (s[i] == '{')
                {
                    poz3 = i - uyt9;
                }


                if (s[i] == '}')
                {
                    calculeazaParantezeEcuatie(poz3, i - uyt9);
                }

                if (s[i] == ']')
                {
                    calculeazaParantezeEcuatie(poz2, i - uyt9);
                }

                if (s[i] == ')')
                {
                    calculeazaParantezeEcuatie(poz1, i - uyt9);
                }
            }


            falala = ecuatie;
            uyt9 = 0;
            s = falala;

            for (int i = 0; i < falala.Length; i++)
            {

                if (s[i] == '(')
                {
                    poz1 = i - uyt9;
                }

                if (s[i] == '[')
                {
                    poz2 = i - uyt9;
                }

                if (s[i] == '{')
                {
                    poz3 = i - uyt9;
                }


                if (s[i] == '}')
                {
                    desfaceParantezeEcuatie(poz3, i - uyt9);
                }

                if (s[i] == ']')
                {
                    desfaceParantezeEcuatie(poz2, i - uyt9);
                }

                if (s[i] == ')')
                {
                    desfaceParantezeEcuatie(poz1, i - uyt9);
                }
            }

            /*
                 int j = i;
                    while (s[j] != '{')
                    {
                        j--;
                    }
                    poz3 = j - uyt9;
                    
                    inmultesteTermeni(poz3, i - uyt9);

                    j = i;
                    while (s[j] != '{')
                    {
                        j--;
                    }
                    poz3 = j - uyt9; 
                    
                    calculeazaParanteze(poz3, i - uyt9);

                    j = i;
                    while (s[j] != '{')
                    {
                        j--;
                    }
                    poz3 = j - uyt9;

                    desfaceParanteze(poz3, i - uyt9);
                */


            ////MessageBox.Show(ecuatie + "             " + 1);

            if (ecuatie[0] == '+')
            {
                ecuatie = ecuatie.Remove(0, 1);
                uyt9++;
            }
            calculeFinaleEcuatie();
            string membruStang = ecuatie;
            //MessageBox.Show("ecuatie in calculeaza membre    " + ecuatie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lala">membrul drept</param>
        public string ReverseSemnEcuatie(string lala)
        {
            string s = lala;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '+')
                {
                    s = s.Remove(i, 1);
                    s = s.Insert(i, "-");
                }
                else
                    if (s[i] == '-')
                    {
                        s = s.Remove(i, 1);
                        s = s.Insert(i, "+");
                    }
            }
            return s;
        }

        public void calculeFinaleEcuatie()
        {
            string s = ecuatie;
            string s1 = "";
            int i = ecuatie.Length - 1;

            while (i >= 0)
            {
                if (s[i] == 'x')
                {
                    /*if (i - 1 > 0)
                    {
                        if (s[i - 1] != '*')
                        {
                            s = s.Insert(i, "1*");
                        }
                    }
                    else
                    {*/
                    s = s.Insert(i, "1*");
                    //}
                }
                i--;
            }
            ecuatie = s;
            //MessageBox.Show("ecuatie:          " + ecuatie);
            i = s.Length - 1;
            //retin care sunt termenii care contin pe x si cei care nu il contin, dupa care fac calcule intre ei
            while (i >= 0)
            {
                if (s[i] == 'x')
                {
                    int j = i - 2;
                    while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != '['
                            && s[j] != '{')
                    {
                        s1 += s[j];
                        j--;
                    }
                    if (j >= 0)
                    {
                        if (s[j] == '+' || s[j] == '-')
                        {
                            s1 += s[j];
                        }
                    }
                }
                i--;
            }
            s1 = ReverseStringEcuatie(s1);
            if (s1 != "")
            {
                if (s1[0] == '+')
                {
                    s1 = s1.Remove(0, 1);
                }
            }
            if (s1 != "")
            {
                s1 = faCalculeEcuatie(s1) + "*x";
            }
            else
            {
                s1 = "0*x";
            }

            if (s1[0] != '-')
            {
                s1 = s1.Insert(0, "+");
            }
            string s2 = "";
            i = s.Length - 1;
            while (i >= 0)
            {
                if (s[i] == 'x')
                {
                    int j = i - 1;
                    while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != '['
                                && s[j] != '{')
                    {
                        j--;
                    }
                    i = j;
                }
                else
                {
                    s2 += s[i];
                }
                i--;
            }
            s2 = ReverseStringEcuatie(s2);
            s2 = faCalculeEcuatie(s2);
            string s3 = s2 + s1;
            ecuatie = s3;
        }

        /// <summary>
        /// desface parantezele
        /// </summary>
        /// <param name="poz11"></param>
        /// <param name="ii"></param>
        public void desfaceParantezeEcuatie(int poz11, int ii)
        {
            //MessageBox.Show("ecuatie la inceputul desface paranteze    " + ecuatie);
            int uyt = 0, poz22 = poz11;
            string ecuatie2 = ecuatie;
            string s = ecuatie;
            string s1 = s.Substring(poz11, ii - poz11 + 1), s2 = "", s3 = "", s4 = "";
            //s2 pentru termeni liberi si s3 pentru termenii care contin pe x
            int j = poz11 - 1;
            while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != ')' && s[j] != '['
                        && s[j] != ']' && s[j] != '{' && s[j] != '}')
            {
                //terbuie sa fie diferit de primul semn de langa paranteza pentru ca poate fi * sau /
                if (j != poz11 - 1)
                {
                    s2 += s[j];
                }
                j--;
            }
            //poz22=pozitia de unde o sa sterg paranteza, pentru ca inainte de paranteza pot fi niste
            //termeni ai unei inmultiri
            if (j >= 0)
            {
                if (j != poz11 - 1)
                {
                    poz22 = j;
                }
                else
                {
                    //daca se afla imediat langa paranteza si este + sau - trebuie sa incep inlocuirea de 
                    //la acea pozitie
                    if (s[j] == '+' || s[j] == '-')
                    {
                        poz22 = j;
                    }
                }
            }
            else
            {
                poz22 = 0;
            }

            ////MessageBox.Show("poz22    " + poz22+"       poz11    "+ poz11);
            //daca inainte de paranteza este doar un + sau -
            if (s2 == "")
            {
                s2 = "1";
            }
            if (j >= 0)
            {
                if (s[j] == '-')
                {
                    s2 += '-';
                }
            }

            s2 = ReverseStringEcuatie(s2);
            j = 1;
            char semn;
            //vad care este semnul primului numar pentru a vedea cum sa fac inmultirea cu 
            //termenul liber din afara parantezei
            if (s1[j] == '-')
            {
                semn = '-';
                //il fac pe j++ pentru ca altfel nu o sa intre in urmatorul while
                j++;
            }
            else
                if (s1[j] == '+')
                {
                    semn = '+';
                    j++;
                }
                else
                {
                    semn = '+';
                }

            while (j < s1.Length && s1[j] != '+' && s1[j] != '-' && s1[j] != ')' && s1[j] != ']' && s1[j] != 'x' &&
                         s1[j] != '[' && s1[j] != '(' && s1[j] != '{' && s1[j] != '}')
            {
                s3 += s1[j];
                //verific daca urmatorul caracter este x sau este un + sau -
                if (j + 1 < s1.Length)
                {
                    if (s1[j + 1] == 'x')
                    {
                        //sterg ultimul caracter
                        s3 = s3.Remove(s3.Length - 1, 1);
                        s4 = s4 + semn + faCalculeEcuatie(s2 + "*" + s3) + "*x";
                        //vad care este semnul urmatorului numar
                        if (j + 2 < s1.Length)
                        {
                            if (s[j + 2] == '+')
                            {
                                semn = '+';
                            }
                            else
                                if (s[j + 2] == '-')
                                {
                                    semn = '-';
                                }
                            j += 2;
                        }
                        //reinitializez numarul
                        s3 = "";
                    }
                    else
                        if (s1[j + 1] == '+')
                        {
                            s4 = s4 + semn + faCalculeEcuatie(s2 + "*" + s3);
                            semn = '+';
                            s3 = "";
                            j++;
                        }
                        else
                            if (s1[j + 1] == '-')
                            {
                                s4 = s4 + semn + faCalculeEcuatie(s2 + "*" + s3);
                                semn = '-';
                                j++;
                                s3 = "";
                            }
                }
                j++;
            }

            s3 = "";
            j++;
            //fac un for in care daca gaseste +- sa il inlocuiasca cu -, sau daca gaseste -- sa il inlocuiasca cu +
            string ss4 = s4;
            int uyt4 = 0;
            for (int i = 0; i < s4.Length; i++)
            {
                if (s4[i] == '+' && i + 1 < s4.Length)
                {
                    if (s4[i + 1] == '+')
                    {
                        ss4 = ss4.Remove(i - uyt4, 2);
                        ss4 = ss4.Insert(i - uyt4, "+");
                        uyt4++;
                        //MessageBox.Show("primul if");
                    }

                    if (s4[i + 1] == '-')
                    {
                        ss4 = ss4.Remove(i - uyt4, 2);
                        ss4 = ss4.Insert(i - uyt4, "-");
                        uyt4++;
                        //MessageBox.Show("al treilea if");
                    }
                }
                else
                    if (s4[i] == '-' && i + 1 < s4.Length)
                    {
                        if (s4[i + 1] == '+')
                        {
                            ss4 = ss4.Remove(i - uyt4, 2);
                            ss4 = ss4.Insert(i - uyt4, "-");
                            uyt4++;
                            //MessageBox.Show("al doilea if");
                        }

                        if (s4[i + 1] == '-')
                        {
                            ss4 = ss4.Remove(i - uyt4, 2);
                            ss4 = ss4.Insert(i - uyt4, "+");
                            uyt4++;
                            //MessageBox.Show("al patrulea if");
                        }
                    }
            }
            s4 = ss4;
            //MessageBox.Show("acesta numar este s4    " + s4 + "        ecuatia   " + ecuatie);
            ecuatie = ecuatie.Remove(poz22, ii - poz22 + 1);
            ecuatie = ecuatie.Insert(poz22, s4);
            uyt9 += ii - poz22 + 1;
            uyt9 -= s4.Length;
            //MessageBox.Show("ecuatie in desface paranteze    " + ecuatie);
        }

        /// <summary>
        /// calculeaza termenii liberi din jurul parantezelor : 2/(1+2x)*3 = 6/(1+2x)
        /// </summary>
        /// <param name="poz11">pozitia de unde incepe paranteza</param>
        /// <param name="ii">pozitia de unde se termina paranteza</param>
        public void inmultesteTermeniEcuatie(int poz11, int ii)
        {
            //MessageBox.Show(poz11 + "    " + ii + "    " + ecuatie + "     " + uyt9);
            string s = ecuatie;
            if (inmultiriParantezeEcuatie(poz11, ii) != "")
            {
                //falala va contine operatiile din jurul parantezelor : 3*2(1+2x)/4*5 ( 3*2/4*5)
                string falala = inmultiriParantezeEcuatie(poz11, ii);
                //fala1=pozitia cea mai la stanga a termenului cu care se inmuleteste : 3*2*(1+2x) (pozitia lui 3)
                string fala1 = falala.Substring(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                falala = falala.Remove(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                //fala2=pozitia cea mai la dreapta a termenului cu care se inmulteste : (1+2x)*3*2 (pozitia lui 2)
                string fala2 = falala.Substring(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));

                falala = falala.Remove(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                int uy = 0;

                for (int o = 0; o < falala.Length; o++)
                {
                    if (falala[o] == ' ')
                    {
                        uy++;
                    }
                }

                int j = poz11 - 1, m1 = 0, k1 = 0, m2 = 0, k2 = 0;
                string semn1 = "", semn2 = "";
                while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != ')' && s[j] != ']' &&
                    s[j] != '}' && s[j] != '(' && s[j] != '[' && s[j] != '{')
                {
                    if (s[j] == ' ')
                    {
                        m1++;
                    }
                    else
                        if (semn1 == "")
                        {
                            if (s[j] == '*' || s[j] == '/')
                            {
                                semn1 = s[j].ToString();
                            }
                        }
                    j--;
                    k1++;
                }
                j = ii + 1;
                while (j < s.Length && s[j] != '+' && s[j] != '-' && s[j] != ')' && s[j] != ']' && s[j] != '}'
           && s[j] != '(' && s[j] != '[' && s[j] != '{')
                {
                    if (s[j] == ' ')
                    {
                        m2++;
                    }
                    else
                        if (semn2 == "")
                        {
                            if (s[j] == '*' || s[j] == '/')
                            {
                                semn2 = s[j].ToString();
                            }
                        }
                    j--;
                    k2++;
                }
                //daca are termeni si in stanga si in dreapta
                if (uy != falala.Length)
                {
                    //daca la stanga se afla termeni
                    if (m1 != k1)
                    {
                        string calculll;
                        //calculele termenilor de langa paranteze + semnul de dinaintea parantezei + paranteza
                        calculll = faCalculeEcuatie(falala) + semn1 + s.Substring(poz11, ii - poz11 + 1);

                        //daca paranteza NU este pe prima pozitie
                        if (Convert.ToDouble(fala1) > 0)//(Convert.ToDouble(fala2) - uyt9 <= ecuatie.Length)
                        {
                            ecuatie = ecuatie.Remove(Convert.ToInt32(fala1), Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1);
                            ecuatie = ecuatie.Insert(Convert.ToInt32(fala1), calculll);
                            uyt9 += Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1;
                            uyt9 -= calculll.Length;
                        }
                        else
                        {
                            ecuatie = ecuatie.Remove(Convert.ToInt32(fala1), Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1);
                            ecuatie = ecuatie.Insert(Convert.ToInt32(fala1), calculll);
                            uyt9 += Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1;
                            uyt9 -= calculll.Length;
                        }

                    }
                    //daca la stanga nu se afla termeni
                    else
                        if (m1 == k1 && m2 != k2)
                        {
                            string calculll = s.Substring(poz11, ii - poz11 + 1);
                            if (semn2 == "*")
                            {
                                calculll = faCalculeEcuatie(falala) + semn2 + s.Substring(poz11, ii - poz11 + 1);
                            }
                            else
                                if (semn2 == "/")
                                {
                                    falala = falala.Insert(0, "1/");
                                    calculll = faCalculeEcuatie(falala) + "*" + s.Substring(poz11, ii - poz11 + 1);
                                }
                            if (Convert.ToDouble(fala1) >= 0)
                            {
                                ecuatie = ecuatie.Remove(Convert.ToInt32(fala1), Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1);
                                ecuatie = ecuatie.Insert(Convert.ToInt32(fala1), calculll);
                                uyt9 += Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1;
                                uyt9 -= calculll.Length;
                            }
                        }
                }
                else
                {
                    ////MessageBox.Show("Nu are termeni");
                }
            }
            //MessageBox.Show("ecuatie in inmulteste termeni   " + ecuatie);
        }

        /// <summary>
        /// schimba pe textbox1 cu textbox1 fara spatii
        /// </summary>
        public void stergeSpatiiEcuatie()
        {
            string s = textBox1.Text;
            string s1 = s;
            int uyt1 = 0;
            bool apare = false;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (s[i] == ' ')
                {
                    s1 = s1.Remove(i - uyt1, 1);
                    uyt1++;
                }
                if (s[i] == 'x')
                {
                    if (i != 0)
                    {
                        for (int j = 0; j <= 9; j++)
                        {
                            if (s[i - 1] == j)
                            {
                                apare = true;
                            }
                        }
                    }
                    if (apare == true)
                    {
                        apare = false;
                        s1 = s1.Insert(i, "*");
                        uyt1--;
                    }
                }
            }
            ecuatie = s1;
            //textBox1.Text = s1;
        }

        /// <summary>
        /// Calculeaza termenii dinauntrul parantezelor care
        /// nu contin pe x, nu returneaza nimic, si schimba
        /// variabila "ecuatie" cu rezultatul obtinut
        /// </summary>
        /// <param name="e">substring din ecuatie de la ( )</param>
        /// <param name="qwe"></param>
        /// <param name="ert"></param>
        public void calculeazaParantezeEcuatie(int poz11, int ii)
        {//(1+2*x)+2+2+3*(1+2+2*2*x)
            //MessageBox.Show("aici se afla ec in calcParanteze    " + ecuatie);
            int uyt = 0;
            string ecuatie2 = ecuatie;
            string s = ecuatie.Substring(poz11, ii - poz11 + 1);
            string s1 = s, s2 = "", s3 = "", s4 = "";//s2 pentru termeni liberi si s3 pentru termenii care contin pe x
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')' && i != s.Length - 1)
                {
                    int j = i;
                    while (j >= 0 && s[j] != '(')
                    {
                        s3 += s[j];
                        j--;
                    }
                    if (s3 != "" && j >= 0)
                    {
                        s3 += s[j];
                    }
                    i = j + 1;
                }
                else
                    if (s[i] == '(' && i >= 1)
                    {
                        int j = i - 1;
                        while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != ')' &&
                                    s[j] != '[' && s[j] != ']' && s[j] != '{' && s[j] != '}')
                        {
                            s3 += s[j];
                            j--;
                        }
                        if (s3 != "" && j >= 0)
                        {
                            s3 += s[j];
                        }
                        i = j;
                    }
                    else
                        if (s[i] == ']' && i != s.Length - 1)
                        {
                            int j = i - 1;
                            while (j >= 0 && s[j] != '[')
                            {
                                j--;
                            }
                            i = j + 1;
                        }
                        else
                            if (s[i] == '[' && i >= 1)
                            {
                                int j = i - 1;
                                while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != ')' &&
                                            s[j] != '[' && s[j] != ']' && s[j] != '{' && s[j] != '}')
                                {
                                    j--;
                                }
                                i = j;
                            }
                            else
                                if (s[i] == 'x')
                                {
                                    int j = i;
                                    //s2 = "";
                                    while (j > 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != ')' &&
                                                s[j] != '[' && s[j] != ']' && s[j] != '{' && s[j] != '}')
                                    {
                                        s3 += s[j];
                                        j--;
                                    }
                                    if (s3 != "" && j > 0)
                                    {
                                        if (s[j] == '+' || s[j] == '-')
                                        {
                                            s3 += s[j];
                                        }
                                    }
                                    //daca termenul care il are pe x se afla la sfarsitul parantezei
                                    //atunci fac un j+1 pentru a salva si paranteza 
                                    if (s[j] == '(' || s[j] == '[' || s[j] == '{')
                                    {
                                        s2 += s[j];
                                        i = j;
                                    }
                                    else
                                        if (s[j] != '(' && s[j] != '[' && s[j] != '{')
                                        {
                                            i = j;
                                        }
                                        else
                                            if (j == 0)
                                                break;
                                }
                                else
                                {
                                    ////MessageBox.Show("s[i]            " + s[i]);
                                    s2 += s[i];
                                }
            }
            s2 = ReverseString2Ecuatie(s2);
            s3 = ReverseString2Ecuatie(s3);
            char paranteza1, paranteza2;
            //MessageBox.Show("ecuatie[poz11]    " + ecuatie[poz11] + "    poz11    " + poz11 +
            //'\n' + "ecuatie[ii]    " + ecuatie[ii] + "    ii    " + ii +
            //'\n' + s2 + "         " + s3 + "        " + ecuatie +
            //'\n' + uyt9);
            paranteza1 = ecuatie[poz11];
            paranteza2 = ecuatie[ii];
            if (s2.Length > 2)
            {
                s2 = s2.Remove(s2.Length - 1, 1);
                s2 = s2.Remove(0, 1);
                s2 = faCalculeEcuatie(s2);
            }
            else
            //if (s2.Length == 0)
            {
                s2 = "";
            }
            ecuatie = ecuatie.Remove(poz11, ii - poz11 + 1);
            if (s3 != "")
            {
                if (s3[0] != '-' && s3[0] != '+')
                {
                    s3 = s3.Insert(0, "+");
                }
            }
            s4 = s2 + s3;
            //MessageBox.Show("noile s3 si s4    " + s3 + "     " + s4);
            int plus = 0;
            //verific daca in s4 sunt numai termeni care contin pe x sau mai sunt si termeni liberi
            //si daca NU sunt numai termeni cu x atunci o sa afisam si parantezele
            for (int j = 0; j < s4.Length; j++)
            {
                if (s4[j] == '+' || s4[j] == '-')
                {
                    plus = 1;
                }
            }
            if (plus == 1)
            {
                ecuatie = ecuatie.Insert(poz11, paranteza1 + s2 + s3 + paranteza2);
                uyt9 -= (s2 + s3).Length + 2;
            }
            else
            {
                ecuatie = ecuatie.Insert(poz11, s2 + s3);
                uyt9 -= (s2 + s3).Length;
            }
            uyt9 += ii - poz11 + 1;
            if (s3 != "")
            {
                s4 = s2 + s3;
            }
            //MessageBox.Show("ecuatie in calculeaza paranteze      " + ecuatie);
        }

        /// <summary>
        /// Returneaza un string format din termenii liberi de
        /// pe langa paranteza cu x + pozitia parantezelor
        /// </summary>
        /// <param name="qwe"></param>
        /// <param name="ert"></param>
        /// <returns></returns>
        public string inmultiriParantezeEcuatie(int poz11, int ii)
        {
            string ret = "";
            string s = ecuatie, intermediar = "", intermediar1 = "", intermediar2 = "";
            int j = poz11 - 1;
            int uy = 0;
            while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != ')' && s[j] != ']' && s[j] != '}'
                    && s[j] != '(' && s[j] != '[' && s[j] != '{')
            {
                if (s[j] == ' ')
                {
                    uy++;
                }
                if (j != poz11 - 1)
                {
                    intermediar1 += s[j];
                }
                if (s[j] == 'x')
                {
                    ret = "nu";
                }
                j--;
            }
            int f = j + 1;
            intermediar1 = ReverseStringEcuatie(intermediar1);
            int l = poz11 - 1 - j;
            if (uy != poz11 - 1 - j)
            {
                j = ii + 1;

            }
            else
            {
                j = ii + 2;
            }
            while (j < s.Length && s[j] != '+' && s[j] != '-' && s[j] != ')' && s[j] != ']' && s[j] != '}'
                        && s[j] != '(' && s[j] != '[' && s[j] != '{')
            {
                if (s[j] == 'x')
                {
                    ret = "nu";
                }
                intermediar2 += s[j];
                j++;
            }
            int f2 = j - 1;
            //MessageBox.Show(intermediar1 + '\n' + intermediar2);
            if (ret != "nu")
            {
                intermediar = intermediar1 + intermediar2 + ' ' + f2.ToString() + ' ' + f.ToString();
            }
            else
            {
                intermediar = "";
            }
            return intermediar;
        }

        /// <summary>
        /// Returneaza un string
        /// </summary>
        /// <param name="ecuatie2"></param>
        /// <returns></returns>
        public string faCalculeEcuatie(string ecuatie2)
        {
            string hg = "";
            try
            {
                string lala = ecuatie2;
                ScriereaPoloneza sc = new ScriereaPoloneza();
                hg = sc.calculeazaToateParantezele(lala);
                return hg;
            }
            catch
            {
                hg = "Eroare!";
                return hg;
            }
        }

        /// <summary>
        /// Returneaza un string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseStringEcuatie(string s)
        {
            char[] a = s.ToCharArray();
            Array.Reverse(a);
            string f = new string(a);
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i] == '(')
                {
                    f = f.Remove(i, 1);
                    f = f.Insert(i, ")");
                }
                else
                    if (f[i] == ')')
                    {
                        f = f.Remove(i, 1);
                        f = f.Insert(i, "(");
                    }
                    else
                        if (f[i] == '[')
                        {
                            f = f.Remove(i, 1);
                            f = f.Insert(i, "]");
                        }
                        else
                            if (f[i] == ']')
                            {
                                f = f.Remove(i, 1);
                                f = f.Insert(i, "[");
                            }
                            else
                                if (f[i] == '{')
                                {
                                    f = f.Remove(i, 1);
                                    f = f.Insert(i, "}");
                                }
                                else
                                    if (f[i] == '}')
                                    {
                                        f = f.Remove(i, 1);
                                        f = f.Insert(i, "{");
                                    }
            }
            return f;
        }

        public string ReverseString2Ecuatie(string s)
        {
            char[] a = s.ToCharArray();
            Array.Reverse(a);
            string f = new string(a);
            return f;
        }

        private void button2_ClickEcuatie(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                double x = Convert.ToDouble(textBox4.Text);
                double y = Convert.ToDouble(textBox5.Text);
                double z = Convert.ToDouble(textBox6.Text);
                double w = Convert.ToDouble(textBox7.Text);
                double rasp = 0;
                z = z - w;
                double delta = y * y - 4 * x * z;
                if (delta > 0)
                {
                    LabelXX22.Show();
                    LabelXX21.Text = "x1= ";
                    LabelXX22.Text = "x2= ";

                    delta = Math.Sqrt(delta * delta - 4 * x * z);
                    rasp = (-y + delta) / (-2 * x);

                    LabelX21.Show();
                    LabelX21.Text = rasp.ToString();

                    rasp = (-y - delta) / (-2 * x);

                    LabelX22.Show();
                    LabelX22.Text = rasp.ToString();
                }
                else
                    if (delta == 0)
                    {
                        LabelXX22.Hide();
                        LabelX22.Hide();

                        rasp = -y / (-2 * x);

                        LabelXX21.Text = "x1= ";
                        LabelX21.Show();
                        LabelX21.Text = rasp.ToString();
                    }
                    else
                    {
                        LabelXX21.Text = "ecuatia nu are radacini reale";

                        LabelX21.Hide();
                        LabelXX22.Hide();
                        LabelX22.Hide();
                    }
            }
            else
            {
                MessageBox.Show("Introduceti toate datele!");
            }
        }

        private void button3_ClickEcuatie(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "")
            {
                double x = Convert.ToDouble(textBox8.Text);
                double y = Convert.ToDouble(textBox9.Text);
                double z = Convert.ToDouble(textBox10.Text);
                double q = Convert.ToDouble(textBox11.Text);
                double w = Convert.ToDouble(textBox12.Text);
                double rasp = 0;
                q = q - w;

                double inter1 = 0, inter2 = 0;
                int j = 0;
                while (rasp == 0)
                {
                    j++;
                    if (x * j * j * j + y * j * j + z * j + q == 0)
                    {
                        rasp = j;
                        LabelX31.Text = rasp.ToString();
                    }
                }
                if (rasp == 0)
                {
                    LabelXX33.Hide();
                    LabelXX32.Hide();
                    LabelX32.Hide();
                    LabelX33.Hide();
                    LabelX31.Hide();
                    LabelXX31.Text = "ecuatia nu are radacini reale";
                }
                //else
                //{
                //    string s1=
                //}



            }
            else
            {
                MessageBox.Show("Introduceti toate datele!");
            }
        }

        private void label14_ClickEcuatie(object sender, EventArgs e)
        {

        }

        private void label38_ClickEcuatie(object sender, EventArgs e)
        {

        }

        private void label8_ClickEcuatie(object sender, EventArgs e)
        {

        }

        private void label5_ClickEcuatie(object sender, EventArgs e)
        {

        }

        private void label2_ClickEcuatie(object sender, EventArgs e)
        {

        }

        private void label1_ClickEcuatie(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChangedEcuatie(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPressEcuatie(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }


    }
}
