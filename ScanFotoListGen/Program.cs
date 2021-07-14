using System;
using System.IO;
using System.Collections.Generic;

namespace ScanFotoListGen
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir1 = new DirectoryInfo(".");
            FileInfo[] arr =  dir1.GetFiles();
            List<String> nameList = new List<string>();
            foreach (var elem in arr)
            {
                string Fname = elem.Name;
                if (Fname.EndsWith(".jpg") ||Fname.EndsWith(".jpeg")
                    || Fname.EndsWith(".JPEG") || Fname.EndsWith(".JPG")){
                    nameList.Add(elem.Name);
                }
                
            }

            foreach (var elem in nameList)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine(nameList.Count);
            try
            {
                using (StreamWriter sw = File.CreateText("generated.txt"))
                {
                    foreach (var elem in nameList)
                    {
                        sw.WriteLine("<a href=\""+elem+"\" data-lightbox=\"roadtrip\">");
                        sw.WriteLine("<div class=\"image-container\">");
                        string str = null;
                        if (elem.EndsWith(".JPEG")){
                            str = elem.Replace(".JPEG", ".jpeg");
                        }
                        if (elem.EndsWith(".JPG")){
                            str = elem.Replace(".JPG", ".jpg");
                        }
                        if (str == null)
                        {
                            sw.WriteLine("<img src=\"thumbs/" + elem + "\" alt=\"tumb1\" />");
                        }
                        else
                        {
                            sw.WriteLine("<img src=\"thumbs/" + str + "\" alt=\"tumb1\" />");
                        }
                        sw.WriteLine("</div>");
                        sw.WriteLine("</a>");

                    }
                    Console.WriteLine("generated file: \"generated.txt\"");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
