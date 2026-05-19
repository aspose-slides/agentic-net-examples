using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtCsvReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputCsvPath = "SmartArtReport.csv";
            string outputPresentationPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // format not supported
                return;
            }

            // Prepare CSV writer
            StreamWriter csvWriter = null;
            try
            {
                csvWriter = new StreamWriter(outputCsvPath);
                // Write CSV header
                csvWriter.WriteLine("Text,FillStyle,IsAssistant");

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    // Iterate through shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        // Check if shape is a SmartArt diagram
                        if (shape is Aspose.Slides.SmartArt.SmartArt)
                        {
                            Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                            // Iterate through all nodes in the SmartArt
                            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                            {
                                // Get node text
                                string nodeText = string.Empty;
                                if (node.TextFrame != null && node.TextFrame.Text != null)
                                {
                                    nodeText = node.TextFrame.Text.Replace(",", " "); // Escape commas
                                }

                                // Determine fill style (using first shape's fill if available)
                                string fillStyle = "None";
                                if (node.Shapes.Count > 0)
                                {
                                    Aspose.Slides.SmartArt.ISmartArtShape firstShape = node.Shapes[0];
                                    if (firstShape.FillFormat != null)
                                    {
                                        fillStyle = firstShape.FillFormat.FillType.ToString();
                                    }
                                }

                                // Assistant status
                                bool isAssistant = node.IsAssistant;

                                // Write CSV line
                                csvWriter.WriteLine($"{nodeText},{fillStyle},{isAssistant}");
                            }
                        }
                    }
                }
            }
            finally
            {
                if (csvWriter != null)
                {
                    csvWriter.Flush();
                    csvWriter.Close();
                }
            }

            // Save presentation before exit
            try
            {
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose presentation
            presentation.Dispose();
        }
    }
}