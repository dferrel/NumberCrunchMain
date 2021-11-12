using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberCrunchProblem.Models
{
    public class ResultsModel
    {
        public int MaxResults { get; set; }
        public int DoctorScore { get; set; }
        public int PatientScore { get; set; }

        public ResultsModel()
        {

        }

        public ResultsModel(int inMaxResults, int inDoctorScore, int inPatientScore)
        {
            MaxResults = inMaxResults;
            DoctorScore = inDoctorScore;
            PatientScore = inPatientScore;
        }
    }
}
