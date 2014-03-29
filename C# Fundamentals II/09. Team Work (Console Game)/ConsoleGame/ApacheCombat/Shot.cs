using System;
using System.Collections.Generic;
using System.Linq;


class Shot
{
    private int startX;
    private int startY;
    private int damage;
    private string shotForm = "——";
    private ConsoleColor color;

    public int StartX
    {
        get { return startX; }
        set { startX = value; }
    }
    public int StartY
    {
        get { return startY; }
        set { startY = value; }
    }
    public int EndX
    {
        get { return startX + shotForm.Length - 1; }
    }
    public int EndY
    {
        get { return startY; }
    }
    public int Height
    {
        get { return 1; }
    }
    public int Width
    {
        get { return shotForm.Length; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public string ShotForm
    {
        get { return shotForm; }
        set { shotForm = value; }
    }
    public ConsoleColor Color
    {
        get { return color; }
        set { color = value; }
    }

    public Shot(int startX, int startY, int damage, ConsoleColor color)
    {
        this.startX = startX;
        this.startY = startY;
        this.color = color;
        this.damage = damage;
        Window.PrintShotStart(this);
    }

    public void MoveRight()
    {
        startX++;
    }

}

