using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rename_pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath;
            string csvPath;

            Console.Write("Provide path to pictures: ");
            picPath = Console.ReadLine();

            Console.Write("Provide path to CSV: " );
            csvPath = Console.ReadLine();

            using (StreamReader sr = new StreamReader(csvPath)) {
                while(!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    string idNum = line.Substring(0, line.IndexOf(','));
                    string imageName = line.Substring(line.IndexOf(',') + 1, line.Length - line.IndexOf(',') - 1);

                    if(File.Exists(picPath + imageName)) {
                        string newPath = picPath + idNum + ".jpg";
                        Console.WriteLine("Renaming {0} to {1}...", imageName, newPath);
                        File.Move(picPath + imageName, picPath + idNum + ".jpg");
                    }
                }

                Console.WriteLine("Finished. Press any key to exit");
                Console.Read();
            }
        }
    }
}
