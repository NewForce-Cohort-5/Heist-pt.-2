using System;
using System.Collections.Generic;
using System.Linq;

namespace heistVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> roladex = new List<IRobber>()
            {
               new Hacker()
            {
                Name = "Jordan",
                SkillLevel = 39,
                PercentageCut = 20
            },
             new Hacker()
            {
                Name = "Jonah",
                SkillLevel = 32,
                PercentageCut = 25
            },
             new LockPickSpecialist()
            {
                Name = "Aki",
                SkillLevel = 45,
                PercentageCut = 18
            },
             new LockPickSpecialist()
            {
                Name = "Heaven",
                SkillLevel = 41,
                PercentageCut = 33
            },
           new Muscle()
            {
                Name = "Nick",
                SkillLevel = 25,
                PercentageCut = 15
            },
          new Muscle()
            {
                Name = "Gary",
                SkillLevel = 37,
                PercentageCut = 22
            }
            };


            Console.WriteLine("We're planning another heist!");
             Bank bank = new Bank(){
                AlarmScore = new Random().Next(0, 100),
                VaultScore = new Random().Next(0, 100),
                SecurityGuardScore = new Random().Next(0, 100),
                CashOnHand = new Random().Next(50000, 1000000)
            };

            while(true){
            Console.WriteLine($"We currently have {roladex.Count} contacts in the roladex");
            Console.WriteLine("New Crew Members Name:");
            string newMemberName = Console.ReadLine();
            if(newMemberName == "")
            {
                break;
            }
            else
            {


            Console.WriteLine("What's their Skill Set?");
            Console.WriteLine("1) Hacker");
            Console.WriteLine("2) Muscle");
            Console.WriteLine("3) Lock Specialist");

            string newMemberSkill = Console.ReadLine();

            Console.WriteLine("What's their Skill Level?");
            string newMemberSkillLevel = Console.ReadLine();

             Console.WriteLine("What's their Cut?");
            string newMemberCut = Console.ReadLine();

            if(newMemberSkill == "1"){
                Hacker hacker = new Hacker(){
                    Name = newMemberName,
                    SkillLevel = Int32.Parse(newMemberSkillLevel),
                    PercentageCut = Int32.Parse(newMemberCut)
                };
                 roladex.Add(hacker);
            }
            else if (newMemberSkill == "2")
            {
                Muscle muscle = new Muscle(){
                    Name = newMemberName,
                    SkillLevel = Int32.Parse(newMemberSkillLevel),
                    PercentageCut = Int32.Parse(newMemberCut)
                };
                 roladex.Add(muscle);
            }
            else if (newMemberSkill == "3")
            {
                LockPickSpecialist lockPickSpecialist = new LockPickSpecialist(){
                    Name = newMemberName,
                    SkillLevel = Int32.Parse(newMemberSkillLevel),
                    PercentageCut = Int32.Parse(newMemberCut)
                };
                 roladex.Add(lockPickSpecialist);
            }
            }
            }

            bank.Report();

            List<IRobber> crew = new List<IRobber>();

            Console.WriteLine("Time to get busy. Choose your crew.");
            while(true){

            for(int i=0; i<roladex.Count;i++){
                if(!crew.Any(x => x.Name == roladex[i].Name)){

                Console.WriteLine($"Choose {i + 1} for: ");
                Console.WriteLine($"Name: {roladex[i].Name} ");
                Console.WriteLine($"Speciality: {roladex[i].Type}");
                Console.WriteLine($"Skill Level: {roladex[i].SkillLevel}");
                Console.WriteLine($"Cut: {roladex[i].PercentageCut}");
                Console.WriteLine($"----------------");
                }
            }
            Console.WriteLine("Choose a member:");
            string choice = Console.ReadLine();
            if(choice == ""){
                break;
            }
            else{
                int currentPercent = crew.Sum(x => x.PercentageCut);
                if(currentPercent + roladex[Int32.Parse(choice)-1].PercentageCut <= 100){
                crew.Add(roladex[Int32.Parse(choice)-1]);
                }
                else{
                    Console.WriteLine("Sorry can't add'em... too expensive");
                    Console.WriteLine("                  ");
                }
            }
            // Allow the user to select as many crew members as they'd like from the rolodex. Continue to print out the report after each crew member is selected, but the report should not include operatives that have already been added to the crew, or operatives that require a percentage cut that can't be offered.



            }
            Console.WriteLine("----------------");

            Console.WriteLine("                  ");

            Console.WriteLine("----------------");

            Console.WriteLine("Let the heist begin!");
            crew.ForEach(x => x.PerformSkill(bank));
            if(bank.IsSecure()) {
                Console.WriteLine("Too bad ya got busted. Enjoy your new life in prison.");
            }
            else{
                Console.WriteLine("Enjoy your hard earned stolen cash");
                crew.ForEach(x => {
                    Console.WriteLine($"{x.Name}'s cut is ${bank.CashOnHand*x.PercentageCut/100}");
                });

            }
            // Once the user enters a blank value for a crew member, we're ready to begin the heist. Each crew member should perform his/her skill on the bank. Afterwards, evaluate if the bank is secure. If not, the heist was a success! Print out a success message to the user. If the bank does still have positive values for any of its security properties, the heist was a failure. Print out a failure message to the user.
        }
    }
}
