///////////////////////////////////////////////////////////
//  Order.cs
//  Implementation of the Class Order
//  Generated by Enterprise Architect
//  Created on:      12-Feb-2018 9:05:32 AM
//  Original author: paulus_d
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



/// <summary>
/// This will contain each of the objects that make up an order
/// </summary>
public class Order {

	public Finish FinishOptions;
	public ProcessingOptions ProcessingOptions;
	public Quantites QuantityOptions;
	public Sizes SizeOptions;
    public int OrderID;
    public double OrderTotal { get; set; }

	public Order(int ID){
        FinishOptions = new Finish();
        ProcessingOptions = new ProcessingOptions();
        QuantityOptions = new Quantites();
        SizeOptions = new Sizes();
        OrderID = ID;
	}

    //This applies the busines rule pricing for order 1's (the order is the same)
	public double CalculateOrder1(){
        OrderTotal = 0.0;
        string size = SizeOptions.SelectedItem;
        int qty = Convert.ToInt32(QuantityOptions.SelectedItem);
        string time = ProcessingOptions.SelectedItem;
        string finish = FinishOptions.SelectedItem;

        //Get the qty times size options
        if (qty <= 50)
        {
            SizePrice(size, qty, .14, .34, .68);
        }
        else if (qty > 50 && qty <= 75)
        {
            SizePrice(size, qty, .12, .31, .64);
        }
        else if (qty > 75 && qty <= 100)
        {
            SizePrice(size, qty, .10, .28, .60);
        }
      
        FinishPrice(finish, size, qty, .2, .3, .4);
        ProcessingTimePrice(time, qty, 1, 1.5);

        return OrderTotal;
	}

    //This applies the business ruled prices for order 2's (order is different)
    public double CalculateOrder2()
    {
        OrderTotal = 0.0;
        string size = SizeOptions.SelectedItem;
        int qty = Convert.ToInt32(QuantityOptions.SelectedItem);
        string time = ProcessingOptions.SelectedItem;
        string finish = FinishOptions.SelectedItem;

        SizePrice(size, qty, .19, .39, .79);
        FinishPrice(finish, size, qty, .4, .6, .8);
        ProcessingTimePrice(time, qty, 2,2.5);
        
        return 0;
    }

    //the pricing for the size * qty options
    private void SizePrice(string size, int qty, double price1, double price2, double price3)
    {
        //Get the qty times size options
        if (size == Sizes.SMALL)
        {
            OrderTotal = OrderTotal + (qty * price1);
        }
        else if (size == Sizes.MEDIUM)
        {
            OrderTotal = OrderTotal + (qty * price2);
        }
        else if (size == Sizes.LARGE)
        {
            OrderTotal = OrderTotal + (qty * price3);
        }
    }

    //the pricing for the finish options
    private void FinishPrice(string finish, string size, int qty, double price1, double price2, double price3)
    {
        //get the finish options update
        if (finish == Finish.MATTE)
        {
            if (size == Sizes.SMALL)
            {
                OrderTotal = OrderTotal + (qty * price1);
            }
            else if (size == Sizes.MEDIUM)
            {
                OrderTotal = OrderTotal + (qty * price2);
            }
            else if (size == Sizes.LARGE)
            {
                OrderTotal = OrderTotal + (qty * price3);
            }
        }
    }

    //the pricing for the processing time option
    private void ProcessingTimePrice(string time, int qty, double price1, double price2)
    {
        //get the processing time option updates
        if (time == ProcessingOptions.FAST)
        {
            if (qty <= 60)
            {
                OrderTotal += price1;
            }
            else if (qty > 60)
            {
                OrderTotal += price2;
            }
        }
    }

}//end Order