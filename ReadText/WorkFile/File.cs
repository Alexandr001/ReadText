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

	public void WriteText(Dictionary<string, int> dictionary, string path)
	{
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

	private static bool DictionaryValidation(KeyValuePair<string, int> pair)
	{
		const int MIN_NUMBER_OF_USES_THE_WORD = 2;
		const int MINIMUM_WORD_LENGTH = 4;
		
		return !((pair.Value <= MIN_NUMBER_OF_USES_THE_WORD) || (pair.Key.Length < MINIMUM_WORD_LENGTH));
	}
}