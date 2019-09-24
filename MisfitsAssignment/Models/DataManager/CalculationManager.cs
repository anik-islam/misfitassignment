using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MisfitsAssignment.Models.Repository;

namespace MisfitsAssignment.Models.DataManager
{
    public class CalculationManager : ICalculationDataRepository<Calculation>
    {
        readonly CalculationContext _calculationContext;
        public CalculationManager(CalculationContext context)
        {
            _calculationContext = context;
        }
        public IEnumerable<Calculation> GetAll()
        {
            return _calculationContext.Calculation.ToList();
        }

        public Calculation Get(int id)
        {
            return _calculationContext.Calculation
                  .FirstOrDefault(e => e.ID == id);
        }
        public Calculation GetByUser(string UserId)
        {
            return _calculationContext.Calculation
                  .FirstOrDefault(e => e.User.UserID == UserId);
        }

        public void Add(Calculation entity)
        {
            entity.Result = Sum(entity.Value_1,entity.Value_2);
            entity.EntryDate = DateTime.Now;
            _calculationContext.Calculation.Add(entity);
            _calculationContext.SaveChanges();
        }

        public void Update(Calculation calculation, Calculation entity)
        {
            calculation.Value_1 = entity.Value_1;
            calculation.Value_2 = entity.Value_2;
            calculation.Result = Sum(entity.Value_1, entity.Value_2);
            calculation.UserID = entity.UserID;
            calculation.EntryDate = entity.EntryDate;

            _calculationContext.SaveChanges();
        }

        public void Delete(Calculation calculation)
        {
            _calculationContext.Calculation.Remove(calculation);
            _calculationContext.SaveChanges();
        }
        private string Sum(string strValue1, string strValue2)
        {

            string result = "", temp;

            if (strValue2.Length > strValue1.Length) { temp = strValue2; strValue2 = strValue1; strValue1 = temp; }

            string revValue1 = Reverse(strValue1), revValue2 = Reverse(strValue2);

            int carry = 0;

            for (int i = 0; i < revValue2.Length; i++)
            {
                int x = 0, y = 0, sum = 0, remain = 0;

                x = Convert.ToInt32(revValue2[i].ToString());
                y = Convert.ToInt32(revValue1[i].ToString());

                sum = x + y + carry;
                remain = sum % 10;
                result += remain.ToString();

                carry = 0;
                if (sum > 9) { carry = 1; }
            }

            if (carry > 0 && strValue1.Length != strValue2.Length)
            {

                for (int i = revValue2.Length; i < revValue1.Length; i++)
                {
                    int x = 0, y = 0, sum = 0, remain = 0;

                    x = carry;
                    y = Convert.ToInt32(revValue1[i].ToString());

                    sum = x + y;
                    remain = sum % 10;
                    result += remain.ToString();

                    carry = 0;
                    if (sum > 9) { carry = 1; }
                }
            }

            if (carry > 0 && strValue1.Length == strValue2.Length)
            {
                result += carry.ToString();
            }

            return Reverse(result);
        }

        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
