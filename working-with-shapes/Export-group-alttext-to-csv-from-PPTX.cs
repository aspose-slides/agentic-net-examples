// -----------------------------------------------------------------------------
// Example: Export group alttext to csv from PPTX using C#
//
// Description:
// Demonstrates how to export group alttext to csv from PPTX using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Group, Alttext, CSV, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of group alttext to CSV from PPTX.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputCsv = "groups_alttext.csv";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Create CSV file and write header
                    using (StreamWriter sw = new StreamWriter(outputCsv))
                    {
                        sw.WriteLine("SlideIndex,GroupIndex,AltText");

                        int slideIndex = 0;
                        foreach (ISlide slide in pres.Slides)
                        {
                            int groupIndex = 0;
                            foreach (IShape shape in slide.Shapes)
                            {
                                IGroupShape groupShape = shape as IGroupShape;
                                if (groupShape != null)
                                {
                                    string altText = groupShape.AlternativeText ?? string.Empty;
                                    // Escape double quotes in AltText
                                    string escapedAltText = altText.Replace("\"", "\"\"");
                                    sw.WriteLine(string.Format("{0},{1},\"{2}\"", slideIndex, groupIndex, escapedAltText));
                                    groupIndex++;
                                }
                            }
                            slideIndex++;
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    pres.Save("output.pptx", SaveFormat.Pptx);
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
}
