using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static async Task Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputFolder = "output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception)
        {
            // format not supported
            return;
        }

        // Set up font fallback rules
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
        rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
        presentation.FontsManager.FontFallBackRulesCollection = rules;

        // Asynchronously render each slide to PNG
        Task[] renderTasks = new Task[presentation.Slides.Count];
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            int slideIndex = i; // capture loop variable
            renderTasks[i] = Task.Run(() =>
            {
                Aspose.Slides.IImage image = presentation.Slides[slideIndex].GetImage(1f, 1f);
                string outputPath = Path.Combine(outputFolder, $"slide_{slideIndex + 1}.png");
                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                image.Dispose();
            });
        }

        await Task.WhenAll(renderTasks);

        // Save the presentation before exit
        string savedPath = Path.Combine(outputFolder, "output.pptx");
        presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}