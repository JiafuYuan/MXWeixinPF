using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
    /// <summary>
    /// 数据访问类:wx_fc_houseType
    /// </summary>
    public partial class wx_fc_houseType
    {
        public wx_fc_houseType()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "wx_fc_houseType");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_fc_houseType");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MxWeiXinPF.Model.wx_fc_houseType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_fc_houseType(");
            strSql.Append("sid,sort_id,Name,Jieshao,houseType,storey,htimgA,htImgB,htimgC,htimgD,createDate,pid,wid,jzmj,fid)");
            strSql.Append(" values (");
            strSql.Append("@sid,@sort_id,@Name,@Jieshao,@houseType,@storey,@htimgA,@htImgB,@htimgC,@htimgD,@createDate,@pid,@wid,@jzmj,@fid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,500),
					new SqlParameter("@Jieshao", SqlDbType.VarChar,1000),
					new SqlParameter("@houseType", SqlDbType.VarChar,300),
					new SqlParameter("@storey", SqlDbType.VarChar,300),
					new SqlParameter("@htimgA", SqlDbType.VarChar,500),
					new SqlParameter("@htImgB", SqlDbType.VarChar,500),
					new SqlParameter("@htimgC", SqlDbType.VarChar,500),
					new SqlParameter("@htimgD", SqlDbType.VarChar,500),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@jzmj", SqlDbType.Float,8),
					new SqlParameter("@fid", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.sort_id;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Jieshao;
            parameters[4].Value = model.houseType;
            parameters[5].Value = model.storey;
            parameters[6].Value = model.htimgA;
            parameters[7].Value = model.htImgB;
            parameters[8].Value = model.htimgC;
            parameters[9].Value = model.htimgD;
            parameters[10].Value = model.createDate;
            parameters[11].Value = model.pid;
            parameters[12].Value = model.wid;
            parameters[13].Value = model.jzmj;
            parameters[14].Value = model.fid;

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
        public bool Update(MxWeiXinPF.Model.wx_fc_houseType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_fc_houseType set ");
            strSql.Append("sid=@sid,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("Name=@Name,");
            strSql.Append("Jieshao=@Jieshao,");
            strSql.Append("houseType=@houseType,");
            strSql.Append("storey=@storey,");
            strSql.Append("htimgA=@htimgA,");
            strSql.Append("htImgB=@htImgB,");
            strSql.Append("htimgC=@htimgC,");
            strSql.Append("htimgD=@htimgD,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("pid=@pid,");
            strSql.Append("wid=@wid,");
            strSql.Append("jzmj=@jzmj,");
            strSql.Append("fid=@fid");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,500),
					new SqlParameter("@Jieshao", SqlDbType.VarChar,1000),
					new SqlParameter("@houseType", SqlDbType.VarChar,300),
					new SqlParameter("@storey", SqlDbType.VarChar,300),
					new SqlParameter("@htimgA", SqlDbType.VarChar,500),
					new SqlParameter("@htImgB", SqlDbType.VarChar,500),
					new SqlParameter("@htimgC", SqlDbType.VarChar,500),
					new SqlParameter("@htimgD", SqlDbType.VarChar,500),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@jzmj", SqlDbType.Float,8),
					new SqlParameter("@fid", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.sort_id;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Jieshao;
            parameters[4].Value = model.houseType;
            parameters[5].Value = model.storey;
            parameters[6].Value = model.htimgA;
            parameters[7].Value = model.htImgB;
            parameters[8].Value = model.htimgC;
            parameters[9].Value = model.htimgD;
            parameters[10].Value = model.createDate;
            parameters[11].Value = model.pid;
            parameters[12].Value = model.wid;
            parameters[13].Value = model.jzmj;
            parameters[14].Value = model.fid;
            parameters[15].Value = model.Id;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_fc_houseType ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_fc_houseType ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public MxWeiXinPF.Model.wx_fc_houseType GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,sid,sort_id,Name,Jieshao,houseType,storey,htimgA,htImgB,htimgC,htimgD,createDate,pid,wid,jzmj,fid from wx_fc_houseType ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            MxWeiXinPF.Model.wx_fc_houseType model = new MxWeiXinPF.Model.wx_fc_houseType();
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
        public MxWeiXinPF.Model.wx_fc_houseType DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_fc_houseType model = new MxWeiXinPF.Model.wx_fc_houseType();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid = int.Parse(row["sid"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Jieshao"] != null)
                {
                    model.Jieshao = row["Jieshao"].ToString();
                }
                if (row["houseType"] != null)
                {
                    model.houseType = row["houseType"].ToString();
                }
                if (row["storey"] != null)
                {
                    model.storey = row["storey"].ToString();
                }
                if (row["htimgA"] != null)
                {
                    model.htimgA = row["htimgA"].ToString();
                }
                if (row["htImgB"] != null)
                {
                    model.htImgB = row["htImgB"].ToString();
                }
                if (row["htimgC"] != null)
                {
                    model.htimgC = row["htimgC"].ToString();
                }
                if (row["htimgD"] != null)
                {
                    model.htimgD = row["htimgD"].ToString();
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["pid"] != null && row["pid"].ToString() != "")
                {
                    model.pid = int.Parse(row["pid"].ToString());
                }
                if (row["wid"] != null && row["wid"].ToString() != "")
                {
                    model.wid = int.Parse(row["wid"].ToString());
                }
                if (row["jzmj"] != null && row["jzmj"].ToString() != "")
                {
                    model.jzmj = decimal.Parse(row["jzmj"].ToString());
                }
                if (row["fid"] != null && row["fid"].ToString() != "")
                {
                    model.fid = int.Parse(row["fid"].ToString());
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
            strSql.Append("select Id,sid,sort_id,Name,Jieshao,houseType,storey,htimgA,htImgB,htimgC,htimgD,createDate,pid,wid,jzmj,fid,(select newsTitle from wx_fc_floor f where f.id=h.fid) fname ");
            strSql.Append(" FROM wx_fc_houseType h");
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
            strSql.Append(" Id,sid,sort_id,Name,Jieshao,houseType,storey,htimgA,htImgB,htimgC,htimgD,createDate,pid,wid,jzmj,fid ");
            strSql.Append(" FROM wx_fc_houseType ");
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
            strSql.Append("select count(1) FROM wx_fc_houseType ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_fc_houseType T ");
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
            parameters[0].Value = "wx_fc_houseType";
            parameters[1].Value = "Id";
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,(select name from wx_fc_sonfloor s where s.id=a.sid) as sfloor  from wx_fc_houseType a ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion  ExtensionMethod
    }
}

