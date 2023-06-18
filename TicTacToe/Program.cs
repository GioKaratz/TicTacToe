bool isPlayer1Turn = true;

// Create a 3x3 game board
char[,] board = new char[3, 3];

// Initialize the board with empty spaces
for (int row = 0; row < 3; row++)
{
    for (int col = 0; col < 3; col++)
    {
        board[row, col] = ' ';
    }
}

while (true)
{
    DisplayBoard(board);

    // Determine the current player's symbol
    char currentPlayerSymbol = isPlayer1Turn ? 'X' : 'O';

    // Prompt the current player for their move
    Console.WriteLine($"Player {(isPlayer1Turn ? 1 : 2)}, enter your move (row column) or 'e' for exit:");
    string input = Console.ReadLine().ToLower();
    //string[] input = Console.ReadLine().Split(' ');

    if (input == "e")
    {
        Console.WriteLine("Game Exited.");
        break;
    }

    string[] move = input.Split(' ');

    int row = int.Parse(move[0]);
    int col = int.Parse(move[1]);

    // Validate the move

    if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
    {
        Console.WriteLine("Invalid move! Try again.");
        continue;
    }

    // Update the game board with the player's move
    board[row, col] = currentPlayerSymbol;

    // Check for a win
    if (HasPlayerWon(board, currentPlayerSymbol))
    {
        DisplayBoard(board);
        Console.WriteLine($"Player {(isPlayer1Turn ? 1 : 2)} wins!");
        break;
    }

    if (isBoardFull(board))
    {
        DisplayBoard(board);
        Console.WriteLine("It's a tie!");
        break;
    }

    // Switch to the other player's turn
    isPlayer1Turn = !isPlayer1Turn;
}

void DisplayBoard(char[,] board)
{
    Console.WriteLine("    0   1   2");
    Console.WriteLine(" --------------");

    for (int row = 0; row < 3; row++)
    {
        Console.Write($"{row} ");
        for (int col = 0; col < 3; col++)
        {
            Console.Write($"| {board[row, col]} ");
        }

        Console.WriteLine("|");
        Console.WriteLine(" --------------");
    }
}

bool HasPlayerWon(char[,] board, char playerSymbol)
{
    // Check rows
    for (int row = 0; row < 3; row++)
    {
        if (board[row, 0] == playerSymbol && board[row, 1] == playerSymbol && board[row, 2] == playerSymbol)
            return true;
    }

    // Check Columns
    for (int col = 0; col < 3; col++)
    {
        if (board[0, col] == playerSymbol && board[1, col] == playerSymbol && board[2, col] == playerSymbol)
            return true;
    }

    // Check Diagonals
    if ((board[0, 0] == playerSymbol && board[1, 1] == playerSymbol && board[2, 2] == playerSymbol) ||
        (board[0, 2] == playerSymbol && board[1, 1] == playerSymbol && board[2, 0] == playerSymbol))
        return true;

    return false;
}

bool isBoardFull(char[,] board)
{
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (board[row, col] == ' ')
                return false;
        }
    }
    return true;
}