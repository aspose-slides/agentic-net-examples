using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the PPTX file into memory
                string inputFile = "input.pptx";
                Presentation presentation = new Presentation(inputFile);

                // Save the presentation before exiting
                string outputFile = "output.pptx";
                presentation.Save(outputFile, SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}