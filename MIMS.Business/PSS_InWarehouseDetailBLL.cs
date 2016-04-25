﻿using MIMS.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MIMS.Service;
using MIMS.Entity.Model;
using MIMS.Entity.Dtos;

namespace MIMS.Business
{
    public class PSS_InWarehouseDetailBLL : IPSS_InWarehouseDetailBLL
    {
        private static readonly PSS_InWarehouseDetailDAL dal = new PSS_InWarehouseDetailDAL();

        public IList GetList(Hashtable ht)
        {
            string where = string.Empty;
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (ht["IWID"] != null && !string.IsNullOrEmpty(ht["IWID"].ToString()))
            {
                where = " AND IWID = @IWID";
                prams.Add("@IWID", ht["IWID"]);
            }
            return dal.GetList(prams,where);
        }

        public IList GetPageList(string query, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            string where = string.Empty;
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(query))
            {
                prams.Add("@IWID", query);
                where = " AND IWID = @IWID";
            }
            IList list = dal.GetPageListWhere(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
            //foreach (Dto_InWarehouseDetail item in list)
            //    item.InWarehouseSum = item.InWarehousePrice * item.InWarehouseCount;
            return list;
        }

        public PSS_InWarehouseDetail GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Insert(PSS_InWarehouseDetail obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(PSS_InWarehouseDetail obj)
        {
            return dal.Delete(obj);
        }
    }
}
