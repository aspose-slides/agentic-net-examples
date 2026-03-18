---
name: aspose-slides-examples
description: AI-friendly C# code examples for Aspose.Slides for .NET
language: csharp
framework: net10.0
package: Aspose.Slides
---

# Aspose.Slides for .NET Examples

AI-friendly repository containing validated C# examples for Aspose.Slides.


## Persona

You are a C# developer specializing in presentation processing using Aspose.Slides for .NET.
When working in this repository:
- Each `.cs` file is a **standalone Console Application**
- Do not create multi-file projects
- All examples must compile with `dotnet build`
- All examples must run with `dotnet run`
- Follow the repository conventions and boundaries strictly
- Use the **Command Reference** section for build and run commands



## Repository Overview

This repository contains **1747** working code examples demonstrating Aspose.Slides for .NET capabilities.

**Statistics** (as of 2026-03-18):
- Total Examples: 1747
- Categories: 15

## Category Details

### 3d-presentations
- Examples: 11
- Guide: [agents.md](./3d-presentations/agents.md)

### animations
- Examples: 20
- Guide: [agents.md](./animations/agents.md)

### comments-and-notes
- Examples: 25
- Guide: [agents.md](./comments-and-notes/agents.md)

### conversion
- Examples: 199
- Guide: [agents.md](./conversion/agents.md)

### design-presentations
- Examples: 139
- Guide: [agents.md](./design-presentations/agents.md)

### manage-presentation-content
- Examples: 233
- Guide: [agents.md](./manage-presentation-content/agents.md)

### manage-presentation-media-files
- Examples: 180
- Guide: [agents.md](./manage-presentation-media-files/agents.md)

### manage-presentation-text
- Examples: 141
- Guide: [agents.md](./manage-presentation-text/agents.md)

### manage-tags-and-custom-data
- Examples: 17
- Guide: [agents.md](./manage-tags-and-custom-data/agents.md)

### math-equations
- Examples: 35
- Guide: [agents.md](./math-equations/agents.md)

### vba-macros
- Examples: 23
- Guide: [agents.md](./vba-macros/agents.md)

### working-with-charts
- Examples: 329
- Guide: [agents.md](./working-with-charts/agents.md)

### working-with-shapes
- Examples: 166
- Guide: [agents.md](./working-with-shapes/agents.md)

### working-with-slides
- Examples: 111
- Guide: [agents.md](./working-with-slides/agents.md)

### working-with-tables
- Examples: 118
- Guide: [agents.md](./working-with-tables/agents.md)



## Boundaries

### ✅ Always

These rules are mandatory for every example.

#### Use explicit types where clarity matters
```csharp
Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
Aspose.Slides.ISlide slide = presentation.Slides[0];
```

#### Use fully qualified namespaces where ambiguity exists
```csharp
Aspose.Slides.Export.SaveFormat format = Aspose.Slides.Export.SaveFormat.Pptx;
```

#### Use using blocks for disposable objects
```csharp
using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
{
    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

#### Save the presentation after modifications
```csharp
presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### ⚠️ Ask First

Check with a human before doing any of these:

- Creating multi-file projects
- Adding NuGet packages other than Aspose.Slides
- Using deprecated APIs
- Modifying repository infrastructure


### 🚫 Never

- Never use `Aspose.Slides.SaveFormat`
- Never mix chart APIs from incorrect namespaces
- Never rely on `System.Drawing.Image` when Slides APIs exist
- Never modify generated `agents.md` files
- Never modify generated `.csproj` templates



## Common Mistakes (Anti-Patterns)

### cs0103-imageformat-not-found

```csharp
// WRONG
Used ImageFormat enum without namespace qualification (ImageFormat.Png)
```

```csharp
// CORRECT
Qualified enum with full namespace (Aspose.Slides.ImageFormat.Png) or added appropriate using
```

Reference ImageFormat via its full namespace (Aspose.Slides.ImageFormat) or include a using for Aspose.Slides to resolve the enum

### cs0234-missing-namespace-aspose-slides-saveformat

```csharp
// WRONG
Aspose.Slides.SaveFormat used for SaveFormat enum
```

```csharp
// CORRECT
Aspose.Slides.Export.SaveFormat used for SaveFormat enum
```

Reference SaveFormat via the Aspose.Slides.Export namespace (e.g., Aspose.Slides.Export.SaveFormat.Pptx) instead of Aspose.Slides.SaveFormat

### cs1069-image-not-found-in-system-drawing

