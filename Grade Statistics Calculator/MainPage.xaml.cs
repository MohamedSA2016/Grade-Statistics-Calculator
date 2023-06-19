using System;
using System.Collections.Generic;
using System.Linq;

namespace Grade_Statistics_Calculator
{
    public partial class MainPage : ContentPage
    {
        private List<double> scores = new List<double>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAddScoreClicked(object sender, EventArgs e)
        {
            string input = scoreEntry.Text;
            string[] scoreStrings = input.Split(',');

            foreach (string scoreString in scoreStrings)
            {
                if (double.TryParse(scoreString.Trim(), out double score))
                {
                    scores.Add(score);
                }
                else
                {
                    DisplayAlert("Error", $"Invalid score entered: {scoreString}", "OK");
                    return;
                }
            }

            scoreEntry.Text = string.Empty;
            CalculateStatistics();
        }

        private void CalculateStatistics()
        {
            if (scores.Count > 0)
            {
                double averageScore = scores.Average();
                averageLabel.Text = $"Average Score: {averageScore:F2}";

                double minimumScore = scores.Min();
                minimumLabel.Text = $"Minimum Score: {minimumScore:F2}";

                double maximumScore = scores.Max();
                maximumLabel.Text = $"Maximum Score: {maximumScore:F2}";

                double medianScore = CalculateMedian();
                medianLabel.Text = $"Median Score: {medianScore:F2}";
            }
            else
            {
                ClearStatisticsLabels();
            }
        }

        private double CalculateMedian()
        {
            List<double> sortedScores = scores.OrderBy(x => x).ToList();
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

        private void ClearStatisticsLabels()
        {
            averageLabel.Text = string.Empty;
            minimumLabel.Text = string.Empty;
            maximumLabel.Text = string.Empty;
            medianLabel.Text = string.Empty;
        }
    }
}
