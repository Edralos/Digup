using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : StageRoom
{
    public Side AllySide { get; set; }
    public Side EnemySide { get; set; }

    public CombatRoom(): this(0)
    {
        AllySide = new Side();
        EnemySide = new Side();

        //Randomly set the number of enemies
        int nbAllies = 4;
        int nbEnemies = 0;
        System.Random rand = new System.Random();
        int randInt = rand.Next(100);
        if(randInt < 20) {
            nbEnemies = 1;
        } else if(randInt < 40) {
            nbEnemies = 2;
        } else if(randInt < 80) {
            nbEnemies = 3;
        } else {
            nbEnemies = 4;
        }
        nbEnemies += nbAllies;

        //Generate the enemies
        for(int i = 0; i < nbEnemies; i++)
        {
            bool isFrontLane = rand.Next(100) <= 50 ? true : false;

            if (isFrontLane) {
                //Generate a front lane enemy
                Enemy enemy = GameData.GetEnemy("Rat soldier");

                bool isCellAvailable = true;
                do {
                    int position = rand.Next(6);
                    isCellAvailable = EnemySide.FrontLane.AddCharacter(position, enemy);
                } while (isCellAvailable);
            } else {
                //Generate a back lane enemy
                Enemy enemy = GameData.GetEnemy("Squarab");

                bool isCellAvailable = true;
                do {
                    int position = rand.Next(6);
                    isCellAvailable = EnemySide.BackLane.AddCharacter(position, enemy);
                } while (isCellAvailable);
            }
        }


    }

    public CombatRoom(int depth) : base(depth)
    {
        Name = "Combat Room";
    }

}
