        using System;
        using System.Collections.Generic;

        namespace STL {
            partial class App 
            {
                int[] arr1;
                int[,] arr2;
                int[][] arr3;

                public void Run() 
                {
                    DictionaryEx();
                }

                public void DictionaryEx() {
                    var dict = new Dictionary<String, String>();
                    dict.Add("hello", "привет");
                    dict.Add("bye", "пока");
#region Menu
                    Console.WriteLine("Англо-русский словарь");
                    Console.WriteLine("1 - Найти перевод на Русский");
                    Console.WriteLine("2 - Найти перевод на Английский");
                    Console.WriteLine("3 - Добавить запись");
                    Console.WriteLine("0 - Выход");
#endregion
                    var keyPressed = Console.ReadKey(true);
                    while(keyPressed.KeyChar != '0') {
#region Поиск по англ слову
                        if(keyPressed.KeyChar == '1') {
                            Console.WriteLine("Введите английское слово : ");
                            String enWord = Console.ReadLine();
                            String ruWord = null;
                            try {
                                ruWord = dict[enWord];
                            }
                            catch {
                                ruWord = "НЕ НАЙДЕНО";
                            }
                            finally {
                                Console.WriteLine($"ru : {ruWord}");
                            }
                        }
                        else if(keyPressed.KeyChar == '2') {
                            Console.WriteLine("Введите русское слово : ");
                            String ruWord = Console.ReadLine();

                            foreach(var it in dict) 
                            {
                                if(it.Value == ruWord) {
                                    Console.WriteLine($"Перевод: {it.Key}");
                                    break;
                                }
                                else {
                                    Console.WriteLine("НЕ НАЙДЕНО");
                                }
                            }
                        }
#endregion
                    }
                }
               
                public void CollectionsDemo() {
                    List<String> strings;
                    Dictionary<String, String> dict;
                    #region List
                    strings = new List<string>();
                    strings.Add("String 1");
                    strings.Add("String 2");
                    strings.Add("String 3");
                    strings.Add("String 3");
                    foreach (String item in strings) {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("----------------------");
                    // доступ по индексу:
                    // возможен отсчет от нуля, при неправильном индексе - исключение

                    // возможность изменения
                    // а) элементов по индексу
                    strings[1] += "++";
                    // б) элементов в цикле (foreach)
                    // нельзя
                    // foreach(String item in strings) {item += " -- ";}
                    // в) саму коллекцию
                    strings.Remove("String 4");
                    strings.RemoveAll(s => s.Equals("String 4"));
                    foreach (String item in strings) {
                        Console.WriteLine(item);
                    }
                    // поиск элемента
                    Console.WriteLine(strings.Contains("String 3")); // True or False
                    Console.WriteLine(strings.IndexOf("String 3")); // первый найденный
                    Console.WriteLine(strings.LastIndexOf("String 3")); // последний найденный
                    Console.WriteLine("----------------------");
                    // г) изменение коллекции в цикле
                    // foreach (String item in strings)
                    //     strings.Remove("String 3");
                    // нельзя. Ошибок компиляции нет, но при выполнении - исключение
                    strings.Clear(); // очистка коллекции
                    #endregion 
                    
                    #region Dictionary
                    // словарь - набор "пар" ключ-значение
                    // при объявлении указываем два типа: для ключа, для значения
                    dict = new Dictionary<String, String>();
                    dict.Add("one", "раз");
                    dict.Add("two", "два");
                    dict.Add("three", "три");

                    dict["one"] = "один"; // изменение по ключу
                    dict["four"] = "четыре";
                    dict["five"] = null;
                    // Console.WriteLine(dict["one"]); // обращение к значению по ключу: если ключ есть - выводится
                                                    // иначе - исключение
                    // Console.WriteLine(dict["five"] ?? "NULL");

                    foreach(var pair in dict) // KeyValuePair<string, string>
                    {
                        Console.WriteLine($"{pair.Key} - {pair.Value}");
                    }
                    // поиск
                    Console.WriteLine("------------------");
                    // 1. Ключ (есть ли такой ключ)
                    Console.WriteLine(dict.ContainsKey("five"));
                    Console.WriteLine(dict.ContainsKey("six"));
                    // 2. Значение (есть ли)
                    Console.WriteLine(dict.ContainsValue("два"));
                    Console.WriteLine(dict.ContainsValue("семь"));
                    foreach(String str in new String[] {"3", "4", "5"})
                    {
                        dict.Add(str, "digit");
                    }

                    #endregion
                }

                public void CtorDemo() 
                {
                    TheClass obj = new TheClass();
                    Console.WriteLine(obj);
                }

                public void ArraysDemo() {
                    Console.WriteLine("О массивах и коллекциях");
                    arr1 = new int[10];
                    for(int i = 0; i < 10; i++) {
                        arr1[i] = i*i;
                    }
                    foreach(int x in arr1) {
                        Console.WriteLine(x);
                    }
                    Console.WriteLine($"Всего {arr1.Length} элементов");
                    
                    arr2 = new int[3, 4];
                    for(int i = 0; i < 3; i++)
                    {
                        for(int j = 0; j < 4; j++)
                        {
                            arr2[i, j] = 10 * i + j + 11;
                        }
                    }

                    Console.WriteLine("двойной");
                    for(int i = 0; i < 3; i++)
                    {
                        for(int j = 0; j < 4; j++)
                        {
                            Console.Write(arr2[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("-----------------");
                    arr3 = new int[3][];
                    for(int i = 0; i < 3; i++) 
                    {
                        arr3[i] = new int[2 + i];
                        for(int j = 0; j < 2 + i; j++) {
                            arr3[i][j] = 10 * i + j + 11;
                        }
                    }
                    foreach(var x2 in arr3) 
                    {
                        foreach(var x in x2) 
                        {
                            Console.Write(x + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }

            class TheClass
            {
                private int x;
                public TheClass() // конструктор с параметрами
                {
                    x = 10;
                }
                private TheClass(int x) // конструктор с параметрами
                {
                    this.x = x;
                }
                public override string ToString()
                {
                    return $"x = {this.x}";
                }


                public int Y { get; set; } // auto property
                public int W { get; private set; }
                public int X { get { return this.x; }  set { this.x = value; } }
            }
        }