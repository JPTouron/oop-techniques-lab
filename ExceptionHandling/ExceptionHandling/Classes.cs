using System;

namespace ExceptionHandling
{
    public class FirstLevelClass
    {
        public int LvlOneDo(int i)
        {
            return new SecondLevelClass().LvlTwoDo(i) + 1;
        }
    }

    public class FourthLevelClass
    {

        public int ThrowACustomException(int theParam)
        {

            int x = 0;
            try
            {
                int r = 1 / x;
            }
            catch (Exception ex)
            {

                throw InvalidCalculation.BecauseACalculationMemberWasInvalid(theParam, x, ex);
                throw;
            }

            return 0;
        }
    }

    public class SecondLevelClass
    {
        public int LvlTwoDo(int i)
        {
            return new ThirdLevelClass().LvlThreeDo(i);
        }
    }

    public class ThirdLevelClass
    {
        public int LvlThreeDo(int i)
        {
            return new FourthLevelClass().ThrowACustomException(i);
        }
    }
}