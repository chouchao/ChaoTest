using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NSH.Core.Dto;

namespace TestStoreHost.Models
{
    public class DataPage : IDataPage
    {
        public DataPage(int page, int pagesize)
        {
            Page = page < 1 ? 1 : page;
            PageSize = pagesize < 1 ? 1 : pagesize;
        }

        public int? PrevPage { get; set; }

        public int? NextPage { get; set; }

        public int BeginPage { get; set; }

        public int EndPage { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        public int PageCount { get; set; }

        #region IDataPage Members

        public int Skip { get { return (Page - 1) * PageSize; } }

        public int PageSize { get; set; }

        public int RecordCount { get; set; }

        #endregion

        public virtual DataPage CreateShowPage()
        {
            //生成总页数
            if (RecordCount <= 0 || RecordCount < PageSize)
            {
                PageCount = 1;
            }
            else
            {
                PageCount = RecordCount / PageSize;
                if (RecordCount % PageSize != 0)
                {
                    PageCount++;
                }
            }

            //根据新_pageCount检查Page
            if (Page > PageCount)
            {
                Page = PageCount;
            }

            //生成上一页页码
            if (Page > 1)
            {
                PrevPage = Page - 1;
            }

            //生成下一页页码
            if (Page < PageCount)
            {
                NextPage = Page + 1;
            }

            //生成起始页码
            BeginPage = Page - 10;
            if (BeginPage < 1)
            {
                BeginPage = 1;
            }

            //生成结束页码
            EndPage = Page + 9;
            if (EndPage > PageCount)
            {
                EndPage = PageCount;
            }

            return this;
        }
    }
}