using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var filePath = "input.pptm";
            var presentation = new Aspose.Slides.Presentation(filePath);
            var vbaProject = presentation.VbaProject;
            if (vbaProject != null && vbaProject.IsPasswordProtected)
            {
                Console.WriteLine("The VBAProject '" + vbaProject.Name + "' is protected by a password.");
            }
            else
            {
                Console.WriteLine("The VBAProject is not password protected.");
            }
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}