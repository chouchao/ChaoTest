using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using NSH.Core.Service;

namespace TestStore
{
    public abstract class CodeActivityBase : CodeActivity
    {
        public T GetObject<T>(string objectId)
            where T : class
        {
            return ServiceLocatorRegister.ServiceLocator.GetObject(objectId) as T;
        }
    }
}
