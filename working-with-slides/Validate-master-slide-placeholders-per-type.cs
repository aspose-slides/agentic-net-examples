using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ValidateMasterPlaceholders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Required placeholder types
                    PlaceholderType[] requiredTypes = new PlaceholderType[]
                    {
                        PlaceholderType.DateAndTime,
                        PlaceholderType.SlideNumber,
                        PlaceholderType.Footer,
                        PlaceholderType.Header
                    };

                    // Iterate through each master slide
                    for (int i = 0; i < presentation.Masters.Count; i++)
                    {
                        IMasterSlide master = presentation.Masters[i];
                        Console.WriteLine("Checking Master Slide index " + i + "...");

                        foreach (PlaceholderType type in requiredTypes)
                        {
                            // Find shapes with the specified placeholder type on the master slide
                            IShape[] shapes = SlideUtil.FindShapesByPlaceholderType(master, type);
                            if (shapes == null || shapes.Length == 0)
                            {
                                Console.WriteLine($"  Missing placeholder of type {type} on master slide index {i}.");
                            }
                            else
                            {
                                Console.WriteLine($"  Found {shapes.Length} placeholder(s) of type {type}.");
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}