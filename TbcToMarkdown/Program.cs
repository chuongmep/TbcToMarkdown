// See https://aka.ms/new-console-template for more information

using Aspose.Html.Saving;

Console.WriteLine("Hello, World!");


string dir = @"D:\API\Web\tbc\a";
string newdir = @"D:\API\Web\tbc\b";
DirectoryInfo directoryInfo = new DirectoryInfo(newdir);
if (!directoryInfo.Exists) directoryInfo.Create();
// get file htm or html from directory
string[] files = Directory.GetFiles(dir, "*.htm*");
// string[] files = Directory.GetFiles(dir, "*.htm", SearchOption.AllDirectories);

foreach (string file in files)
{
    FileInfo fileInfo = new FileInfo(file);
    // if (fileInfo.Name != "0034_creating_family_symbol.htm")
    // {
    //     Console.WriteLine(fileInfo.Name);
    //     continue;
    // }

    Console.WriteLine(file);
    // read all string in file 
    // Create an instance of SaveOptions and set up the rule: 
    // - only <a> and <p> elements will be converted to markdown.
    var options = new Aspose.Html.Saving.MarkdownSaveOptions();
    options.Formatter = MarkdownFormatter.Git;
    //                    Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;
    string fileOutput = String.Empty;
    if (fileInfo.Name.EndsWith(".htm"))
    {
        fileOutput = Path.Combine(newdir, fileInfo.Name.Replace(".htm", ".md"));
    }

    if (fileInfo.Name.EndsWith(".html"))
    {
        fileOutput = Path.Combine(newdir, fileInfo.Name.Replace(".html", ".md"));
    }
    // Call the ConvertHTML method to convert the HTML to Markdown.

    Aspose.Html.Converters.Converter.ConvertHTML(file, options, fileOutput);

    //Process.Start(fileOutput);
    //break;
}

Console.WriteLine("Done");
Console.ReadKey();