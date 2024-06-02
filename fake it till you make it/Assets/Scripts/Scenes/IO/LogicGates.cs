using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGates : MonoBehaviour
{
    public bool AndGate(bool input1, bool input2)
    {
        return input1 && input2;
    }

    public bool NandGate(bool input1, bool input2)
    {
        return !(input1 && input2);
    }

    public bool OrGate(bool input1, bool input2)
    {
        return input1 || input2;
    }

    public bool NorGate(bool input1, bool input2)
    {
        return !(input1 || input2);
    }

    public bool XorGate(bool input1, bool input2)
    {
        return input1 ^ input2;
    }

    public bool XnorGate(bool input1, bool input2)
    {
        return !(input1 ^ input2);
    }

}
