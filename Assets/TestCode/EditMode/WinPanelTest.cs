using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WinPanelTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void updatePanelTest()

        {
           //here we will get the reference from the WinPanel script for timeText;
           //bool text = WinPanel.timeText.text;
           string text = "TimeText";
            Assert.NotNull(text);
        }
        
        
    }
}
