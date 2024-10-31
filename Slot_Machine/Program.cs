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
        
        //Console.WriteLine(string.Join("", grid));  // how tp print a whole array?
        
        Console.WriteLine($"|{grid[0,0]}|{grid[0,1]}|{grid[0,2]}| \n" +
                          $"|{grid[1,0]}|{grid[1,1]}|{grid[1,2]}| \n" +
                          $"|{grid[2,0]}|{grid[2,1]}|{grid[2,2]}| \n");
        
        double payoutRate = 0.0;
        double totalPayout = 0.0;
        char gameWin = 'N';

        // Logical breakdown to validate match in values accorss diagnals, horizontals, verticals
        // This could be done as a method which checks for all the true cases of matches
        if (gameMode == CENTER_LINE_MODE)
        {
            
        }

        if (gameMode == HORIZONTAL_LINE_MODE)
        {
            
        }
        if (gameMode == VERTICAL_LINE_MODE)
        {
            
        }
        if (gameMode == ALL_DIAGONOL_LINE_MODE)
        {
            
        }
        
        //game win variable == Y and rate % variable value, ask to play again?
        
        //print message and calculate payout if won
        
        
      
        
        
    }
}