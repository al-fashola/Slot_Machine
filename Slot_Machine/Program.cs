namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const int MATRIX_A = 3;
        const int MATRIX_B = 3;
        const int NUMBER_OF_GAMES_OPTIONS = 4;
        const int MAX_SLOT_MACHINE_INT = 40;
        
        

        double wager = 0.0;
        int gameMode = 0;
        
        
        Console.WriteLine("Let's play a game! Ths name of the game is a slot machine");
        Console.WriteLine("You will have the following options: \n" +
                          "1 - Play the center line \n" +
                          "2 - Play all three horizontals \n" +
                          "3 - Play all vertical lines \n" +
                          "4 - Play diagonal lines \n");
        
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
        int[,] Array2d = new int[MATRIX_A,MATRIX_B];
        
        //assign random integers into array slots
        Random rand = new Random();

        // This could be defined as a function/method to be repeatedly called for slot game replays
        for (int i = 0; i < MATRIX_A; i++)
        {
            for (int j = 0; j < MATRIX_B; j++)
            {
                Array2d[i,j] = rand.Next(0, MAX_SLOT_MACHINE_INT);
            }
        }
        
        
        /*
        Console.WriteLine(Array2d.Length);
        Console.WriteLine(gameMode);
        Console.WriteLine(wager);
        */
        
        //Console.WriteLine(string.Join("", Array2d));  // how tp print a whole array?
        
        Console.WriteLine($"|{Array2d[0,0]}|{Array2d[0,1]}|{Array2d[0,2]}| \n" +
                          $"|{Array2d[1,0]}|{Array2d[1,1]}|{Array2d[1,2]}| \n" +
                          $"|{Array2d[2,0]}|{Array2d[2,1]}|{Array2d[2,2]}| \n");
        
        double payoutRate = 0.0;
        double totalPayout = 0.0;
        char gameWin = 'N';

        // Logical breakdown to validate match in values accorss diagnals, horizontals, verticals
        // This could be done as a method which checks for all the true cases of matches
        if (gameMode == 1)
        {
            
        }

        if (gameMode == 2)
        {
            
        }
        if (gameMode == 3)
        {
            
        }
        if (gameMode == 4)
        {
            
        }
        
        //game win variable == Y and rate % variable value, ask to play again?
        
        //print message and calculate payout if won
        
        
      
        
        
    }
}