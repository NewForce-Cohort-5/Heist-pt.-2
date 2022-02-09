using System;
namespace heistVer2
{
    public class Muscle : IRobber
    {
        public string Name {get; set;}
        public int SkillLevel {get; set;}
        public int PercentageCut {get;set;}
        public string Type {
            get
        {return "Muscle";}
        }

        public void PerformSkill (Bank bank){
            bank.SecurityGuardScore  -= SkillLevel;

            Console.WriteLine($"{Name} is all out of bubble gum. Decrease security by {SkillLevel}");

            if(bank.SecurityGuardScore <= 0){
                Console.WriteLine($"{Name} has taken out the security team!");
            }

        }




    }
}