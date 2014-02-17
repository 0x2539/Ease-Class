using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proiect.Aplicatii;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace Proiect.Aplicatii.Informatica.Evaluator
{
    public class Problema
    {
        public int IndexProblema;
        public string Path;
        public string NumeProblema;
        public bool OK = true;
        public int[] Puncte = new int[40];
        public int nrPrb = 0;

        // structura problemei
        public static string NumeConfig  = "config.xml";
        private string NumeFolderExe     = "executabile";
        private string NumeFolderSurse   = "surse";
        private string NumeFolderTeste   = "teste";

        // detaliile despre problema din fisierul config.xml
        public int LimitaTimp;
        public int MemorieTotala;
        public int MemorieStiva;
        public int NrTeste;
        public int DimensiuneSursa;
        public string AlteInformatii;

        // teste intrare, iesire, surse, exe
        public List<string> TesteIntrare = new List<string>();
        public List<string> TesteIesire = new List<string>();
        public List<string> Surse = new List<string>();
        public List<string> Executabile = new List<string>();

        public Problema(int index, string nume, string path) 
        {
            IndexProblema = index;
            NumeProblema = nume;
            Path = path + "\\" + nume + "\\";

            if (!verificaStructura())
            {
                MesajeAvertizare.structuraProblema("Structura problemei este invalida.");
                OK = false;
            }
            if (OK)
            {
                // citeste fisierul config
                CitesteFieConfig();
                TesteIntrare = citesteTesteIntrare();
                TesteIesire = citesteTesteIesire();
            }
        }

        bool verificaStructura() 
        {
            
            //Verifica structura folderului cu problema

            if (!File.Exists(Path + NumeConfig))
            {
                return false;
            }

            if (!Directory.Exists(Path + NumeFolderExe) || !Directory.Exists(Path + NumeFolderSurse) || !Directory.Exists(Path + NumeFolderTeste))
            {
                return false;
            }

            return true;
        }

        private void CitesteFieConfig() 
        {
            try
            {
                XmlDocument citConfig = new XmlDocument();
                citConfig.Load(Path + NumeConfig);
                XmlElement root = citConfig.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("//problema");

                LimitaTimp      = Convert.ToInt32(nodes[0]["limitaTimp"].InnerText);
                MemorieTotala   = Convert.ToInt32(nodes[0]["memorieTotala"].InnerText);
                MemorieStiva    = Convert.ToInt32(nodes[0]["memorieStiva"].InnerText);
                NrTeste         = Convert.ToInt32(nodes[0]["nrTeste"].InnerText);
                DimensiuneSursa = Convert.ToInt32(nodes[0]["dimensiuneSursa"].InnerText);
                AlteInformatii  = nodes[0]["alteInformatii"].InnerText;
            }
            catch 
            {
 
            }
        }

        private List<string> citesteTest(string extension)
        {
            List<string> listaTeste = new List<string>();
            
            // scanez directorul cu probleme si le afisez
            if (!Directory.Exists(Path + NumeFolderTeste))
            {
                MesajeAvertizare.mesajDirectorInexistent(NumeFolderTeste);
            }
            else
            {
                string[] testeIntrare = Directory.GetFiles(Path + NumeFolderTeste, extension);
                foreach (string teste in testeIntrare)
                {
                    string nume = teste.Substring(teste.LastIndexOf('\\') + 1);
                    listaTeste.Add(nume);
                }
                // selectez prima problema
                if (listaTeste.Count == 0)
                {
                    listaTeste.Add("Fara teste");
                }
            }
            return listaTeste;
        }

        public List<string> citesteTesteIntrare() 
        {
            //TesteIntrare = citesteTest("*.in");
            return citesteTest("*.in");
        }

        public List<string> citesteTesteIesire()
        {
            //TesteIesire = citesteTest("*.ok");
            return citesteTest("*.ok");
        }

        public List<string> citesteSurse() 
        {
            List<string> listaSurse = new List<string>();

            // scanez directorul cu surse .cpp si le afisez
            if (!Directory.Exists(Path + NumeFolderSurse))
            {
                MesajeAvertizare.mesajDirectorInexistent(NumeFolderSurse);
            }
            else
            {
                string[] surse = Directory.GetFiles(Path + NumeFolderSurse);
                
                foreach (string sursa in surse)
                {
                    string nume = sursa.Substring(sursa.LastIndexOf('\\') + 1);
                    string ext = sursa.Substring(sursa.LastIndexOf('.') + 1);
                    
                    if (ext == "cpp" || ext == "c")
                    {
                        listaSurse.Add(nume);
                    }
                }
            }

            Surse = listaSurse;
            return listaSurse;
        }

        public List<string> citesteExecutabile()
        {
            List<string> listaExe = new List<string>();

            // scanez directorul cu surse .cpp si le afisez
            if (!Directory.Exists(Path + NumeFolderExe))
            {
                MesajeAvertizare.mesajDirectorInexistent(NumeFolderExe);
            }
            else
            {
                string[] executabile = Directory.GetFiles(Path + NumeFolderExe);

                foreach (string exe in executabile)
                {
                    string nume = exe.Substring(exe.LastIndexOf('\\') + 1);
                    string ext = exe.Substring(exe.LastIndexOf('.') + 1);

                    if (ext == "exe")
                    {
                        listaExe.Add(nume);
                    }
                }
            }

            Executabile = listaExe;
            return listaExe;
        }

        public string directorTeste()
        {
            return Path + NumeFolderTeste;
        }

        public void compileazaSursa(string sursa) 
        {
            if (SetariCompilator.Default.CaleCPP == "" || SetariCompilator.Default.CaleC == "")
            {
                MesajeAvertizare.mesajEroareString("Nu ai modificat setarile pentru compilatoare.");
            }
            else
            {
                try
                {
                    string PathCompiler = string.Empty;
                    string name = string.Empty;
                    string strCmdText = string.Empty;
                    string extensie = sursa.Substring(sursa.LastIndexOf('.') + 1);

                    // calea sursei si numele
                    name = "\"" + Path + NumeFolderExe + "\\" + sursa.Substring(0, sursa.LastIndexOf('.')) + "\"";
                    sursa = "\"" + Path + NumeFolderSurse + "\\" + sursa + "\"";

                    // in functie de sursa, folosesc compilatoare diferite
                    if (extensie == "cpp")
                    {
                        //c++
                        PathCompiler = SetariCompilator.Default.CaleCPP;
                        strCmdText = PathCompiler + " -Wall " + sursa + " -o " + name;
                    }
                    else
                        if (extensie == "c")
                        {
                            //c
                            PathCompiler = SetariCompilator.Default.CaleC;
                            strCmdText = PathCompiler + " -Wall " + sursa + " -o " + name;
                        }
                        else
                        {
                            PathCompiler = SetariCompilator.Default.CalePas;
                            strCmdText = PathCompiler + " " + sursa + " -e " + name;
                        }

                    System.Diagnostics.ProcessStartInfo pStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + strCmdText);

                    // urmatoarele comenzi sunt necesare ca sa redirectionez datele de iesire
                    // asta inseamna ca redirectionez catre Process.StandardOutput StreamReader.
                    pStartInfo.RedirectStandardOutput = true;
                    pStartInfo.UseShellExecute = false;
                    // nu vreau sa creeze fereastra neagra
                    pStartInfo.CreateNoWindow = false;

                    MesajeAvertizare.mesajEroareString("/c " + strCmdText);

                    // creez un proces, ii bag informatiile si il rulez
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo = pStartInfo;
                    proc.Start();
                    proc.WaitForExit();
                    //proc.StandardOutput.ReadToEnd();
                }
                catch
                {
                    MesajeAvertizare.mesajEroareString("Nu am putut compila sursa \"" + sursa + "\"");
                }
            }
        }

        public void compileazaSurse() 
        {
            foreach (string sursa in Surse)
            {
                compileazaSursa(sursa);
            }
        }

        public void stergeSursa(string sursa) 
        {
            // sterg sursa de pe hdd
            sursa = Path + NumeFolderSurse + "\\" + sursa;
            File.Delete(sursa);
        }

        public void stergeExecutabil(string exe)
        { 
            // sterg executabilul de pe HDD
            exe = Path + NumeFolderExe + "\\" + exe;
            File.Delete(exe);
        }

        public void adaugaSursa(string pathSursa) 
        {
            string name = pathSursa.Substring(pathSursa.LastIndexOf("\\") + 1).ToLower();
            File.Copy(pathSursa, Path + NumeFolderSurse + "\\" + name, true);
        }

        public void stergeProblema() 
        {
            Directory.Delete(Path, true);
        }

        public Dictionary<int, Dictionary<string, long>> evalueazaExe(string exe, string pct)
        {
            string[] Pct = pct.Split('\n');
            for (int i = 0; i < Pct.Length - 1; i++)
            {
                //    MesajeAvertizare.mesajAtentie("|"+Pct[i]+"|");
                if (Pct[i] != "")
                {
                    Puncte[i] = Convert.ToInt32(Pct[i]);
                }
            }

            string path = exe; // Path + NumeFolderExe + "\\" + exe;

            // lista cu toate testele ale problemei
            Dictionary<int, Dictionary<string, long>> rezultatTeste = new Dictionary<int, Dictionary<string, long>>();

            for (int i = 0; i < TesteIntrare.Count && TesteIesire.Count == TesteIntrare.Count; i++)
            {
                // salvez rezultatul la test
                rezultatTeste.Add(i, evalueazaExeTest(path, i));
            }
            
            return rezultatTeste;   // de forma rezultatTeste[nrTest]["Timp/Memorie/Puncte/te"]
        }

        public Dictionary<string, long> evalueazaExeTest(string exe, int test)
        {
            Dictionary<string, long> rezultat = new Dictionary<string, long>();
            rezultat.Add("Timp", 0);
            rezultat.Add("Memorie", 0);
            rezultat.Add("Puncte", 0);
            rezultat.Add("Mesaj", 2); 
            /* Mesaj codificat in numar 
             * -1 = timp depasit
             *  0 = Corect
             *  1 = fisier inexistent
             *  2 = eroare necunoscuta
             *  3 = ram depasit
             *  4 = incorect
             */
            long mesaj = 2;

            int puncte = 0; long memorie = 0; int timp = 0;

            try
            {
                string lastDirectory = Directory.GetCurrentDirectory();

                // copiez fisierul cu testul de intrare
                string numeTest = TesteIntrare[test].Substring(TesteIntrare[test].LastIndexOf('-') + 1);
                File.Copy(Path + NumeFolderTeste + "\\" + TesteIntrare[test], Path + NumeFolderExe + "\\" + numeTest, true);

                // dir exe
                Directory.SetCurrentDirectory(lastDirectory + "\\" + Path + NumeFolderExe);

                // lansez executabilul
                Process executabil = new Process();
                executabil.StartInfo.UseShellExecute = false;
                executabil.StartInfo.CreateNoWindow = true;
                executabil.StartInfo.FileName = exe;
                executabil.Start();
                DateTime start = executabil.StartTime;

                memorie = executabil.PrivateMemorySize64;

                // limita timp
                executabil.WaitForExit(LimitaTimp + 1);

                // il opresc fortat
                if (!executabil.HasExited)
                {
                    executabil.Kill();
                }

                DateTime stop = executabil.ExitTime;
                timp = (stop - start).Milliseconds;

                if (timp < 0)
                {
                    rezultat["Mesaj"] = mesaj = -1;
                }

                // revin la dir implicit
                Directory.SetCurrentDirectory(lastDirectory);

                /*MesajeAvertizare.mesajAtentie("PrivateMemorySize64:" + memorie.ToString() + "bytes \n" +
                                                "Timp: " + (stop - start).ToString());
                */

                // evaluez raspunsul

                if (raspunsCorect(test, ref mesaj) && seIncadreasaInLimite(memorie, start, stop, ref mesaj))
                {
                    if (Puncte[nrPrb] != 0)
                    {
                        puncte = Puncte[nrPrb];
                    }
                    else
                    {
                        puncte = 10;
                    }
                    nrPrb++;
                    rezultat["Mesaj"] = 0;
                }
                else 
                {
                    rezultat["Mesaj"] = mesaj;
                }

                // sterg fisierul de intrare si de iesire
                File.Delete(Path + NumeFolderExe + "\\" + numeTest);
                File.Delete(Path + NumeFolderExe + "\\" + numeTest.Substring(0, numeTest.LastIndexOf('.')) + ".out");
            }
            catch 
            {
 
            }

            rezultat["Timp"] = timp;
            rezultat["Memorie"] = memorie;
            rezultat["Puncte"] = puncte;
            
            return rezultat;
        }

        private bool seIncadreasaInLimite(long memorie, DateTime start, DateTime stop, ref long mesaj)
        {
            double ram = ConvertBytesToKilobytes(memorie);
            int timpScurs = (stop - start).Milliseconds;

            if (ram > MemorieTotala)
            {
                mesaj = 3;
                return false;
            }

            if (timpScurs > LimitaTimp)
            {
                mesaj = -1;
                return false;
            }

            //MesajeAvertizare.mesajAtentie("Ram: " + ram.ToString() + "KB\nTimp: "+ timpScurs.ToString() + "ms");

            //if(new FileInfo(sursa) dimensiune .cpp)

            
            return true;
        }

        public bool raspunsCorect(int test, ref long mesaj) 
        {
            try
            {
                string numeTest = TesteIntrare[test].Substring(TesteIntrare[test].LastIndexOf('-') + 1);

                FileInfo testOK = new FileInfo(Path + NumeFolderTeste + "\\" + TesteIesire[test]);
                FileInfo testOut = new FileInfo(Path + NumeFolderExe + "\\" + numeTest.Substring(0, numeTest.LastIndexOf('.')) + ".out");

                StreamReader testok = testOK.OpenText();
                StreamReader testout = testOut.OpenText();

                string ok = testok.ReadToEnd().Trim(), Out = testout.ReadToEnd().Trim();
                testok.Close();
                testout.Close();

                //MesajeAvertizare.mesajAtentie(ok + "=" + Out);

                if (ok == Out)
                {
                    mesaj = 0;
                    return true;
                }
            }
            catch
            {
                mesaj = 1;
                //MesajeAvertizare.mesajEroareString("Fisier de iesire inexistent.");
            }
            mesaj = 4;
            return false;
        }

        private double ConvertBytesToKilobytes(long bytes)
        {
            return bytes / 1024f;
        }
    }
}
