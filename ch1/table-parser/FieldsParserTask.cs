using System.Collections.Generic;
using System.Linq;

namespace TableParser
{
    public class FieldsParserTask
    {
        public static List<string> ParseLine(string line)
        {
            var result = new List<string>();
            int i = 0;
            while (i < line.Length)
            {
                i = Spaces(line, i).GetIndexNextToToken();
                if (i == line.Length)
                {
                    return result;
                }
                else
                {
                    var newField = ReadField(line, i);
                    result.Add(newField.Value);
                    i += newField.Length;
                }
            }
            return result;
        }

        private static Token Spaces(string line, int position)
        {
            string spacesString = "";
            int i = position;
            while (i < line.Length && (line[i] == ' ' || line[i] == '\t'))
            {
                spacesString += line[i];
                i++;
            }
            return new Token(spacesString, position, spacesString.Length);
        }

        private static Token ReadField(string line, int startIndex)
        {
            Token field;
            if (line[startIndex] == '"' || line[startIndex] == '\'')
            {
                field = FieldsInQuotes(line, startIndex, line[startIndex]);
            }
            else
            {
                field = SimpleField(line, startIndex);
            }
            return field;
        }
        private static Token SimpleField(string line, int startIndex)
        {
            var separateArray = new char[] { '\'', '"', ' ' };
            string newSimpleField = "";
            int i = startIndex;
            while (i < line.Length && !separateArray.Contains(line[i]))
            {
                newSimpleField += line[i];
                i++;
            }
            return new Token(newSimpleField, startIndex, newSimpleField.Length);
        }
        private static Token FieldsInQuotes(string line, int startIndex, char endCharInField)
        {
            string newQuotesField = "";
            int i = startIndex + 1;
            int slashes = 0;
            while (i < line.Length && line[i] != endCharInField)
            {
                if (line[i] == '\\')
                {
                    i++;
                    slashes++;
                }
                newQuotesField += line[i];
                i++;
            }
            return new Token(newQuotesField, startIndex, newQuotesField.Length + 2 + slashes);
        }
    }
}