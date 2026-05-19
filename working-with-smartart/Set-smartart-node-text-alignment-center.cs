using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Cast shape to SmartArt if possible
                            SmartArt smartArt = shape as SmartArt;
                            if (smartArt != null)
                            {
                                // Iterate through all nodes in the SmartArt diagram
                                foreach (ISmartArtNode node in smartArt.AllNodes)
                                {
                                    // Get the first paragraph of the node's text frame
                                    Aspose.Slides.IParagraph paragraph = node.TextFrame.Paragraphs[0];
                                    // Set paragraph alignment to center
                                    paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
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
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}