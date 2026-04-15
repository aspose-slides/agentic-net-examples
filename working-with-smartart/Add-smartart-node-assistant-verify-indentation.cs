using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtAssistantDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputPath = "AssistantNodeDemo.pptx";

            try
            {
                var pres = new Presentation();
                try
                {
                    var smart = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
                    var node = smart.AllNodes.AddNode();
                    node.IsAssistant = true;
                    var level = node.Level;
                    Console.WriteLine($"Added node IsAssistant=true, Level={level}");

                    pres.Save(outputPath, SaveFormat.Pptx);
                }
                finally
                {
                    pres.Dispose();
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}