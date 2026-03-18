using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Check if there are any ActiveX controls on the slide
            if (slide.Controls.Count > 0)
            {
                // Get the first control
                Aspose.Slides.Control control = (Aspose.Slides.Control)slide.Controls[0];

                // Set a custom XML property if the control uses property bag persistence
                if (control.Persistence == Aspose.Slides.PersistenceType.PersistPropertyBag)
                {
                    control.Properties["Value"] = "123";
                }
                else
                {
                    // Binary persistence handling can be added here if needed
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}