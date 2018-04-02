using System;
using System.Data;
using System.Collections.Generic;
using MxWeiXinPF.Common;
using MxWeiXinPF.Model;
namespace MxWeiXinPF.BLL
{
    /// <summary>
    /// 微信Crm同步设置表
    /// </summary>
    public partial class wx_crm_setting
    {
        private readonly MxWeiXinPF.DAL.wx_crm_setting dal = new MxWeiXinPF.DAL.wx_crm_setting();
        public wx_crm_setting()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MxWeiXinPF.Model.wx_crm_setting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MxWeiXinPF.Model.wx_crm_setting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_crm_setting GetModel(int id)
        {

            return dal.GetModel(id);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MxWeiXinPF.Model.wx_crm_setting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MxWeiXinPF.Model.wx_crm_setting> DataTableToList(DataTable dt)
        {
            List<MxWeiXinPF.Model.wx_crm_setting> modelList = new List<MxWeiXinPF.Model.wx_crm_setting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MxWeiXinPF.Model.wx_crm_setting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 修改分组的同步信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="count"></param>
        /// <param name="sysDate"></param>
        /// <returns></returns>
        public bool UpdateGroupSysDate(int wid, int count, DateTime sysDate)
        {
            Model.wx_crm_setting setting = GetModelByWid(wid);
            if (setting == null || setting.id == 0)
            {
                setting = new Model.wx_crm_setting();
                //不存在，则新增
                setting.wid = wid;
                setting.groupCount = count;
                setting.openidCount = 0;
                setting.groupSynDate = sysDate;
                int ret = Add(setting);
                if (ret > 0)
                {  return true; }
                else
                {  return false;  }
            }
            else
            {
                //存在，则修改
                setting.groupCount = count;
                setting.groupSynDate = sysDate;
                return Update(setting);
            }
        }


        /// <summary>
        /// 修改粉丝的同步信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="count"></param>
        /// <param name="sysDate"></param>
        /// <returns></returns>
        public bool UpdatePersonSysDate(int wid, int count, DateTime sysDate)
        {
            Model.wx_crm_setting setting = GetModelByWid(wid);
            if (setting == null || setting.id == 0)
            {
                setting = new Model.wx_crm_setting();
                //不存在，则新增
                setting.wid = wid;
                setting.groupCount = 0;
                setting.openidCount = count;
                setting.personSynDate = sysDate;
                int ret = Add(setting);
                if (ret > 0)
                { return true; }
                else
                { return false; }
            }
            else
            {
                //存在，则修改
                setting.openidCount = count;
                setting.personSynDate = sysDate;
                return Update(setting);
            }
        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_crm_setting GetModelByWid(int wid)
        {

            return dal.GetModelByWid(wid);
        }

        #endregion  ExtensionMethod
    }
}

