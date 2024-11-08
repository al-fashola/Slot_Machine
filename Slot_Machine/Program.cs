namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const int MATRIX_GRID_SIZE = 3;
        const int NUMBER_OF_GAMES_OPTIONS = 4;
        const int MAX_SLOT_MACHINE_INT = 3;
        
        const int CENTER_LINE_MODE = 1;
        const int HORIZONTAL_LINE_MODE = 2;
        const int VERTICAL_LINE_MODE = 3;
        const int ALL_DIAGONOL_LINE_MODE = 4;
        const double CENTER_LINE_PAYOUT = 2.0 ;
        const double HORIZONTAL_LINE_PAYOUT = 0.33 ;
        const double VERTICAL_LINE_PAYOUT = 0.25;
        const double ALL_DIAGONOL_LINE_PAYOUT = 0.75;
        const char CONTINUE_PLAYING_GAME = 'Y';
        
        
        Console.WriteLine("Let's play a game! The name of the game is a slot machine");
        // boolean values to confirm wallet, wager and game choices are valid entries
        bool wagerEntrySuccessful;
        bool gameChoiceSuccessful;
        bool walletEntrySuccessful;
        
        
        double wallet = 0.0;
        
        Console.WriteLine("Please enter how much you would like to load in your wallet now: ");
        string walletEntry = Console.ReadLine(); 
        walletEntrySuccessful = Double.TryParse(walletEntry, out wallet);
        
        while (!walletEntrySuccessful)
        {
            Console.WriteLine("Please enter digits only!");
            Console.Write("Please enter your Wallet amount now: ");
            walletEntry = Console.ReadLine(); 
            walletEntrySuccessful = Double.TryParse(walletEntry, out wallet);
        }
        
        Start:
        Console.WriteLine($"You currently have ${wallet} loaded in your wallet .");
        Console.WriteLine("You will have the following options: \n" +
                          $"{CENTER_LINE_MODE} - Play the center line \n" +
                          $"{HORIZONTAL_LINE_MODE} - Play all three horizontals \n" +
                          $"{VERTICAL_LINE_MODE} - Play all vertical lines \n" +
                          $"{ALL_DIAGONOL_LINE_MODE} - Play diagonal lines \n");
       
        
        double wager = 0.0;
        
        Console.WriteLine("Please enter your bet now: ");
        string wagerEntry = Console.ReadLine(); 
        wagerEntrySuccessful = Double.TryParse(wagerEntry, out wager);
        
        //Validate relevant wager values entered and repeat warnings until so
        while (!wagerEntrySuccessful || wager > wallet || wager == 0.0)
        {
            Console.WriteLine($"Please enter digits only! The wager amount will need to be greater than 0 and less than or equal to the funds currently in your wallet. Wallet: {wallet}");
            Console.Write("Please enter your bet now: ");
            wagerEntry = Console.ReadLine(); 
            wagerEntrySuccessful = Double.TryParse(wagerEntry, out wager);
        }
        
        int gameMode = 0;
        
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
        int[,] grid = new int[MATRIX_GRID_SIZE,MATRIX_GRID_SIZE];
        
        //assign random integers into array slots
        Random rand = new Random();

        // This could be defined as a function/method to be repeatedly called for slot game replays
        for (int i = 0; i < MATRIX_GRID_SIZE; i++)
        {
            for (int j = 0; j < MATRIX_GRID_SIZE; j++)
            {
                grid[i,j] = rand.Next(0, MAX_SLOT_MACHINE_INT);
            }
        }
        /*
        Console.WriteLine(grid.Length);
        Console.WriteLine(gameMode);
        Console.WriteLine(wager);
        */
        
        for (int i = 0; i < MATRIX_GRID_SIZE; i++)
        {
            for (int j = 0; j < MATRIX_GRID_SIZE; j++)
            {
                Console.Write($"|{grid[i, j]}|");
            }
            Console.WriteLine("");
        }
        double payoutRate = 0.0;
        double totalPayout = 0.0;
        bool gameWin = false;

        int matchCounter = 0;
        int firstValue = 0;
        
        // Logical breakdown to validate match in values across diagonals, horizontals, verticals
        // This could be done as a method which checks for all the true cases of matches
        if (gameMode == CENTER_LINE_MODE )
        {
            int centerValueInt = MATRIX_GRID_SIZE / 2;
            int middleValue = grid[centerValueInt, centerValueInt];
            
            for (int i = 0; i < MATRIX_GRID_SIZE; i++)
            {
                if (middleValue == grid[centerValueInt, i]) matchCounter++;
            }
            if (matchCounter == MATRIX_GRID_SIZE)
            {
                payoutRate = CENTER_LINE_PAYOUT;
                gameWin = true;
            }
        }
        if (gameMode == HORIZONTAL_LINE_MODE)
        {
            
            for (int i = 0; i < MATRIX_GRID_SIZE; i++)
            {
                matchCounter = 0;
                firstValue = grid[i, 0];
                for (int j = 0; j < MATRIX_GRID_SIZE; j++)
                {
                   if (firstValue == grid[i,j]) matchCounter++;
                }
                if (matchCounter == MATRIX_GRID_SIZE)
                {
                    payoutRate = HORIZONTAL_LINE_PAYOUT;
                    gameWin = true;
                    break;
                }
            }
        }
        if (gameMode == VERTICAL_LINE_MODE)
        {
            for (int i= 0; i < MATRIX_GRID_SIZE; i++)
            {
                matchCounter = 0;
                firstValue = grid[0, i];
                for (int j = 0; j < MATRIX_GRID_SIZE; j++)
                {
                    if (firstValue == grid[j,i]) matchCounter++;
                }
                if (matchCounter == MATRIX_GRID_SIZE)
                {
                    payoutRate = VERTICAL_LINE_PAYOUT;
                    gameWin = true;
                    break;
                }
            }
        }
        if (gameMode == ALL_DIAGONOL_LINE_MODE)
        {
            //((grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) 
            // || (grid[2, 0] == grid[1, 1] && grid[1, 0] == grid[0, 2]))
            matchCounter = 0;
            int matchCounterAlt = 0;
            
            int centerValueInt = MATRIX_GRID_SIZE / 2;
            int matchValue = grid[centerValueInt, centerValueInt];
            
            for (int h = 0, i = 0, j= MATRIX_GRID_SIZE-1; h < MATRIX_GRID_SIZE; h++, i++, j--)
            {
                if (matchValue == grid[h,i]) matchCounter++;
                if (matchValue == grid[j,i]) matchCounterAlt++;
            }
            
            if (matchCounter == MATRIX_GRID_SIZE || matchCounterAlt == MATRIX_GRID_SIZE)
            {
                payoutRate = ALL_DIAGONOL_LINE_PAYOUT;
                gameWin = true;
            }
        }
        
        //Win or lose logic
        if (gameWin == false)
        {
            Console.WriteLine("You Lose!");
            wallet = (wallet - wager);
        }
        if (gameWin)
        {
            Console.WriteLine("You Win!");
            totalPayout =  payoutRate * wager;
            wallet = totalPayout + wallet ;
            Console.WriteLine($"Your total payout is: {totalPayout}");
            Console.WriteLine($"The total in your wallet is: {wallet}");
        }

        if (wallet == 0.0)
        {
            Console.WriteLine("Game Over! You currently have no funds left.");
        }
        else
        {   
            Console.WriteLine($"You currently have ${wallet} in your wallet");
            Console.WriteLine($"would you like to play again? {CONTINUE_PLAYING_GAME}/N");
            char input = Console.ReadKey().KeyChar;
            input = char.ToUpper(input);
            if (input == CONTINUE_PLAYING_GAME)
            {
                goto Start;
            }
        }  
        
        
        
    }
}