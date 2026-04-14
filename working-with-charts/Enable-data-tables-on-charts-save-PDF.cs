using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BatchChartProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Directory containing presentations
            string dataDir = @"C:\Presentations";

            // Verify directory exists
            if (!Directory.Exists(dataDir))
            {
                Console.WriteLine("Directory does not exist: " + dataDir);
                return;
            }

            // Supported presentation extensions
            string[] extensions = new string[] { ".pptx", ".ppt", ".odp", ".pptm" };

            // Process each file in the directory
            string[] files = Directory.GetFiles(dataDir);
            foreach (string filePath in files)
            {
                string fileExtension = Path.GetExtension(filePath);
                bool isSupported = false;
                foreach (string ext in extensions)
                {
                    if (string.Equals(ext, fileExtension, StringComparison.OrdinalIgnoreCase))
                    {
                        isSupported = true;
                        break;
                    }
                }

                if (!isSupported)
                {
                    // Format not supported
                    Console.WriteLine("Skipping unsupported file: " + filePath);
                    continue;
                }

                try
                {
                    // Load presentation
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);

                    // Enable data tables on all charts
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.Charts.IChart)
                            {
                                Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shape;
                                chart.HasDataTable = true;
                            }
                        }
                    }

                    // Save as PDF
                    string pdfPath = Path.ChangeExtension(filePath, ".pdf");
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    pdfOptions.IncludeOleData = true;
                    pres.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                    // Save presentation before exit (optional, can be omitted if not needed)
                    string backupPath = Path.Combine(dataDir, Path.GetFileNameWithoutExtension(filePath) + "_updated.pptx");
                    pres.Save(backupPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("File format not supported: " + filePath);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file access issues)
                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
                }
            }
        }
    }
}