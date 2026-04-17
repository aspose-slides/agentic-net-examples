using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlideMasters
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputJsonPath = "masters.json";
            string outputPresPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Build JSON schema for master slides and their layouts
                    List<object> mastersList = new List<object>();

                    IMasterSlideCollection masters = pres.Masters;
                    for (int m = 0; m < masters.Count; m++)
                    {
                        IMasterSlide master = masters[m];
                        List<object> layoutsList = new List<object>();

                        IMasterLayoutSlideCollection layouts = master.LayoutSlides;
                        for (int l = 0; l < layouts.Count; l++)
                        {
                            ILayoutSlide layout = layouts[l];
                            List<object> placeholdersList = new List<object>();

                            foreach (IShape shape in layout.Shapes)
                            {
                                if (shape.Placeholder != null)
                                {
                                    placeholdersList.Add(new
                                    {
                                        Index = shape.Placeholder.Index,
                                        Type = shape.Placeholder.Type.ToString(),
                                        Name = shape.Name
                                    });
                                }
                            }

                            layoutsList.Add(new
                            {
                                Index = l,
                                Name = layout.Name,
                                Placeholders = placeholdersList
                            });
                        }

                        mastersList.Add(new
                        {
                            Index = m,
                            Name = master.Name,
                            Layouts = layoutsList
                        });
                    }

                    string json = JsonSerializer.Serialize(mastersList, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(outputJsonPath, json);
                    Console.WriteLine("Master collection exported to JSON: " + outputJsonPath);

                    // Save the presentation before exiting
                    pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported file format: " + ex.Message);
                // format not supported
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported file format: " + ex.Message);
                // format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}