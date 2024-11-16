using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CodeMechanic.RegularExpressions;

namespace CodeMechanic.FileSystem;

public class Grepper
{
    public Grepper() => Recursive = true;

    public string RootPath { get; set; }
    public bool Recursive { get; set; }

    // e.g. an extension might be *.xml,*.aspx,.*.csv...
    public string FileSearchMask { get; set; } = @"**.*";

    // e.g. a phone might be:  \d{3,}-\d{3,}-\d{4,}
    public string FileSearchLinePattern { get; set; } = string.Empty;

    // NOTE! I WANT To keep this null by default b/c an empty Regex will pickup EVERYTHING.
    // public RegexEnumBase FileSearchLineRegex { get; set; }

    public string FileNamePattern { get; set; } = @".*";

    public IEnumerable<string> GetFileNames()
    {
        if (!Directory.Exists(RootPath))
            throw new ArgumentException("GetFileNames() -- Can't find RootPath!");

        if (string.IsNullOrWhiteSpace(FileSearchMask))
            throw new ArgumentException(
                $"GetFileNames() -- {nameof(FileSearchMask)} is empty; use *.*!"
            );

        var searchOptions = Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

        // If multiple:
        if (FileSearchMask.Contains(','))
        {
            string[] masks = FileSearchMask.Split(',').Select(m => m.Trim()).ToArray();
            var results = Directory
                .EnumerateFiles(RootPath, masks[0], searchOptions)
                .Where(path => System.Text.RegularExpressions.Regex.IsMatch(path, FileNamePattern));

            if (masks.Length > 1)
            {
                for (int index = 1; index < masks.Length; index++)
                {
                    results = results.Concat(
                        Directory.EnumerateFiles(RootPath, masks[index], searchOptions)
                    );
                }
            }

            return results;
        }

        // If only one:
        var files = Directory
            .EnumerateFiles(RootPath, FileSearchMask, searchOptions)
            .Where(path => System.Text.RegularExpressions.Regex.IsMatch(path, FileNamePattern));

        return files;
    }

    private static string empty_is_bad_reason =
        " cannot be empty!  Leaving this pattern empty will return too many results!";

    public IEnumerable<GrepResult> GetMatchingFiles(RegexEnumBase regex_enum = null)
    {
        var options =
            RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline;
        Regex rgx =
            regex_enum != null
                ? regex_enum.CompiledRegex
                : new Regex(FileSearchLinePattern, options);

        int lineNumber = 0;
        foreach (var filePath in GetFileNames())
        {
            var lines = File.ReadAllLines(filePath);
            int total_lines = lines.Length;
            foreach (var line in lines)
            {
                // old way:
                // System.Text.RegularExpressions.Regex.Match(line, FileSearchLinePattern).Success
                if (rgx.IsMatch(line))
                    yield return new GrepResult()
                    {
                        FilePath = filePath,
                        FileName = Path.GetFileName(filePath),
                        LineNumber = lineNumber,
                        Line = line,
                        LineCount = total_lines,
                    };

                lineNumber++;
            }
        }
    }

    public class GrepResult
    {
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public int LineNumber { get; set; }
        public int LineCount { get; set; }

        public override string ToString() => $"--file {FilePath}:{LineNumber}";
    }
}
