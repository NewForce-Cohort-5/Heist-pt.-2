using System;

namespace heistVer2
{
    public interface IRobber
    {
//         A string property for Name
        string Name {get;set;}
        string Type {get;}
// An integer property for SkillLevel
        int SkillLevel {get; set;}
// An integer property for PercentageCut
        int PercentageCut {get;set;}
// A method called PerformSkill that takes in a Bank parameter and doesn't return anything.
        void PerformSkill (Bank bank);

    }
}