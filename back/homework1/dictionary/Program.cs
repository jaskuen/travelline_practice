// TODO: сейчас программа уязвима к множественным пробелам между словами
using System.Text.RegularExpressions;
using dictionary.DictionaryCommandsList;

Dictionary<string, string> wordsDictionary = new();


Console.WriteLine("Русско-английский словарь.");
Console.WriteLine("Пробел разделяет команды и разные слова, вместо пробела для слов используется символ _");
Console.WriteLine("Список команд: " +
                  $"\n\r{DictionaryCommandList.CommandAddTranslation} <русский> <английский> - добавить перевод слова" +
                  $"\n\r{DictionaryCommandList.CommandRemoveTranslation} <русский> - удалить перевод слова" +
                  $"\n\r{DictionaryCommandList.CommandChangeTranslation} <русский> <английский> - изменить перевод уже существующего слова" +
                  $"\n\r{DictionaryCommandList.CommandTranslate} <русский> - перевести слово" +
                  $"\n\r{DictionaryCommandList.CommandExit} - выйти из программы");

string userRequest;
string command;
string russianWord = "";
string englishWord = "";
bool usingDictionary = true;
while (usingDictionary) 
{
    userRequest = Console.ReadLine().Trim();
    MatchCollection matches = Regex.Matches(userRequest, @"\b[\w-]+(?:_\w+)*\b");
    if (matches.Count >= 3)
    {
        command = matches[0].Value.ToLower();
        russianWord = matches[1].Value.ToLower();
        englishWord = matches[2].Value.ToLower();
    }
    else if (matches.Count >= 2)
    {
        command = matches[0].Value.ToLower();
        russianWord = matches[1].Value.ToLower();
    }
    else
    {
        command = matches[0].Value.ToLower();
    }

    if (command == CommandAddTranslation)
    {
        if (!dictionary.ContainsKey(russianWord))
        {
            dictionary.Add(russianWord, englishWord);
            Console.WriteLine("Успешно!");
        }
        else 
        {
            Console.WriteLine($"{russianWord} уже есть в словаре, его перевод - {englishWord}");
        }
    }
    else if (command == CommandRemoveTranslation) 
    {
        if (dictionary.ContainsKey(russianWord))
        {
            dictionary.Remove(russianWord);
            Console.WriteLine("Успешно!");
        }
        else
        {
            Console.WriteLine($"{russianWord} отсутствует в словаре");
        }
    }
    else if (command == CommandChangeTranslation) 
    {
        if (dictionary.ContainsKey(russianWord))
        {
            dictionary[russianWord] = englishWord;
            Console.WriteLine("Успешно!");
        }
        else
        {
            Console.WriteLine($"{russianWord} отсутствует в словаре");
        }
    }
    else if (command == CommandTranslate)
    {
        if (dictionary.ContainsKey(russianWord))
        {
            Console.WriteLine($"{russianWord} переводится как {dictionary[russianWord]}");
        }
        else
        {
            Console.WriteLine($"{russianWord} отсутствует в словаре");
        }
    }
    else if (command == CommandExit.ToLower())
    {
        usingDictionary = false;
    }
    else { Console.WriteLine("Данная команда не найдена"); }
}