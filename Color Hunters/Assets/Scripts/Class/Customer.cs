using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    public string Id { set; get; }
    public string Name { set; get; }
    public string Surnames { set; get; }
    public string Age { set; get; }
    public string Phone { set; get; }
    public string Email { set; get; }
    public string Address { set; get; }
    public int Doctor { set; get; }

    public Customer(string id, string name, string surnames, string age, string phone, string email, string address, int doctor)
    {
        Id = id;
        Name = name;
        Surnames = surnames;
        Age = age;
        Phone = phone;
        Email = email;
        Address = address;
        Doctor = doctor;
    }

    public Customer() : this("", "", "", "", "", "", "", 0) { }

}
