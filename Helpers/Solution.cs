using System;

namespace Catalog.Helpers{
    public class Solution{
        private int _entranceFee;
        private int _firstFullHoursFee;
        private int _successiveFullOrPart;
        public Solution(int entranceFee,int firstFullHoursFee, int successiveFullOrPart){
            _entranceFee = entranceFee;
            _firstFullHoursFee = firstFullHoursFee;
            _successiveFullOrPart = successiveFullOrPart;

        }
        private int[] succesiveFullOPartHours(int totalHoursUsed){
            int[] hoursUsage = { 0,0 };
            int firstFullHours = 1;
            if(totalHoursUsed>1){
                hoursUsage[0] = 1;
                hoursUsage[1] = totalHoursUsed-firstFullHours;
            }
            if(totalHoursUsed>0 && totalHoursUsed<1){
                 hoursUsage[0] = 1;
                 hoursUsage[1] = 0;
            }
            return hoursUsage;
        }
        public int solution(string E, string L){
            var entryTimeSplit = E.Split(':');
            var entryTimeHours = Int32.Parse(entryTimeSplit[0]);
            var entryTimeMinutes = Int32.Parse(entryTimeSplit[1]);
            var ExitTimeSplit = L.Split(':');
            var exitTimeHours = Int32.Parse(ExitTimeSplit[0]);
            var exitTimeMinutes = Int32.Parse(ExitTimeSplit[1]);

            var calculateHoursDifference = (exitTimeHours - entryTimeHours);
            var calculateMinuteDifference = exitTimeMinutes - entryTimeMinutes;
            var TotalCost = 0;
            if(calculateMinuteDifference>0){
                calculateHoursDifference++;
            }

            if(calculateHoursDifference>1){ 
                TotalCost = _entranceFee + _firstFullHoursFee;
            }

            var hoursUsage = this.succesiveFullOPartHours(calculateHoursDifference);

            return _entranceFee + hoursUsage[0]*_firstFullHoursFee+ hoursUsage[1]*_successiveFullOrPart;
        }
    }
}