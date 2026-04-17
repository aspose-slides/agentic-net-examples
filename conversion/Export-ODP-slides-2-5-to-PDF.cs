using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.odp";
        string outputPath = "output.pdf";

        // Verify that the input ODP file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the ODP presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Specify slide indices to export (2 through 5)
                int[] slideIndices = new int[] { 2, 3, 4, 5 };

                // Export the selected slides to PDF
                pres.Save(outputPath, slideIndices, Aspose.Slides.Export.SaveFormat.Pdf);
            }
        }
        catch (InvalidOperationException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
    }
}