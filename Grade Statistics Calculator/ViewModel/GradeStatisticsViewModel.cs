using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Grade_Statistics_Calculator.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private List<double> scores = new List<double>();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<double> Scores
        {
            get { return scores; }
            set
            {
                scores = value;
                OnPropertyChanged(nameof(Scores));
                CalculateStatistics();
            }
        }

        private double averageScore;
        public double AverageScore
        {
            get { return averageScore; }
            set
            {
                averageScore = value;
                OnPropertyChanged(nameof(AverageScore));
            }
        }

        private double minimumScore;
        public double MinimumScore
        {
            get { return minimumScore; }
            set
            {
                minimumScore = value;
                OnPropertyChanged(nameof(MinimumScore));
            }
        }

        private double maximumScore;
        public double MaximumScore
        {
            get { return maximumScore; }
            set
            {
                maximumScore = value;
                OnPropertyChanged(nameof(MaximumScore));
            }
        }

        private double medianScore;
        public double MedianScore
        {
            get { return medianScore; }
            set
            {
                medianScore = value;
                OnPropertyChanged(nameof(MedianScore));
            }
        }

        public void AddScores(string input)
        {
            string[] scoreStrings = input.Split(',');

            foreach (string scoreString in scoreStrings)
            {
                if (double.TryParse(scoreString.Trim(), out double score))
                {
                    Scores.Add(score);
                }
            }

            CalculateStatistics();
        }

        private void CalculateStatistics()
        {
            if (Scores.Count > 0)
            {
                AverageScore = Scores.Average();
                MinimumScore = Scores.Min();
                MaximumScore = Scores.Max();
                MedianScore = CalculateMedian();
            }
            else
            {
                ClearStatistics();
            }
        }

        private double CalculateMedian()
        {
            List<double> sortedScores = Scores.OrderBy(x => x).ToList();
            int count = sortedScores.Count;

            if (count % 2 == 0)
            {
                int midIndex1 = count / 2 - 1;
                int midIndex2 = count / 2;
                return (sortedScores[midIndex1] + sortedScores[midIndex2]) / 2;
            }
            else
            {
                int midIndex = count / 2;
                return sortedScores[midIndex];
            }
        }

        private void ClearStatistics()
        {
            AverageScore = 0;
            MinimumScore = 0;
            MaximumScore = 0;
            MedianScore = 0;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
