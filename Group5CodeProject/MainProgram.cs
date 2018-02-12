///////////////////////////////////////////////////////////
//  MainProgram.cs
//  Implementation of the Class MainProgram
//  Generated by Enterprise Architect
//  Created on:      12-Feb-2018 9:03:26 AM
//  Original author: paulus_d
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class MainProgram {

    public List<Order> orders;
    public const string PROMOCODE_1 = "N56M2"; 
    public double TotalPrice { get; set; }

    //Create a new lis to hold all the orders
	public MainProgram(){
        orders = new List<Order>();
	}

    //Create and add a new order to the list
	public void AddNewOrder(int OrderID){
        orders.Add(new Order(OrderID));
	}

    //If the user applied a discount or qualifies for one adjust the total accordingly
	public void UpdateTotalAndDiscount(string Code){
        CalculateAllTotal();
        //If the promo code is applied and it is an order 1 with qty = 100 subtract 2 dollars
        if (Code == PROMOCODE_1 && orders.Count == 1 && Convert.ToInt32(orders[0].QuantityOptions.SelectedItem) == 100)
        {
            TotalPrice = TotalPrice - 2;
        }
        //If hte promo code does not apply but the total is > 35 reduce the price by 5%
        else if (TotalPrice > 35)
        {
            TotalPrice = TotalPrice * .95;
        }
            
	}

    //Return the total for all orders
	private double CalculateAllTotal(){
        TotalPrice = 0.0;

        if (orders.Count > 1)
        {
            foreach (Order o in orders)
            {
                o.CalculateOrder2();
            }
        }
        else
        {
             orders[0].CalculateOrder1();
        }

        foreach (Order o in orders)
        {
            TotalPrice += o.OrderTotal;
        }

        return TotalPrice;
	}

}//end MainProgram