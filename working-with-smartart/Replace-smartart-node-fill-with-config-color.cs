// -----------------------------------------------------------------------------
// Example: Replace smartart node fill with config color using C#
//
// Description:
// Demonstrates how to read a color value from a configuration file and apply
// it as a solid fill to all SmartArt node shapes in a PowerPoint presentation
// using Aspose.Slides for .NET. The example loads an input PPTX, updates the
// SmartArt node fills, and saves the result to an output PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, SmartArt, Node, Fill,
// Configuration, Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Apply a uniform fill color to SmartArt nodes based on external configuration.
// - Automate PowerPoint styling tasks in .NET applications.
// - Generate or modify PPTX files with custom SmartArt appearance.
// - Validate and enforce presentation design standards programmatically.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;
using System.Drawing;

namespace SmartArtNodeFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, output presentation and configuration file
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string configPath = "color.txt";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Verify that the configuration file exists
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuration file does not exist: " + configPath);
                return;
            }

            // Read the color value from the configuration file (e.g., "#FF0000")
            string colorString = File.ReadAllText(configPath).Trim();
            Color uniformColor;
            try
            {
                uniformColor = ColorTranslator.FromHtml(colorString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid color format in configuration file.");
                return;
            }

            // Load the presentation
            Presentation presentation;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Iterate through shapes on the first slide and modify SmartArt node fills
            foreach (IShape shape in presentation.Slides[0].Shapes)
            {
                if (shape is ISmartArt)
                {
                    ISmartArt smartArt = (ISmartArt)shape;
                    foreach (ISmartArtNode node in smartArt.AllNodes)
                    {
                        foreach (ISmartArtShape nodeShape in node.Shapes)
                        {
                            nodeShape.FillFormat.FillType = FillType.Solid;
                            nodeShape.FillFormat.SolidFillColor.Color = uniformColor;
                        }
                    }
                }
            }

            // Save the modified presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
