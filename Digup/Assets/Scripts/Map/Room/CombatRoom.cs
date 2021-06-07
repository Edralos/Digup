
using UnityEngine;

public class CombatRoom : StageRoom
{
    public Side AllySide { get; set; }
    public Side EnemySide { get; set; }

    public CombatRoom() : this(0)
    {
        
    }

    public CombatRoom(int depth) : base(depth)
    {
        Name = "Combat Room";

        AllySide = new Side();
        EnemySide = new Side();

        //Randomly set the number of enemies
        int nbAllies = 4; //TODO : utiliser la valeur stock�e plutot qu'une valeur en brut
        System.Random rand = new System.Random();
        int nbEnemies =  Difficulty + nbAllies;

        //Generate the enemies
        for (int i = 0; i < nbEnemies; i++)
        {
            bool isFrontLane = rand.Next(100) <= 50 ? true : false;

            if (isFrontLane) {
                //Generate a front lane enemy
                Enemy enemy = GameData.GetEnemy("Rat soldier");

                bool isCellAvailable;
                do {
                    int position = rand.Next(6);
                    isCellAvailable = EnemySide.FrontLane.AddCharacter(position, enemy);
                } while (!isCellAvailable);
            }
            else
            {
                //Generate a back lane enemy
                Enemy enemy = GameData.GetEnemy("Squarab");

                bool isCellAvailable;
                do {
                    int position = rand.Next(6);
                    isCellAvailable = EnemySide.BackLane.AddCharacter(position, enemy);
                } while (!isCellAvailable);
            }
        }


        Debug.Log(this);
    }

    public override string ToString()
    {

        string sRet = "\n" + "--------------------------------" + "\n";
        sRet += "Combat Room :\n";

        foreach (Enemy enemy in EnemySide.FrontLane.Characters)
        {
            if (enemy != null)
                sRet += enemy.Name + "\n";
        }
        foreach (Enemy enemy in EnemySide.BackLane.Characters)
        {
            if (enemy != null)
                sRet += enemy.Name + "\n";
        }

        return sRet;
    }
}
