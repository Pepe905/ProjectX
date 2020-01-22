using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummy : MonoBehaviour {


    public void TakeDamage(int amn) {
        Debug.Log("enemy took damage " + amn.ToString());
    }

}
