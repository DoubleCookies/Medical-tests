using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalTests
{
    static class ProcessingMethods
    {
        private static readonly string[] answerProcPositive = new string[] { "shift", "~%100%", "~%50%", "~%33.333%", "~%25%", "~%20%", "~%16.666%", "~%14.289%", "~%12.5%", "~%11.111%", "~%10%", "~%9.091%", "~%8.333%" };
        private static readonly string[] answerProcNegative = new string[] { "shift", "~%-100%", "~%-50%", "~%-33.333%", "~%-25%", "~%-20%", "~%-16.666%", "~%-14.289%", "~%-12.5%", "~%-11.111%", "~%-10%", "~%-9.091%", "~%-8.333%" };

        public static string ProcessText(string text, int startNum)
        {
            string res = "";
            string[] tasks = text.Split(new string[] { "***\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tasks.Length; i++)
            {
                string taskRes = $"::Q-{startNum + i}::";
                string[] taskStrings = tasks[i].Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);

                //вопрос
                string question = taskStrings[0].Trim();
                int braceLeft = question.LastIndexOf('(');
                int braceRight = question.LastIndexOf(')');
                int tabPosition = question.IndexOf('\t');
                taskRes += question.Substring(tabPosition + 1, braceLeft - tabPosition - 2).TrimEnd() + " {\r\n";
                int answersCount = int.Parse(question.Substring(braceLeft + 1, braceRight - braceLeft - 1));

                //номера ответов
                string answers = taskStrings[taskStrings.Length - 1].Trim();
                answers = answers.Replace("Ответ", "").Trim().Replace("ответ", "").Trim().Replace("(", "").Replace(")", "").Trim();
                string[] answersNumbers = answers.Split(',');
                int[] answersNumbersArray = Array.ConvertAll(answersNumbers, int.Parse);

                //сами ответы
                for (int j = 1; j < taskStrings.Length - 1; j++)
                {
                    string answerString = taskStrings[j].Substring(j.ToString().Length + 1).Trim();
                    if (answersCount == 1)
                    {
                        if (answersNumbersArray.Contains(j))
                            taskRes += "=" + answerString + "\r\n";
                        else
                            taskRes += "~" + answerString + "\r\n";
                    }
                    else
                    {
                        int positive = answersNumbersArray.Length;
                        int negative = taskStrings.Length - 2 - positive;
                        if (answersNumbersArray.Contains(j))
                            taskRes += answerProcPositive[positive] + answerString + "\r\n";
                        else
                            taskRes += answerProcNegative[negative] + answerString + "\r\n";
                    }
                }

                taskRes += "}\r\n\r\n";
                res += taskRes;
            }
            return res;
        }

        public static string ProcessTextOtherFormat(string text, int startNum)
        {
            string res = "";
            string[] tasks = text.Split(new string[] { "\r\n\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tasks.Length; i++)
            {
                string taskRes = $"::T-{startNum + i}::";
                string[] taskStrings = tasks[i].Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);

                //вопрос
                int questionString = 4;
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
                taskRes += question.Substring(tabPosition + 1, braceLeft - tabPosition - 2).TrimEnd() + " {\r\n";
                int answersCount = int.Parse(question.Substring(braceLeft + 1, braceRight - braceLeft - 1));

                List<int> parts = new List<int>();
                for (int j = 1; j < taskStrings.Length; j++)
                {
                    if (taskStrings[j].Trim().StartsWith("+"))
                        parts.Add(j);
                }

                int[] answersNumbersArray = parts.ToArray();

                //сами ответы
                for (int j = questionString + 1; j < taskStrings.Length; j++)
                {
                    string answerString = taskStrings[j].Trim();
                    if (taskStrings[j].Trim().StartsWith("+"))
                        answerString = taskStrings[j].Trim().Substring(1, answerString.Length - 1);

                    if (answersCount == 1)
                    {
                        if (answersNumbersArray.Contains(j))
                            taskRes += "=" + answerString + "\r\n";
                        else
                            taskRes += "~" + answerString + "\r\n";
                    }
                    else
                    {
                        int positive = answersNumbersArray.Length;
                        int negative = taskStrings.Length - 1 - questionString - positive;
                        if (answersNumbersArray.Contains(j))
                            taskRes += answerProcPositive[positive] + answerString + "\r\n";
                        else
                            taskRes += answerProcNegative[negative] + answerString + "\r\n";
                    }
                }

                taskRes += "}\r\n\r\n";
                res += taskRes;
            }
            return res;
        }


        public static string ProcessTextLastFormat(string text, int startNum)
        {
            string res = "";
            string[] tasks = text.Split(new string[] { "\r\n\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tasks.Length; i++)
            {
                string taskRes = $"::T-{startNum + i}::";
                string[] taskStrings = tasks[i].Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);

                //вопрос
                int questionString = 1;
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
                taskRes += question.Substring(0, braceLeft).TrimEnd() + " {\r\n";
                int answersCount = int.Parse(question.Substring(braceLeft + 1, braceRight - braceLeft - 1));

                //номера ответов
                string answers = taskStrings[taskStrings.Length - 1].Trim();
                answers = answers.Replace("#конец задания", "").Trim().Replace("(", "").Replace(")", "").Trim();
                string[] answersNumbers = answers.Split(',');
                int[] answersNumbersArray = Array.ConvertAll(answersNumbers, int.Parse);

                //сами ответы
                for (int j = questionString + 1; j < taskStrings.Length - 1; j++)
                {
                    string answerString = taskStrings[j].Substring(j.ToString().Length + 1).Trim();

                    if (answersCount == 1)
                    {
                        if (answersNumbersArray.Contains(j - questionString))
                            taskRes += "=" + answerString + "\r\n";
                        else
                            taskRes += "~" + answerString + "\r\n";
                    }
                    else
                    {
                        int positive = answersNumbersArray.Length;
                        int negative = taskStrings.Length - questionString - positive - 2;
                        if (answersNumbersArray.Contains(j - questionString))
                            taskRes += answerProcPositive[positive] + answerString + "\r\n";
                        else
                            taskRes += answerProcNegative[negative] + answerString + "\r\n";
                    }
                }

                taskRes += "}\r\n\r\n";
                res += taskRes;
            }
            return res;
        }
    }
}
