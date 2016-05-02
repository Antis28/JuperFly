using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;


public class TaskGenerator
{

    int numTask = 1;
    XmlDocument xmlDoc;
    /*
        public class Task
        {
            //Многоугольник и его периметр. Равные фигуры.
            //Сумма всех сторон многоугольника называется периметром многоугольника.
            //Две фигуры называются равными, если они совмещаются наложением.
            public string header  = "Многоугольник и его периметр. Равные фигуры.";		
            public string question = "Сумма всех сторон многоугольника называется...";
            public string Answer = "Периметр" ;
        }

        public void SerializationInXML()
        {
            string path = "Data/Save/TaskBase.xml";
            Task task = new Task ();

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer (typeof(Task));
            System.IO.FileStream file = System.IO.File.Create (path);

            writer.Serialize (file, task);
            file.Close ();

        }
    */
    public XmlElement GenerationXMLnode( int numTask, string Header, string Question, string Answer )
    {
        XmlElement Element1;
        XmlElement Element2;

        Element1 = xmlDoc.CreateElement( "Task_" + numTask );

        Element2 = xmlDoc.CreateElement( "Header" );
        Element2.InnerText = Header;
        Element1.AppendChild( Element2 );

        Element2 = xmlDoc.CreateElement( "Question" );
        Element2.InnerText = Question;
        Element1.AppendChild( Element2 );

        Element2 = xmlDoc.CreateElement( "Answer" );
        Element2.InnerText = Answer;
        Element1.AppendChild( Element2 );

        Element2 = xmlDoc.CreateElement( "IsAnswer" );
        Element2.InnerText = "false";
        Element1.AppendChild( Element2 );

        return Element1;
    }
    public XmlElement GenerationXMLnodeDrobi( int numTask, string Header, string Question, string AnswerCeloe, string AnswerChislitel, string AnswerZnamenatel )
    {
        XmlElement Element1;
        XmlElement Element2;

        Element1 = xmlDoc.CreateElement( "Task_" + numTask );

        Element2 = xmlDoc.CreateElement( "Header" );
        Element2.InnerText = Header;
        Element1.AppendChild( Element2 );

        Element2 = xmlDoc.CreateElement( "Question" );
        Element2.InnerText = Question;
        Element1.AppendChild( Element2 );

        Element2 = xmlDoc.CreateElement( "AnswerCeloe" );
        Element2.InnerText = AnswerCeloe;
        Element1.AppendChild( Element2 );

        Element2 = xmlDoc.CreateElement( "AnswerChislitel" );
        Element2.InnerText = AnswerChislitel;
        Element1.AppendChild( Element2 );

        Element2 = xmlDoc.CreateElement( "AnswerZnamenatel" );
        Element2.InnerText = AnswerZnamenatel;
        Element1.AppendChild( Element2 );

        Element2 = xmlDoc.CreateElement( "IsAnswer" );
        Element2.InnerText = "false";
        Element1.AppendChild( Element2 );

        return Element1;
    }
    public void GenerationXML()
    {
        // Создаем корневой элемент
        xmlDoc = new XmlDocument();
        XmlElement xRoot = xmlDoc.CreateElement( "Tasks" ); // Корневой элемент

        xmlDoc.AppendChild( xRoot );

        //Временные преременные для дочерних элементов и атрибутов
        XmlElement taskElement1; //Элемент 1-го уровня
        XmlElement taskElement2; //Элемент 2-го уровня

        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "Многоугольник и его периметр. Равные фигуры.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Сумма всех сторон многоугольника называется...";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "периметр";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////

        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "Многоугольник и его периметр. Равные фигуры.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Две фигуры называются равными, если они...";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "совмещаются наложением";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ТРЕУГОЛЬНИК И ЕГО ВИДЫ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Скольким градусам равна сумма углов треугольника?";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "180";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ТРЕУГОЛЬНИК И ЕГО ВИДЫ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "От длин сторон треугольника зависит ...";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "периметр";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УМНОЖЕНИЕ НАТУРАЛЬНЫХ ЧИСЕЛ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Умножить число a на натуральное число b - значит найти сумму b одинаковых слагаемых, каждое из которых равно ...";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "а";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УМНОЖЕНИЕ НАТУРАЛЬНЫХ ЧИСЕЛ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "От порядка групировки множителей ... не изменяется.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "произведение";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "РАСПРЕДЕЛИТЕЛЬНЫЙ ЗАКОН";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Произведение суммы и числа равно ... произведений каждого слагаемого";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "сумме";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ДЕЛЕНИЕ НАТУРАЛЬНЫХ ЧИСЕЛ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Разделить одно число на другое - значит найти такое третье число, которое в ... со вторым дает первое";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "произведении";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Уравнением называется ..., содержащее неизвестное, значение которого нужно найти.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "равенство";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Значение неизвестного, при котором уравнение превращается в верное числовое равенство называется ... уравнения.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "корнем";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Найти все корни уравнения или установить, что уравнение не имеет ни одного корня, значит ... уравнение.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "решить";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Чтобы найти неизвестное слагаемое, нужно из суммы ... известное слагаемое.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "вычесть";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Чтобы найти неизвестное уменьшаемое, нужно к разности ... вычитаемое.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "прибавить";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Чтобы найти неизвестное вычитаемое, нужно из уменьшаемого ... разность";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "вычесть";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Чтобы найти неизвестный множитель, нужно произведение ... на известный множитель";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "разделить";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Чтобы найти неизвестное делимое, нужно частное ... на делитель.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "умножить";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "УРАВНЕНИЯ";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Чтобы найти неизвестный делитель, нужно делимое ... на частное.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "разделить";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "СТЕПЕНЬ ЧИСЛА";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Возвести число а в степень n - значит найти ... n множителей.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "произведение";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ПЛОЩАДЬ ПРЯМОУГОЛЬНИКА И КВАДРАТА";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Прямоугольник вместе с частью плоскости, которую он ограничивает называется ... прямоугольником";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "плоским";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ПЛОЩАДЬ ПРЯМОУГОЛЬНИКА И КВАДРАТА";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Площадь прямоугольника со сторонами а и b равна ... этих сторон.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "произведению";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ПЛОЩАДЬ ПРЯМОУГОЛЬНИКА И КВАДРАТА";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Равные фигуры имеют равные ... .";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "площади";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ПЛОЩАДЬ ПРЯМОУГОЛЬНИКА И КВАДРАТА";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Площадь фигуры равна сумме площадей ее ... .";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "частей";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ПРЯМОУГОЛЬНЫЙ ПАРАЛЛЕЛЕПИПЕД. КУБ. ПИРАМИДА.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Сумма длин всех ребер прямоугольного параллелепипеда с ребрами a,b,c равна ...(a+b+c).";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "4";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "ПРЯМОУГОЛЬНЫЙ ПАРАЛЛЕЛЕПИПЕД. КУБ. ПИРАМИДА.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Сумма площадей всех граней куба с ребром а равна 6a в ... .";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "квадрате";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        xRoot.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
                                    numTask++,
                                    "ОБЪЕМ ПРЯМОУГОЛЬНОГО ПАРАЛЛЕЛЕПИПЕДА И КУБА",
                                    "Напишите формулу объема прямоугольного параллелепипида с ребрами a,b,c.",
                                    "V=abc"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
                                    numTask++,
                                    "ОБЪЕМ ПРЯМОУГОЛЬНОГО ПАРАЛЛЕЛЕПИПЕДА И КУБА",
                                    "V = a\xb3 , это формула объема ... .",
                                    "куба"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
                                    numTask++,
                                    "ОБЪЕМ ПРЯМОУГОЛЬНОГО ПАРАЛЛЕЛЕПИПЕДА И КУБА",
                                    "Равные прямоугольные параллелепипеды имеют равные ... .",
                                    "объемы"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
                                    numTask++,
                                    "ОБЪЕМ ПРЯМОУГОЛЬНОГО ПАРАЛЛЕЛЕПИПЕДА И КУБА",
                                    "Объем прямоугольного параллелепипеда равен ... объемов его частей.",
                                    "сумме"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
                                    numTask++,
                                    "Комбинаторные задачи",
                                    "Чтобы найти количество всех комбинаций из n элементов, нужно ... все натуральные числа, начиная с числа n и заканчивая числом 1.",
                                    "умножить"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
                                    numTask++,
                                    "ОБЫКНОВЕННАЯ ДРОБЬ.СРАВНЕНИЕ ДРОБЕЙ",
                                    "Дробь у которой числитель ... знаменателя, называется правильной.",
                                    "меньше"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
                                    numTask++,
                                    "ОБЫКНОВЕННАЯ ДРОБЬ.СРАВНЕНИЕ ДРОБЕЙ",
                                    "Дробь у которой числитель больше знаменателя или равен ему, называется ... .",
                                    "неправильной"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
                                    numTask++,
                                    "ОБЫКНОВЕННАЯ ДРОБЬ",
                                    "Выделить целую часть из неправильной дроби." + "8/3",
                                    "2",
                                    "2",
                                    "3"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
                                    numTask++,
                                    "ОБЫКНОВЕННАЯ ДРОБЬ",
                                    "Выделить целую часть из неправильной дроби." + "9/5",
                                    "1",
                                    "4",
                                    "5"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
                                    numTask++,
                                    "ОБЫКНОВЕННАЯ ДРОБЬ",
                                    "Обращение смешаного числа в неправильную дробь." + "2 5/9",
                                    "",
                                    "23",
                                    "9"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
                                    numTask++,
                                    "ОБЫКНОВЕННАЯ ДРОБЬ",
                                    "Обращение смешаного числа в неправильную дробь." + "3 2/3",
                                    "",
                                    "11",
                                    "3"
                                            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
            numTask++,
            "НАХОЖДЕНИЕ ДРОБИ ОТ ЧИСЛА И ЧИСЛА ПО ЕГО ДРОБИ",
            "Чтобы найти дробь от числа, нужно данное число разделить " +
            "на ... дроби и полученый результат умножить на ее числитель.",
            "знаменатель"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnode(
            numTask++,
            "НАХОЖДЕНИЕ ДРОБИ ОТ ЧИСЛА И ЧИСЛА ПО ЕГО ДРОБИ",
            "Чтобы найти число по его дроби, нужно данное число разделить на числитель дроби и полученый результат ... на ее знаменатель.",
            "умножить"
            ) );
        /////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "СЛОЖЕНИЕ И ВЫЧИТАНИЕ ДРОБЕЙ С ОДИНАКОВЫМИ ЗНАМЕНАТЕЛЯМИ",
            "Найти сумму двух дробей с одинаковыми знаменателями. 1/6 + 3/6",
            "",
            "4",
            "6"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "СЛОЖЕНИЕ И ВЫЧИТАНИЕ ДРОБЕЙ С ОДИНАКОВЫМИ ЗНАМЕНАТЕЛЯМИ",
            "Найти сумму двух дробей с одинаковыми знаменателями. 2/3 + 4/3",
            "",
            "6",
            "3"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
        numTask++,
        "СЛОЖЕНИЕ И ВЫЧИТАНИЕ ДРОБЕЙ С ОДИНАКОВЫМИ ЗНАМЕНАТЕЛЯМИ",
        "Найти сумму двух дробей с одинаковыми знаменателями. 3/9 + 5/9",
        "",
        "8",
        "9"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
        numTask++,
        "СЛОЖЕНИЕ И ВЫЧИТАНИЕ ДРОБЕЙ С ОДИНАКОВЫМИ ЗНАМЕНАТЕЛЯМИ",
        "Найти разность двух дробей с одинаковыми знаменателями. 8/9 - 4/9",
        "",
        "4",
        "9"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "СЛОЖЕНИЕ И ВЫЧИТАНИЕ ДРОБЕЙ С ОДИНАКОВЫМИ ЗНАМЕНАТЕЛЯМИ",
            "Найти разность двух дробей с одинаковыми знаменателями. 6/7 - 2/7",
            "",
            "4",
            "7"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "ДОПОЛНЕНИЕ ПРАВИЛЬНОЙ ДРОБИ ДО ЕДЕНИЦЫ. ВЫЧИТАНИЕ ДРОБИ ИЗ НАТУРАЛЬНОГО ЧИСЛА",
            "Вычесть дробь из натурального числа./n 1 - 5/16",
            "",
            "11",
            "16"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "ДОПОЛНЕНИЕ ПРАВИЛЬНОЙ ДРОБИ ДО ЕДЕНИЦЫ. ВЫЧИТАНИЕ ДРОБИ ИЗ НАТУРАЛЬНОГО ЧИСЛА",
            "Вычесть дробь из натурального числа. 1 - 1/2",
            "",
            "1",
            "2"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "ДОПОЛНЕНИЕ ПРАВИЛЬНОЙ ДРОБИ ДО ЕДЕНИЦЫ. ВЫЧИТАНИЕ ДРОБИ ИЗ НАТУРАЛЬНОГО ЧИСЛА",
            "Вычесть дробь из натурального числа. 4 - 3/4",
            "3",
            "1",
            "4"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "ДОПОЛНЕНИЕ ПРАВИЛЬНОЙ ДРОБИ ДО ЕДЕНИЦЫ. ВЫЧИТАНИЕ ДРОБИ ИЗ НАТУРАЛЬНОГО ЧИСЛА",
            "Вычесть дробь из натурального числа. 6 - 2/9",
            "5",
            "7",
            "9"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "ДОПОЛНЕНИЕ ПРАВИЛЬНОЙ ДРОБИ ДО ЕДЕНИЦЫ. ВЫЧИТАНИЕ ДРОБИ ИЗ НАТУРАЛЬНОГО ЧИСЛА",
            "Вычесть дробь из натурального числа. 2 2/3 - 4/3",
            "1",
            "1",
            "3"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "СЛОЖЕНИЕ И ВЫЧИТАНИЕ СМЕШАНЫХ ЧИСЕЛ",
            "Найти сумму двух смешаных чисел. 2 2/5 + 2 4/5",
            "5",
            "1",
            "5"
            ) );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( GenerationXMLnodeDrobi(
            numTask++,
            "СЛОЖЕНИЕ И ВЫЧИТАНИЕ СМЕШАНЫХ ЧИСЕЛ",
            "Найти сумму двух смешаных чисел. 1 2/4 + 3 1/4",
            "4",
            "3",
            "4"
            ) );
        /////////////////////////////////////////////////////////////



        if( Directory.Exists( "Data/Save" ) )
            xmlDoc.Save( "Data/Save/TaskBase.xml" );

        else
        {
            Directory.CreateDirectory( "Data/Save" );
            xmlDoc.Save( "Data/Save/BaseData.xml" );
            //Debug.LogError( "Not found Directory \"Data/Save\"" );
        }
    }

    public void BattleTaskGenerationXML()
    {
        numTask = 1;
        // Создаем корневой элемент
        xmlDoc = new XmlDocument();
        XmlElement xRoot = xmlDoc.CreateElement( "BaseData" ); // Корневой элемент BattleTasks
        xmlDoc.AppendChild( xRoot );

        XmlElement BattleTasks = xmlDoc.CreateElement( "BattleTasks" );

        //Временные преременные для дочерних элементов и атрибутов
        XmlElement taskElement1; //Элемент 1-го уровня
        XmlElement taskElement2; //Элемент 2-го уровня

        /////////////////////////////////////////////////////////////
        taskElement1 = xmlDoc.CreateElement( "Task_" + numTask++ );

        taskElement2 = xmlDoc.CreateElement( "Header" );
        taskElement2.InnerText = "Многоугольник и его периметр. Равные фигуры.";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Question" );
        taskElement2.InnerText = "Сумма всех сторон многоугольника называется...";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "Answer" );
        taskElement2.InnerText = "периметр";
        taskElement1.AppendChild( taskElement2 );

        taskElement2 = xmlDoc.CreateElement( "IsAnswer" );
        taskElement2.InnerText = "false";
        taskElement1.AppendChild( taskElement2 );

        BattleTasks.AppendChild( taskElement1 );
        /////////////////////////////////////////////////////////////
        xRoot.AppendChild( BattleTasks );


        if( Directory.Exists( "Data/Save" ) )
            xmlDoc.Save( "Data/Save/BaseData.xml" );

        else
        {
            Directory.CreateDirectory( "Data/Save" );
            xmlDoc.Save( "Data/Save/BaseData.xml" );
            //Debug.LogError( "Not found Directory \"Data/Save\"" );
        }

    }
}