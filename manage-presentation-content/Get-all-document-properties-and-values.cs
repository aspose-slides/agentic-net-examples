using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            string dataDir = "Data";
            string fileName = "sample.pptx";
            string filePath = Path.Combine(dataDir, fileName);

            Dictionary<string, object> properties = GetAllDocumentProperties(filePath);

            foreach (KeyValuePair<string, object> entry in properties)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }
        }

        public static Dictionary<string, object> GetAllDocumentProperties(string filePath)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: " + filePath);
                return dict;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                {
                    Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                    PropertyInfo[] props = docProps.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo prop in props)
                    {
                        if (prop.CanRead)
                        {
                            object value = prop.GetValue(docProps, null);
                            dict.Add(prop.Name, value);
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dict;
        }
    }
}