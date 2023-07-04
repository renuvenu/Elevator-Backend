
using ES.DataAccess;
namespace Common
{
    public class ElevatorCalculation
    {
        private readonly DbContextAccess dbContextAccess;


        public ElevatorCalculation(DbContextAccess dbContextAccess)
        {
            this.dbContextAccess = dbContextAccess;
        }

        public bool VerifyLiftCapacity()
        {
            decimal weight = 0;
            var PersonDetails = Array.FindAll(dbContextAccess.PersonDetailsInLifts.ToArray(),person => person.Status == "Inprogress");
            if (PersonDetails.Length > 0 )
            {
                weight = PersonDetails.Sum(x => x.Weight);
                //foreach ( var person in PersonDetails )
                //{
                //    if ( person != null && person.Status == "Inprogress")
                //    {
                //        weight += person.Weight;
                //    }
                //}

                if( weight < 600 )
                {
                    return true;
                }
            }
            return false;
        }
    }
}