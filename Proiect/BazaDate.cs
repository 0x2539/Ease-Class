using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Proiect
{
    class BazaDate
    {
        //int s3 = 0;
        string s5 = "lalla";

        public int conectat = 0;

        //SqlConnection Conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Alex\\Documents\\Visual Studio 2010\\Projects\\Proiect2 - Copy\\Proiect\\Proiect.mdf;Integrated Security=True;User Instance=True");
        //SqlConnection Conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFileName=|DataDirectory|Concurs.mdf;Integrated Security=True;User Instance=True");

        string d = Deschidere.Default.SqlCon;
        string d2 = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + Deschidere.Default.SqlCon + "\\Database1.mdf;Integrated Security=True;User Instance=True";
        //SqlConnection Conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Projects\Proiect2 - Copy\Proiect\Database1.mdf;Integrated Security=True;User Instance=True");
        SqlConnection Conn = new SqlConnection(Deschidere.Default.SqlCon);
        //SqlConnection Conn = new SqlConnection(@"Data Source=.\\SQLEXPRESS;AttachDbFilename=" + System.IO.Path.GetFullPath("") + "\\Database1.mdf;Integrated Security=True;User Instance=True");
        
        //SqlConnection Conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\Projects\\Proiect2 - Copy\\Proiect\\Database1.mdf;Integrated Security=True;User Instance=True");
        //SqlConnection Conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Alex\Desktop\Galaciuc 2.7\Proiect\Database3.mdf;Integrated Security=True;User Instance=True");


        SqlDataReader rdr = null;


        /// <summary>
        /// insereaza in tabel o materie noua
        /// </summary>
        /// <param name="Materie"></param>
        public void InsertNewColumn(string newColumnName, string newColumnType, string table)
        {
            try
            {
                Conn.Open();

                string addColumn = "ALTER TABLE " + table + " ADD " + newColumnName + " " + newColumnType;

                SqlCommand cmd = new SqlCommand(addColumn, Conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        //trebuie sa o modific pentru ca inca nu merge
        /// <summary>
        /// schimba numele unei materii
        /// </summary>
        /// <param name="Materie"></param>
        /// <param name="MaterieNoua"></param>
        public void ChangeColumnNameMaterie(string Materie, string MaterieNoua)
        {
            if (Materie != MaterieNoua)
            {
                try
                {
                    Conn.Open();

                    //string addColumn = "ALTER TABLE Table1 CHANGE @materieVeche @materieNoua nvarchar(MAX)";
                    string addColumn = "ALTER TABLE Table1 CHANGE " + Materie + " " + MaterieNoua + " nvarchar(20)";

                    SqlCommand cmd = new SqlCommand(addColumn, Conn);

                    cmd.Parameters.AddWithValue("@materieVeche", Materie);
                    cmd.Parameters.AddWithValue("@materieNoua", MaterieNoua);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// sterge o materie
        /// </summary>
        /// <param name="Materie"></param>
        public void DeleteColumn(string columnName, string table)
        {
            try
            {
                Conn.Open();

                string delColumn = "ALTER TABLE " + table + " DROP COLUMN " + columnName;

                SqlCommand cmd = new SqlCommand(delColumn, Conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// selecteaza notele de la materia respectiva
        /// </summary>
        /// <param name="util"></param>
        /// <returns></returns>
        public string selectNoteMaterie(string utilizator, string Materie)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT " + Materie + " FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", utilizator);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr[Materie].ToString();
                    string y = "";
                    /*for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o] == ':')
                            {
                                y += s1[o];
                            }
                    }*/
                    y = s1.TrimEnd(' ');

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


        public string selectPassword(string utilizator)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT parola FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", utilizator);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["parola"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o - 1] == ',')
                            {
                                y += s1[o];
                            }
                            else
                                if (s1[o] == ' ' && o == s1.Length - 1)
                                {
                                    //y += s1[o];
                                }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1">id-ul utilizatorului</param>
        /// <param name="s2">nota utilizatorului</param>
        public void insereazaNotaMaterie(string utilizator, string Materie, string nota)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string numeleMateriei = Materie, numeleUtilizatorului = utilizator;
                string g = selectNoteMaterie(numeleUtilizatorului, numeleMateriei);

                Conn.Open();

                string insert = "UPDATE Table1 SET " + Materie + "=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", g + nota);
                cmd.Parameters.AddWithValue("@util", utilizator);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void inserezaDataMaterie(string utilizator, string Materie)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string g = selectDataMaterie(utilizator, Materie);
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET data" + Materie + "=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", g + dt.ToShortDateString() + ", " + dt.ToShortTimeString() + ';');
                cmd.Parameters.AddWithValue("@util", utilizator);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public string selectDataMaterie(string utilizator, string Materie)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();

                string select = "SELECT data" + Materie + " FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", utilizator);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["data" + Materie].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o - 1] == ',')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }





        public void insereaza(string s1, string s2, string s3, string s4, string s5, string s6, string s7)
        {
            try
            {

                Conn.Open();

                string insert = "INSERT INTO Table1 (nume, prenume, utilizator, parola, oras, email, profesor, raspuns) VALUES (@NUME1, @PRENUME1, @UTILIZATOR1, @PAROLA1, @ORAS1, @EMAIL1, @PROFESOR1, @RASPUNS1)";

                SqlCommand cmd = new SqlCommand(insert, Conn);

                cmd.Parameters.AddWithValue("@NUME1", s1);
                cmd.Parameters.AddWithValue("@PRENUME1", s2);
                cmd.Parameters.AddWithValue("@UTILIZATOR1", s3);
                cmd.Parameters.AddWithValue("@PAROLA1", s4);
                cmd.Parameters.AddWithValue("@ORAS1", s5);
                cmd.Parameters.AddWithValue("@EMAIL1", s6);
                cmd.Parameters.AddWithValue("@PROFESOR1", "Nu");
                cmd.Parameters.AddWithValue("@RASPUNS1", s7);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public void insereazaProf(string s1, string s2, string s3, string s4, string s5, string s6, string s7)
        {
            try
            {
                Conn.Open();

                string insert = "INSERT INTO Table1 (nume, prenume, utilizator, parola, oras, email, profesor, raspuns) VALUES (@NUME1, @PRENUME1, @UTILIZATOR1, @PAROLA1, @ORAS1, @EMAIL1, @PROFESOR1, @RASPUNS1)";
                SqlCommand cmd = new SqlCommand(insert, Conn);

                cmd.Parameters.AddWithValue("@NUME1", s1);
                cmd.Parameters.AddWithValue("@PRENUME1", s2);
                cmd.Parameters.AddWithValue("@UTILIZATOR1", s3);
                cmd.Parameters.AddWithValue("@PAROLA1", s4);
                cmd.Parameters.AddWithValue("@ORAS1", s5);
                cmd.Parameters.AddWithValue("@EMAIL1", s6);
                cmd.Parameters.AddWithValue("@PROFESOR1", "Da");
                cmd.Parameters.AddWithValue("@RASPUNS1", s7);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


        /*
        public void insereazaConectatNume(string conect)
        {
            try
            {
                Conn.Open();
                string insert = "UPDATE Table1 SET nume=@conect WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@conect", conect.ToString());
                cmd.Parameters.AddWithValue("@util", "bmbnmbnm");
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }
        */

        public void inserezaNota(string s1, string s2, string s3)
        {
            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string s = note(s3);
                Conn.Open();
                string insert = "UPDATE Table1 SET Note=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", s + s1 + " " + s2 + "\n");
                cmd.Parameters.AddWithValue("@util", s3);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public string note(string s1)
        {
            try
            {
                Conn.Open();
                string select = "SELECT utilizator,Note FROM Table1 WHERE utilizator = @utilizator1";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@utilizator1", s1);

                //cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    return rdr["Note"].ToString();
                }
                return "0";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


        int x = 0;

        public bool compare(string s1, string s2)
        {
            return String.Compare(s1, s2, true, System.Globalization.CultureInfo.InvariantCulture) == 0 ? true : false;
        }

        public int select(string utilizator1, string parola1)
        {
            try
            {
                Conn.Open();

                DataSet dsa = new DataSet();
                DataSet dsu = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("select * from Table1 where utilizator ='" + utilizator1 + "' and parola='" + parola1 + "' and profesor='" + "Da" + "'", Conn);
                SqlDataAdapter nu = new SqlDataAdapter("select * from Table1 where utilizator ='" + utilizator1 + "' and parola='" + parola1 + "' and profesor='" + "Nu" + "'", Conn);


                da.Fill(dsa);
                nu.Fill(dsu);

                int count1 = dsa.Tables[0].Rows.Count;
                int count2 = dsu.Tables[0].Rows.Count;


                if (count1 == 0 && count2 == 0)
                {
                    x = 0;
                }
                else
                    if (count1 == 1 && count2 == 0)
                    {
                        x = 1;
                    }
                    else
                        if (count1 == 0 && count2 == 1)
                        {
                            x = 2;
                        }


                return x;

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// verifica daca id-ul introdus exista deja in baza de date
        /// </summary>
        /// <param name="utilizator1"></param>
        /// <returns></returns>
        public int selectU(string utilizator1)
        {
            try
            {
                Conn.Open();
                string select = "SELECT utilizator FROM Table1 WHERE utilizator = @utilizator1";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@utilizator1", utilizator1);

                //cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    return 1;
                }
                return 0;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// vede daca mai exista numele si prenumele in baza de date, si returneaza 1 daca exista
        /// </summary>
        /// <param name="utilizator1"></param>
        /// <returns></returns>
        public int selectNumePrenume(string prenume, string nume)
        {
            try
            {
                Conn.Open();
                string select = "SELECT prenume, nume FROM Table1 WHERE prenume=@prenume AND nume=@nume";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@prenume", prenume);
                cmd.Parameters.AddWithValue("@nume", nume);

                //cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    return 1;
                }
                return 0;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string selectEmail(string util)
        {
            try
            {
                Conn.Open();
                string select = "SELECT email FROM Table1 WHERE utilizator = @util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                //cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string s = rdr["email"].ToString();
                    string y = "";
                    for (int i = s.Length - 1; i >= 0; i--)
                    {
                        if (s[i] != ' ')
                        {
                            for (int j = 0; j <= i; j++)
                            {
                                y += s[j];
                            }
                            break;
                        }
                        //break;
                    }
                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// returneaza true in caz ca raspunsul este corect
        /// </summary>
        /// <param name="util"></param>
        /// <returns></returns>
        public bool selectRaspuns(string utilizator, string answer)
        {
            try
            {
                Conn.Open();

                //cu md5hasher voi cripta parola
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //in hashedBytes retin parola criptata
                Byte[] cryptedAnswer;

                //cu encoder voi transforma parola din string intr-un vector de bytes
                UTF8Encoding encoder = new UTF8Encoding();

                //criptez si salvez parola in hashedBytes
                cryptedAnswer = md5.ComputeHash(encoder.GetBytes(answer));


                string select = "SELECT raspuns FROM Table1 WHERE utilizator=@utilizator AND raspuns=@raspuns";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@utilizator", utilizator);
                cmd.Parameters.AddWithValue("@raspuns", cryptedAnswer);

                //cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    return true;
                }
                return false;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string[] elevi = new String[100];
        public int nrElevi = 0;

        public int nrConturi = 0;
        public string[] selectIdNewPass2()
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string[] conturi = new string[1000];
                int nr = 0;
                string select = "SELECT utilizator FROM Table1";

                SqlCommand cmd = new SqlCommand(select, Conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    conturi[nr] = rdr["utilizator"].ToString().Trim(' ');
                    nr++;
                }
                nrConturi = nr;
                return conturi;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


        public void createNewTable(string name)
        {
            try
            {
                Conn.Open();
                StringBuilder query = new StringBuilder();
                query.Append("CREATE TABLE ");
                query.Append(name);
                query.Append(" (NumeTest nvarchar(MAX), NumarProbleme nvarchar(MAX), TimpTest int, DetaliiTest nvarchar(MAX))");
                /*
                            for (int i = 0; i < columnNames.Length; i++)
                            {
                                query.Append(columnNames[i]);
                                query.Append(" ");
                                query.Append(columnTypes[i]);
                                query.Append(", ");
                            }
            
                            if (columnNames.Length > 1) { query.Length -= 2; }  //Remove trailing ", "
                            query.Append(")");*/
                SqlCommand cmd = new SqlCommand(query.ToString(), Conn);
                rdr = cmd.ExecuteReader();
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


        /// <summary>
        /// returneaza un string parola encriptata cu md5
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string CryptPassword(string password)
        {
            //cu md5hasher voi cripta parola
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //in hashedBytes retin parola criptata
            Byte[] cryptedPassword;

            //cu encoder voi transforma parola din string intr-un vector de bytes
            UTF8Encoding encoder = new UTF8Encoding();

            //criptez si salvez parola in hashedBytes
            cryptedPassword = md5.ComputeHash(encoder.GetBytes(password));

            return cryptedPassword.ToString();
        }

        /// <summary>
        /// returneaza 0 in caz ca UserNameul si parola sunt gresite
        /// returneaza 1 in caz ca se conecteaza ca elev
        /// returneaza 2 in caz ca se conecteaza ca profesor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int SelectEncryptedPassword(string userName, string password)
        {
            try
            {
                Conn.Open();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                Byte[] cryptedPassword;

                UTF8Encoding encoder = new UTF8Encoding();

                cryptedPassword = md5.ComputeHash(encoder.GetBytes(password));

                SqlCommand cmd = new SqlCommand("SELECT * FROM Table1 WHERE utilizator=@UserName AND parola=@Password", Conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", cryptedPassword);


                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["profesor"].ToString().Trim(' ') == "Da")
                    {
                        return 1;
                    }
                    else
                        if (rdr["profesor"].ToString().Trim(' ') == "Nu")
                        {
                            return 2;
                        }
                }
                return 0;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// returneaza 1 in caz ca UserNameul si parola sunt corecte
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int SelectEncryptedPasswordForChangePw(string userName, string password)
        {
            try
            {
                Conn.Open();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                Byte[] cryptedPassword;

                UTF8Encoding encoder = new UTF8Encoding();

                cryptedPassword = md5.ComputeHash(encoder.GetBytes(password));

                SqlCommand cmd = new SqlCommand("SELECT * FROM Table1 WHERE utilizator=@UserName AND parola=@Password", Conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", cryptedPassword);


                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    return 1;
                }
                return 0;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// insereaza o parola noua pentru userul cu UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void insertTheNewEncryptedPassword(string userName, string password)
        {
            try
            {
                Conn.Open();
                //cu md5hasher voi cripta parola
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //in hashedBytes retin parola criptata
                Byte[] cryptedPassword;

                //cu encoder voi transforma parola din string intr-un vector de bytes
                UTF8Encoding encoder = new UTF8Encoding();

                //criptez si salvez parola in hashedBytes
                cryptedPassword = md5.ComputeHash(encoder.GetBytes(password));

                //inserez userName-ul si parola in baza de date
                SqlCommand cmd = new SqlCommand("UPDATE Table1 SET parola=@Password WHERE utilizator=@UserName", Conn);
                cmd.CommandType = CommandType.Text;

                //adaug parametrii din string-ul de mai sus
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", cryptedPassword);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// creeaza un rand nou cu toate datele
        /// </summary>
        /// <param name="id"></param>
        /// <param name="oras"></param>
        /// <param name="nume"></param>
        /// <param name="prenume"></param>
        /// <param name="intrebare"></param>
        /// <param name="raspuns"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="ProfElev"></param>
        public void insertCryptedPassword(string oras, string nume, string prenume, string intrebare,
                                                string raspuns, string userName, string password, string ProfElev)
        {
            try
            {
                Conn.Open();
                //cu md5hasher voi cripta parola
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //in hashedBytes retin parola criptata
                Byte[] cryptedPassword;
                Byte[] cryptedAnswer;

                //cu encoder voi transforma parola din string intr-un vector de bytes
                UTF8Encoding encoder = new UTF8Encoding();
                UTF8Encoding encoder2 = new UTF8Encoding();

                //criptez si salvez parola in hashedBytes
                cryptedPassword = md5.ComputeHash(encoder.GetBytes(password));
                cryptedAnswer = md5.ComputeHash(encoder2.GetBytes(raspuns));

                //inserez userName-ul si parola in baza de date
                string insert = "INSERT INTO Table1 (nume, prenume, utilizator, parola, oras, email, profesor, raspuns) VALUES (@NUME1, @PRENUME1, @UTILIZATOR1, @PAROLA1, @ORAS1, @EMAIL1, @PROFESOR1, @RASPUNS1)";

                SqlCommand cmd = new SqlCommand(insert, Conn);

                cmd.Parameters.AddWithValue("@NUME1", nume);
                cmd.Parameters.AddWithValue("@PRENUME1", prenume);
                cmd.Parameters.AddWithValue("@ORAS1", oras);
                cmd.Parameters.AddWithValue("@EMAIL1", intrebare);
                cmd.Parameters.AddWithValue("@PROFESOR1", ProfElev);
                cmd.Parameters.AddWithValue("@RASPUNS1", cryptedAnswer);
                cmd.Parameters.AddWithValue("@UTILIZATOR1", userName);
                cmd.Parameters.AddWithValue("@Parola1", cryptedPassword);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// returneaza un string cu toti elevii din baza de date, astfel : nume1 prenume1;nume2 prenume2;
        /// </summary>
        /// <returns></returns>
        public string incarcaElevii()
        {
            try
            {
                Conn.Open();

                string elevi = "";
                int nrElevi = 0;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Table1 WHERE profesor=@profesor", Conn);

                cmd.Parameters.AddWithValue("@profesor", "Nu");

                cmd.CommandType = CommandType.Text;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    elevi += rdr["nume"].ToString().Trim(' ') + ' ' + rdr["prenume"].ToString().Trim(' ') + ';';
                }

                return elevi;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        /// <summary>
        /// incarca notele si datele materiei, returnand un vectire de stringuri astfel
        /// returneaza[0]: test:3/4;test2:2/4; 
        /// returneaza[1]: 23/3/23;21/2/12;
        /// </summary>
        /// <param name="nume"></param>
        /// <param name="prenume"></param>
        /// <param name="materie">scris cu litera mare</param>
        /// <returns></returns>
        public string[] incarcaNoteleSiDateleMateriei(string nume, string prenume, string materie, string userName)
        {
            try
            {
                Conn.Open();

                string noteDate = "";
                int nr = 0;

                string note = "", date = "";

                string select = "";

                if (userName == "")
                {
                    select = "SELECT * FROM Table1 WHERE nume=@nume AND prenume=@prenume";
                }
                else
                {
                    nr = 1;
                    select = "SELECT * FROM Table1 WHERE utilizator=@utilizator";
                }
                SqlCommand cmd = new SqlCommand(select, Conn);
                if (nr == 0)
                {
                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@prenume", prenume);
                }
                else
                    if (nr == 1)
                    {
                        cmd.Parameters.AddWithValue("@utilizator", userName);
                    }

                cmd.CommandType = CommandType.Text;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (materie == "m")
                    {
                        note += rdr["Matematica"].ToString();
                        date += rdr["data" + materie].ToString().Trim(' ');
                    }
                    else
                        if (materie == "f")
                        {
                            note += rdr["Fizica"].ToString().Trim(' ');
                            date += rdr["data" + materie].ToString().Trim(' ');
                        }
                        else
                            if (materie == "c")
                            {
                                note += rdr["Chimie"].ToString().Trim(' ');
                                date += rdr["data" + materie].ToString().Trim(' ');
                            }
                            else
                                if (materie == "i")
                                {
                                    note += rdr["Informatica"].ToString().Trim(' ');
                                    date += rdr["data" + materie].ToString().Trim(' ');
                                }
                                else
                                {
                                    note += rdr[materie].ToString().Trim(' ');
                                    date += rdr["data" + materie].ToString().Trim(' ');
                                }
                }
                string[] returneaza = new string[2];

                returneaza[0] = note;
                returneaza[1] = date;

                return returneaza;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


        public void adaugaNoteleSiDateleInBazaDeDate(string Materie, string nota, string data, string nume, string prenume)
        {
            try
            {
                Conn.Open();
                string s = Materie;
                if (Materie == "m")
                {
                    s = "Matematica";
                }
                else
                    if (Materie == "f")
                    {
                        s = "Fizica";
                    }
                    else
                        if (Materie == "c")
                        {
                            s = "Chimie";
                        }
                        else
                            if (Materie == "i")
                            {
                                s = "Informatica";
                            }

                string insert = "UPDATE Table1 SET " + s + "=@nota, data" + Materie + "=@data WHERE nume=@nume AND prenume=@prenume";

                SqlCommand cmd = new SqlCommand(insert, Conn);

                cmd.Parameters.AddWithValue("@nota", nota);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@nume", nume);
                cmd.Parameters.AddWithValue("@prenume", prenume);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


        public void Aleator(string utilizator, string raspuns)
        {
            try
            {
                Conn.Open();
                //cu md5hasher voi cripta parola
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //in hashedBytes retin parola criptata
                Byte[] cryptedAnswer;

                //cu encoder voi transforma parola din string intr-un vector de bytes
                UTF8Encoding encoder = new UTF8Encoding();

                //criptez si salvez parola in hashedBytes
                cryptedAnswer = md5.ComputeHash(encoder.GetBytes(raspuns));

                //inserez userName-ul si parola in baza de date

                string insert = "UPDATE Table1 SET raspuns=@raspuns WHERE utilizator=@userName";

                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@userName", utilizator);
                cmd.Parameters.AddWithValue("@raspuns", cryptedAnswer);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }




        //Cod care nu este important.....*********************



        public string selectNoteMatematica(string util)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT Matematica FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["Matematica"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o] == ':')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string selectNoteFizica(string util)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT Fizica FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["Fizica"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o] == ':')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string selectNoteChimie(string util)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT Chimie FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["Chimie"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o] == ':')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string selectNoteInformatica(string util)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT Informatica FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["Informatica"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o] == ':')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1">id-ul utilizatorului</param>
        /// <param name="s2">nota utilizatorului</param>
        public void inserezaNotaChimie(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string g = selectNoteChimie(s1);

                Conn.Open();

                string insert = "UPDATE Table1 SET Chimie=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", g + s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void inserezaNotaMatematica(string s1, string s2)
        {
            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string g = selectNoteMatematica(s1);

                Conn.Open();

                string insert = "UPDATE Table1 SET Matematica=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", g + s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void inserezaNotaInformatica(string s1, string s2)
        {
            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string g = selectNoteInformatica(s1);

                Conn.Open();

                string insert = "UPDATE Table1 SET Informatica=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", g + s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void inserezaNotaFizica(string s1, string s2)
        {
            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {

                string g = selectNoteFizica(s1);

                Conn.Open();

                string insert = "UPDATE Table1 SET Fizica=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", g + s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }



        public void NotaCatalogC(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                Conn.Open();

                string insert = "UPDATE Table1 SET Chimie=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void NotaCatalogF(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                Conn.Open();

                string insert = "UPDATE Table1 SET Fizica=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void NotaCatalogM(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                Conn.Open();

                string insert = "UPDATE Table1 SET Matematica=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void NotaCatalogI(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                Conn.Open();

                string insert = "UPDATE Table1 SET Informatica=@note1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@note1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }



        public void DataCatalogC(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET datac=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void DataCatalogF(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET dataf=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void DataCatalogM(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET datam=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void DataCatalogI(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET datai=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }





        public string selectDataMatematica(string util)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT datam FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["datam"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o - 1] == ',')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string selectDataFizica(string util)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT dataf FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["dataf"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o - 1] == ',')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string selectDataChimie(string util)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT datac FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["datac"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o - 1] == ',')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string selectDataInformatica(string util)
        {
            int i = 0, uu = 0;
            try
            {
                Conn.Open();
                string select = "SELECT datai FROM Table1 WHERE utilizator=@util";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //elimin spatiile din baza de date
                    string s1 = rdr["datai"].ToString();
                    string y = "";
                    for (int o = 0; o < s1.Length; o++)
                    {
                        if (s1[o] != ' ')
                        {
                            y += s1[o];
                        }
                        else
                            if (s1[o] == ' ' && s1[o - 1] == ',')
                            {
                                y += s1[o];
                            }
                    }

                    return y;
                }
                return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }




        public void inserezaDataChimie(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string g = selectDataChimie(s1);
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET datac=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", g + dt.ToShortDateString() + ", " + dt.ToShortTimeString() + ';');
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void inserezaDataFizica(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string g = selectDataFizica(s1);
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET dataf=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", g + dt.ToShortDateString() + ", " + dt.ToShortTimeString() + ';');
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void inserezaDataMatematica(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string g = selectDataMatematica(s1);
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET datam=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", g + dt.ToShortDateString() + ", " + dt.ToShortTimeString() + ';');
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }

        public void inserezaDataInformatica(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                string g = selectDataInformatica(s1);
                DateTime dt = DateTime.Now;
                Conn.Open();

                string insert = "UPDATE Table1 SET datai=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", g + dt.ToShortDateString() + ", " + dt.ToShortTimeString() + ';');
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1">id-ul utilizatorului</param>
        /// <param name="s2">stringul parolei schimbate</param>
        public void schimbaPass(string s1, string s2)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                Conn.Open();

                string insert = "UPDATE Table1 SET parola=@data1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", s2);
                cmd.Parameters.AddWithValue("@util", s1);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }



        public string[] selectProfil(string util)
        {
            int i = 0, uu = 0;
            try
            {
                string[] campuri = new string[10];

                Conn.Open();
                string select = "SELECT prenume, nume, oras, email, raspuns FROM Table1 WHERE utilizator=@util1";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@util1", util);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    campuri[0] = rdr["prenume"].ToString();
                    campuri[1] = rdr["nume"].ToString();
                    campuri[2] = rdr["oras"].ToString();
                    campuri[3] = rdr["email"].ToString();
                    campuri[4] = rdr["raspuns"].ToString();

                    string s = rdr["prenume"].ToString() + " " + rdr["nume"].ToString() + " " +
                        rdr["oras"].ToString() + " " + rdr["email"].ToString() + " " + rdr["raspuns"].ToString();
                    string y = "";
                    for (int q = 0; q < s.Length; q++)
                    {
                        if (s[q] != ' ')
                        {
                            y += s[q];
                        }
                        else
                            if (s[q] == ' ' && s[q - 1] != ' ')
                            {
                                y += s[q];
                            }
                    }

                    nrElevi++;
                    i++;
                    uu = 1;

                    return campuri;//y + ' ';
                }
                return null;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public void insereazaProfil(string s1, string s2, string s3, string s4, string s5, string s6)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                Conn.Open();
                //cu md5hasher voi cripta parola
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //in hashedBytes retin parola criptata
                Byte[] cryptedAnswer;

                //cu encoder voi transforma parola din string intr-un vector de bytes
                UTF8Encoding encoder = new UTF8Encoding();

                //criptez si salvez parola in hashedBytes
                cryptedAnswer = md5.ComputeHash(encoder.GetBytes(s6));


                string insert = "UPDATE Table1 SET prenume=@prenume1, nume=@nume1, oras=@oras1, email=@email1, raspuns=@raspuns1 WHERE utilizator=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);

                cmd.Parameters.AddWithValue("@util", s1);
                cmd.Parameters.AddWithValue("@prenume1", s2);
                cmd.Parameters.AddWithValue("@nume1", s3);
                cmd.Parameters.AddWithValue("@oras1", s4);
                cmd.Parameters.AddWithValue("@email1", s5);
                cmd.Parameters.AddWithValue("@raspuns1", cryptedAnswer);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }



        public void insereazaIdProf(string cod)
        {
            try
            {
                Conn.Open();
                //cu md5hasher voi cripta parola
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //in hashedBytes retin parola criptata
                Byte[] cryptedCode;

                //cu encoder voi transforma parola din string intr-un vector de bytes
                UTF8Encoding encoder = new UTF8Encoding();

                //criptez si salvez parola in hashedBytes
                cryptedCode = md5.ComputeHash(encoder.GetBytes(cod));


                string insert = "INSERT INTO Table2 (idProf) VALUES (@cod)";

                SqlCommand cmd = new SqlCommand(insert, Conn);

                cmd.Parameters.AddWithValue("@cod", cryptedCode);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public string selectIdProf()
        {
            try
            {
                Conn.Open();
                string select = "SELECT idProf FROM Table2";// WHERE utilizator = @utilizator1";

                SqlCommand cmd = new SqlCommand(select, Conn);


                //cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();

                string y = "";

                while (rdr.Read())
                {
                    string s = rdr["idProf"].ToString();
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != ' ')
                        {
                            y += s[i];
                        }
                    }
                    y += ';';
                }
                return y;
                //return "";
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public int selectEncryptedIdProf(string cod)
        {
            try
            {
                Conn.Open();
                //cu md5hasher voi cripta parola
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //in hashedBytes retin parola criptata
                Byte[] cryptedCode;

                //cu encoder voi transforma parola din string intr-un vector de bytes
                UTF8Encoding encoder = new UTF8Encoding();

                //criptez si salvez parola in hashedBytes
                cryptedCode = md5.ComputeHash(encoder.GetBytes(cod));


                string select = "SELECT idProf FROM Table2 WHERE idProf=@cod";

                SqlCommand cmd = new SqlCommand(select, Conn);

                cmd.Parameters.AddWithValue("@cod", cryptedCode);

                //cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();

                string y = "";

                while (rdr.Read())
                {
                    return 1;
                }
                return 0;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        public void stergeIdProf(string cod)
        {

            //s1=numele testului, s2=nota, s3=numele utilizatorului
            try
            {
                Conn.Open();

                string insert = "UPDATE Table2 SET idProf=@data1 WHERE idProf=@util";
                SqlCommand cmd = new SqlCommand(insert, Conn);
                cmd.Parameters.AddWithValue("@data1", "");
                cmd.Parameters.AddWithValue("@util", cod);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }




    }
}
