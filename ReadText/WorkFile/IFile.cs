namespace ReadText.WorkFile;

public interface IFile
{
	string[] ReadText(string path);
	void WriteText(string[] text, string path);
}