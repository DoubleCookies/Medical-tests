using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalTests
{
    static class ProcessingMethods
    {
        private static readonly string[] answerProcPositive = new string[] { "value for shift", "~%100%", "~%50%", "~%33.333%", "~%25%", "~%20%", "~%16.666%", "~%14.289%", "~%12.5%", "~%11.111%", "~%10%", "~%9.091%", "~%8.333%" };
        private static readonly string[] answerProcNegative = new string[] { "value for shift", "~%-100%", "~%-50%", "~%-33.333%", "~%-25%", "~%-20%", "~%-16.666%", "~%-14.289%", "~%-12.5%", "~%-11.111%", "~%-10%", "~%-9.091%", "~%-8.333%" };

        private static string resultText;

        public static string ProcessFormat1(string text, int startNum)
        {
            resultText = "";
            string[] tasks = text.Split(new string[] { "***\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tasks.Length; i++)
            {
                string taskRes = $"::Q-{startNum + i}::";
                string[] taskStrings = tasks[i].Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);

                int answersCount = 0;

                string question = taskStrings[0].Trim();
                string formattedQuestion = ProcessQuestionFormat1(question, ref answersCount);
                taskRes += formattedQuestion;

                string answers = taskStrings[taskStrings.Length - 1].Trim();
                int[] answersNumbersArray = GetAnswerNumbers(answers);

                string answersText = ProcessAnswers(taskStrings, answersNumbersArray);
                taskRes += answersText + "}\r\n\r\n";

                resultText += taskRes;
            }
            return resultText;
        }

        private static string ProcessQuestionFormat1(string question, ref int answersCount) {
            int braceLeft = question.LastIndexOf('(');
            int braceRight = question.LastIndexOf(')');
            int tabPosition = question.IndexOf('\t');
            answersCount = int.Parse(question.Substring(braceLeft + 1, braceRight - braceLeft - 1));
            string formattedQuestion = question.Substring(tabPosition + 1, braceLeft - tabPosition - 2).TrimEnd() + " {\r\n";
            return formattedQuestion;
        }

        private static int[] GetAnswerNumbers(string answers) {
            answers = answers.Replace("Ответ", "").Trim().Replace("ответ", "").Trim().Replace("(", "").Replace(")", "").Trim();
            string[] answersNumbers = answers.Split(',');
            int[] answersNumbersArray = Array.ConvertAll(answersNumbers, int.Parse);
            return answersNumbersArray;
        }

        private static string ProcessAnswers(string[] taskStrings, int[] answerNumbers) {
            string answersText = "";
            for (int j = 1; j < taskStrings.Length - 1; j++)
            {
                string answerString = taskStrings[j].Substring(j.ToString().Length + 1).Trim();
                if (answerNumbers.Length == 1)
                {
                    answersText += answerNumbers.Contains(j) ? "=" : "~";
                    answersText += answerString + "\r\n";
                }
                else
                {
                    int positive = answerNumbers.Length;
                    int negative = taskStrings.Length - 2 - positive;

                    answersText += answerNumbers.Contains(j) ? answerProcPositive[positive] : answerProcNegative[negative];
                    answersText += answerString + "\r\n";
                }
            }
            return answersText;
        }

        public static string ProcessFormat2(string text, int startNum)
        {
            resultText = "";
            string[] tasks = text.Split(new string[] { "\r\n\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tasks.Length; i++)
            {
                string taskRes = $"::T-{startNum + i}::";
                string[] taskStrings = tasks[i].Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);

                int answersCount = 0;
                int questionString = 4;

                string formattedQuestion = ProcessQuestionsFormat2(questionString, taskStrings, ref answersCount);
                taskRes += formattedQuestion;

                int[] answersNumbersArray = GetAnswersFormat2(taskStrings);

                string answers = ProcessAnswersFormat2(questionString, taskStrings, answersNumbersArray);
                taskRes += answers + "}\r\n\r\n";

                resultText += taskRes;
            }
            return resultText;
        }

        private static string ProcessQuestionsFormat2(int questionString, string[] taskStrings, ref int answersCount) {
            string resultText = "";

            string question = taskStrings[questionString].Trim();
            int braceLeft = question.LastIndexOf('(');
            int braceRight = question.LastIndexOf(')');
            while (braceLeft == -1 && braceRight == -1)
            {
                questionString++;
                question += "\r\n" + taskStrings[questionString].Trim();
                braceLeft = question.LastIndexOf('(');
                braceRight = question.LastIndexOf(')');
            }
            int tabPosition = question.IndexOf('\t');
            resultText += question.Substring(tabPosition + 1, braceLeft - tabPosition - 2).TrimEnd() + " {\r\n";
            answersCount = int.Parse(question.Substring(braceLeft + 1, braceRight - braceLeft - 1));
            return resultText;
        }

        private static int[] GetAnswersFormat2(string[] taskStrings) {
            List<int> parts = new List<int>();
            for (int j = 1; j < taskStrings.Length; j++)
            {
                if (taskStrings[j].Trim().StartsWith("+"))
                    parts.Add(j);
            }

            int[] answersNumbersArray = parts.ToArray();
            return answersNumbersArray;
        }

        private static string ProcessAnswersFormat2(int questionString, string[] taskStrings, int[] answersNumbersArray) {
            string resultText = "";

            for (int j = questionString + 1; j < taskStrings.Length; j++)
            {
                string answerString = taskStrings[j].Trim();
                if (taskStrings[j].Trim().StartsWith("+"))
                    answerString = taskStrings[j].Trim().Substring(1, answerString.Length - 1);

                if (answersNumbersArray.Length == 1)
                {
                    resultText += answersNumbersArray.Contains(j) ? "=" : "~";
                    resultText += answerString + "\r\n";
                }
                else
                {
                    int positive = answersNumbersArray.Length;
                    int negative = taskStrings.Length - 1 - questionString - positive;

                    resultText += answersNumbersArray.Contains(j) ? answerProcPositive[positive] : answerProcNegative[negative];
                    resultText += answerString + "\r\n";
                }
            }
            return resultText;
        }


        public static string ProcessFormat3(string text, int startNum)
        {
            resultText = "";
            string[] tasks = text.Split(new string[] { "\r\n\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tasks.Length; i++)
            {
                string taskRes = $"::T-{startNum + i}::";
                string[] taskStrings = tasks[i].Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);

                int answersCount = 0;
                int questionString = 1;

                string questionText = ProcessQuestionFormat3(taskStrings, ref answersCount, ref questionString);
                taskRes += questionText;
                int[] answersNumbersArray = GetAnswersFormat3(taskStrings);

                string answers = ProcessAnswersFormat3(questionString, taskStrings, answersNumbersArray);
                taskRes += answers + "}\r\n\r\n";

                resultText += taskRes;
            }
            return resultText;
        }


        private static string ProcessQuestionFormat3(string[] taskStrings, ref int answersCount, ref int questionString) {
            string question = taskStrings[questionString].Trim();
            int braceLeft = question.LastIndexOf('(');
            int braceRight = question.LastIndexOf(')');
            while (braceLeft == -1 && braceRight == -1)
            {
                questionString++;
                question += "\r\n" + taskStrings[questionString].Trim();
                braceLeft = question.LastIndexOf('(');
                braceRight = question.LastIndexOf(')');
            }
            string result = question.Substring(0, braceLeft).TrimEnd() + " {\r\n";
            answersCount = int.Parse(question.Substring(braceLeft + 1, braceRight - braceLeft - 1));

            return result;
        }

        private static int[] GetAnswersFormat3(string[] taskStrings) {
            string answers = taskStrings[taskStrings.Length - 1].Trim();
            answers = answers.Replace("#конец задания", "").Trim().Replace("(", "").Replace(")", "").Trim();
            string[] answersNumbers = answers.Split(',');
            int[] answersNumbersArray = Array.ConvertAll(answersNumbers, int.Parse);
            return answersNumbersArray;
        }

        private static string ProcessAnswersFormat3(int questionString, string[] taskStrings, int[] answersNumbersArray) {
            string resultText = "";

            for (int j = questionString + 1; j < taskStrings.Length - 1; j++)
            {
                string answerString = taskStrings[j].Substring(j.ToString().Length + 1).Trim();

                if (answersNumbersArray.Length == 1)
                {
                    resultText += answersNumbersArray.Contains(j - questionString) ? "=" : "~";
                    resultText += answerString + "\r\n";
                }
                else
                {
                    int positive = answersNumbersArray.Length;
                    int negative = taskStrings.Length - questionString - positive - 2;

                    resultText += answersNumbersArray.Contains(j - questionString) ? answerProcPositive[positive] : answerProcNegative[negative];
                    resultText += answerString + "\r\n";
                }
            }

            return resultText;
        }
    }
}
