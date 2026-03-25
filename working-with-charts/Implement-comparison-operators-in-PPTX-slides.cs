using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Clone the first slide three times
                Aspose.Slides.ISlide slide1 = presentation.Slides.AddClone(presentation.Slides[0]);
                Aspose.Slides.ISlide slide2 = presentation.Slides.AddClone(presentation.Slides[0]);
                Aspose.Slides.ISlide slide3 = presentation.Slides.AddClone(presentation.Slides[0]);

                // Compare slides using Equals method
                bool areEqual12 = slide1.Equals(slide2);
                bool areEqual13 = slide1.Equals(slide3);

                Console.WriteLine("Slide1 equals Slide2: " + areEqual12);
                Console.WriteLine("Slide1 equals Slide3: " + areEqual13);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}