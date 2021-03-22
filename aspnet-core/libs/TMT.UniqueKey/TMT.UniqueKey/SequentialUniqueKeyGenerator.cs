using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace TMT.UniqueKey
{
    public class SequentialUniqueKeyGenerator : IUniqueKey, ITransientDependency
    {
        public string Create()
        {
            int randomSize = 6;
            long unixTimestamp = (long)(DateTime.Now.Subtract(new DateTime(2021, 1, 1))).TotalMilliseconds;
            String result = unixTimestamp.ToString();
            Random random = new Random();
            string randomString = "";
            for (int i = 0; i < randomSize; i++)
            {
                int temp = random.Next(0, 10);
                randomString = randomString + temp.ToString();
            }
            Int32.TryParse(randomString, out int randomNumber);
            randomNumber = randomNumber + DateTime.Now.Millisecond % 100;
            if (randomNumber >= Math.Pow(10, randomSize))
            {
                randomNumber = randomNumber - 100;
            }
            result = result + randomNumber.ToString();
            return result;
        }
    }
}
