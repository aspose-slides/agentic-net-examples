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
            string inputPath = "input.pptx";
            string jsonOutputPath = "master_hierarchy.json";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
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
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
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