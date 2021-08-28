using NUnit.Framework;
using RandomWordGenerator;
using static RandomWordGenerator.WordGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RandomWordGeneratorTest
{
    public class WordGeneratorFixture
    {
        public List<string> words;
        public string word;
        public List<PartOfSpeech> partsOfSpeech;
        public List<PartOfSpeech> pattern;
        public char delimiter;
        public bool myBool;

        public WordGeneratorFixture()
        {

        }
    }
}
