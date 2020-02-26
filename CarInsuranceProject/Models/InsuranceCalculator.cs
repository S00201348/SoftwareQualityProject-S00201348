using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarInsuranceProject.Models
{
    public class InsuranceCalculator
    {
        public DateTime DOB{ get; set; }
        public int CarValue { get; set; }
        public bool ComprehensiveCover { get; set; }
        public int PenaltyPoints { get; set; }

        public InsuranceCalculator()
        {
            DOB = DateTime.Parse("1900/1/1");
            CarValue = 0;
            ComprehensiveCover = false;
            PenaltyPoints = 0;
        }

        public InsuranceCalculator (DateTime dob, int carValue, bool comprehensive, int penaltyPoints)
        {
            DOB = dob;
            CarValue = carValue;
            ComprehensiveCover = comprehensive;
            PenaltyPoints = penaltyPoints;
        }

        public double CalculateInsurance()
        {            
            double finalValue = CarValue;
            if (DateTime.Now.Year - DOB.Year < 18)
            {
                return -1;
            }
            else
            {
                if (!ComprehensiveCover) {
                    finalValue *= 0.025;
                }
                else
                {
                    finalValue *= 0.04;
                }

                if (DateTime.Now.Year - DOB.Year >= 18 && DateTime.Now.Year - DOB.Year <= 25)
                {
                    finalValue *= 1.1;
                }
                return CalculateExtraCharge() >= 0 ? finalValue + CalculateExtraCharge() : -1;
            }
        }

        private double CalculateExtraCharge()
        {
            switch (PenaltyPoints)
            {
                case 0:
                    return 0;
                case 1:
                case 2:
                case 3:
                case 4:
                    return 100;
                case 5:
                case 6:
                case 7:
                    return 200;
                case 8:
                case 9:
                case 10:
                    return 300;
                case 11:
                case 12:
                    return 400;
                default: 
                    return -1;
            }
        }
    }
}