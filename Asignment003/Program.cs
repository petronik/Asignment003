using Asignment003.DbModels;
using System;
using static System.Console;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Asignment003
{
    class Program
    {
        private static readonly northwindContext _context = new northwindContext();
        public class Categories
        {
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            var products = _context.Products.ToList();
            List<Categories> catList = new List<Categories>();


            foreach (var p in products)
            {
                Categories cat = p.Category;
                catList.Add( (Categories)p.Category);
                WriteLine($"{p.Category} ");
            };
            string xmlProducts = "products.xml";
            ToXmlFile(xmlProducts, products);

            string jsonProductsDto = "productsDto.json";
            ToJsonFile(jsonProductsDto, products);

            //string binaryProductsDto = "productsDto.dat";
            //ToBinaryFile(binaryProductsDto, products);

            //fileList.Sort();
            //int place = 1;
            //foreach (var file in fileList)
            //{
            //    WriteLine($"{place++}. {file.Name} : {file.Size} bytes");
            //}

            Console.WriteLine("Hello World!");
        }
        public static void ToXmlFile<T>(string file, T obj)
        {
            using(StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                xmls.Serialize(sw, obj);
                File.WriteAllText(file, sw.ToString());
            }
        }
        public static T FromXmlFile<T>(string file)
        {
            using StringReader sr = new StringReader(file);
            XmlSerializer xmls = new XmlSerializer(typeof(T));
            return (T)xmls.Deserialize(sr);
        }
        public static void ToBinaryFile<T>(string file, T obj)
        {
            using (Stream st = File.Open(file, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, obj);
            }
        }
        public static void ToJsonFile<T>(string file, T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(file, json);
        }
    }
}
