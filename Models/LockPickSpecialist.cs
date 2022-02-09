using System;
namespace heistVer2
{
    public class LockPickSpecialist : IRobber
    {
        public string Name {get; set;}
        public string Type {get{ return "Lock Pick";}}
        public int SkillLevel {get; set;}
        public int PercentageCut {get;set;}
        public void PerformSkill (Bank bank){
            bank.VaultScore  -= SkillLevel;

            Console.WriteLine($"{Name} is opening the vault. Decrease vault score by {SkillLevel}");

            if(bank.VaultScore <= 0 ){
                 Console.WriteLine( $"{Name} has cracked the vault!");
            }

        }




    }
}