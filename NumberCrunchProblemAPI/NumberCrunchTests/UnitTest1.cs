using NumberCrunchProblemAPI;
using NumberCrunchProblemAPI.Manager;
using NUnit.Framework;
using System.Collections.Generic;

namespace NumberCrunchTests
{
    public class Tests
    {
        private ResultQuery rQuery;

        [SetUp]
        public void Setup()
        {
            rQuery = new ResultQuery();
           
        }

        [TestCase(15, 5, 3)]
        [TestCase(25, 7, 2)]
        [TestCase(35, 2, 8)]
        [TestCase(12,3,4)]
        public void NoFailure(int max, int doc, int patient)
        {
            rQuery.DoctorScore = doc;
            rQuery.PatientScore = patient;
            rQuery.MaxSample = max;
            NumberCrunchMGR mgr = new NumberCrunchMGR();
            List<ResultSet> list = mgr.generateResults(rQuery);
            Assert.Pass();
        }

        [TestCase(9, 3)]
        public void checkScoreComparisonDoctor_True(int currentSample, int score)
        {
            NumberCrunchMGR.DoctorResolver doctorResolver = new NumberCrunchMGR.DoctorResolver();
            ResultSet result = doctorResolver.scoreSample(currentSample, score);
            Assert.AreEqual("Doctor",result.SampleScoreDesc);
        }
        //I would add more test cases but it's currently 1:46AM and I'm very tired.

    }
}