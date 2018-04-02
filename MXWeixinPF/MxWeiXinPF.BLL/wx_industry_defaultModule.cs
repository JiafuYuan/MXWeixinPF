using System;
using System.Data;
using System.Collections.Generic;
using MxWeiXinPF.Common;
using MxWeiXinPF.Model;
namespace MxWeiXinPF.BLL
{
    /// <summary>
    /// 行业默认模块
    /// </summary>
    public partial class wx_industry_defaultModule
    {
        private readonly MxWeiXinPF.DAL.wx_industry_defaultModule dal = new MxWeiXinPF.DAL.wx_industry_defaultModule();
        public wx_industry_defaultModule()
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
        public int Add(MxWeiXinPF.Model.wx_industry_defaultModule model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MxWeiXinPF.Model.wx_industry_defaultModule model)
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
        public MxWeiXinPF.Model.wx_industry_defaultModule GetModel(int id)
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
        public List<MxWeiXinPF.Model.wx_industry_defaultModule> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MxWeiXinPF.Model.wx_industry_defaultModule> DataTableToList(DataTable dt)
        {
            List<MxWeiXinPF.Model.wx_industry_defaultModule> modelList = new List<MxWeiXinPF.Model.wx_industry_defaultModule>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MxWeiXinPF.Model.wx_industry_defaultModule model;
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
        /// 根据微用户所在行业给微账户添加默认模块
        /// </summary>
        public void addMouduleByRoleid(int roleid, int wid)
        {
            BLL.article_category acBll = new article_category();
            //得到模型的实体类集合 
            List<Model.wx_industry_defaultModule> idList = getModelList(" role_id=" + roleid + " order by sort_id asc"); 

            //循环给为账户添加行业模块
            for (int i = 0; i < idList.Count; i++)
            {
                Model.article_category acModel = new Model.article_category
                {
                    title = idList[i].mName,
                    call_index = "mubanpinyin",
                    wid = wid,
                    link_url = idList[i].url,
                    channel_id = 1,
                    sort_id = MyCommFun.Obj2Int(idList[i].sort_id)
                };
                int resId = acBll.Add(acModel);
                Model.article_category upModel = acBll.GetModel(resId);
                upModel.class_list = "," + resId + ",";
                acBll.Update(upModel);
            }

        }

        /// <summary>
        /// 得到实体集合
        /// </summary>
        /// <param name="strwhere">查询条件</param>
        /// <returns></returns>
        public List<Model.wx_industry_defaultModule> getModelList(string strwhere)
        {
            DataSet ds = dal.GetList(strwhere);
            List<Model.wx_industry_defaultModule> idList = new List<Model.wx_industry_defaultModule>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Model.wx_industry_defaultModule idModel = dal.DataRowToModel(dr);
                    idList.Add(idModel);
                }
            }

            return idList;
        }

        #endregion  ExtensionMethod
    }
}

