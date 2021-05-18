using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerDataModelTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void RecordBestAttemptTest()

        {
           //here we will get the reference from the PlayerDataModel of the bestattempt
           int bestAttempt = PlayerPrefs.GetInt("RecordAttempt");
           
            Assert.AreEqual(bestAttempt, PlayerPrefs.GetInt("RecordAttempt"));
        }
        [Test]
        public void RecordBestTimingTest()
        {
           
           int recordTiming = PlayerPrefs.GetInt("RecordTiming");
           
            Assert.AreEqual(recordTiming, PlayerPrefs.GetInt("RecordTiming"));
        }
        [Test]
        public void CurrentBestAttemptTest()
        {
           
           int recordTiming = PlayerPrefs.GetInt("RecordAttempt");
           
            Assert.AreEqual(recordTiming, PlayerPrefs.GetInt("RecordAttempt"));
        }
        [Test]
        public void BlindRecordBestAttemptTest()

        {
           //here we will get the reference from the PlayerDataModel of the bestattempt
           int bestAttempt = PlayerPrefs.GetInt("BlindRecordAttempt");
           
            Assert.AreEqual(bestAttempt, PlayerPrefs.GetInt("BlindRecordAttempt"));
        }
        [Test]
        public void BlindRecordBestTimingTest()
        {
           
           int recordTiming = PlayerPrefs.GetInt("BlindRecordTiming");
           
            Assert.AreEqual(recordTiming, PlayerPrefs.GetInt("BlindRecordTiming"));
        }
        [Test]
        public void BlindCurrentBestAttemptTest()
        {
           
           int recordTiming = PlayerPrefs.GetInt("BlindRecordAttempt");
           
            Assert.AreEqual(recordTiming, PlayerPrefs.GetInt("BlindRecordAttempt"));
        }
        
        
    }
}
