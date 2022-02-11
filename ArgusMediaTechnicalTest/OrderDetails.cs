namespace ArgusMedisTechnicalTest
{
    public class OrderDetails : Constants
    {

        #region Properties 
        public int StartersCount;
        public int MainsCount;
        public int DrinksCount;
        public string ConditionType;
        public double TotalMeal;
        public double TotalDrinks;
        public double FinalBill;
        #endregion

        #region Constructors
        public void TakeOrder(int startersCount, int mainsCount, int drinksCount, string conditionType)
        {
            this.StartersCount = startersCount;
            this.MainsCount = mainsCount;
            this.DrinksCount = drinksCount;
            this.ConditionType = conditionType;
        }

        public void AddOrder(int startersCount, int mainsCount, int drinksCount, string conditionType)
        {
            this.StartersCount = startersCount;
            this.MainsCount = mainsCount;
            this.DrinksCount = drinksCount;
            this.ConditionType = conditionType;
        }
        public void PlaceOrder(int startersCount, int mainsCount, int drinksCount)
        {
            this.StartersCount = startersCount;
            this.MainsCount = mainsCount;
            this.DrinksCount = drinksCount;
        }
        #endregion

        public double ApplyServiceCharge()
        {
            TotalMeal = CalculateMeal();
            var totalServiceCharge = ((TotalMeal * SERVICE_CHARGE) / 100);
            return TotalMeal + totalServiceCharge;
        }


        public double CalculateMeal()
        {
            double starterBill = this.StartersCount * Constants.STARTER_COST;
            double mainsBill = this.MainsCount * Constants.MAINS_COST;
            return TotalMeal = starterBill + mainsBill;
        }


        public double CalculateDrinks()
        {
            double drinksBill = this.DrinksCount * Constants.DRINKS_COST;
            switch (this.ConditionType)
            {
                case "Before":
                    {
                        double calculateDiscount = ((DRINKS_DISCOUNT / 100) * drinksBill);
                        double appliedDiscountDrinks = drinksBill - calculateDiscount;
                        return appliedDiscountDrinks;
                    }
                case "After":
                    {
                        return drinksBill;
                    }
                default:
                    {
                        return drinksBill;
                    }
            }
        }

        public double CalculateFinalBill()
        {
            var appliedServiceCharge = ApplyServiceCharge();
            var drinksBill = CalculateDrinks();

            return FinalBill += appliedServiceCharge + drinksBill;
        }
    }
}