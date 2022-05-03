using System;

namespace MyGame
{
    class Program
    {
        static Int32 MeX = 10, MeY = 10, oldMeX, oldMeY;    //Birthing the player
        static ConsoleKey k = ConsoleKey.NoName;

        static Int32 GtargetX, GtargetY, oldGtargetX, oldGtargetY; //Birthing good target
        static Int32 XGtargetloc, YGtargetloc; // need this to create random locations 

        static Int32 BtargetX, BtargetY, oldBtargetX, oldBtargetY;  //birthing bad target
        static Int32 XBtargetloc, YBtargetloc;  // need this to create random locations 

        static Int32 LivesX = 110, LivesY = 0; //bithing the location of my lives setup 

        static Int32 MeSpeed = 1;
        static Int32 ScoreX = 1, ScoreY = 0;  //bithing the location of my score setup 
        static Int32 points = 0;  //birthing points
        static Int32 lives = 5;     //birthing lives
        static Random rnd = new Random();  //birthing random variable to be use by many
        static Int32 attempts=0;
        static void Main(string[] args)
        {
    
            IntroPageGame();
            Console.Clear();


            XBtargetloc = rnd.Next(0, 118); //creating random locations for bad target
            YBtargetloc = rnd.Next(0, 29);
            BtargetX = XBtargetloc;
            BtargetY = YBtargetloc;


            XGtargetloc = rnd.Next(0, 118);  //creating random locations for good target
            YGtargetloc = rnd.Next(0, 29);
            GtargetX = XGtargetloc;
            GtargetY = YGtargetloc;


            // create Targetx, targety, give it random number
            Console.CursorVisible = false;


            while (!gameover())
            {
                getkeystroke();
                draw();
                gameover();

                if (k == ConsoleKey.Escape)
                {
                    break;
                }
            }
            Console.Clear();


             IntroPageMiniGame();
            Console.Clear();


           if(points!=0)
        {
                Int32 rightnumber;
            rightnumber = rnd.Next(1, 10);
            Int32 guessnumber;
            Boolean goodnumber;

            do
            {

                do
                {
                    Console.Write("What is your guessing number? ");
                    goodnumber = Int32.TryParse(Console.ReadLine(), out guessnumber);
                    if (!goodnumber)
                    {
                        Console.WriteLine("You didn't type in numbers! Try again! ");
                    }
                } while (!goodnumber);

                if (guessnumber < rightnumber)
                {
                    Console.WriteLine("Guess is too low");
                }
                else if (guessnumber > rightnumber)
                {
                    Console.WriteLine("Guess is too high");
                }

                attempts = attempts + 1;

            } while (guessnumber != rightnumber && points!=0);

            if (attempts <= 1 )
            {
                points = points * 2;
            }

            if (attempts >= 3 )
            {
                points = points / 2;
            }

            Console.Clear();

            OutroPage();
        }
        }
        static void IntroPageGame()
        {
            while (true) //INTRO PAGE FOR GAME
            {
                Console.WriteLine("Hello Players!");
                Console.WriteLine(" ");
                Console.WriteLine("In this game, you will be the '0' on the screen");
                Console.WriteLine("Reach any of the two 'X's on the screen by moving with your arrows");
                Console.WriteLine("You can move faster if you hit the spacebar and break with the key 'B'");
                Console.WriteLine("If you get the right one, you will recieve points");
                Console.WriteLine("But get the wrong one and lose a life!");
                Console.WriteLine("Your goal is to get as many points before you run out of lives");
                Console.WriteLine("You're beating the odds if you get more than fifty points!");
                Console.WriteLine(" ");
                Console.WriteLine("Press any key to to play");
                getkeystroke();
                if (k != Console.ReadKey(true).Key)
                {
                    break;
                }
            }

        }

