namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const int MATRIX_A = 3;
        const int NUMBER_OF_GAMES_OPTIONS = 4;
        const int MAX_SLOT_MACHINE_INT = 40;
        
        const int CENTER_LINE_MODE = 1;
        const int HORIZONTAL_LINE_MODE = 2;
        const int VERTICAL_LINE_MODE = 3;
        const int ALL_DIAGONOL_LINE_MODE = 4;
        const double CENTER_LINE_PAYOUT = 2.0 ;
        const double HORIZONTAL_LINE_PAYOUT = 0.33 ;
        const double VERTICAL_LINE_PAYOUT = 0.25;
        const double ALL_DIAGONOL_LINE_PAYOUT = 0.75;
        
        //Wager and Game mode variables 
        double wager = 0.0;
        int gameMode = 0;
        
        Console.WriteLine("Let's play a game! Ths name of the game is a slot machine");
        Console.WriteLine("You will have the following options: \n" +
                          $"{CENTER_LINE_MODE} - Play the center line \n" +
                          $"{HORIZONTAL_LINE_MODE} - Play all three horizontals \n" +
                          $"{VERTICAL_LINE_MODE} - Play all vertical lines \n" +
                          $"{ALL_DIAGONOL_LINE_MODE} - Play diagonal lines \n");
       
        // boolean values to confirm wager and Gamechoice valid entries
        bool wagerEntrySuccessful;
        bool gameChoiceSuccessful;
        
        Console.WriteLine("Please enter your bet now: ");
        string wagerEntry = Console.ReadLine(); 
        wagerEntrySuccessful = Double.TryParse(wagerEntry, out wager);
        
        //Validate relevant wager values entered and repeat warnings until so
        while (!wagerEntrySuccessful)
        {
            Console.WriteLine("Please enter digits only!");
            Console.Write("Please enter your bet now: ");
            wagerEntry = Console.ReadLine(); 
            wagerEntrySuccessful = Double.TryParse(wagerEntry, out wager);
        }
        
        //Validate relevant game choice values entered and repeat warnings until so
        Console.WriteLine("Enter your choice number: ");
        string gameEntry = Console.ReadLine(); 
        gameChoiceSuccessful = int.TryParse(gameEntry, out gameMode);

        while (!gameChoiceSuccessful || (gameMode <= 0 || gameMode > NUMBER_OF_GAMES_OPTIONS))
        {
            Console.WriteLine("Please enter only integer numbers from the list above!");
            Console.Write("Enter your choice number: ");
            gameEntry = Console.ReadLine(); 
            gameChoiceSuccessful = int.TryParse(gameEntry, out gameMode);
        }
        
        
        
        // assign the size of array
        int[,] grid = new int[MATRIX_A,MATRIX_A];
        
        //assign random integers into array slots
        Random rand = new Random();

        // This could be defined as a function/method to be repeatedly called for slot game replays
        for (int i = 0; i < MATRIX_A; i++)
        {
            for (int j = 0; j < MATRIX_A; j++)
            {
                grid[i,j] = rand.Next(0, MAX_SLOT_MACHINE_INT);
            }
        }
        /*
        Console.WriteLine(grid.Length);
        Console.WriteLine(gameMode);
        Console.WriteLine(wager);
        */
        
        for (int x = 0; x < MATRIX_A; x++)
        {
            for (int y = 0; y < MATRIX_A; y++)
            {
                Console.Write($"|{grid[x, y]}|");
            }
            Console.WriteLine("");
        }
        double payoutRate = 0.0;
        double totalPayout = 0.0;
        bool gameWin = false;

        int matchCounter = 0;
        int firstValue = 0;
        
        //Console.WriteLine(centerValue);

        // Logical breakdown to validate match in values across diagonals, horizontals, verticals
        // This could be done as a method which checks for all the true cases of matches
        if (gameMode == CENTER_LINE_MODE )
        {
            int centerValueInt = MATRIX_A / 2;
            int middleValue = grid[centerValueInt, centerValueInt];
            
            //grid[1, 0] == grid[1, 1] && grid[1, 0] == grid[1, 2]
            for (int c = 0; c < MATRIX_A; c++)
            {
                if (middleValue == grid[centerValueInt, c]) matchCounter++;
            }
            if (matchCounter == MATRIX_A)
            {
                payoutRate = CENTER_LINE_PAYOUT;
                gameWin = true;
            }
        }
        if (gameMode == HORIZONTAL_LINE_MODE)
        {
            matchCounter = 0;
            for (int d = 0; d < MATRIX_A; d++)
            {
                firstValue = grid[d, 0];
                for (int e = 0; e < MATRIX_A; e++)
                {
                   if (firstValue == grid[d,e]) matchCounter++;
                }
                if (matchCounter == MATRIX_A)
                {
                    payoutRate = HORIZONTAL_LINE_PAYOUT;
                    gameWin = true;
                    break;
                }
            }
        }
        if (gameMode == VERTICAL_LINE_MODE)
        {
            matchCounter = 0;
            for (int f= 0; f < MATRIX_A; f++)
            {
                firstValue = grid[0, f];
                for (int g = 0; g < MATRIX_A; g++)
                {
                    if (firstValue == grid[g,f]) matchCounter++;
                }
                if (matchCounter == MATRIX_A)
                {
                    payoutRate = VERTICAL_LINE_PAYOUT;
                    gameWin = true;
                    break;
                }
            }
        }
        if (gameMode == ALL_DIAGONOL_LINE_MODE && 
            ((grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) 
             || (grid[2, 0] == grid[1, 1] && grid[1, 0] == grid[0, 2])))
        {
            payoutRate = ALL_DIAGONOL_LINE_PAYOUT;
            gameWin = true;
        }
        if (gameWin == false)
        {
            Console.WriteLine("You Lose!");
        }
            
        
        //game win variable == Y and rate % variable value, ask to play again?
        totalPayout =  payoutRate * wager;
        //print message and calculate payout if won
        
        
      
        
        
    }
}