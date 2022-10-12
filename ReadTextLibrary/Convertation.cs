namespace ReadTextLibrary;

public class Convertation
{
	private Dictionary<string, int> DictionaryConvert(string[] words)
	{
		Dictionary<string, int> dictionary = new();
		foreach (string word in words) {
			if (!dictionary.ContainsKey(word)) {
				dictionary.Add(word, 1);
			} else {
				dictionary[word]++;
			}
		}
		Console.WriteLine("WOW!!! I RUNING!");
		return dictionary;
	}
}