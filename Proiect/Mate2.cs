using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Security.Cryptography;


namespace Proiect
{
    public partial class Mate2 : Form
    {
        public Mate2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = Compare(pictureBox1.BackgroundImage, pictureBox2.BackgroundImage).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public enum CompareResult
        {
            ciCompareOk,
            ciPixelMismatch,
            ciSizeMismatch
        };
        /*
        public static CompareResult Compare(Image bmp1, Image bmp2)
        {
            CompareResult cr = CompareResult.ciCompareOk;
            CompareResult nr = CompareResult.ciCompareOk;
            nr = 0;
            //Test to see if we have the same size of image
            if (bmp1.Size != bmp2.Size)
            {
                cr = CompareResult.ciSizeMismatch;
            }
            else
            {
                //Convert each image to a byte array
                System.Drawing.ImageConverter ic =
                       new System.Drawing.ImageConverter();
                byte[] btImage1 = new byte[1];
                btImage1 = (byte[])ic.ConvertTo(bmp1, btImage1.GetType());
                byte[] btImage2 = new byte[1];
                btImage2 = (byte[])ic.ConvertTo(bmp2, btImage2.GetType());

                //Compute a hash for each image
                SHA256Managed shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);

                //Compare the hash values
                for (int i = 0; i < hash1.Length && i < hash2.Length
                                  && cr == CompareResult.ciCompareOk; i++)
                {
                    if (hash1[i] != hash2[i])
                        cr = CompareResult.ciPixelMismatch;
                        //nr++;
                }
            }
            nr++;
            return nr;
        }*/
        int Compare(Image bmp1, Image bmp2)
        {
            int cr = 1;
            int nr = 0;
            nr = 0;
            //Test to see if we have the same size of image
            if (bmp1.Size != bmp2.Size)
            {
                cr = -1;
            }
            else
            {
                //Convert each image to a byte array
                System.Drawing.ImageConverter ic =
                       new System.Drawing.ImageConverter();
                byte[] btImage1 = new byte[1];
                btImage1 = (byte[])ic.ConvertTo(bmp1, btImage1.GetType());
                byte[] btImage2 = new byte[1];
                btImage2 = (byte[])ic.ConvertTo(bmp2, btImage2.GetType());

                //Compute a hash for each image
                SHA256Managed shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);

                //Compare the hash values
                for (int i = 0; i < hash1.Length && i < hash2.Length
                                  && cr == 1; i++)
                {
                    if (hash1[i] != hash2[i])
                        //cr = CompareResult.ciPixelMismatch;
                        nr++;
                }
            }
            //nr++;
            return nr;
        }
    }
}