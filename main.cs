using System;
using System.Linq;
using System.IO;	//StreamReader Belongs Here

class MainClass {
  public static void Main (string[] args) {

Console.Clear();	
string mySecret = System.Environment.GetEnvironmentVariable("my-secret");
Console.WriteLine (mySecret);
Console.Clear();

		Console.ForegroundColor = ConsoleColor.Magenta;	
    Console.WriteLine ("- SQUID GAME -");
		Console.WriteLine ("    ◯ △ ▢");
		System.Threading.Thread.Sleep(1000);
		Console.WriteLine ("Are you ready to win $100,000,000 ? [yes/no]");
		string startgame = Console.ReadLine();
		if (startgame == "yes")
			{
				Console.ForegroundColor = ConsoleColor.DarkMagenta;	
				Console.WriteLine ("Perfect, now time for us to take you there. Get in the car-");	Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine (" > you are blindfolded and fall alseep ");
				System.Threading.Thread.Sleep(3000);
				Console.ForegroundColor = ConsoleColor.DarkMagenta;	
				Console.WriteLine ("\nWELCOME PLAYERS !");
				Console.WriteLine ("This is SQUID GAME and you are ALL competing for a large sum, $100,000,000 and as you all know, every single one of you needs this money.\n The winner will receive everything.");
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("\nA PLAYER : Why should we believe you? Show us your faces!");	
				System.Threading.Thread.Sleep(1500);
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine ("The identities of every guard is kept a secret. And you should believe us since you are in dire need of money.\n");
			}
		else
		{
			Console.ForegroundColor = ConsoleColor.DarkMagenta;	
      Console.WriteLine("Oh well nevermind...you missed out.");
      System.Environment.Exit(0);
    }

		/////////////

		System.Threading.Thread.Sleep(2000);
		Console.ForegroundColor = ConsoleColor.DarkMagenta;	
		Console.WriteLine ("Pick your name. \n[your name cannot be changed, so type carefully]");
		string name = Console.ReadLine();
		Console.WriteLine ("Now we will assign you numbers. Please wait for your number to be assigned.");
		Random rnd = new Random();
		int playernum  = rnd.Next(100, 200);
		System.Threading.Thread.Sleep(1000);
		Console.WriteLine ("Your number is " + playernum);
		Console.WriteLine ("LET THE GAMES BEGIN!\n");
		
		System.Threading.Thread.Sleep(2000);
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine ("CHO SANG WOO : Hey "+playernum+" do you think you will win all this money??");
		System.Threading.Thread.Sleep(1000);
		Console.ForegroundColor = ConsoleColor.DarkRed;
		Console.WriteLine ("YOU : I don't know, but I'm going to try my best - I NEED THIS MONEY!\n What is your name by the way?");
		System.Threading.Thread.Sleep(1000);
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine ("CHO SANG WOO : The name's Cho Sang-Woo.");

		System.Threading.Thread.Sleep(5000);
		Console.Clear(); //clears console

		Console.ForegroundColor = ConsoleColor.DarkMagenta;
		Console.WriteLine ("The first game... Hangman.\n I hope everyone knows the rules. If not, let me explain: you need to guess a series of letters to guess the word that we have chosen. If you don't guess in 5 tries, you lose.");
		System.Threading.Thread.Sleep(3000);

		string[] words = new string[100]; 
		//random number generator that picks the word
    Random rnd1 = new Random();
		int num  = rnd1.Next(0, 100);
		StreamReader sr1 = new StreamReader("words.txt");
		for (int i=0;i<100;i++)
      {
        words[i] = sr1.ReadLine();
      }
		string guessword;
		guessword = Convert.ToString(words[num]);
    guessword = guessword.ToUpper();

    int lives = 5;
    int counter = -1;
    int wordLength = guessword.Length;
    char[] secretArray = guessword.ToCharArray();
    char[] printArray = new char[wordLength];
    char[] guessedLetters = new char[26];
    int numberStore = 0;
    bool victory = false;

		//outputs a '-' for every letter of the word
    foreach(char letter in printArray)
    {
      counter++;
      printArray[counter] = '-';
    }

    while(lives > 0)
    {
      counter = -1;
      string printProgress = String.Concat(printArray);
      bool letterFound = false;
      int multiples = 0;

      if (printProgress == guessword)
      {
        victory = true;
        break;
      }

      if (lives > 1)
      {
				Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("You have {0} lives!", lives);
				Console.ForegroundColor = ConsoleColor.White;
      }
      else
      {
				Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You only have {0} life left!", lives);
				Console.ForegroundColor = ConsoleColor.White;
      }

      Console.WriteLine("Progress : " + printProgress);
      Console.Write("\n");
      Console.Write("Guess a letter: ");
      string playerGuess = Console.ReadLine();

      //test to make sure a single letter
      bool guessTest = playerGuess.All(Char.IsLetter);
    
      while (guessTest == false || playerGuess.Length != 1)
      {
				Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("GUESS ONE LETTER ONLY!");
				Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Guess a letter: ");
        playerGuess = Console.ReadLine();
        guessTest = playerGuess.All(Char.IsLetter);
      }

      playerGuess = playerGuess.ToUpper();
      char playerChar = Convert.ToChar(playerGuess);

      if (guessedLetters.Contains(playerChar) == false)
      {       
        guessedLetters[numberStore] = playerChar;
        numberStore++;

        foreach(char letter in secretArray)
        { 
          counter++;
          if (letter == playerChar)
          {
            printArray[counter] = playerChar;
            letterFound = true;
            multiples++;
          }
        }
        if (letterFound)
        {
          Console.WriteLine("Found {0} letter {1}!", multiples, playerChar);
        }
        else
        {
          Console.WriteLine("No letter {0}!", playerChar);
          lives--;
        }
      }
      else
      {
        Console.WriteLine("You already guessed {0}!!", playerChar);
      }
    }

    if (victory)
      {
				Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\nThe word was: {0}", guessword);
        Console.WriteLine("\nWell done, you won this game.");
				Console.ForegroundColor = ConsoleColor.White;
      }
    else
      {
				Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nThe word was: {0}", guessword);
        Console.WriteLine("\nYou did not guess the word. You lost.");
				Console.ForegroundColor = ConsoleColor.White;
				System.Environment.Exit(0);
      }

	System.Threading.Thread.Sleep(4000);
	Console.Clear();
	
/////

	Console.ForegroundColor = ConsoleColor.DarkMagenta;
	Console.WriteLine ("Welcome to this game of Marbles! You need to get 0 marbles in your bag... Have fun.");
	System.Threading.Thread.Sleep(2000);
	Random rnd2 = new Random();
	int marbles  = rnd2.Next(7, 12);
	Console.ForegroundColor = ConsoleColor.White;
  Console.WriteLine ("\n > You have " + marbles + " marbles.");
	System.Threading.Thread.Sleep(1500);
	Console.ForegroundColor = ConsoleColor.DarkMagenta;
	Console.WriteLine ("But... there's a twist... You can only remove 1,2 or 3 marbles at a time...\n And not only that... you need to get rid of all those marbles in a maximum of 4 goes");
	int gone;
	int anothercounter = 4;
	System.Threading.Thread.Sleep(2000);
	do {
	Console.ForegroundColor = ConsoleColor.DarkGreen;
	Console.WriteLine (" > How many marbles do you want to remove? [type either 1,2,3]");
	gone = Convert.ToInt32(Console.ReadLine());
		do
			{
				if (anothercounter == 0)
					{
						Console.WriteLine ("You ran out of tries.\n You lost this game.");
						System.Environment.Exit(0);
					}
				
				if (marbles <= 0)
				{
					Console.WriteLine (" > You have no marbles left.");
				}

				if (gone > 3)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("YOU CAN ONLY REMOVE 1/2/3 MARBLES");
					anothercounter = anothercounter - 1;
					break;
				}

				else
				{
					marbles = (marbles - gone);
					anothercounter = anothercounter - 1;
					break;
				}

			}
			while (marbles != 0);

	if (marbles <= 0)
		{
			Console.WriteLine (" > You have no marbles");		
			break;	
		}

	if (marbles != 0)
	{
	Console.ForegroundColor = ConsoleColor.DarkRed;
	Console.WriteLine ("You have " + anothercounter + " tries left");
	}

	if (anothercounter == 0 && marbles > 0)
		{
			Console.WriteLine ("You ran out of tries.");
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.WriteLine("You lost this game.");
			System.Environment.Exit(0);			
		}
	
	Console.ForegroundColor = ConsoleColor.Green;
	Console.WriteLine (" > You have " + marbles + " marble(s)");
	}
	while (marbles != 0);  

System.Threading.Thread.Sleep(2000);
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine ("Well done.\nAll your marbles have been removed sucessfully. Good job players.");
System.Threading.Thread.Sleep(3000);
Console.Clear();
	
/////

Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine ("Only 10 players remain... and YOU are one of them! Beat this last game to become rich beyond your wildest dreams.");
System.Threading.Thread.Sleep(2000);
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine ("This is a simple 'fight-to-the-death' game.\nYou need to try and beat the other player using the letters 'p' or 'd'.");
Console.WriteLine ("p stands for punch. d stands for defend.");
Console.ForegroundColor = ConsoleColor.White;

	
var player1 = 100;
var computer = 100;

do
{
if (player1 <= 0)
	{
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine ("You lost.");
		System.Environment.Exit(0);	
		break;			
	}

if (computer <= 0)
	{
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine ("Kang Sae-byeok lost.");
		break;
	}

Console.ForegroundColor = ConsoleColor.Blue;	
Console.WriteLine  ("What would you like to do ?");
string option1 = Console.ReadLine();

if (option1 == "p")
	{
		Random rnd10 = new Random();
		int damage  = rnd10.Next(1, 50);
			if (damage > 25)
				{
				computer = computer - damage;
				Console.WriteLine ("You deal an awesome hit and now Kang Sae-byeok is left with " + (computer) + " HP");
				}
			if (damage < 25)
				{
				computer = computer - damage;
				Console.WriteLine ("You deal a measly hit and now Kang Sae-byeok is left with " + (computer) + " HP");
				}
			}
	
if (option1 == "d")
	{
		Random rnd3 = new Random();
		int protect  = rnd3.Next(1, 15);
		player1 = player1 + protect;
		Console.WriteLine ("YOU PROTECT and gain " + protect + " HP");
		Console.WriteLine ("You have " + player1 + "HP");			
	}

//next player aka computer

if (player1 <= 0)
	{
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine ("You lost.");
		System.Environment.Exit(0);	
		break;			
	}

if (computer <= 0)
	{
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine ("Kang Sae-byeok lost.");
		break;
	}

Random rnd4 = new Random();
int compdamage  = rnd4.Next(1, 30);
	if (compdamage > 15)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			player1 = player1 - compdamage;
			Console.WriteLine ("Kang Sae-byeok deals an amazing hit and now you are left with " + (player1) + " HP");
			Console.ForegroundColor = ConsoleColor.White;
		}
	if (compdamage < 15)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			player1 = player1 - compdamage;
			Console.WriteLine ("Kang Sae-byeok deals a terrible hit and now you are left with " + (player1) + " HP");
			Console.ForegroundColor = ConsoleColor.White;
		}
	
	
}
while (player1 > 0 || computer > 0);

System.Threading.Thread.Sleep(5000);
Console.Clear();
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine ("You made it this far, well done " + name);
Console.WriteLine ("You have won the game! Here is your $100,000,000!");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine (" ______________");
Console.WriteLine ("|              |");
Console.WriteLine ("|     $  $     |");
Console.WriteLine ("|              |");
Console.WriteLine (" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
Console.ForegroundColor = ConsoleColor.White;

	
	
	
	}
}
