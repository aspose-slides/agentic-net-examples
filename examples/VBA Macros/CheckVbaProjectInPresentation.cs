class Program
{
    static void Main()
    {
        // Path to the PPTX file
        string inputFile = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.pptx");

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // Check if a VBA project exists
        Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;
        bool hasVbaProject = vbaProject != null;

        System.Console.WriteLine("Presentation contains VBA project: " + hasVbaProject);

        // Save the presentation before exiting (no modifications made)
        presentation.Save(inputFile, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}