using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtTruncateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a SmartArt diagram
                            if (shape is Aspose.Slides.SmartArt.SmartArt smartArt)
                            {
                                // Process all nodes (including child nodes) of the SmartArt
                                ProcessSmartArtNodes(smartArt.AllNodes);
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Recursively processes SmartArt nodes to truncate long text
        private static void ProcessSmartArtNodes(Aspose.Slides.SmartArt.ISmartArtNodeCollection nodes)
        {
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in nodes)
            {
                Aspose.Slides.ITextFrame textFrame = node.TextFrame;
                if (textFrame != null)
                {
                    string text = textFrame.Text;
                    if (!string.IsNullOrEmpty(text) && text.Length > 50)
                    {
                        // Truncate text to 50 characters
                        string truncated = text.Substring(0, 50);
                        textFrame.Text = truncated;
                    }
                }

                // Recursively process child nodes
                ProcessSmartArtNodes(node.ChildNodes);
            }
        }
    }
}