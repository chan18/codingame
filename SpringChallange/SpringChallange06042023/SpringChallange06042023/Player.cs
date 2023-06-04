using System;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SpringChallange06042023;


/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
 
public class State
{
    // amount of hexagonal cells in this map
    public int numberOfCells {get; set;}
    public List<int> cellNumber {get; set;} = new();

    // 0 for empty, 1 for eggs, 2 for crystal
    public CellType cellType {get; set;}   

    // the initial amount of eggs/crystals on this cell
    public int initialResources {get; set;}

     // the index of the neighbouring cell for each direction
    public List<int> neighbouring {get; set;} = new();

    public int numberOfBases {get; set;}
    public Base bases {get; set;} = new();
    public List<Intel> gameIntel {get; set;} = new();
}

public class Base
{    
    //public List<(int x,int y)> point {get; set;} = new();
    public List<int> myBases {get; set;} = new();
    public List<int> myOppBases {get; set;} = new();

}

public enum CellType
{
    Empty = 0,
    Eggs = 1,
    Crystal = 2
}


public class Intel
{
    public int cellNumber {get; set;}
    // the current amount of eggs/crystals on this cell
    public int resources {get; set;}
    public int myAnts {get; set;}
    public int oppAnts {get; set;}
}

class Player
{
    // Commands
    private const string MESSAGE = "MESSAGE";
    private const string BEACON = "BEACON";
    private const string LINE = "LINE";
    private const string WAIT = "WAIT";
    private const string EOA = ";";

    static void Main(string[] args)
    {
        string[] inputs;
        var gameIntel = new List<Intel>();
        var gameState = new State();

        // Write an action using Console.WriteLine()
        Action<String> cw = Console.WriteLine;

        // To debug: Console.Error.WriteLine("Debug messages...");
        Action<String> cwe = Console.Error.WriteLine;

        // amount of hexagonal cells in this map
        int numberOfCells = int.Parse(Console.ReadLine());
        gameState.numberOfCells = numberOfCells;

        for (int i = 0; i < numberOfCells; i++)
        {
            inputs = Console.ReadLine().Split(' ');

            // 0 for empty, 1 for eggs, 2 for crystal
            int type = int.Parse(inputs[0]);

            // the initial amount of eggs/crystals on this cell
            int initialResources = int.Parse(inputs[1]);

            // the index of the neighbouring cell for each direction
            int neigh0 = int.Parse(inputs[2]);
            int neigh1 = int.Parse(inputs[3]);
            int neigh2 = int.Parse(inputs[4]);
            int neigh3 = int.Parse(inputs[5]);
            int neigh4 = int.Parse(inputs[6]);
            int neigh5 = int.Parse(inputs[7]);

            gameState.cellNumber.Add(i);
            gameState.initialResources = initialResources;
            gameState.cellType = (CellType)type;

            gameState.neighbouring.Add(neigh0);
            gameState.neighbouring.Add(neigh1);
            gameState.neighbouring.Add(neigh2);
            gameState.neighbouring.Add(neigh3);
            gameState.neighbouring.Add(neigh4);
            gameState.neighbouring.Add(neigh5);
        }

        int numberOfBases = int.Parse(Console.ReadLine());
        gameState.numberOfBases = numberOfBases;

        inputs = Console.ReadLine().Split(' ');

        for (int i = 0; i < numberOfBases; i++)
        {
            int myBaseIndex = int.Parse(inputs[i]);
            gameState.bases.myBases.Add(myBaseIndex);
        }

        inputs = Console.ReadLine().Split(' ');
        for (int i = 0; i < numberOfBases; i++)
        {
            int oppBaseIndex = int.Parse(inputs[i]);            
            gameState.bases.myOppBases.Add(oppBaseIndex);
        }

        // game loop
        while (true)
        {

            // reading game inputes.
            for (int i = 0; i < numberOfCells; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                // the current amount of eggs/crystals on this cell
                int resources = int.Parse(inputs[0]);

                // the amount of your ants on this cell
                int myAnts = int.Parse(inputs[1]);

                // the amount of opponent ants on this cell
                int oppAnts = int.Parse(inputs[2]);
            }

            cwe("started");
        
            cw(Play());
            
            cwe("Debug message");


            // WAIT | LINE <sourceIdx> <targetIdx> <strength> | BEACON <cellIdx> <strength> | MESSAGE <text>
            Console.WriteLine("WAIT");
        }
    }

    public static string Play()
    {
        var command = new StringBuilder();

        // if it has type 2 i need to collect it

        command.Append(BEACON);
        command.Append(" 0 1");
        command.Append(EOA);

        command.Append(MESSAGE);
        command.Append(" something");
        command.Append(EOA);

        return command.ToString();
    }
}

