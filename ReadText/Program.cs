// Были сделаны ограничения для уменьшения списска слов.
using ReadText.WorkFile;
using File = ReadText.WorkFile.File;

const string PATH_SOURCE_FILE = @"Text.txt";
const string PATH_NEW_FILE = @"NewFile.txt";

IFile file = new File();
string[] readText = file.ReadText(PATH_SOURCE_FILE);
file.WriteText(readText, PATH_NEW_FILE);