using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace ГенийИдиотConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat = "Да";
            while ((repeat == "Да") || (repeat == "да") || (repeat == "дА"))
            {
                int countQuestions = 5;
                string[] questions = GetQuestions(countQuestions);
                string[] answers = GetAnswers(countQuestions);
                int countRightAnswers = 0;
                ShuffleQA(questions, answers);
                Console.WriteLine("Здравствуйте! Представьтесь, пожалуйста!");
                string userName = Console.ReadLine();
                int checkedUserAnswer = 0;
                for (int o = 0; o < countQuestions; o++)
                {
                    Console.WriteLine("Вопрос №" + (o + 1));
                    Console.WriteLine(questions[o]);
                    bool userAnswerIsCorrect = false;
                    while (userAnswerIsCorrect == false)
                    {
                        string userAnswer = Console.ReadLine();
                        
                        userAnswerIsCorrect = int.TryParse(userAnswer, out checkedUserAnswer);
                        if (userAnswerIsCorrect == false)
                        {
                            Console.WriteLine("Пожалуйста, введите число.");
                            continue;
                        }
                        else break;
                    }//проверка ответа пользователя на корректность через TryParse
                    int rightAnswer = Convert.ToInt32(answers[o]);
                    
                    if (checkedUserAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }
                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                string diagnosis = GetDiagnosis(countQuestions, countRightAnswers);
                Console.WriteLine(userName + ", Ваш диагноз:" + diagnosis);
                Console.WriteLine("Хотите пройти тест снова? Да/Нет");
                repeat = Console.ReadLine();
            }
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
        static string GetDiagnosis(int countQuestions, int countRightAnswers)
        {
            string[] diagnoses = new string[countQuestions + 1];
            diagnoses[0] = "Идиот!";
            diagnoses[1] = "кретин";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "Гений!";
            string diagnosis = diagnoses[countRightAnswers];
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



        
 


      
        
    

