// -----------------------------------------------------------------------------
// Example: Export Slide Master Hierarchy to JSON using C#
// 
// Description:
// Demonstrates how to export the slide master hierarchy of a PowerPoint PPTX
// file to a JSON document using Aspose.Slides for .NET. The program creates a
// sample presentation if none exists, extracts master and layout information,
// serializes it to JSON, and saves the result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide Master, Hierarchy, JSON
// 
// Use Cases:
// - Automate extraction of slide master structures for documentation.
// - Build tools that analyze PPTX files for compliance or reporting.
// - Integrate slide master data into downstream .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace SlideMasterExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string jsonOutputPath = "master_hierarchy.json";

            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation newPresentation = new Aspose.Slides.Presentation();
                    newPresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    newPresentation.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                Environment.Exit(1);
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                List<MasterInfo> mastersInfo = new List<MasterInfo>();

                Aspose.Slides.IMasterSlideCollection masters = presentation.Masters;
                for (int i = 0; i < masters.Count; i++)
                {
                    Aspose.Slides.IMasterSlide masterSlide = masters[i];
                    MasterInfo masterInfo = new MasterInfo();
                    masterInfo.Index = i;
                    masterInfo.Name = masterSlide.Name;
                    masterInfo.Layouts = new List<LayoutInfo>();

                    Aspose.Slides.IMasterLayoutSlideCollection layouts = masterSlide.LayoutSlides;
                    for (int j = 0; j < layouts.Count; j++)
                    {
                        Aspose.Slides.ILayoutSlide layoutSlide = layouts[j];
                        LayoutInfo layoutInfo = new LayoutInfo();
                        layoutInfo.Index = j;
                        layoutInfo.Name = layoutSlide.Name;
                        masterInfo.Layouts.Add(layoutInfo);
                    }

                    mastersInfo.Add(masterInfo);
                }

                string json = JsonSerializer.Serialize(mastersInfo, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonOutputPath, json);

                // Save the presentation before exit (no changes made, just re-saving)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Slide master hierarchy exported to: " + jsonOutputPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported for this operation.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }

        private class MasterInfo
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public List<LayoutInfo> Layouts { get; set; }
        }

        private class LayoutInfo
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
    }
}
