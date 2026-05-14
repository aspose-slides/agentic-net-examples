using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

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

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                List<MasterInfo> mastersList = new List<MasterInfo>();

                for (int m = 0; m < pres.Masters.Count; m++)
                {
                    IMasterSlide master = pres.Masters[m];
                    List<LayoutInfo> layoutsList = new List<LayoutInfo>();

                    IMasterLayoutSlideCollection layoutSlides = master.LayoutSlides;
                    for (int l = 0; l < layoutSlides.Count; l++)
                    {
                        ILayoutSlide layout = layoutSlides[l];
                        int placeholderCount = 0;

                        foreach (IShape shape in layout.Shapes)
                        {
                            if (shape.Placeholder != null)
                            {
                                placeholderCount++;
                            }
                        }

                        LayoutInfo layoutInfo = new LayoutInfo
                        {
                            Name = layout.Name,
                            LayoutType = layout.LayoutType.ToString(),
                            PlaceholderCount = placeholderCount
                        };
                        layoutsList.Add(layoutInfo);
                    }

                    MasterInfo masterInfo = new MasterInfo
                    {
                        Name = master.Name,
                        Layouts = layoutsList
                    };
                    mastersList.Add(masterInfo);
                }

                string json = JsonSerializer.Serialize(mastersList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputJson, json);

                // Save presentation before exit (no modifications made)
                pres.Save(outputPres, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}