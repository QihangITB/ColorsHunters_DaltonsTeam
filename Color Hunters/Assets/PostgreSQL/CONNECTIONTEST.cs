using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONNECTIONTEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DBManager db = new DBManager();
        db.Test();
    }
}
