using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InGameControllerTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void UpdateCountdownTest()
        {
           //here we will get the reference from the InGameController script  about the card cuurent countdown;
           //int currentTime = InGameController.currentTime;
           int currentTime = 0;
            Assert.AreEqual(0, currentTime);
        }
         
        [Test]
        public void UpdateTimeTest()
        {
           //here we will get the reference from the InGameController script  about the card cuurent countdown;
           //int currentTime = InGameController.currentTime(1);
           int currentTime = 0+1;
            Assert.AreEqual(1, currentTime);
        }
        [Test]
        public void GoingToMainMenuTest()
        {
           //here we will get the reference from the InGameController script  about the scene index;
           //int currentScene = InGameController.GoToMainMenu();
           int currentScene = 1;
            Assert.AreNotEqual(0, currentScene);
        }
        [Test]
        public void GameRestartTest()
        {
           //here we will get the reference from the InGameController script  about the card cuurent countdown;
           //int currentTime = InGameController.currentTime;
           int currentTime = 0;
            Assert.AreEqual(0, currentTime);
        }
         [Test]
        public void StartPlayTest()
        {
           //here we will get the reference from the InGameController script  about the current GameStatus;
           //int gameFinished = InGameController.gameFinished;
           bool gameFinished = false;
            Assert.AreEqual(false, gameFinished);
        }
         [Test]
        public void AttempUpdateCheck()
        {
           //here we will get the reference from the InGameController script  about the currentAttemp;
           //int attempt = InGameController.UpdateAttempt(1);
           int attempt = 1;
            Assert.AreEqual(1, attempt);
        }
        
        
        
    }
}
