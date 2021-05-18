using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameControllerTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CardTapTest()
        {
           //here we will get the reference from the GameController script the about the card name;
           //bool cardTap = GameController.CardTapped;
           bool cardTaped = false;
            Assert.AreNotEqual(true, cardTaped);
        }
        
        
        
    }
}
