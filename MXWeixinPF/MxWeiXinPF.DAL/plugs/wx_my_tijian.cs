using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
    /// <summary>
    /// 数据访问类:wx_my_tijian
    /// </summary>
    public partial class wx_my_tijian
    {
        public wx_my_tijian()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_my_tijian");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_my_tijian");
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
        public int Add(MxWeiXinPF.Model.wx_my_tijian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_my_tijian(");
            strSql.Append("wid,userid,tijianmonth,tijiandate,tijiangao,tijianzhong,tijiantou,tijianxiong,tijianfu,tijiandetails,tijianluru,adminname)");
            strSql.Append(" values (");
            strSql.Append("@wid,@userid,@tijianmonth,@tijiandate,@tijiangao,@tijianzhong,@tijiantou,@tijianxiong,@tijianfu,@tijiandetails,@tijianluru,@adminname)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@tijianmonth", SqlDbType.Int,4),
					new SqlParameter("@tijiandate", SqlDbType.DateTime),
					new SqlParameter("@tijiangao", SqlDbType.Float,8),
					new SqlParameter("@tijianzhong", SqlDbType.Float,8),
					new SqlParameter("@tijiantou", SqlDbType.Float,8),
					new SqlParameter("@tijianxiong", SqlDbType.Float,8),
					new SqlParameter("@tijianfu", SqlDbType.Float,8),
					new SqlParameter("@tijiandetails", SqlDbType.Text),
					new SqlParameter("@tijianluru", SqlDbType.DateTime),
					new SqlParameter("@adminname", SqlDbType.VarChar,30)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.tijianmonth;
            parameters[3].Value = model.tijiandate;
            parameters[4].Value = model.tijiangao;
            parameters[5].Value = model.tijianzhong;
            parameters[6].Value = model.tijiantou;
            parameters[7].Value = model.tijianxiong;
            parameters[8].Value = model.tijianfu;
            parameters[9].Value = model.tijiandetails;
            parameters[10].Value = model.tijianluru;
            parameters[11].Value = model.adminname;

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
        public bool Update(MxWeiXinPF.Model.wx_my_tijian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_my_tijian set ");
            strSql.Append("wid=@wid,");
            strSql.Append("userid=@userid,");
            strSql.Append("tijianmonth=@tijianmonth,");
            strSql.Append("tijiandate=@tijiandate,");
            strSql.Append("tijiangao=@tijiangao,");
            strSql.Append("tijianzhong=@tijianzhong,");
            strSql.Append("tijiantou=@tijiantou,");
            strSql.Append("tijianxiong=@tijianxiong,");
            strSql.Append("tijianfu=@tijianfu,");
            strSql.Append("tijiandetails=@tijiandetails,");
            strSql.Append("tijianluru=@tijianluru,");
            strSql.Append("adminname=@adminname");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@tijianmonth", SqlDbType.Int,4),
					new SqlParameter("@tijiandate", SqlDbType.DateTime),
					new SqlParameter("@tijiangao", SqlDbType.Float,8),
					new SqlParameter("@tijianzhong", SqlDbType.Float,8),
					new SqlParameter("@tijiantou", SqlDbType.Float,8),
					new SqlParameter("@tijianxiong", SqlDbType.Float,8),
					new SqlParameter("@tijianfu", SqlDbType.Float,8),
					new SqlParameter("@tijiandetails", SqlDbType.Text),
					new SqlParameter("@tijianluru", SqlDbType.DateTime),
					new SqlParameter("@adminname", SqlDbType.VarChar,30),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.tijianmonth;
            parameters[3].Value = model.tijiandate;
            parameters[4].Value = model.tijiangao;
            parameters[5].Value = model.tijianzhong;
            parameters[6].Value = model.tijiantou;
            parameters[7].Value = model.tijianxiong;
            parameters[8].Value = model.tijianfu;
            parameters[9].Value = model.tijiandetails;
            parameters[10].Value = model.tijianluru;
            parameters[11].Value = model.adminname;
            parameters[12].Value = model.id;

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
            strSql.Append("delete from wx_my_tijian ");
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
            strSql.Append("delete from wx_my_tijian ");
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
        public MxWeiXinPF.Model.wx_my_tijian GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,userid,tijianmonth,tijiandate,tijiangao,tijianzhong,tijiantou,tijianxiong,tijianfu,tijiandetails,tijianluru,adminname from wx_my_tijian ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            MxWeiXinPF.Model.wx_my_tijian model = new MxWeiXinPF.Model.wx_my_tijian();
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
        public MxWeiXinPF.Model.wx_my_tijian DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_my_tijian model = new MxWeiXinPF.Model.wx_my_tijian();
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
                if (row["userid"] != null && row["userid"].ToString() != "")
                {
                    model.userid = int.Parse(row["userid"].ToString());
                }
                if (row["tijianmonth"] != null && row["tijianmonth"].ToString() != "")
                {
                    model.tijianmonth = int.Parse(row["tijianmonth"].ToString());
                }
                if (row["tijiandate"] != null && row["tijiandate"].ToString() != "")
                {
                    model.tijiandate = DateTime.Parse(row["tijiandate"].ToString());
                }
                if (row["tijiangao"] != null && row["tijiangao"].ToString() != "")
                {
                    model.tijiangao = decimal.Parse(row["tijiangao"].ToString());
                }
                if (row["tijianzhong"] != null && row["tijianzhong"].ToString() != "")
                {
                    model.tijianzhong = decimal.Parse(row["tijianzhong"].ToString());
                }
                if (row["tijiantou"] != null && row["tijiantou"].ToString() != "")
                {
                    model.tijiantou = decimal.Parse(row["tijiantou"].ToString());
                }
                if (row["tijianxiong"] != null && row["tijianxiong"].ToString() != "")
                {
                    model.tijianxiong = decimal.Parse(row["tijianxiong"].ToString());
                }
                if (row["tijianfu"] != null && row["tijianfu"].ToString() != "")
                {
                    model.tijianfu = decimal.Parse(row["tijianfu"].ToString());
                }
                if (row["tijiandetails"] != null)
                {
                    model.tijiandetails = row["tijiandetails"].ToString();
                }
                if (row["tijianluru"] != null && row["tijianluru"].ToString() != "")
                {
                    model.tijianluru = DateTime.Parse(row["tijianluru"].ToString());
                }
                if (row["adminname"] != null)
                {
                    model.adminname = row["adminname"].ToString();
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
            strSql.Append("select id,wid,userid,tijianmonth,tijiandate,tijiangao,tijianzhong,tijiantou,tijianxiong,tijianfu,tijiandetails,tijianluru,adminname ");
            strSql.Append(" FROM wx_my_tijian ");
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
            strSql.Append(" id,wid,userid,tijianmonth,tijiandate,tijiangao,tijianzhong,tijiantou,tijianxiong,tijianfu,tijiandetails,tijianluru,adminname ");
            strSql.Append(" FROM wx_my_tijian ");
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
            strSql.Append("select count(1) FROM wx_my_tijian ");
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
            strSql.Append(")AS Row, T.*  from wx_my_tijian T ");
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
            parameters[0].Value = "wx_my_tijian";
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.*,(select username from wx_my_user u where t.userid=u.id) as username from wx_my_tijian t ");

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

