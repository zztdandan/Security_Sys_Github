using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBox.CommonHelper
{
    public class PageSpreadHelper<T>
    {
        /// <summary>
        /// 初始化的类型实体，该类就是需要分页的类
        /// </summary>
        private List<T> Enity { get; set; }

        public int TotalCount { get; set; }

        /// <summary>
        /// 该实体默认初始化的页数
        /// </summary>
        private int PageSize { get; set; }
        /// <summary>
        /// 该实体按默认分页后有几页
        /// </summary>
        private int PageCount { get; set; }
        /// <summary>
        /// 实例化,获得实体，获得页数，获得分页属性
        /// </summary>
        /// <param name="initentity">将要分页的实体类</param>
        public PageSpreadHelper(IQueryable<T> initentity,int pagesize)
        {
            this.Enity = initentity.ToList();
            this.TotalCount=this.Enity.Count();
            this.PageSize=pagesize;
            this.PageCount = PageSpreadHelper<T>.GetPageCount(this.Enity.Count(), this.PageSize);
        }
        /// <summary>
        /// 获得该列表一共有多少页
        /// </summary>
        /// <param name="recordCount">列表数据总数</param>
        /// <param name="pagesize">分页规则</param>
        /// <returns></returns>
        public static int GetPageCount(int recordCount, int pagesize)
        {
            int pageCount = recordCount / pagesize;
            if (recordCount % pagesize != 0)
            {
                pageCount += 1;
            }
            return pageCount;
        }

        //获取分页数据
        /// <summary>
        /// 将数据跳页后返回需求页码的那部分数据(外链版本)
        /// </summary>
        /// <param name="result">原始大数据</param>
        /// <param name="pageIndex">跳到第几页</param>
        /// <param name="recordCount">数据总条数</param>
        /// /// <param name="pagesize">分页每页数据数</param>
        /// <returns></returns>
        public static  List<T1> GetPagedDataSource<T1>(List<T1> ent, int pageIndex, int recordCount, int pagesize)
        {
            var pageCount = PageSpreadHelper<T1>.GetPageCount(recordCount, pagesize);
            if (pageIndex >= pageCount && pageCount >= 1)
            {
                pageIndex = pageCount - 1;
            }
            List<T1> return_list = ent.Skip(pageIndex * pagesize).Take(pagesize).ToList();
            return return_list;
        }



        /// <summary>
        /// 将数据跳页后返回需求页码的那部分数据(内置版本)
        /// </summary>
        /// <param name="pageIndex">跳到第几页</param>
        /// <returns></returns>
        public List<T> PagedDataSource( int pageIndex)
        {

            if (pageIndex >= this.PageCount && this.PageCount >= 1)
            {
                pageIndex = this.PageCount - 1;
            }
            List<T> return_list = this.Enity.Skip(pageIndex * this.PageSize).Take(this.PageSize).ToList();
            return return_list;
        }


    }
}