using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get an existing master slide to clone
            Aspose.Slides.IMasterSlide sourceMaster = presentation.Masters[0];

            // Insert a cloned master slide at the end of the masters collection
            Aspose.Slides.IMasterSlide newMaster = presentation.Masters.InsertClone(presentation.Masters.Count, sourceMaster);

            // Optionally set a name for the new master slide
            newMaster.Name = "Cloned Master";

            // Save the presentation with the new master slide
            presentation.Save("output_with_new_master.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}