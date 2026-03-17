using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Access normal view properties (read‑only property, but its members are writable)
                INormalViewProperties normalView = presentation.ViewProperties.NormalViewProperties;

                // Restore or modify normal view settings
                normalView.HorizontalBarState = SplitterBarStateType.Restored;
                normalView.VerticalBarState = SplitterBarStateType.Maximized;
                normalView.ShowOutlineIcons = true;

                // Create PPTX save options using the factory
                SaveOptionsFactory optionsFactory = new SaveOptionsFactory();
                IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

                // Save the presentation with the restored view settings
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}