// -----------------------------------------------------------------------------
// Example: Extract text from PPTX and save CSV using C#
//
// Description:
// Demonstrates how to extract slide and master slide text from a PPTX file
// and write it to a CSV file using C# and Aspose.Slides for .NET. The example
// also shows how to save the presentation after processing. This pattern can
// be used to automate text extraction, generate reports, or integrate PowerPoint
// content handling into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Text, CSV, Presentation
// Processing, Office Automation
//
// Use Cases:
// - Automate extraction of slide text for reporting or analysis.
// - Build tools that convert PowerPoint content to CSV for data pipelines.
// - Integrate PowerPoint text extraction into .NET services or utilities.
// - Validate and archive presentation text before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ExtractTextToCsv
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputCsv = "output.csv";
            string savedPresentationPath = "saved_output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Collect CSV lines
                    System.Collections.Generic.List<string> csvLines = new System.Collections.Generic.List<string>();
                    int slideNumber = 1;

                    // Extract text from each slide
                    foreach (ISlide slide in presentation.Slides)
                    {
                        StringBuilder slideTextBuilder = new StringBuilder();
                        foreach (ITextFrame textFrame in SlideUtil.GetAllTextBoxes(slide))
                        {
                            slideTextBuilder.Append(textFrame.Text);
                            slideTextBuilder.Append(' ');
                        }
                        string slideText = slideTextBuilder.ToString().Trim();
                        csvLines.Add(slideNumber.ToString() + "," + EscapeCsv(slideText));
                        slideNumber++;
                    }

                    // Extract text from master slides (prefix with M)
                    int masterIndex = 1;
                    foreach (IMasterSlide master in presentation.Masters)
                    {
                        StringBuilder masterTextBuilder = new StringBuilder();
                        foreach (ITextFrame textFrame in SlideUtil.GetAllTextBoxes(master))
                        {
                            masterTextBuilder.Append(textFrame.Text);
                            masterTextBuilder.Append(' ');
                        }
                        string masterText = masterTextBuilder.ToString().Trim();
                        csvLines.Add("M" + masterIndex.ToString() + "," + EscapeCsv(masterText));
                        masterIndex++;
                    }

                    // Write CSV file
                    File.WriteAllLines(outputCsv, csvLines, Encoding.UTF8);

                    // Save presentation before exit
                    presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported for PPT
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Helper method to escape CSV fields
        private static string EscapeCsv(string field)
        {
            if (field.Contains("\"") || field.Contains(","))
            {
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            }
            return field;
        }
    }
}
