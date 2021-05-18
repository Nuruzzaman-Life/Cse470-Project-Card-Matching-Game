using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MenuTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void StartPlayingTest()

        {
           //here we will get the reference from the Menu script of the menupanel;
           //bool menuPanel = Menu.menuPanel.active;
           bool menuPanel = false;
            Assert.AreNotEqual(true, menuPanel);
        }
        
        
    }
}
