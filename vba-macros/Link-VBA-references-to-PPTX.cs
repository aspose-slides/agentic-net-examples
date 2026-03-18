using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation with default load options
            LoadOptions loadOptions = new LoadOptions();
            Presentation presentation = new Presentation("input.pptx", loadOptions);

            // Access the embedded VBA project
            IVbaProject vbaProject = presentation.VbaProject;
            if (vbaProject != null)
            {
                // Example: add a reference to an external library (placeholder code)
                // The actual method to add a reference may vary depending on the Aspose.Slides version.
                // vbaProject.References.Add("stdole");
            }

            // Save the presentation (as macro-enabled PPTM to preserve VBA)
            presentation.Save("output.pptm", SaveFormat.Pptm);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}