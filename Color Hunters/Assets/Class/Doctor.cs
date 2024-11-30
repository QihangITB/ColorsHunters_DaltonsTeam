using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string Surnames { set; get; }
    public string Phone { set; get; }
    public string Email { set; get; }


    public Doctor(string id, string name, string surnames, string phone, string email)
    {
        Id = id;
        Name = name;
        Surnames = surnames;
        Phone = phone;
        Email = email;
    }

    public Doctor() : this("", "", "", "", "") { }


}
