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
using Asignment003.DtoModels;

namespace Asignment003
{
    class Program
    {
        private static readonly northwindContext _context = new northwindContext();
        
        static void Main(string[] args)
        {
            var products = _context.Products.ToList();
            List<Product> prodList = new List<Product>();
            var productsDto = new List<ProductDto>();

            foreach (var p in products) 
            {
                ProductDto prod = new ProductDto
                {
                    SupplierIds = p.SupplierIds,
                    Id = p.Id,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    StandardCost = p.StandardCost,
                    ListPrice = p.ListPrice,
                    ReorderLevel = p.ReorderLevel,
                    TargetLevel = p.TargetLevel,
                    QuantityPerUnit = p.QuantityPerUnit,
                    Discontinued = p.Discontinued,
                    MinimumReorderQuantity = p.MinimumReorderQuantity,
                    Category = p.Category,
                    Attachments = p.Attachments
                };
                productsDto.Add(prod);
            }
            foreach(var p in prodList)
            {
                WriteLine(p.Category );
            }

            string xmlProductsDto = "productsDto.xml";
            ToXmlFile(xmlProductsDto, productsDto);

            string jsonProductsDto = "productsDto.json";
            ToJsonFile(jsonProductsDto, productsDto);

            string binaryProductsDto = "productsDto.dat";
            ToBinaryFile(binaryProductsDto, productsDto);

            List<SerializedFile> fileList = new List<SerializedFile>
            {
                new SerializedFile{
                    Name = xmlProductsDto,
                    Size = new FileInfo(xmlProductsDto).Length},
                new SerializedFile{
                    Name = jsonProductsDto,
                    Size = new FileInfo(jsonProductsDto).Length},
                new SerializedFile{
                    Name = binaryProductsDto,
                    Size = new FileInfo(binaryProductsDto).Length},
            };

            fileList.Sort();
            int place = 1;
            foreach (var file in fileList)
            {
                WriteLine($"{place++}. {file.Name} : {file.Size} bytes");
            }

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
