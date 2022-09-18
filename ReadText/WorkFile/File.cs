using System.Text.RegularExpressions;

namespace ReadText.WorkFile;

public class File : IFile
{
	public string[] ReadText(string path)
	{
		const string REGEX_PATTERN = @"\W+";
		string text = System.IO.File.ReadAllText(path);
		text = text.ToLower();
		string[] words = Regex.Split(text, REGEX_PATTERN);
		return words;
	}

	public void WriteText(string[] text, string path)
	{
		Dictionary<string, int> dictionary = DictionaryFormation(text);
		using (StreamWriter writer = new(path, false)) {
			foreach (KeyValuePair<string, int> pair in dictionary.OrderByDescending(pair => pair.Value))
			{
				if (DictionaryValidation(pair) == false) {
					dictionary.Remove(pair.Key);
				} else {
					writer.WriteLine($"{pair.Key}\t{pair.Value}");
				}
			}
		}
	}

	private static Dictionary<string, int> DictionaryFormation(string[] words)
	{
		Dictionary<string, int> dictionary = new();
		foreach (string word in words) {
			if (!dictionary.ContainsKey(word)) {
				dictionary.Add(word, 1);
			} else {
				dictionary[word]++;
			}
		}
		return dictionary;
	}

	private static bool DictionaryValidation(KeyValuePair<string, int> pair)
	{
		const int MIN_NUMBER_OF_USES_THE_WORD = 2;
		const int MINIMUM_WORD_LENGTH = 4;
		
		return !((pair.Value <= MIN_NUMBER_OF_USES_THE_WORD) || (pair.Key.Length < MINIMUM_WORD_LENGTH));
	}
}