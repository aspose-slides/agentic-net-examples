using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace ReplaceSmartArtNodeFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string configPath = "config.txt";
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load fill color from configuration file
            Color fillColor = Color.Black; // default
            if (File.Exists(configPath))
            {
                try
                {
                    string colorName = File.ReadAllText(configPath).Trim();
                    if (!string.IsNullOrEmpty(colorName))
                    {
                        Color parsed = Color.FromName(colorName);
                        if (parsed.A != 0 || parsed.R != 0 || parsed.G != 0 || parsed.B != 0)
                        {
                            fillColor = parsed;
                        }
                    }
                }
                catch (Exception)
                {
                    // If parsing fails, keep default color
                }
            }

            // Load or create presentation
            Presentation pres = null;
            if (File.Exists(inputPath))
            {
                try
                {
                    pres = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format
                    // Format not supported
                    Console.WriteLine("Failed to load presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                pres = new Presentation();
            }

            // Iterate through slides and SmartArt shapes
            foreach (ISlide slide in pres.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    // Check if shape is a SmartArt diagram
                    ISmartArt smartArt = shape as ISmartArt;
                    if (smartArt != null)
                    {
                        // Process all nodes (including child nodes)
                        foreach (ISmartArtNode node in smartArt.AllNodes)
                        {
                            // Apply fill to each shape within the node
                            foreach (ISmartArtShape nodeShape in node.Shapes)
                            {
                                if (nodeShape.FillFormat != null)
                                {
                                    nodeShape.FillFormat.FillType = FillType.Solid;
                                    nodeShape.FillFormat.SolidFillColor.Color = fillColor;
                                }
                            }

                            // Optionally apply fill to bullet if present
                            if (node.BulletFillFormat != null)
                            {
                                node.BulletFillFormat.FillType = FillType.Solid;
                                node.BulletFillFormat.SolidFillColor.Color = fillColor;
                            }
                        }
                    }
                }
            }

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}