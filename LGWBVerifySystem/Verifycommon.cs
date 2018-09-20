using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGWBVerifySystem
{
    /// <summary>
    /// 回传类型（带实例本身）
    /// </summary>
    public class CSException
    {
        public int? StatusNum { get; set; }

        //设默认的正常状态为0，0代表成功,falsestat是默认错误代码
        private int Orginstats = 0;
        private int Falsestats = -1;

        public string Msg { get; set; }
        //设定默认正常与异常信息
        private string OrginMsg = "成功";
        private string FalseMsg = "发生异常";
        public bool Flag { get; set; }
        /// <summary>
        /// 返回一个带状态与信息的反馈
        /// </summary>
        /// <param name="_bool"></param>
        /// <param name="msg"></param>
        public CSException(bool _bool, string msg)
        {
            this.StatusNum = -1;
            this.Flag = _bool;
            this.Msg = msg;
        }
        public CSException(bool _bool, int stats, string msg)
        {
            this.StatusNum = stats;
            this.Flag = _bool;
            this.Msg = msg;
        }
        /// <summary>
        /// 返回一个默认为异常的反馈，msg为输入，stats为默认异常
        /// </summary>
        /// <param name="msg"></param>
        public CSException(string msg)
        {
            this.Msg = msg;
            this.Flag = false;
            this.StatusNum = this.Falsestats;
        }
        public CSException(int stats)
        {
            this.Msg = "返回状态为[" + stats + "]";
            this.Flag = (stats == this.Orginstats) ? true : false;
            this.StatusNum = stats;
        }
        /// <summary>
        /// 返回一个默认反馈，flag为true
        /// </summary>
        public CSException()
        {
            this.Flag = true;
            this.StatusNum = this.Orginstats;
            this.Msg = this.OrginMsg;
        }
        /// <summary>
        /// 返回一个反馈，正确性由_bool决定
        /// </summary>
        /// <param name="_bool"></param>
        public CSException(bool _bool)
        {
            this.Flag = _bool;
            this.StatusNum = (_bool) ? this.Orginstats : this.Falsestats;
            this.Msg = (_bool) ? this.OrginMsg : this.FalseMsg;

        }
        /// <summary>
        /// 返回一个反馈，一般包含错误代码和错误信息。如果是一个无错反馈，则返回stats应该为0
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="msg"></param>
        public CSException(int? stats, string msg)
        {
            this.Flag = (stats == this.Orginstats) ? true : false;
            this.StatusNum = (stats == null) ? this.Falsestats : stats;
            this.Msg = (msg == null) ? this.FalseMsg : msg;
        }
    }

    public class CSException<T>
    {
        public int? StatusNum { get; set; }

        public T Entity { get; set; }
        //设默认的正常状态为0，0代表成功,falsestat是默认错误代码
        private int Orginstats = 0;
        private int Falsestats = -1;

        public string Msg { get; set; }
        //设定默认正常与异常信息
        private string OrginMsg = "成功";
        private string FalseMsg = "发生异常";
        public bool Flag { get; set; }
        public CSException(bool _bool, string msg, T entity)
        {
            this.StatusNum = -1;
            this.Flag = _bool;
            this.Msg = msg;
            this.Entity = entity;
        }
        public CSException(bool _bool, T entity)
        {
            this.StatusNum = (_bool) ? this.Orginstats : this.Falsestats;
            this.Flag = _bool;
            this.Entity = entity;
        }
        public CSException(string msg, T entity)
        {
            this.Msg = msg;
            this.Flag = false;
            this.StatusNum = this.Falsestats;
            this.Entity = entity;
        }
        public CSException(int stats, T entity)
        {
            this.Msg = "返回状态为[" + stats + "]";
            this.Flag = (stats == this.Orginstats) ? true : false;
            this.StatusNum = stats;
            this.Entity = entity;
        }
        /// <summary>
        /// 返回一个默认反馈，flag为true
        /// </summary>
        public CSException()
        {
            this.Flag = true;
            this.StatusNum = this.Orginstats;
            this.Msg = this.OrginMsg;
        }
        /// <summary>
        /// 返回一个反馈，正确性由_bool决定
        /// </summary>
        /// <param name="_bool"></param>
        public CSException(bool _bool)
        {
            this.Flag = _bool;
            this.StatusNum = (_bool) ? this.Orginstats : this.Falsestats;
            this.Msg = (_bool) ? this.OrginMsg : this.FalseMsg;

        }
        /// <summary>
        /// 返回一个反馈，一般包含错误代码和错误信息。如果是一个无错反馈，则返回stats应该为0
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="msg"></param>
        public CSException(int? stats, string msg)
        {
            this.Flag = (stats == this.Orginstats) ? true : false;
            this.StatusNum = (stats == null) ? this.Falsestats : stats;
            this.Msg = (msg == null) ? this.FalseMsg : msg;
        }

        public CSException(bool _bool,int num, T entity)
        {
            this.Msg = (_bool)? OrginMsg:FalseMsg;
            this.Flag =_bool;
            this.StatusNum = num;
            this.Entity = entity;
        }
    }
}
