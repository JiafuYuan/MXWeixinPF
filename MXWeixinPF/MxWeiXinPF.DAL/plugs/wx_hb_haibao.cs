using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
    /// <summary>
    /// 数据访问类:wx_hb_haibao
    /// </summary>
    public partial class wx_hb_haibao
    {
        public wx_hb_haibao()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_hb_haibao");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_hb_haibao");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MxWeiXinPF.Model.wx_hb_haibao model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_hb_haibao(");
            strSql.Append("wid,musicUrl,hTitle,hContent,cid,hViewNum,hForwardNum,coverimg,copyright,address,urllink,createdate,sort_id,remark)");
            strSql.Append(" values (");
            strSql.Append("@wid,@musicUrl,@hTitle,@hContent,@cid,@hViewNum,@hForwardNum,@coverimg,@copyright,@address,@urllink,@createdate,@sort_id,@remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@musicUrl", SqlDbType.VarChar,800),
					new SqlParameter("@hTitle", SqlDbType.VarChar,800),
					new SqlParameter("@hContent", SqlDbType.VarChar,1000),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@hViewNum", SqlDbType.Int,4),
					new SqlParameter("@hForwardNum", SqlDbType.Int,4),
					new SqlParameter("@coverimg", SqlDbType.VarChar,800),
					new SqlParameter("@copyright", SqlDbType.VarChar,1000),
					new SqlParameter("@address", SqlDbType.VarChar,800),
					new SqlParameter("@urllink", SqlDbType.VarChar,800),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1000)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.musicUrl;
            parameters[2].Value = model.hTitle;
            parameters[3].Value = model.hContent;
            parameters[4].Value = model.cid;
            parameters[5].Value = model.hViewNum;
            parameters[6].Value = model.hForwardNum;
            parameters[7].Value = model.coverimg;
            parameters[8].Value = model.copyright;
            parameters[9].Value = model.address;
            parameters[10].Value = model.urllink;
            parameters[11].Value = model.createdate;
            parameters[12].Value = model.sort_id;
            parameters[13].Value = model.remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MxWeiXinPF.Model.wx_hb_haibao model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_hb_haibao set ");
            strSql.Append("wid=@wid,");
            strSql.Append("musicUrl=@musicUrl,");
            strSql.Append("hTitle=@hTitle,");
            strSql.Append("hContent=@hContent,");
            strSql.Append("cid=@cid,");
            strSql.Append("hViewNum=@hViewNum,");
            strSql.Append("hForwardNum=@hForwardNum,");
            strSql.Append("coverimg=@coverimg,");
            strSql.Append("copyright=@copyright,");
            strSql.Append("address=@address,");
            strSql.Append("urllink=@urllink,");
            strSql.Append("createdate=@createdate,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("remark=@remark");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@musicUrl", SqlDbType.VarChar,800),
					new SqlParameter("@hTitle", SqlDbType.VarChar,800),
					new SqlParameter("@hContent", SqlDbType.VarChar,1000),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@hViewNum", SqlDbType.Int,4),
					new SqlParameter("@hForwardNum", SqlDbType.Int,4),
					new SqlParameter("@coverimg", SqlDbType.VarChar,800),
					new SqlParameter("@copyright", SqlDbType.VarChar,1000),
					new SqlParameter("@address", SqlDbType.VarChar,800),
					new SqlParameter("@urllink", SqlDbType.VarChar,800),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.musicUrl;
            parameters[2].Value = model.hTitle;
            parameters[3].Value = model.hContent;
            parameters[4].Value = model.cid;
            parameters[5].Value = model.hViewNum;
            parameters[6].Value = model.hForwardNum;
            parameters[7].Value = model.coverimg;
            parameters[8].Value = model.copyright;
            parameters[9].Value = model.address;
            parameters[10].Value = model.urllink;
            parameters[11].Value = model.createdate;
            parameters[12].Value = model.sort_id;
            parameters[13].Value = model.remark;
            parameters[14].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_hb_haibao ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_hb_haibao ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_hb_haibao GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,musicUrl,hTitle,hContent,cid,hViewNum,hForwardNum,coverimg,copyright,address,urllink,createdate,sort_id,remark from wx_hb_haibao ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            MxWeiXinPF.Model.wx_hb_haibao model = new MxWeiXinPF.Model.wx_hb_haibao();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_hb_haibao DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_hb_haibao model = new MxWeiXinPF.Model.wx_hb_haibao();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["wid"] != null && row["wid"].ToString() != "")
                {
                    model.wid = int.Parse(row["wid"].ToString());
                }
                if (row["musicUrl"] != null)
                {
                    model.musicUrl = row["musicUrl"].ToString();
                }
                if (row["hTitle"] != null)
                {
                    model.hTitle = row["hTitle"].ToString();
                }
                if (row["hContent"] != null)
                {
                    model.hContent = row["hContent"].ToString();
                }
                if (row["cid"] != null && row["cid"].ToString() != "")
                {
                    model.cid = int.Parse(row["cid"].ToString());
                }
                if (row["hViewNum"] != null && row["hViewNum"].ToString() != "")
                {
                    model.hViewNum = int.Parse(row["hViewNum"].ToString());
                }
                if (row["hForwardNum"] != null && row["hForwardNum"].ToString() != "")
                {
                    model.hForwardNum = int.Parse(row["hForwardNum"].ToString());
                }
                if (row["coverimg"] != null)
                {
                    model.coverimg = row["coverimg"].ToString();
                }
                if (row["copyright"] != null)
                {
                    model.copyright = row["copyright"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["urllink"] != null)
                {
                    model.urllink = row["urllink"].ToString();
                }
                if (row["createdate"] != null && row["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(row["createdate"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,musicUrl,hTitle,hContent,cid,hViewNum,hForwardNum,coverimg,copyright,address,urllink,createdate,sort_id,remark ");
            strSql.Append(" FROM wx_hb_haibao ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,wid,musicUrl,hTitle,hContent,cid,hViewNum,hForwardNum,coverimg,copyright,address,urllink,createdate,sort_id,remark ");
            strSql.Append(" FROM wx_hb_haibao ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wx_hb_haibao ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_hb_haibao T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "wx_hb_haibao";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 【微帐号】获得查询分页数据
        /// </summary>
        public DataSet GetWCodeList(int wid,int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM wx_hb_haibao");
            strSql.Append(" where  wid=" + wid);
            if (category_id > 0)
            {
                strSql.Append(" and cid=" + category_id);
            }
            if (strWhere.Trim() != "")
            {
                if (category_id > 0)
                {
                    strSql.Append(" and " + strWhere);
                }
                else
                {
                    strSql.Append(" and " + strWhere);
                }
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion  ExtensionMethod
    }
}

