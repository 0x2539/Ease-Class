using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proiect
{
    class ScriereaPoloneza
    {
        string s1 = "", s2 = "", ecuatie = "";
        int uyt9 = 0, poz1 = 0, poz2 = 0, poz3 = 0;
        string infinit = "", text = "";

        /// <summary>
        /// calculeaza doar ecuatii cu paranteze { [ ( ) ] }
        /// </summary>
        /// <param name="text2">ecuatia care trebuie calculata</param>
        public string calculeazaToateParantezele(string text2)
        {
            text = text2;
            if (text != "")
            {
                s1 = text;
                s2 = text;
                ecuatie = s1;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (ecuatie[i - uyt9] == '{')
                    {
                        poz1 = i - uyt9;
                    }

                    if (ecuatie[i - uyt9] == '[')
                    {
                        poz2 = i - uyt9;
                    }

                    if (ecuatie[i - uyt9] == '(')
                    {
                        poz3 = i - uyt9;
                    }


                    if (ecuatie[i - uyt9] == '}')
                    {
                        string s = ecuatie.Substring(poz1 + 1, i - poz1 - uyt9 - 1);
                        calcule(s, poz1, i - poz1 - uyt9 + 1);
                    }

                    if (ecuatie[i - uyt9] == ']')
                    {
                        string s = ecuatie.Substring(poz2 + 1, i - poz2 - uyt9 - 1);
                        calcule(s, poz2, i - poz2 - uyt9 + 1);
                    }

                    if (ecuatie[i - uyt9] == ')')
                    {
                        string s = ecuatie.Substring(poz3 + 1, i - poz3 - uyt9 - 1);
                        calcule(s, poz3, i - poz3 - uyt9 + 1);
                    }
                }
                calcule(ecuatie, 0, ecuatie.Length);
            }
            if (infinit == "")
            {
                text = ecuatie;
            }
            else
            {
                text = "Infinit!";
            }
            ecuatie = "";
            uyt9 = 0;
            infinit = "";
            return text;
        }

        /// <summary>
        /// face calculele
        /// </summary>
        /// <param name="s">substringul din ecuatie</param>
        /// <param name="poz1">pozitia de inceput a substringului</param>
        /// <param name="lungime">lungimea substringului</param>
        /// <returns></returns>
        public string calcule(string s, int pozz, int lungime)
        {
            string intermediar = "";
            int k = 0;
            double[] numere = new double[40];
            string semn = "";

            //fac un while in care sterg semnele consecutive gen: +3*-1 sa scrie -3*1
            int pozz1 = 0, pozz2 = 0, j = 0, uyt = 0;
            string ss = s, SEMNE = "";
            while (j < s.Length)
            {
                //daca gaseste * sau /
                if (s[j] == '*' || s[j] == '/')
                {
                    //daca e primul * din secventa
                    if (SEMNE == "")
                    {
                        //daca inainte are + sau -, retin daca e + sau - si ii retin si pozitia
                        //fac un while inapoi sa ajung sa vad ce semn e inainte de inmultire
                        int u = j - uyt;
                        while (u >= 0)
                        {
                            if (ss[u] == '+' || ss[u] == '-')
                            {
                                SEMNE += ss[u];
                                pozz1 = u;
                                break;
                            }
                            u--;
                        }
                        if (SEMNE == "")
                        {
                            ss = ss.Insert(0, "+");
                            uyt--;
                            SEMNE = "+";
                            pozz1 = 0;
                        }
                    }

                    //daca dupa are + sau -, verific care era semnul de dinainte si il schimb daca e nevoie
                    if (s[j + 1] == '+' || s[j + 1] == '-')
                    {
                        if (SEMNE == "+" && s[j + 1] == '+')
                        {
                            ss = ss.Remove(j - uyt + 1, 1);
                            uyt++;
                            SEMNE = "";
                        }
                        else
                            if (SEMNE == "+" && s[j + 1] == '-')
                            {
                                ss = ss.Remove(pozz1, 1);
                                ss = ss.Insert(pozz1, "-");
                                ss = ss.Remove(j - uyt + 1, 1);
                                uyt++;
                                SEMNE = "";
                            }
                            else
                                if (SEMNE == "-" && s[j + 1] == '+')
                                {
                                    ss = ss.Remove(pozz1, 1);
                                    ss = ss.Insert(pozz1, "-");
                                    ss = ss.Remove(j - uyt + 1, 1);
                                    uyt++;
                                    SEMNE = "";
                                }
                                else
                                    if (SEMNE == "-" && s[j + 1] == '-')
                                    {
                                        ss = ss.Remove(pozz1, 1);
                                        ss = ss.Insert(pozz1, "+");
                                        ss = ss.Remove(j - uyt + 1, 1);
                                        uyt++;
                                        SEMNE = "";
                                    }
                        SEMNE = "";
                    }
                }

                //inlocuiesc semnele consecutive gen : ++  sau +-.... 
                if (j + 1 < s.Length)
                {
                    if (s[j] == '+' && s[j + 1] == '-')
                    {
                        ss = ss.Remove(j - uyt, 2);
                        ss = ss.Insert(j - uyt, "-");
                        uyt++;
                    }
                    else
                        if (s[j] == '-' && s[j + 1] == '+')
                        {
                            ss = ss.Remove(j - uyt, 2);
                            ss = ss.Insert(j - uyt, "-");
                            uyt++;
                        }
                        else
                            if (s[j] == '-' && s[j + 1] == '-')
                            {
                                ss = ss.Remove(j - uyt, 2);
                                ss = ss.Insert(j - uyt, "+");
                                uyt++;
                            }
                            else
                                if (s[j] == '+' && s[j + 1] == '+')
                                {
                                    ss = ss.Remove(j - uyt, 2);
                                    ss = ss.Insert(j - uyt, "+");
                                    uyt++;
                                }
                }
                j++;
            }
            s = ss;



            //fac mai intai inmultirile si impartirile
            double[] nnn = new double[40];
            string sss = "", inter1 = "";//sss este stringul de semne
            int uyt0 = 0, k0 = 0, numar1 = 0, numar2 = 0, Sposition = 0, Fposition = 0;
            //sposition si fposition 
            //sunt pozitiile de inceput si final unde gaseste inmultirile ca sa stiu care
            //inmultire sa o inlocuiesc cu raspunsul
            for (int i = 0; i < s.Length; i++)
            {
                numar1 = ss.Length;
                if (ss[i - uyt0] == '*' || ss[i - uyt0] == '/')
                {
                    int q = i - uyt0;
                    //gasesc pozitia primului element din inmultire sau impartire
                    while (q >= 0)
                    {
                        if (ss[q] == '+' || ss[q] == '-')
                        {
                            break;
                        }
                        q--;
                    }
                    q++;
                    Sposition = q;
                    //retin numerele si semnele de dinainte
                    while (q < ss.Length && ss[q] != '+' && ss[q] != '-')
                    {
                        if (ss[q] != '*' && ss[q] != '/')
                        {
                            inter1 += ss[q];
                        }
                        else
                            if (ss[q] == '*' || ss[q] == '/')
                            {
                                nnn[k0] = Convert.ToDouble(inter1);
                                inter1 = "";
                                sss += ss[q];
                                k0++;
                            }

                        if (q + 1 < ss.Length)
                        {
                            if (ss[q + 1] == '+' || ss[q + 1] == '-')
                            {
                                nnn[k0] = Convert.ToDouble(inter1);
                                inter1 = "";
                                sss += ss[q + 1];
                                k0++;
                            }
                        }

                        if (q == ss.Length - 1)
                        {
                            nnn[k0] = Convert.ToDouble(inter1);
                            k0++;
                            inter1 = "";
                        }
                        q++;
                    }
                    q--;
                    Fposition = q;
                    double rrr = nnn[0];
                    for (int p = 1; p < k0; p++)
                    {
                        if (sss[p - 1] == '*')
                        {
                            rrr *= nnn[p];
                        }
                        else
                            if (sss[p - 1] == '/')
                            {
                                rrr /= nnn[p];
                            }
                    }
                    ss = ss.Remove(Sposition, Fposition - Sposition + 1);
                    ss = ss.Insert(Sposition, rrr.ToString());
                    numar2 = ss.Length;
                    uyt0 += numar1 - numar2;
                    i = Fposition + uyt0;
                    k0 = 0;
                    sss = "";
                    inter1 = "";
                }
            }
            s = ss;


            //retin numerele dintre paranteze in vectorul numere si in string semn retin semnele
            for (int i = 0; i < s.Length; i++)
            {
                //retin cifrele numarului intr-un string intermediar
                if (s[i] != '+' && s[i] != '-' && s[i] != '*' && s[i] != '/' && s[i] != '=')
                {
                    intermediar += s[i];
                }
                else
                    //schimb stringul intermediar in numar
                    if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/' || s[i] == '=')
                    {
                        semn += s[i];
                        if (intermediar != "")
                        {
                            numere[k] = Convert.ToDouble(intermediar);
                        }
                        else
                        {
                            numere[k] = 0;
                        }
                        intermediar = "";
                        k++;
                    }
                //daca ajunge la sfarsit sa adauge si ultimul numar
                if (i == s.Length - 1)
                {
                    if (s[i] != '+' && s[i] != '-' && s[i] != '*' && s[i] != '/' && s[i] != '=')
                    {
                        numere[k] = Convert.ToDouble(intermediar);
                        intermediar = "";
                        k++;
                    }
                }
            }

            if (semn.Length < k)
            {
                semn = semn.Insert(0, "+");
            }

            double raspuns = 0;

            for (int i = 0; i < semn.Length; i++)
            {
                if (semn[i] == '+')
                {
                    raspuns += numere[i];
                }
                else
                    if (semn[i] == '-')
                    {
                        raspuns -= numere[i];
                    }
                    else
                        if (semn[i] == '*')
                        {
                            raspuns *= numere[i];
                        }
                        else
                            if (semn[i] == '/')
                            {
                                if (numere[i] == 0)
                                {
                                    infinit = "infinit";
                                }
                                else
                                {
                                    raspuns /= numere[i];
                                }
                            }
            }

            int nr1 = ecuatie.Length, nr2 = 0;

            ecuatie = ecuatie.Remove(pozz, lungime);
            ecuatie = ecuatie.Insert(pozz, raspuns.ToString());

            nr2 = ecuatie.Length;
            uyt9 += nr1 - nr2;
            k = 0;
            return raspuns.ToString();
        }

        /// <summary>
        /// Calculeaza ecuatii care contin doar paranteza ( )
        /// </summary>
        /// <param name="text2">ecuatia care trebuie calculata</param>
        public string calculeazaOparanteza(string text2)
        {
            text = text2;
            if (text != "")
            {
                s1 = text;
                s2 = text;
                ecuatie = s1;
                for (int i = 0; i < s1.Length; i++)
                {

                    if (ecuatie[i - uyt9] == ')')
                    {
                        int f = i - uyt9;
                        while (f >= 0)
                        {
                            if (ecuatie[f] == '(')
                            {
                                poz1 = f;
                                break;
                            }
                            f--;
                        }
                        string s = ecuatie.Substring(poz1 + 1, i - poz1 - uyt9 - 1);
                        calcule(s, poz1, i - poz1 - uyt9 + 1);
                    }
                }
                calcule(ecuatie, 0, ecuatie.Length);
            }
            if (infinit == "")
            {
                text = ecuatie;
            }
            else
            {
                text = "Infinit!";
            }
            ecuatie = "";
            uyt9 = 0;
            infinit = "";
            return text;
        }
    }
}
