using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPScript : MonoBehaviour
{
    [SerializeField] MoveScript moveScript;
    int xp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addXP(int _xp)
    {
        xp += _xp;
        speedBasedOnLevel();

    }
    private void speedBasedOnLevel()
    {
        moveScript.speed += xp % 10;
    }
}
