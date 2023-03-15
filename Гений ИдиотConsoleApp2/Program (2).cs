using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ГенийИдиотConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var repeat = "да";//использовал var
            while (repeat.ToLower() == "да")
            {
                int countQuestions = 5;
                int checkedUserAnswer = 0;
                int countRightAnswers = 0;
                var questions = GetQuestions(countQuestions);
                var answers = GetAnswers(countQuestions);
                ShuffleQA(questions, answers);
                Console.WriteLine("Здравствуйте! Пожалуйста введите ваши Фамилию Имя Отчество через пробел");
                var userName = Console.ReadLine();
                for (int o = 0; o < countQuestions; o++)
                {
                    Console.WriteLine("Вопрос №" + (o + 1));
                    Console.WriteLine(questions[o]);
                    var userAnswerIsCorrect = false;//использовал var
                    while (userAnswerIsCorrect == false)
                    {
                        var userAnswer = Console.ReadLine();//использовал var

                        userAnswerIsCorrect = int.TryParse(userAnswer, out checkedUserAnswer);
                        if (userAnswerIsCorrect == false)
                        {
                            Console.WriteLine("Пожалуйста, введите число.");
                            continue;
                        }
                        else break;
                    }
                    int rightAnswer = Convert.ToInt32(answers[o]);

                    if (checkedUserAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }
                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                double rightAnswerPercentage = ((countRightAnswers * (100 / (double)countQuestions)) / (double)(countQuestions * (100 / countQuestions))) * 100;
                string diagnosis = GetDiagnosis(rightAnswerPercentage);
                Console.WriteLine(userName + ", Ваш диагноз:" + diagnosis);
                SaveStats(userName, countRightAnswers, diagnosis);
                Console.WriteLine("Хотите посмотреть сатистику? Да/Нет");
                var userStatsAnswer = Console.ReadLine();//использовал var              
                if (userStatsAnswer.ToLower() == "да")
                {
                    ShowStats();
                }
                Console.WriteLine("Хотите пройти тест снова? Да/Нет");
                repeat = Console.ReadLine();
            }
        }
        static void ShowStats()
        {
            String line;
            StreamReader statsToShow = new StreamReader("C:\\Users\\alber\\source\\repos\\OnlineCourse11Stream_Kurators\\GeniyIdiotConsoleApp\\testStats.txt");
            line = statsToShow.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = statsToShow.ReadLine();
            }
            statsToShow.Close();
        }
        static void SaveStats(string userName, int countRightAnswers, string diagnosis)
        {
            StreamWriter statsToSave = new StreamWriter("C:\\Users\\alber\\source\\repos\\OnlineCourse11Stream_Kurators\\GeniyIdiotConsoleApp\\testStats.txt", true);
            statsToSave.WriteLine("| {0,-30} | {1,-30} |{2,-30} |", userName, countRightAnswers, diagnosis);
            statsToSave.Close();
        }
        static string[] GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно разделить на десять частей. Сколько нужно сделать распилов?";
            questions[2] = "На двух руках десять пальцев. Сколько пальцев на пяти руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут для трёх уколов?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
        static string[] GetAnswers(int countQuestions)
        {
            string[] answers = new string[countQuestions];
            answers[0] = "6";
            answers[1] = "9";
            answers[2] = "25";
            answers[3] = "60";
            answers[4] = "2";
            return answers;
        }
        static string GetDiagnosis(double rightAnswerPercentage)
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "Идиот!";
            diagnoses[1] = "кретин";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "Гений!";
            string diagnosis;
            if (rightAnswerPercentage == 0)
            {
                diagnosis = diagnoses[0];
            }
            else if (rightAnswerPercentage > 0 && rightAnswerPercentage <= 20)
            {
                diagnosis = diagnoses[1];
            }
            else if (rightAnswerPercentage > 20 && rightAnswerPercentage <= 40)
            {
                diagnosis = diagnoses[2];
            }
            else if (rightAnswerPercentage > 40 && rightAnswerPercentage <= 60)
            {
                diagnosis = diagnoses[3];
            }
            else if (rightAnswerPercentage > 60 && rightAnswerPercentage <= 80)
            {
                diagnosis = diagnoses[4];
            }
            else
            {
                diagnosis = diagnoses[5];
            }

            return diagnosis;
        }
        static void ShuffleQA(string[] questions, string[] answers)
        {
            Random random = new Random();

            for (int i = questions.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                var buffQuestion = questions[j]; var buffAnswer = answers[j];
                questions[j] = questions[i]; answers[j] = answers[i];
                questions[i] = buffQuestion; answers[i] = buffAnswer;
            }
        }
    }
}