        static void IntroPageMiniGame()
        {
            while (true) //INTRO PAGE FOR MINI GAME REDEMPTION
            {
                if (points==0)
                {
                Console.WriteLine("Sorry! Looks like luck isn't on your side. You have completed the game with " + points + " points.");
                Console.WriteLine(" ");
                Console.WriteLine("The game ends here ");
                Console.WriteLine(" ");
                Console.WriteLine("Thank you for playing the game! ");
                    Console.WriteLine("Press any key to exit");
                }

                else
                {
                    Console.WriteLine("Congratulations! You have completed the game with " + points + " points.");
                    if(points >50)
                    {
                        Console.WriteLine("You beat the odds!");
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("Now it's time to see if you can double your points...");
                    Console.WriteLine("Guess a number between 1 and 10");
                    Console.WriteLine("Get it right the first try and your points will double");
                    Console.WriteLine("Get it right the second try and your points will stay untouched");
                    Console.WriteLine("After that, your points will be cut in half!");
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to to play. Good luck, you'll need it!");
                }

                getkeystroke();
                if (k != Console.ReadKey(true).Key)
                {
                    break;
                }
            }

        }

        static void getkeystroke()
        {
            if (Console.KeyAvailable)
            {
                k = Console.ReadKey(true).Key; //if keybord was hit then...
                oldMeX = MeX;
                oldMeY = MeY; // rememver where you were - you are about to change position so remember the old one so you can clean it up.
                move();     //... move 
            }
        }

        static void move()
        {
            if (k == ConsoleKey.Spacebar)
            {
                MeSpeed = MeSpeed + 1;
            }

            if (k == ConsoleKey.B)
            {
                MeSpeed = MeSpeed - 1;
            }

            if (k == ConsoleKey.UpArrow)
            {
                MeY = MeY - MeSpeed;
            }

            if (k == ConsoleKey.LeftArrow)
            {
                MeX = MeX - MeSpeed;
            }

            if (k == ConsoleKey.DownArrow)
            {
                MeY = MeY + MeSpeed;
            }

            if (k == ConsoleKey.RightArrow)
            {
                MeX = MeX + MeSpeed;
            }

            if (MeX < 0)   //making sure it doesnt bug when i go out of range
            {
                MeX = 118;

            }

            if (MeX > 118)   //making sure it doesnt bug when i go out of range
            {
                MeX = 0;
            }

            if (MeY > 29)   //making sure it doesnt bug when i go out of range
            {
                MeY = 0;
            }

            if (MeY < 0)    //making sure it doesnt bug when i go out of range
            {
                MeY = 29;
            }

            if (MeX == GtargetX && MeY == GtargetY)  //when player hits good target
            {
                oldGtargetX = GtargetX; //need to set good target to old to get rid of litter later
                oldGtargetY = GtargetY;

                XGtargetloc = rnd.Next(0, 118); //giving a new random location for good target
                YGtargetloc = rnd.Next(0, 29);
                GtargetX = XGtargetloc;
                GtargetY = YGtargetloc;



                oldBtargetX = BtargetX; //need to set bad target to old to get rid of litter later
                oldBtargetY = BtargetY;

                XBtargetloc = rnd.Next(0, 118); //giving a new random location for bad target
                YBtargetloc = rnd.Next(0, 29);
                BtargetX = XBtargetloc;
                BtargetY = YBtargetloc;


                points = points + 10;
            }

            if (MeX == BtargetX && MeY == BtargetY)      //when player hits bad target
            {
                oldBtargetX = BtargetX;  //need to set bad target to old to get rid of litter later
                oldBtargetY = BtargetY;

                XBtargetloc = rnd.Next(0, 118);    //giving a new random location for bad target
                YBtargetloc = rnd.Next(0, 29);
                BtargetX = XBtargetloc;
                BtargetY = YBtargetloc;


                oldGtargetX = GtargetX;    //need to set good target to old to get rid of litter later
                oldGtargetY = GtargetY;

                XGtargetloc = rnd.Next(0, 118);    // giving a new random location for good target
                YGtargetloc = rnd.Next(0, 29);
                GtargetX = XGtargetloc;
                GtargetY = YGtargetloc;

                lives = lives - 1;
            }

            // here - you put in two more if statements for vertical movement on the y axis 
            // later - much later - if targetx == Mex && targety == MeY  then pointes = points + 100, and resposition target
        }

        static Boolean gameover()
        {
            if (lives > 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }


        static void draw()
        {
            Console.SetCursorPosition(MeX, MeY); //setting new postion for player
            Console.Write('0');

            Console.SetCursorPosition(oldMeX, oldMeY);   //cleaning up litter of player
            Console.Write(' '); //clean up the litter....


            Console.SetCursorPosition(GtargetX, GtargetY);//setting new postion for good target
            Console.Write('X');

            Console.SetCursorPosition(oldGtargetX, oldGtargetY);//cleaning up litter of good target
            Console.Write(' ');


            Console.SetCursorPosition(ScoreX, ScoreY); //setting position for score
            Console.Write("Score = " + points);


            Console.SetCursorPosition(BtargetX, BtargetY);   //setting new postion for bad target
            Console.Write('X');

            Console.SetCursorPosition(oldBtargetX, oldBtargetY);    //cleaning up litter of bad target
            Console.Write(' ');


            Console.SetCursorPosition(LivesX, LivesY); //setting position for lives
            Console.Write("Lives: " + lives);

            // print out your target
            // later print out your score = I suggest a corner
        }

        static void OutroPage()
            {


                if (attempts <=1 )
                {
                    Console.WriteLine("Guess is correct! It took you " + attempts + " attempt.");
                    Console.WriteLine(" ");
                    Console.WriteLine("What luck! Your points doubled to " + points + ". Congratulations! "); 
                    Console.WriteLine(" ");
                    Console.WriteLine("Thank you for playing the game! ");

                }

                else if (attempts == 2 )
                {
                    Console.WriteLine("Guess is correct! It took you " + attempts + " attempts.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Consider yourself lucky! Your points remain the same. ");
                    Console.WriteLine("You finished with " + points + " points.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Thank you for playing the game! ");
                }


                else
                {
                    Console.WriteLine("Guess is correct! It took you " + attempts + " attempts.");
                    Console.WriteLine(" ");
                    Console.WriteLine("You're out of luck. Sorry! You lose half your points!");
                    Console.WriteLine("You finished with " + points + " points.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Thank you for playing the game! ");
                }
    
            }
        }
    }




