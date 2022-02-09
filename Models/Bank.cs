using System;
using System.Collections.Generic;
using System.Linq;

namespace heistVer2
{
    public class Bank
    {
// An integer property for CashOnHand
    public int CashOnHand {get;set;}
// An integer property for AlarmScore
    public int AlarmScore {get;set;}
// An integer property for VaultScore
    public int VaultScore {get;set;}

// An integer property for SecurityGuardScore
    public int SecurityGuardScore {get;set;}

// A computed boolean property called IsSecure. If all the scores are less than or equal to 0, this should be false. If any of the scores are above 0, this should be true
    public bool IsSecure() {
    {
        if(AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0){
            return false;
        }
        else{
            return true;
        }
    }
    }
    public void Report () {
        List<KeyValuePair<string,int>> stats = new List<KeyValuePair<string,int>>();

        stats.Add(new KeyValuePair<string,int>("Alarm Score", AlarmScore));
        stats.Add(new KeyValuePair<string,int>("Vault Score", VaultScore));
        stats.Add(new KeyValuePair<string,int>("Security Guard Score", SecurityGuardScore));
 ;

        var orderStats = stats.OrderBy(n=> n.Value).ToList();


        // orderStats.ForEach(n => Console.WriteLine(n));


        Console.WriteLine("Heres some intel on the bank were hitting.");
        Console.WriteLine($"Most Secure: {orderStats[2].Key}");
        Console.WriteLine($"Lease Secure: {orderStats[0].Key}");
        Console.WriteLine($"                   ");



    }
    }
}