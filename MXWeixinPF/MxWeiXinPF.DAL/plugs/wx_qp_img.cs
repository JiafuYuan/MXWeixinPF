using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using System.Collections.Generic;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
    /// <summary>
    /// 数据访问类:wx_qp_img
    /// </summary>
    public partial class wx_qp_img
    {
        public wx_qp_img()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_qp_img");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_qp_img");
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
        public int Add(MxWeiXinPF.Model.wx_qp_img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_qp_img(");
            strSql.Append("bId,iName,iType,imgPic,webUrl,remark,createDate,sort_id)");
            strSql.Append(" values (");
            strSql.Append("@bId,@iName,@iType,@imgPic,@webUrl,@remark,@createDate,@sort_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@bId", SqlDbType.Int,4),
					new SqlParameter("@iName", SqlDbType.VarChar,300),
					new SqlParameter("@iType", SqlDbType.Int,4),
					new SqlParameter("@imgPic", SqlDbType.VarChar,800),
					new SqlParameter("@webUrl", SqlDbType.VarChar,800),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
            parameters[0].Value = model.bId;
            parameters[1].Value = model.iName;
            parameters[2].Value = model.iType;
            parameters[3].Value = model.imgPic;
            parameters[4].Value = model.webUrl;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.createDate;
            parameters[7].Value = model.sort_id;

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
        public bool Update(MxWeiXinPF.Model.wx_qp_img model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_qp_img set ");
            strSql.Append("bId=@bId,");
            strSql.Append("iName=@iName,");
            strSql.Append("iType=@iType,");
            strSql.Append("imgPic=@imgPic,");
            strSql.Append("webUrl=@webUrl,");
            strSql.Append("remark=@remark,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("sort_id=@sort_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@bId", SqlDbType.Int,4),
					new SqlParameter("@iName", SqlDbType.VarChar,300),
					new SqlParameter("@iType", SqlDbType.Int,4),
					new SqlParameter("@imgPic", SqlDbType.VarChar,800),
					new SqlParameter("@webUrl", SqlDbType.VarChar,800),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.bId;
            parameters[1].Value = model.iName;
            parameters[2].Value = model.iType;
            parameters[3].Value = model.imgPic;
            parameters[4].Value = model.webUrl;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.createDate;
            parameters[7].Value = model.sort_id;
            parameters[8].Value = model.id;

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
            strSql.Append("delete from wx_qp_img ");
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
            strSql.Append("delete from wx_qp_img ");
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
        public MxWeiXinPF.Model.wx_qp_img GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,bId,iName,iType,imgPic,webUrl,remark,createDate,sort_id from wx_qp_img ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            MxWeiXinPF.Model.wx_qp_img model = new MxWeiXinPF.Model.wx_qp_img();
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
        public MxWeiXinPF.Model.wx_qp_img DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_qp_img model = new MxWeiXinPF.Model.wx_qp_img();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["bId"] != null && row["bId"].ToString() != "")
                {
                    model.bId = int.Parse(row["bId"].ToString());
                }
                if (row["iName"] != null)
                {
                    model.iName = row["iName"].ToString();
                }
                if (row["iType"] != null && row["iType"].ToString() != "")
                {
                    model.iType = int.Parse(row["iType"].ToString());
                }
                if (row["imgPic"] != null)
                {
                    model.imgPic = row["imgPic"].ToString();
                }
                if (row["webUrl"] != null)
                {
                    model.webUrl = row["webUrl"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
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
            strSql.Append("select id,bId,iName,iType,imgPic,webUrl,remark,createDate,sort_id ");
            strSql.Append(" FROM wx_qp_img ");
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
            strSql.Append(" id,bId,iName,iType,imgPic,webUrl,remark,createDate,sort_id ");
            strSql.Append(" FROM wx_qp_img ");
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
            strSql.Append("select count(1) FROM wx_qp_img ");
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
            strSql.Append(")AS Row, T.*  from wx_qp_img T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select id, bId, iName, iType, imgPic, webUrl, remark, createDate, sort_id from wx_qp_img p");
            strSql.Append(" where iType =" + category_id);

            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MxWeiXinPF.Model.wx_qp_img> GetModelList(string strWhere)
        {
            DataSet ds = GetList(strWhere);

            DataTable dt = ds.Tables[0];
            List<MxWeiXinPF.Model.wx_qp_img> modelList = new List<MxWeiXinPF.Model.wx_qp_img>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MxWeiXinPF.Model.wx_qp_img model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;

        }

        /// <summary>
        /// 删除图片
        /// </summary>
        public bool DeleteByBid(int bId,int itype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_qp_img ");
            strSql.Append(" where bId=@bId and iType=@iType ");
            SqlParameter[] parameters = {
					new SqlParameter("@bId", SqlDbType.Int,4),
                    new SqlParameter("@iType", SqlDbType.Int,4)
			};
            parameters[0].Value = bId;
            parameters[1].Value = itype;
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

        #endregion  ExtensionMethod
    }
}

