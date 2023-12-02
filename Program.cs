ChatGPT();

static void Day2Part1()
{
    string[] input = File.ReadAllLines("input.txt");

    for (int i = 0; i < Math.Min(9, input.Length); i++)
    {
        string line = input[i];
        string gameID1_9 = line.Substring(5, 1);
        Console.WriteLine(gameID1_9);
    }

    for (int i = 9; i < Math.Min(99, input.Length); i++)
    {
        string line = input[i];
        string gameID10_99 = line.Substring(5, 2);
        Console.WriteLine(gameID10_99);
    }

    for (int i = 99; i < Math.Min(100, input.Length); i++)
    {
        string line = input[i];
        string gameID100 = line.Substring(5, 3);
        Console.WriteLine(gameID100);
    }
}

static void ChatGPT() 
{
    string[] games = File.ReadAllLines("input.txt");

    int redCubes = 12;
    int greenCubes = 13;
    int blueCubes = 14;

    List<int> possibleGames = new List<int>();

    foreach (string game in games)
    {
        string[] parts = game.Split(':');
        int gameId;
        if (int.TryParse(parts[0].Substring(5).Trim(), out gameId))
        {
            bool isPossible = true;
            foreach (string subset in parts[1].Split(';'))
            {
                string[] cubeParts = subset.Trim().Split(' ');
                if (cubeParts.Length == 2)
                {
                    string color = cubeParts[1].ToLower();
                    int count = int.Parse(cubeParts[0]);

                    if ((color == "red" && count > redCubes) || (color == "green" && count > greenCubes) || (color == "blue" && count > blueCubes))
                    {
                        isPossible = false;
                        break; 
                    }
                }
            }

            if (isPossible)
            {
                possibleGames.Add(gameId);
            }
        }
    }

    int sumOfIDs = 0;
    foreach (int gameId in possibleGames)
    {
        sumOfIDs += gameId;
    }
    
    Console.WriteLine("Sum of IDs of possible games: " + sumOfIDs);
}