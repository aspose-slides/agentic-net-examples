using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation from a file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Retrieve and display information about each master slide
            int masterCount = presentation.Masters.Count;
            Console.WriteLine("Number of master slides: " + masterCount);
            for (int i = 0; i < masterCount; i++)
            {
                Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[i];
                Console.WriteLine("Master " + i + " Name: " + masterSlide.Name);
            }

            // Save the presentation (could be the same file or a new one)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}