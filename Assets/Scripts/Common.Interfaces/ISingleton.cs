using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleton
{
    static ISingleton Instance { get; }
}
