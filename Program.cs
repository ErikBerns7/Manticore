using System.Xml.Serialization;

int manticoreHp = 10;
int cityHp = 15;
int cannonDamage = 0;
int distance = AskForDistance();


Console.Clear();

for (int round = 1; manticoreHp > 0 || cityHp > 0; round++)
{

    //Kanonen System
    if (round % 3 != 0 && round % 5 != 0)
    {
        cannonDamage = 1;
    }
    else if (round % 3 == 0 && round % 5 == 0)
    {
        cannonDamage = 10;
    }

    else if (round % 5 == 0)
    {
        cannonDamage = 5;
    }

    else if (round % 3 == 0)
    {
        cannonDamage = 3;
    }

    if (manticoreHp <= 0 || cityHp <= 0)
    {
        break;
    }


    Console.WriteLine($"Status: Round {round} City: {cityHp}/15 Manticore: {manticoreHp}/10 ");
    Console.WriteLine($"Expected canon damage this round: {cannonDamage}");
    Console.Write("Enter the desired Cannon Range: ");
    string rangeText = Console.ReadLine();
    int range = Convert.ToInt32(rangeText);

    if (range > distance)
    {
        Console.WriteLine("That round overshot the target!");
        cityHp -= 1;
    }
    else if (range < distance)
    {
        Console.WriteLine("That round fell short of the target!");
        cityHp -= 1;
    }
    else
    {
        Console.WriteLine("That round was a direct hit!");
        manticoreHp -= cannonDamage;
        cityHp -= 1;

    }


}

if (manticoreHp <= 0)
{
    Console.WriteLine("You have defended the city!");
}

if (cityHp <= 0)
{
    Console.WriteLine("The city has been destroyed!");
}


int AskForDistance()
{
    Console.WriteLine("Player 1, choose the manticores distance.");
    string distanceText = Console.ReadLine();
    int distance = Convert.ToInt32(distanceText);
    return distance;
}
