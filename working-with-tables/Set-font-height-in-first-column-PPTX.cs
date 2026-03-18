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

            // Get the first shape on the first slide and cast it to a table
            Aspose.Slides.ITable table = presentation.Slides[0].Shapes[0] as Aspose.Slides.ITable;

            if (table != null)
            {
                // Create a PortionFormat and set the desired font height
                Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
                portionFormat.FontHeight = 24f; // Example font height in points

                // Apply the format to all cells in the first column (index 0)
                table.Columns[0].SetTextFormat(portionFormat);
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}