```csharp
// WRONG
Using System.Drawing.Image and slide.GetThumbnail() which depends on System.Drawing.Common
```

```csharp
// CORRECT
Use Aspose.Slides.IImage slide.GetImage() and Aspose.Slides.ImageFormat for saving PNG
```

Replace System.Drawing.Image with Aspose.Slides.IImage and call slide.GetImage() instead of GetThumbnail(), then save with Aspose.Slides.ImageFormat

### cs0234-saveformat-not-found-in-aspose-slides-namespace

```csharp
// WRONG
Used Aspose.Slides.SaveFormat.Html (wrong namespace) and passed HtmlOptions unnecessarily
```

```csharp
// CORRECT
Reference Aspose.Slides.Export.SaveFormat.Html (or import Aspose.Slides.Export) and call presentation.Save with that enum
```

Always import and use Aspose.Slides.Export namespace for SaveFormat enum when saving presentations

### htmloptions-does-not-contain-a-definition-for-embedimages

```csharp
// WRONG
Instantiate HtmlOptions and assign htmlOptions.EmbedImages = true;
```

```csharp
// CORRECT
Instantiate Html5Options (or a version of HtmlOptions that supports EmbedImages) and set EmbedImages = true, then save using SaveFormat.Html5.
```

For HTML export with embedded images, use Aspose.Slides.Export.Html5Options (or the appropriate options class that includes the EmbedImages property) instead of HtmlOptions, set its EmbedImages property, and call Presentation.Save with SaveFormat.Html5.

### cs0234-saveformat-not-found-in-aspose-slides

```csharp
// WRONG
presentation.Save(..., Aspose.Slides.SaveFormat.Html, ...)
```

```csharp
// CORRECT
presentation.Save(..., Aspose.Slides.Export.SaveFormat.Html, ...)
```

Reference SaveFormat from Aspose.Slides.Export namespace instead of Aspose.Slides

### html5options-does-not-contain-htmlformatter

```csharp
// WRONG
Instantiate Html5Options and assign HtmlFormatter property; then save with SaveFormat.Html5
```

```csharp
// CORRECT
Instantiate HtmlOptions, assign HtmlFormatter, and save with SaveFormat.Html
```

When using HtmlFormatter, use HtmlOptions (or the options class that defines HtmlFormatter) and the matching SaveFormat.Html instead of Html5Options/Html5

### cs0266-cannot-implicitly-convert-type-embedallfontshtmlcontroller-to-ihtmlformatter

```csharp
// WRONG
Assigning a new EmbedAllFontsHtmlController instance directly to HtmlOptions.HtmlFormatter
```

```csharp
// CORRECT
Assigning HtmlFormatter.CreateDocumentFormatter(...) (or another factory method) to HtmlOptions.HtmlFormatter
```

Use the HtmlFormatter factory method to obtain an IHtmlFormatter instance instead of instantiating EmbedAllFontsHtmlController directly

### cs0234-saveformat-not-found-in-aspose-slides-namespace

```csharp
// WRONG
presentation.Save(outputPath, Aspose.Slides.SaveFormat.Html, options) // wrong namespace and extra parameter
```

```csharp
// CORRECT
presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html) // correct namespace, proper overload
```

Use Aspose.Slides.Export.SaveFormat (or add using Aspose.Slides.Export) when calling Presentation.Save and match the overload signature

### htmloptions-does-not-contain-a-definition-for-embedimages

```csharp
// WRONG
HtmlOptions htmlOptions = new HtmlOptions(); htmlOptions.EmbedImages = true;
```

```csharp
// CORRECT
HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new EmbedAllFontsHtmlController(new string[0])) }; htmlOptions.SlideImageFormat = SlideImageFormat.Bitmap(150f, ImageFormat.Jpeg);
```

Replace the nonexistent HtmlOptions.EmbedImages property with a custom HtmlFormatter (e.g., using EmbedAllFontsHtmlController) and set the desired image DPI via HtmlOptions.SlideImageFormat = SlideImageFormat.Bitmap(dpi, ImageFormat.Jpeg).



## Domain Knowledge

- **Replace fonts explicitly before saving the presentation.**  
  Use `IFontData`, `FontData`, and `FontsManager.ReplaceFont(...)` to swap one font family with another across the deck, then save the updated file.  
  **Example:** Create `IFontData sourceFont = new FontData("Arial");`, `IFontData destFont = new FontData("Times New Roman");`, call `presentation.FontsManager.ReplaceFont(sourceFont, destFont);`, and save as `output.pptx`.

