public class CaseAlternatorTask
{
	//Практика "Перебор паролей 2"
	
    public static List<string> AlternateCharCases(string lowercaseWord)
    {
        var result = new List<string>();
        AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
        return result;
    }

    static void AlternateCharCases(char[] word, int startIndex, List<string> result)
    {
        if (startIndex == word.Length)
        {
            result.Add(new string(word));
            return;
        }
        word[startIndex] = char.ToLower(word[startIndex]);
        if (char.ToLower(word[startIndex]) != char.ToUpper(word[startIndex]) && 
            char.IsLetter(word[startIndex]))
        {
            AlternateCharCases((char[])word.Clone(), startIndex + 1, result);
            word[startIndex] = Char.ToUpper(word[startIndex]);
        }
        AlternateCharCases((char[])word.Clone(), startIndex + 1, result);
    }
}