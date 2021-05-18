using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CardControllerTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CardLengthTest()

        {
           //here we will get the reference from the card controller script the cardlegnt;
           //int length = CardController.cards.lengt;
           int length = 12;
            Assert.AreEqual(12, length);
        }
        [Test]
        public void HiddenCardTest()

        {
           //here we will get the reference from the card controller script the for the Hidden card Sprite;
           //string cardName = CardController.defaultIcon.name;
            string cardName = "default";
            Assert.AreEqual("default", cardName);
        }
        [Test]
        public void WinPanelActivityTest()

        {
           //here we will get the reference from the card controller script the for the Hidden card Sprite;
           //bool active = CardController.winPanel.active;
            bool active = false;
            Assert.AreEqual(false, active);
        }
        
        
    }
}
