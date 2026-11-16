// -----------------------------------------------------------------------------
// Example: Export Slide Master Collection to JSON Schema using C#
// 
// Description:
// Demonstrates how to load a PowerPoint presentation, extract slide master
// metadata including layout names, types, and placeholder counts, serialize the
// information to a formatted JSON file, and save a copy of the original PPTX.
// This assists in automating PPTX analysis, documentation, and validation.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide Master, JSON
// 
// Use Cases:
// - Generate documentation of slide master structures for presentation standards.
// - Build validation tools that check for required placeholders in master layouts.
// - Integrate slide metadata extraction into CI pipelines for PPTX assets.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

class LayoutInfo
{
    public string Name { get; set; }
    public string LayoutType { get; set; }
    public int PlaceholderCount { get; set; }
}

class MasterInfo
{
    public string Name { get; set; }
    public List<LayoutInfo> Layouts { get; set; }
}

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputJson = "masters.json";
        string outputPres = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                // Create a simple presentation as sample input
                using (Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation())
                {
                    // The default presentation already contains a master slide and layout.
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                List<MasterInfo> mastersList = new List<MasterInfo>();

                for (int m = 0; m < pres.Masters.Count; m++)
                {
                    Aspose.Slides.IMasterSlide master = pres.Masters[m];
                    List<LayoutInfo> layoutsList = new List<LayoutInfo>();

                    Aspose.Slides.ILayoutSlideCollection layoutSlides = master.LayoutSlides;
                    for (int l = 0; l < layoutSlides.Count; l++)
                    {
                        Aspose.Slides.ILayoutSlide layout = layoutSlides[l];
                        int placeholderCount = 0;

                        for (int s = 0; s < layout.Shapes.Count; s++)
                        {
                            Aspose.Slides.IShape shape = layout.Shapes[s];
                            if (shape.Placeholder != null)
                            {
                                placeholderCount++;
                            }
                        }

                        LayoutInfo layoutInfo = new LayoutInfo();
                        layoutInfo.Name = layout.Name;
                        layoutInfo.LayoutType = layout.LayoutType.ToString();
                        layoutInfo.PlaceholderCount = placeholderCount;
                        layoutsList.Add(layoutInfo);
                    }

                    MasterInfo masterInfo = new MasterInfo();
                    masterInfo.Name = master.Name;
                    masterInfo.Layouts = layoutsList;
                    mastersList.Add(masterInfo);
                }

                string json = JsonSerializer.Serialize(mastersList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputJson, json);

                // Save a copy of the original presentation
                pres.Save(outputPres, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
