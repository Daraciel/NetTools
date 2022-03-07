using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetTools.Tests
{
    public class DeckTests
    {
        [Fact]
        public void ShuffleTest()
        {
            Deck<String> myDeck = null;
            List<String> original = null;
            List<String> shuffled = null;

            myDeck = new Deck<String>();

            for(int i = 0; i < 10; i++)
            {
                myDeck.Add(i.ToString());
            }

            original = myDeck.ToList();
            myDeck.Shuffle();
            shuffled = myDeck.ToList();

            Assert.NotEqual(original, shuffled);
        }
    }
}
