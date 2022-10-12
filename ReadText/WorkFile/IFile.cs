namespace ReadText.WorkFile;

public interface IFile
{
	string[] ReadText(string path);
	void WriteText(Dictionary<string, int> dictionary, string path);
}