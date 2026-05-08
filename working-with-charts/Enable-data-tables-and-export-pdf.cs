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