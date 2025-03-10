using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public Vector2 Point;

    public Vector2 Position;

    public bool HavePlant;

    public Grid(Vector2 point, Vector2 position, bool havePlant)
    {
        Point = point;
        Position = position;
        HavePlant = havePlant;
    }
}
