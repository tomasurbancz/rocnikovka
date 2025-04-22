using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomName
{
    private static string[] names = { 
        "Draven", 
        "Kael", 
        "Thorne", 
        "Garrik", 
        "Varek", 
        "Cedric", 
        "Alistair", 
        "Beren", 
        "Roderic", 
        "Eldric", 
        "Malakar", 
        "Zephyrus", 
        "Vaelin", 
        "Sylas", 
        "Lucian", 
        "Xalvador", 
        "Morgrim", 
        "Varroth", 
        "Sargath", 
        "Malzarek"
    };
    
    public static string GetNameFromList()
    {
        return names[Random.Range(0, names.Length)];
    }
}
