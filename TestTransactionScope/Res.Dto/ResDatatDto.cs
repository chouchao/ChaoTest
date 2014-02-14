using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Res1.Domain;
using Res2.Domain;

namespace Res.Dto
{
    public class ResDatatDto
    {
        public IList<Res1Data> Res1DataList { get; set; }

        public IList<Res2Data> Res2DataList { get; set; }
    }
}