- **Clone a slide into a specific section to preserve presentation structure.**  
  When duplicating slides, create or append the destination section first and use `Slides.AddClone(...)` with the target `ISection`.  
  **Example:** Add a rectangle to `presentation.Slides[0]`, create `ISection section2 = presentation.Sections.AppendEmptySection("Section 2");`, then call `presentation.Slides.AddClone(presentation.Slides[0], section2);`.

- **Replace placeholder text by iterating shapes and updating only auto shapes.**  
  Loop through `slide.Shapes`, check `shape.Placeholder != null`, cast the shape to `IAutoShape`, and update `TextFrame.Text`.  
  **Example:** Iterate the first slide’s shapes and set `((IAutoShape)shape).TextFrame.Text = "Updated title";` only for placeholder shapes before saving.

- **Animate chart categories element-by-element through the slide timeline.**  
  Access the chart from the slide’s shape collection, add a base effect to `Timeline.MainSequence`, then loop through categories and series to add `ByElementInCategory` effects.  
  **Example:** Cast `slide.Shapes[0]` to `Aspose.Slides.Charts.IChart`, add a `Fade` effect, then use nested loops over `chart.ChartData.Categories.Count` and `chart.ChartData.Series.Count` to add `Appear` animations.

- **Export a shape as a PNG thumbnail without exporting the whole slide.**  
  Create a shape, style it, call `shape.GetImage(...)`, and save the returned `IImage` with `Aspose.Slides.ImageFormat.Png`.  
  **Example:** Add a rectangle, set `FillFormat.FillType = NoFill`, set `LineFormat.SketchFormat.SketchType = Scribble`, then call `shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 2f, 2f)` and save it as `shape.png`.

- **Access SmartArt by walking the slide’s shape collection and casting matching shapes.**  
  To inspect or process SmartArt content, iterate `slide.Shapes`, detect SmartArt shapes, and cast them to `Aspose.Slides.SmartArt.ISmartArt` or `SmartArt`.  
  **Example:** Loop through `slide.Shapes`, check `if (shape is Aspose.Slides.SmartArt.ISmartArt)`, cast it, then inspect `smartArt.AllNodes` to read node text and hierarchy.

- **Read SmartArt child nodes when you need hierarchy, level, and position data.**  
  For tree-style processing, iterate `AllNodes`, then iterate each node’s `ChildNodes` to access nested content and metadata like `Level` and `Position`.  
  **Example:** Cast a SmartArt shape to `SmartArt`, loop over `smart.AllNodes`, then for each parent node loop over `parentNode.ChildNodes` and read `childNode.TextFrame.Text`.

- **Embed audio in a slide and configure playback behavior directly on the audio frame.**  
  After creating an embedded audio frame, set playback options such as `PlayAcrossSlides`, `RewindAudio`, `Volume`, and `PlayMode`.  
  **Example:** Call `slide.Shapes.AddAudioFrameEmbedded(...)`, then set `audioFrame.PlayAcrossSlides = true;`, `audioFrame.RewindAudio = true;`, and `audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;`.

- **Add hyperlinks through text portions inside an auto shape rather than on the shape itself.**  
  Create an auto shape, add text, then attach the hyperlink to the first text portion using `PortionFormat.HyperlinkClick`.  
  **Example:** Create a rectangle, call `shape.AddTextFrame("Open site");`, then set `shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("https://example.com");`.

- **Store images inside table cells by using picture fill formatting on the target cell.**  
  Add a table, load an image, insert it into the presentation image collection, and assign it through `CellFormat.FillFormat.PictureFillFormat.Picture.Image`.  
  **Example:** Create a table with `slide.Shapes.AddTable(...)`, load an image with `Aspose.Slides.Images.FromFile("input.jpg")`, add it via `presentation.Images.AddImage(...)`, then set the first cell’s fill type to `Picture` and apply the image.




## Command Reference

### Build and Run
```bash
# Create a new project
dotnet new console -n ExampleProject --framework net10.0

# Add Aspose.Slides
dotnet add package Aspose.Slides

# Build
dotnet build --configuration Release --verbosity minimal

# Run
dotnet run
```

### Project File (.csproj)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Aspose.Slides" />
  </ItemGroup>
</Project>
```

### Environment

- .NET SDK 10.0 or higher
- NuGet package Aspose.Slides
- Each example is a standalone console application


---
Generated: 2026-03-18
