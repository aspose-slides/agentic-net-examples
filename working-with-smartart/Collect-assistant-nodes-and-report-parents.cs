using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtAssistantReport
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            try
            {
                // Iterate through slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through shapes to find SmartArt objects
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                            // Traverse all nodes to find assistant nodes and report their parents
                            foreach (Aspose.Slides.SmartArt.ISmartArtNode parentNode in smartArt.AllNodes)
                            {
                                Aspose.Slides.SmartArt.ISmartArtNodeCollection childNodes = parentNode.ChildNodes;
                                foreach (Aspose.Slides.SmartArt.ISmartArtNode childNode in childNodes)
                                {
                                    if (childNode.IsAssistant)
                                    {
                                        string parentText = parentNode.TextFrame != null ? parentNode.TextFrame.Text : "(no text)";
                                        string childText = childNode.TextFrame != null ? childNode.TextFrame.Text : "(no text)";
                                        Console.WriteLine("Assistant Node: \"" + childText + "\" | Parent Node: \"" + parentText + "\"");
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the (potentially unchanged) presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            finally
            {
                pres.Dispose();
            }
        }
    }
}