using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Xml.Serialization;


static void Day2Part1()
{
    string[] input = File.ReadAllLines("input.txt");

    const int redCubes = 12;
    const int greenCubes = 13;
    const int blueCubes = 14;

    int gameIdSum = 0;

    foreach (string line in input)
    {
        string[] game = line.Split(':');
        string gameID = game[0];
        string gameIDNumber = gameID.Split(" ")[1];
        string gameInfo = game[1];
        bool gamePossible = true;


        string[] gameSets = gameInfo.Split(";");

        foreach (string gameSet in gameSets)
        {
            if (gameSet.Contains("red"))
            {
                int currentRedCubes = 0;
                string[] redNum = gameSet.Split(",");
                redNum = redNum.Where(num => !num.Contains("green")).ToArray();
                redNum = redNum.Where(num => !num.Contains("blue")).ToArray();

                foreach (string num in redNum)
                {
                    Match match = Regex.Match(num, @"\d+");
                    if (match.Success)
                    {
                        string numberString = match.Value;
                        if (int.TryParse(numberString, out currentRedCubes))
                        {
                            Console.WriteLine("Number of Red Cubes: " + currentRedCubes);
                            if (currentRedCubes > redCubes)
                            {
                                Console.WriteLine("TO GREAT NUMBER: INVALID GAME");
                                gamePossible = false;
                            }
                            else
                            {
                                Console.WriteLine("POSSIBLE GAME");
                            }
                        }
                    }
                }
            }
            if (gameSet.Contains("green"))
            {
                int currentGreenCubes = 0;
                string[] redNum = gameSet.Split(",");
                redNum = redNum.Where(num => !num.Contains("red")).ToArray();
                redNum = redNum.Where(num => !num.Contains("blue")).ToArray();

                foreach (string num in redNum)
                {
                    Match match = Regex.Match(num, @"\d+");
                    if (match.Success)
                    {
                        string numberString = match.Value;
                        if (int.TryParse(numberString, out currentGreenCubes))
                        {
                            Console.WriteLine("Number of Green Cubes: " + currentGreenCubes);
                            if (currentGreenCubes > greenCubes)
                            {
                                Console.WriteLine("TO GREAT NUMBER: INVALID GAME");
                                gamePossible = false;
                            }
                            else
                            {
                                Console.WriteLine("POSSIBLE GAME");
                            }
                        }
                    }
                }
            }
            if (gameSet.Contains("blue"))
            {
                int currentBlueCubes = 0;
                string[] redNum = gameSet.Split(",");
                redNum = redNum.Where(num => !num.Contains("red")).ToArray();
                redNum = redNum.Where(num => !num.Contains("green")).ToArray();

                foreach (string num in redNum)
                {
                    Match match = Regex.Match(num, @"\d+");
                    if (match.Success)
                    {
                        string numberString = match.Value;
                        if (int.TryParse(numberString, out currentBlueCubes))
                        {
                            Console.WriteLine("Number of Blue Cubes: " + currentBlueCubes);
                            if (currentBlueCubes > blueCubes)
                            {
                                Console.WriteLine("TO GREAT NUMBER: INVALID GAME");
                                gamePossible = false;
                            }
                            else
                            {
                                Console.WriteLine("POSSIBLE GAME");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("----------new gameset----------");
            Console.WriteLine();
        }
        if (gamePossible)
        {
            gameIdSum += Convert.ToInt32(gameIDNumber);
            Console.WriteLine(($"sum is {gameIdSum}"));
        }
        Console.WriteLine("----------new line----------");
        Console.WriteLine();
    }
}

static void Day2Part2()
{
    
    
    string[] input = File.ReadAllLines("input.txt");

    const int redCubes = 12;
    const int greenCubes = 13;
    const int blueCubes = 14;

    int gameIdSum = 0;
    int totalProductSum = 0;

    foreach (string line in input)
    {
        string[] game = line.Split(':');
        string gameID = game[0];
        string gameIDNumber = gameID.Split(" ")[1];
        string gameInfo = game[1];
        bool gamePossible = true;

        int maxRedCubes = 0;
        int maxGreenCubes = 0;
        int maxBlueCubes = 0;

        string[] gameSets = gameInfo.Split(";");

        foreach (string gameSet in gameSets)
        {
            if (gameSet.Contains("red"))
            {
                int currentRedCubes = 0;
                string[] redNum = gameSet.Split(",");
                redNum = redNum.Where(num => !num.Contains("green")).ToArray();
                redNum = redNum.Where(num => !num.Contains("blue")).ToArray();

                foreach (string num in redNum)
                {
                    Match match = Regex.Match(num, @"\d+");
                    if (match.Success && int.TryParse(match.Value, out currentRedCubes))
                    {
                        Console.WriteLine("Number of Red Cubes: " + currentRedCubes);
                        if (currentRedCubes > maxRedCubes)
                        {
                            maxRedCubes = currentRedCubes;
                        }
                    }
                }
            }
            if (gameSet.Contains("green"))
            {
                int currentGreenCubes = 0;
                string[] greenNum = gameSet.Split(",");
                greenNum = greenNum.Where(num => !num.Contains("red")).ToArray();
                greenNum = greenNum.Where(num => !num.Contains("blue")).ToArray();

                foreach (string num in greenNum)
                {
                    Match match = Regex.Match(num, @"\d+");
                    if (match.Success && int.TryParse(match.Value, out currentGreenCubes))
                    {
                        Console.WriteLine("Number of Green Cubes: " + currentGreenCubes);
                        if (currentGreenCubes > maxGreenCubes)
                        {
                            maxGreenCubes = currentGreenCubes;
                        }
                    }
                }
            }
            if (gameSet.Contains("blue"))
            {
                int currentBlueCubes = 0;
                string[] blueNum = gameSet.Split(",");
                blueNum = blueNum.Where(num => !num.Contains("red")).ToArray();
                blueNum = blueNum.Where(num => !num.Contains("green")).ToArray();

                foreach (string num in blueNum)
                {
                    Match match = Regex.Match(num, @"\d+");
                    if (match.Success && int.TryParse(match.Value, out currentBlueCubes))
                    {
                        Console.WriteLine("Number of Blue Cubes: " + currentBlueCubes);
                        if (currentBlueCubes > maxBlueCubes)
                        {
                            maxBlueCubes = currentBlueCubes;
                        }
                    }
                }
            }

            Console.WriteLine("----------new gameset----------");
            Console.WriteLine();
        }

        if (gamePossible)
        {
            int product = maxRedCubes * maxGreenCubes * maxBlueCubes;
            totalProductSum += product;  // Accumulate the product in the total sum
            gameIdSum += Convert.ToInt32(gameIDNumber);
            Console.WriteLine($"Product of max values for the current game: {product}");
            Console.WriteLine($"Sum is {gameIdSum}");
        }

        Console.WriteLine("----------new line----------");
        Console.WriteLine();
    }

    // Display the total sum of all product values after processing all games
    Console.WriteLine($"Total Sum of Product of max values across all games: {totalProductSum}");
    
}