using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulbScript : InteractableObject
{

    public int num = 0;
    public LightPuzzle puzzleBois;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void Interact(string item = "none")
    {
        if (num == 0)
            puzzleBois.hit1();
        if (num == 1)
            puzzleBois.hit2();
        if (num == 2)
            puzzleBois.hit3();
        if (num == 3)
            puzzleBois.hit4();
        if (num == 4)
            puzzleBois.hit5();

    }
}
