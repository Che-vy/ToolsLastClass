using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

    public int numberOfTricksPreformed = 0;
    public float foodLevel;

	public void DoTrick()
    {
        numberOfTricksPreformed++;
    }
}
