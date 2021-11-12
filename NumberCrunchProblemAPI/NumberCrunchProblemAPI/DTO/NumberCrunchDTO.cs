using System;
using System.Collections.Generic;

namespace NumberCrunchProblemAPI
{
    public class ResultSet
    {
        public int SampleNumber { get; set; }
        public string SampleScoreDesc { get; set; }

        public int SampleScore { get; set; }

        public ResultSet()
        {
            SampleScore = 0;
            SampleScoreDesc = "None";
        }
    }
    public class ResultQuery
    {
        public int MaxSample { get; set; }
        public int DoctorScore { get; set; }
        public int PatientScore { get; set; }
    }
}
