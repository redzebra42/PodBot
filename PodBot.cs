using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{

    static void Main(string[] args)
    {
        string[] inputs;
        
        int thrust = 0;
        List<int> checkpoints = []; //16000x + y
        bool firstTurnFinished = false;
        int currCheck = 1;
        int prevCheckpointX = 0;
        int prevCheckpointY = 0;
        int prevX, prevY;
        bool usedBoost = false;

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            int nextCheckpointX = int.Parse(inputs[2]); // x position of the next check point
            int nextCheckpointY = int.Parse(inputs[3]); // y position of the next check point
            int nextCheckpointDist = int.Parse(inputs[4]); // distance to the next checkpoint
            int nextCheckpointAngle = int.Parse(inputs[5]); // angle between your pod orientation and the direction of the next checkpoint
            inputs = Console.ReadLine().Split(' ');
            int opponentX = int.Parse(inputs[0]);
            int opponentY = int.Parse(inputs[1]);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            int dirX = nextCheckpointX;
            int dirY = nextCheckpointY;
            bool useBoost = false;

            if (!firstTurnFinished && prevCheckpointX != nextCheckpointX && prevCheckpointY != nextCheckpointY)
            {
                currCheck++;
            }

            if (!firstTurnFinished && !checkpoints.Contains(16000*nextCheckpointX + nextCheckpointY))
            {
                checkpoints.Add(16000*nextCheckpointX + nextCheckpointY);
            }
            else if (prevCheckpointX != nextCheckpointX && prevCheckpointY != nextCheckpointY)
            {
                firstTurnFinished = true;
            }

            if (firstTurnFinished && nextCheckpointDist < 1500)
            {
                if (prevCheckpointX != nextCheckpointX && prevCheckpointY != nextCheckpointY)
                {
                    currCheck++;
                }
                int checkpt = checkpoints[(currCheck) % checkpoints.Count()];
                dirX = checkpt / 16000;
                dirY = checkpt - 16000*dirX;
            }
            if (nextCheckpointAngle > 50 && nextCheckpointAngle < -50)
            {
                thrust = 0;
            }
            else
            {
                if (nextCheckpointDist < 30*thrust)
                {
                    thrust = 20;
                }
                else
                {
                    thrust = 100;
                }
            }

            if (!usedBoost && firstTurnFinished && nextCheckpointAngle < 5 && nextCheckpointAngle > -5 && nextCheckpointDist > 3000)
            {
                useBoost = true;
                usedBoost = true;
            }


            // You have to output the target position
            // followed by the power (0 <= thrust <= 100)
            // i.e.: "x y thrust"
            Console.Error.WriteLine(nextCheckpointDist);
            Console.Error.WriteLine(nextCheckpointAngle);
            Console.Error.WriteLine(usedBoost);
            if (!useBoost)
            {
                Console.WriteLine(dirX + " " + dirY + " " + thrust);
            }
            else
            {
                Console.WriteLine(dirX + " " + dirY + " " + "BOOST");
            }

            prevCheckpointX = nextCheckpointX;
            prevCheckpointY = nextCheckpointY;
        }
    }
}