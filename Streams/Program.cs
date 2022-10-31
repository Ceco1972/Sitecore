using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //look for the word "photo" in the file "Photo_Contest.docx" on my desktop."

        string filet = @"C:\Users\User\Desktop\Photo_Contest.docx";
        WordCount wc = new WordCount(filet);
        var number = wc.Count;
        Console.WriteLine(number);
    }
}
public class WordCount
{
    private String filename = String.Empty;
    private int nWords = 0;
    private String pattern = @"\b[photo]\w+";

    public WordCount(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException("The file does not exist.");

        this.filename = filename;
        string txt = String.Empty;
        using (StreamReader sr = new StreamReader(filename))
        {
            txt = sr.ReadToEnd();
        }
        nWords = Regex.Matches(txt, pattern).Count;
    }

    public string FullName
    { get { return filename; } }

    public string Name
    { get { return Path.GetFileName(filename); } }

    public int Count
    { get { return nWords; } }

    
}

 