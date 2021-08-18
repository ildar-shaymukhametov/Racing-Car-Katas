using System;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public interface IFileReader
    {
        string Read(string filename);
    }

    public class UnicodeFileToHtmlTextConverter
    {
        private readonly IFileReader fileReader;

        public UnicodeFileToHtmlTextConverter(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public string ConvertToHtml(string fullFilenameWithPath)
        {
            var text = fileReader.Read(fullFilenameWithPath);
            var html = HttpUtility.HtmlEncode(text).Replace(Environment.NewLine, "<br />");
            return html;
        }
    }
    class HttpUtility
    {
        public static string HtmlEncode(string line)
        {
            line = line.Replace("&", "&amp;");
            line = line.Replace("<", "&lt;");
            line = line.Replace(">", "&gt;");
            line = line.Replace("\"", "&quot;");
            line = line.Replace("\'", "&quot;");
            return line;
        }
    }
}
