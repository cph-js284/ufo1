using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace assignment1
{
    public class StegoClass
    {


        public void GetMsg(){
             var path = "Stego.png";

            //Bitmap BM = (Bitmap)System.Drawing.Image.FromFile(path);
            Bitmap BM = new Bitmap(path);
            //used to convert bitarray into byte
            List<bool> booliste = new List<bool>();
            //used for printing bits in console
            List<int> intliste = new List<int>();

            //travese columns
            for (int j = 0; j < BM.Height; j++)
            {
                //travese rows
                for (int i = 0; i < BM.Width; i++)
                {
                    //get pixel
                    var res = BM.GetPixel(i,j);
                    //get the red channel
                    var byteVal = res.R;

                    //if byte val is even -> LSB 0
                    if(byteVal % 2 != 0){
                        booliste.Add(true);
                        intliste.Add(1);
                    }else
                    {
                        booliste.Add(false);
                        intliste.Add(0);
                    }
                    if((i) % 8 == 0){
                        System.Console.Write("-");
                        System.Console.Write((char)ConvertBitArraytoByte(new BitArray(booliste.ToArray()))); 
                        booliste = new List<bool>();
                    }
                }
            }

        }

        public byte ConvertBitArraytoByte(BitArray barr){
            byte[] bytes = new byte[1];
            barr.CopyTo(bytes, 0);
            return bytes[0];            
        }

    }
}