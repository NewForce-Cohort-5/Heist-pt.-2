using System;
namespace heistVer2
{
    public class Hacker : IRobber
    {
        public string Name {get; set;}
        public string Type  {get {return"Hacker";} }
        public int SkillLevel {get; set;}
        public int PercentageCut {get;set;}
        public void PerformSkill (Bank bank){
            bank.AlarmScore  -= SkillLevel;

            Console.WriteLine($"{Name} is hacking the alarm. Decrease Alarm Level by {SkillLevel}");

            if(bank.AlarmScore <= 0){
                Console.WriteLine( $"{Name} has disabled the alarm!");
            }

        }




    }
}