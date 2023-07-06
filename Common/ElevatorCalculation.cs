
using ES.DataAccess;
namespace Common
{
    public class ElevatorCalculation
    {
        private readonly DbContextAccess dbContextAccess;

        public ElevatorCalculation()
        {

        }
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

                if( weight < 600 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public string GetCurrentDateTime()
        {
            DateTime dateTime = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            return dateTime.ToString( format );
        }
    }
}