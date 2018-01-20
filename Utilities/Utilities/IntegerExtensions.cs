namespace Utilities
{
    public static class IntegerExtensions
    {
        public static int GetMinimumIntValue(this int integer)
        {
            return 0;
        }

        public static int GetMaximumIntValue(this int integer)
        {
            var maxNumber = 10;
            for (var i = 1; i < integer; i++)
                maxNumber *= 10;
            
            return maxNumber - 1;
        }
    }
}
