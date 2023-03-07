using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace ГенийИдиотConsoleApp2
{
    class Program
    {

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
        static int[] GetAnswers(int countQuestions)
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
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
        static int[] GetShuffle(int countQuestions)
        {
            int[] questionsSequence = new int[countQuestions];
            for (int i = 0; i <= countQuestions - 1; i++)
            {
                int equal = 0;
                Random random = new Random();
                int randomNumber = random.Next(1, (countQuestions));
                for (int j = 0; j <= countQuestions - 1; j++)
                {
                    if (questionsSequence[j] == randomNumber)
                    {
                        equal++;
                    }
                }
                if (equal == 0)
                {
                    questionsSequence[i] = randomNumber;
                }
                else
                {
                    if (i == countQuestions - 1)
                    {
                        int order = 1;

                        for (int p = 0; p <= i; p++)
                        {
                            int equal2 = 0;

                            for (int q = 0; q <= i; q++)
                            {
                                if (questionsSequence[q] == order)
                                {
                                    equal2++;
                                }
                            }
                            if (equal2 == 0)
                            {
                                questionsSequence[i] = order;
                                break;
                            }
                            else order = order + 1;
                        }
                    }
                    else
                    {
                        i = i - 1;
                    }

                }
            }
            return questionsSequence;
        }




        static void Main(string[] args)
        {
            string repeat = "Да";
            while ((repeat == "Да") || (repeat == "да") || (repeat == "дА"))
            {
                int countQuestions = 5;
                string[] questions = GetQuestions(countQuestions);
                int[] answers = GetAnswers(countQuestions);
                int countRightAnswers = 0;
                int[] questionsSequence = GetShuffle(countQuestions);
                Console.WriteLine("Здравствуйте! Представьтесь, пожалуйста!");
                string userName = Console.ReadLine();
                for (int o = 0; o < countQuestions; o++)
                {
                    Console.WriteLine("Вопрос №" + (o + 1));
                    Console.WriteLine(questions[(questionsSequence[o] - 1)]);
                    string userAnswer = Console.ReadLine();
                    int letterCounter = 0;
                    int enterMistakes = 1;
                    string answerForCheck = userAnswer;
                    while (enterMistakes >= 1)    // цикл требующий корректного числового ответа от пользователя.
                    {
                        for (int i = 0; i < answerForCheck.Length; i++)
                        {
                            char partOfUserAnswer = Convert.ToChar(answerForCheck[i]);
                            if (char.IsLetter(partOfUserAnswer))
                            {
                                letterCounter++;
                                enterMistakes++;
                            }
                            if (letterCounter > 0)
                            {
                                Console.WriteLine("Пожалуйста, введите число!");
                                answerForCheck = Console.ReadLine();
                                letterCounter = 0;
                                enterMistakes = 1;
                                break;
                            }
                            else
                            {
                                enterMistakes = 0;
                            }
                        }
                    }
                    int checkedUserAnswer = Convert.ToInt32(answerForCheck);
                    int rightAnswer = answers[(questionsSequence[o] - 1)];
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
        }
    }


      
        
    

