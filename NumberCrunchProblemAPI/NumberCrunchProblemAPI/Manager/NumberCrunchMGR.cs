using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberCrunchProblemAPI.Manager
{
    public class NumberCrunchMGR
    {
        public interface IQueryResolver
        {
            //Allow for scoring based on the specific type so that if we needed to Doctor and Patient could score differently 
            List<ResultSet> generateSet(int sampleMax, int score);
            ResultSet scoreSample(int currentSample, int score);
        }

        public class DoctorResolver : IQueryResolver
        {
            public List<ResultSet> generateSet(int sampleMax, int score)
            {
                List<ResultSet> resultList = new List<ResultSet>();

                for (int i = 1; i <= sampleMax; i++)
                {
                    resultList.Add(scoreSample(i,score));
                }

                return resultList;

            }

            public ResultSet scoreSample(int currentSample, int score)
            {
                ResultSet result = new ResultSet();
                result.SampleNumber = currentSample;
                if (currentSample % score == 0)
                {
                    result.SampleScoreDesc = "Doctor";
                    result.SampleScore = 1;
                }
                return result;
            }
        }

        public class PatientResolver : IQueryResolver
        {
            public List<ResultSet> generateSet(int sampleMax, int score)
            {
                List<ResultSet> resultList = new List<ResultSet>();

                for (int i = 1; i <= sampleMax; i++)
                {
                    resultList.Add(scoreSample(i, score));
                }

                return resultList;
            }

            public ResultSet scoreSample(int currentSample, int score)
            {
                ResultSet result = new ResultSet();
                result.SampleNumber = currentSample;
                if (currentSample % score == 0)
                {
                    result.SampleScoreDesc = "Patient";
                    result.SampleScore = 1;
                }
                return result;
            }
        }

        public List<ResultSet> generateResults(ResultQuery query)
        {
            List<ResultSet> doctorResults = new List<ResultSet>();
            DoctorResolver docResolver = new DoctorResolver();
            doctorResults = docResolver.generateSet(query.MaxSample, query.DoctorScore);
            docResolver = null;

            List<ResultSet> patientResults = new List<ResultSet>();
            PatientResolver patientResolver = new PatientResolver();
            patientResults = patientResolver.generateSet(query.MaxSample, query.PatientScore);
            patientResolver = null;

            return CrunchSets(doctorResults, patientResults);
        }

        public List<ResultSet> CrunchSets(List<ResultSet> set1, List<ResultSet> set2)
        {
            for (int i = 0; i < set1.Count; i++)
            {
                //both zero
                if (set1[i].SampleScore == set2[i].SampleScore && set1[i].SampleScore == 0)
                {
                    set1[i].SampleScoreDesc = "None";
                    continue;
                }
                //both same score
                if (set1[i].SampleScore == set2[i].SampleScore && set1[i].SampleScore != 0)
                {
                    set1[i].SampleScoreDesc = "Both";
                    continue;
                }
                //set2 score higher than set1;
                if (set1[i].SampleScore < set2[i].SampleScore)
                {
                    set1[i].SampleScoreDesc = set2[i].SampleScoreDesc;
                    set1[i].SampleScore = set2[i].SampleScore;
                    continue;
                }
            }
            
            return set1;
        }
    }
}
