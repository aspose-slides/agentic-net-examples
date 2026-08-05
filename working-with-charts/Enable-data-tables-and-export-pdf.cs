// -----------------------------------------------------------------------------
// Example: Enable data tables and export PDF using C#
//
// Description:
// Demonstrates how to enable data tables for all charts in a presentation
// and export the modified presentation to PDF using C# and Aspose.Slides for .NET.
// The example processes PPTX, PPT, and ODP files in a specified input folder,
// updates each chart to show its data table, saves the changes, and creates a
// PDF version of the file.
//
// Keywords:
// C#, PowerPoint, PPTX, PPT, ODP, Aspose.Slides for .NET, PDF, Enable Data Tables,
// Charts, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling data tables on charts and exporting presentations to PDF.
// - Build C# utilities for batch processing of PowerPoint and OpenDocument files.
// - Integrate chart data table activation into .NET applications.
// - Validate and transform presentation content before distribution.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string dataDir = "InputPresentations";
        if (!System.IO.Directory.Exists(dataDir))
        {
            System.Console.WriteLine("Directory does not exist: " + dataDir);
            return;
        }

        string[] files = System.IO.Directory.GetFiles(dataDir);
        foreach (string filePath in files)
        {
            try
            {
                string extension = System.IO.Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".pptx" && extension != ".ppt" && extension != ".odp")
                {
                    // format not supported
                    continue;
                }

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath))
                {
                    foreach (Aspose.Slides.ISlide slide in pres.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                            if (chart != null)
                            {
                                chart.HasDataTable = true;
                            }
                        }
                    }

                    // Save modified presentation
                    pres.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Save as PDF
                    string pdfPath = System.IO.Path.Combine(dataDir, System.IO.Path.GetFileNameWithoutExtension(filePath) + ".pdf");
                    pres.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error processing file: " + filePath);
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
