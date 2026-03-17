using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Retrieve the normal view properties
            Aspose.Slides.INormalViewProperties normalView = presentation.ViewProperties.NormalViewProperties;

            // Update some normal view settings
            normalView.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
            normalView.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
            normalView.ShowOutlineIcons = true;

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}