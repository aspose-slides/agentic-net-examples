using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation("input.ppt"))
            {
                // Set default slide zoom level to 150%
                presentation.ViewProperties.SlideViewProperties.Scale = 150;
                // Set notes view zoom level to 150%
                presentation.ViewProperties.NotesViewProperties.Scale = 150;
                // Save the presentation before exiting
                presentation.Save("output.ppt", SaveFormat.Ppt);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}