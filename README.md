# random-word-generator
[![nuget](https://img.shields.io/badge/nuget-v0.9.3-blue)](https://www.nuget.org/packages/CrypticWizard.RandomWordGenerator)
## Description
* A random word generator for .NET and .NET Core
* Useful for:
  * Username generation
  * Random word stories
## Tests
[![.NET 5.0](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/dotnet.yml)

[![.NET Core 3.1](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/dotnetcore.yml/badge.svg)](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/dotnetcore.yml)

[![Nuget Publish](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/nuget.yml/badge.svg)](https://github.com/cryptic-wizard/random-word-generator/actions/workflows/nuget.yml)

## Usage
### Install Package:
```Text
dotnet add package CrypticWizard.RandomWordGenerator
```
```xml
<PackageReference Include="CrypticWizard.RandomWordGenerator" Version="0.9.3"/>
```

### Include Package:
```C#
using CrypticWizard.RandomWordGenerator;
using static CrypticWizard.RandomWordGenerator.WordGenerator; //for brevity, not required
```

### GetWord( )
```C#
WordGenerator myWordGenerator = new WordGenerator();
string word = myWordGenerator.GetWord(PartOfSpeech.noun);
```
```Text
jewel
```

### GetWords( )
```C#
WordGenerator myWordGenerator = new WordGenerator();
List<string> advs = myWordGenerator.GetWords(PartOfSpeech.adv, 5);
```
```Text
abnormally
boastfully
daintily
shakily
surprisingly
```

### IsWord ()
```C#
WordGenerator myWordGenerator = new WordGenerator();
bool isWord = myWordGenerator.IsWord("exemplary");
```
```Text
true
```

### IsPartOfSpeech( )
```C#
WordGenerator myWordGenerator = new WordGenerator();
bool isPartOfSpeech = myWordGenerator.IsPartOfSpeech("ball", PartOfSpeech.noun);
```
```Text
true
```

### GetPatterns( )
```C#
WordGenerator myWordGenerator = new WordGenerator();

List<PartOfSpeech> pattern = new List<PartOfSpeech>();
pattern.Add(PartOfSpeech.adv);
pattern.Add(PartOfSpeech.adj);
pattern.Add(PartOfSpeech.noun);

List<string> patterns = myWordGenerator.GetPatterns(pattern, ' ', 10);
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

## Features
### Recently Added
* v0.9.3 - package prefix
* v0.9.2 - IsWord()
#### Planned Features
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
