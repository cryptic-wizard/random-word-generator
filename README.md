## Description
* A nuget package to generate random words
* Useful for:
  * Username generation
  * Random word stories
## Tests
[![.NET](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/dotnet.yml)

[![.NET Core](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/dotnetcore.yml/badge.svg)](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/dotnetcore.yml)

## Usage
Includes:
```C#
using RandomWordGenerator; //required
using static RandomWordGenerator.WordGenerator; //for brevity, not required
```

GetWord()
```C#
WordGenerator wordGenerator = new WordGenerator();
string word = wordGenerator.GetWord(PartOfSpeech.noun);
Console.WriteLine(word);
```
```Text
jewel
```

GetWords()
```C#
WordGenerator wordGenerator = new WordGenerator();

List<string> adv = wordGenerator.GetWords(PartOfSpeech.adv, 10);
List<string> adj = wordGenerator.GetWords(PartOfSpeech.adj, 10);
List<string> noun = wordGenerator.GetWords(PartOfSpeech.noun, 10);

for(int i = 0; i < 10; i++)
{
    Console.WriteLine(adv[i] + ' ' + adj[i] + ' ' + noun[i]);
}
```
```Text
clearly calm bandana
doubtfully majestic pizza
faithfully acidic bat
freely bustling earthquake
hastily corrupt cake
jealously poised harmony
lively golden lizard
mechanically foolish mitten
successfully spherical scooter
upbeat salty soldier
```

IsPartOfSpeech()
```C#
WordGenerator wordGenerator = new WordGenerator();
bool isPartOfSpeech = wordGenerator.IsPartOfSpeech("ball", PartOfSpeech.noun);
Console.WriteLine(isPartOfSpeech);
```
```Text
true
```

## Planned Features
* Patterns
* Other languages are not planned but can be added as .txt files in a folder of the language abreviation
  * ES
  * FR
  * etc.

## Tools
* [Visual Studio](https://visualstudio.microsoft.com/vs/)
* [NUnit 3](https://nunit.org/)
* [SpecFlow](https://specflow.org/tools/specflow/)
* [SpecFlow+ LivingDoc](https://specflow.org/tools/living-doc/)
* [Run SpecFlow Tests](https://github.com/marketplace/actions/run-specflow-tests)
## License
* [MIT License](https://github.com/cryptic-wizard/random-word-generator/blob/main/LICENSE.md)
