// Были сделаны ограничения для уменьшения списска слов.

using System.Reflection;
using ReadText.WorkFile;
using ReadTextLibrary;
using File = ReadText.WorkFile.File;

const string PATH_SOURCE_FILE = @"Text.txt";
const string PATH_NEW_FILE = @"NewFile.txt";

IFile file = new File();
string[] readText = file.ReadText(PATH_SOURCE_FILE);
Convertation convertation = new();

MethodInfo? print = typeof(Convertation).GetMethod("DictionaryConvert",
                                                   BindingFlags.Instance |
                                                   BindingFlags.NonPublic);

if (print?.Invoke(convertation, new object?[] {readText}) is Dictionary<string, int> dictionary) {
 file.WriteText(dictionary, PATH_NEW_FILE);
}

/*
 1------------------
select * from Employee
where salarey = 
		(SELECT MAX(salarey) from Employee);
 2--------------------- вывести отдел с максимальной зп сотрудника
select Dep.* from Depatment, Employee
where salarey = 
(SELECT MAX(salarey) from Employee)
and Depatment.id = Employee.dep_id;
 3--------------------
with sum_salary as
( 
select dep_id, sum(salarey) salarey from Employee
group  by dep_id
)
select d.*, s.salarey from sum_salary s, Depatment d  
where  s.salarey =
( select max(salarey) from sum_salary )
  and s.dep_id = d.id;
 4----------------------------------
select * from Employee
where [name] LIKE N'Р%н';
*/