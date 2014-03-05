using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.Service
{
    public interface ITestDataManager
    {
        void InitData();

        void BatchData(int count);

        void DistributedUpdate();

        void DistributedUpdateException();

        decimal GetMoney();

        DateTime GetOrderDate();
    }
}
