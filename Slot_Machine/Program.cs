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
        
        Console.Write("Please enter your bet now: ");
        wager = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter your choice number: ");
        gameMode = Convert.ToInt32(Console.ReadLine());
        //Need to add logic for identifying if it is an integer or try catch for characters
        while (gameMode <= 0 || gameMode > NUMBER_OF_GAMES_OPTIONS)
        {
            Console.WriteLine("Please only enter integer numbers from the list above:");
            gameMode = Convert.ToInt32(Console.ReadLine());
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
        char gameWin = 'N';
        int centerValueInt = MATRIX_A / 2;
        int middleValue = grid[centerValueInt, centerValueInt];
        int matchCounter = 0;
        
        //Console.WriteLine(centerValue);

        // Logical breakdown to validate match in values across diagonals, horizontals, verticals
        // This could be done as a method which checks for all the true cases of matches
        if (gameMode == CENTER_LINE_MODE )
        {
            //grid[1, 0] == grid[1, 1] && grid[1, 0] == grid[1, 2]
            for (int c = 0; c < MATRIX_A; c++)
            {
                if (middleValue == grid[centerValueInt, c]) matchCounter++;
            }
            if (matchCounter == MATRIX_A)
            {
                payoutRate = CENTER_LINE_PAYOUT;
                gameWin = 'Y';
            }
        }
        if (gameMode == HORIZONTAL_LINE_MODE)
        {
            payoutRate = HORIZONTAL_LINE_PAYOUT;
            gameWin = 'Y';
        }
        if (gameMode == VERTICAL_LINE_MODE)
        {
            
            payoutRate = VERTICAL_LINE_PAYOUT;
            gameWin = 'Y';
        }
        if (gameMode == ALL_DIAGONOL_LINE_MODE && 
            ((grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) 
             || (grid[2, 0] == grid[1, 1] && grid[1, 0] == grid[0, 2])))
        {
            payoutRate = ALL_DIAGONOL_LINE_PAYOUT;
            gameWin = 'Y';
        }
        if (gameWin == 'N')
        {
            Console.WriteLine("You Lose!");
        }
            
        
        //game win variable == Y and rate % variable value, ask to play again?
        totalPayout =  payoutRate * wager;
        //print message and calculate payout if won
        
        
      
        
        
    }
}