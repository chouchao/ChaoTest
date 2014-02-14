using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Res.Core
{
    public abstract class EntityBase : IEntity
    {
        public virtual long Id { get; set; }

        #region Equality Tests


        public override bool Equals(object entity)
        {
            return entity != null
                && entity is EntityBase
                && this == (EntityBase)entity;
        }


        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }


        public static bool operator ==(EntityBase base1,
            EntityBase base2)
        {
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }

            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }

            if (base1.Id != base2.Id)
            {
                return false;
            }

            return true;
        }

        public static bool operator !=(EntityBase base1,
            EntityBase base2)
        {
            return (!(base1 == base2));
        }

        #endregion
    }
}
