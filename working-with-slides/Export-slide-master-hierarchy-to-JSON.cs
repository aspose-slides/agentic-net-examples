using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideMasterExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string jsonOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "master_hierarchy.json");
            string savedOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_saved.pptx");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    List<object> mastersInfo = new List<object>();

                    for (int i = 0; i < presentation.Masters.Count; i++)
                    {
                        IMasterSlide master = presentation.Masters[i];
                        var masterInfo = new
                        {
                            Index = i,
                            Name = master.Name,
                            SlideId = master.SlideId,
                            LayoutCount = master.LayoutSlides.Count,
                            LayoutNames = GetLayoutNames(master)
                        };
                        mastersInfo.Add(masterInfo);
                    }

                    string json = JsonSerializer.Serialize(mastersInfo, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonOutputPath, json);

                    // Save the presentation before exiting
                    presentation.Save(savedOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static List<string> GetLayoutNames(IMasterSlide master)
        {
            List<string> names = new List<string>();
            for (int j = 0; j < master.LayoutSlides.Count; j++)
            {
                names.Add(master.LayoutSlides[j].Name);
            }
            return names;
        }
    }
}