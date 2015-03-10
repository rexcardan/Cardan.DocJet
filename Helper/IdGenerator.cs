namespace Cardan.DocJet.Helper
{
    public static class IdGenerator
    {
        //public static string NextIntId()
        //{
        //    var g = Guid.NewGuid().ToString().Replace("-", "");
        //    BigInteger huge = BigInteger.Parse(g, NumberStyles.AllowHexSpecifier);
        //    return huge.ToString().Replace("-", "");
        //}

        ///// <summary>
        ///// Generates a number for the next id.
        ///// </summary>
        ///// <returns>the next id</returns>
        //public static string NextId()
        //{
        //    return "R" + Guid.NewGuid().ToString().Replace("-", "");
        //}
        public static int Id = 25;

        public static string NextIntId()
        {
            Id++;
            return Id.ToString();
        }

        /// <summary>
        ///     Generates a number for the next id.
        /// </summary>
        /// <returns>the next id</returns>
        public static string NextId()
        {
            Id++;
            return "R" + Id; // Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}