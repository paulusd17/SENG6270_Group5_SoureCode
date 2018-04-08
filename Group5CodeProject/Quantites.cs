///////////////////////////////////////////////////////////
//  Quantites.cs
//  Implementation of the Class Quantites
//  Generated by Enterprise Architect
//  Created on:      12-Feb-2018 9:03:19 AM
//  Original author: paulus_d
///////////////////////////////////////////////////////////
using System.Collections.Generic;



/// <summary>
/// This will be a class to control the quantities allowed
/// </summary>
public class Quantites : Option
{
	public static int Maximum = 100;
	private int Minimum = 1;
    private int Used = 0;

	public Quantites(int Used){
        this.Used = Used;
        items = new List<string>();
        for (int i = Minimum; i <= (Maximum - Used); i++)
        {
            items.Add(i.ToString());
        }
    }

    public void SetItems(int current,int Used)
    {
        items = new List<string>();
        for (int i = Minimum; i <= (current + (Maximum-Used)); i++)
        {
            items.Add(i.ToString());
        }
    }

}//end Quantites