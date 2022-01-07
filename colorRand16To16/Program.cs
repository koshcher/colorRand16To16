using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace colorRand16To16
{
    class Program
    {
        static int size = 16;
        static List<Color> colors = new List<Color>();

        static void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader("colors.txt"))
            {
                string line;
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> content = new List<string>(line.Split(' '));
                    int percent = Convert.ToInt32(content[3]);
                    for (int i = 0; i < percent; i++)
                    {
                        colors.Add(Color.FromArgb(Convert.ToInt32(content[0]), Convert.ToInt32(content[1]), Convert.ToInt32(content[2])));
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ReadFromFile();

            Random rnd = new Random();
            Bitmap image = new Bitmap(size, size);

            for(int x = 0; x < size; x++)
            {
                for(int y = 0; y < size; y++)
                {
                    image.SetPixel(x, y, colors[rnd.Next(100)]);
                }
            }
           
            image.Save("colors.png");
        }
    }
}
