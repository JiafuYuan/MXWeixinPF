using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
    /// <summary>
    /// 数据访问类:wx_crm_users
    /// </summary>
    public partial class wx_crm_users
    {
        public wx_crm_users()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_crm_users");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_crm_users");
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
        public int Add(MxWeiXinPF.Model.wx_crm_users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_crm_users(");
            strSql.Append("wid,openid,nickname,sex,city,country,province,language,headimgurl,subscribe_time,unionid,createDate,groupId,updateDate,uStatus)");
            strSql.Append(" values (");
            strSql.Append("@wid,@openid,@nickname,@sex,@city,@country,@province,@language,@headimgurl,@subscribe_time,@unionid,@createDate,@groupId,@updateDate,@uStatus)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,300),
					new SqlParameter("@nickname", SqlDbType.VarChar,200),
					new SqlParameter("@sex", SqlDbType.VarChar,10),
					new SqlParameter("@city", SqlDbType.VarChar,200),
					new SqlParameter("@country", SqlDbType.VarChar,200),
					new SqlParameter("@province", SqlDbType.VarChar,200),
					new SqlParameter("@language", SqlDbType.VarChar,30),
					new SqlParameter("@headimgurl", SqlDbType.VarChar,1000),
					new SqlParameter("@subscribe_time", SqlDbType.VarChar,30),
					new SqlParameter("@unionid", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@groupId", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@uStatus", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.nickname;
            parameters[3].Value = model.sex;
            parameters[4].Value = model.city;
            parameters[5].Value = model.country;
            parameters[6].Value = model.province;
            parameters[7].Value = model.language;
            parameters[8].Value = model.headimgurl;
            parameters[9].Value = model.subscribe_time;
            parameters[10].Value = model.unionid;
            parameters[11].Value = model.createDate;
            parameters[12].Value = model.groupId;
            parameters[13].Value = model.updateDate;
            parameters[14].Value = model.uStatus;

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
        public bool Update(MxWeiXinPF.Model.wx_crm_users model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_crm_users set ");
            strSql.Append("wid=@wid,");
            strSql.Append("openid=@openid,");
            strSql.Append("nickname=@nickname,");
            strSql.Append("sex=@sex,");
            strSql.Append("city=@city,");
            strSql.Append("country=@country,");
            strSql.Append("province=@province,");
            strSql.Append("language=@language,");
            strSql.Append("headimgurl=@headimgurl,");
            strSql.Append("subscribe_time=@subscribe_time,");
            strSql.Append("unionid=@unionid,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("groupId=@groupId,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("uStatus=@uStatus");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,300),
					new SqlParameter("@nickname", SqlDbType.VarChar,200),
					new SqlParameter("@sex", SqlDbType.VarChar,10),
					new SqlParameter("@city", SqlDbType.VarChar,200),
					new SqlParameter("@country", SqlDbType.VarChar,200),
					new SqlParameter("@province", SqlDbType.VarChar,200),
					new SqlParameter("@language", SqlDbType.VarChar,30),
					new SqlParameter("@headimgurl", SqlDbType.VarChar,1000),
					new SqlParameter("@subscribe_time", SqlDbType.VarChar,30),
					new SqlParameter("@unionid", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@groupId", SqlDbType.Int,4),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@uStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.nickname;
            parameters[3].Value = model.sex;
            parameters[4].Value = model.city;
            parameters[5].Value = model.country;
            parameters[6].Value = model.province;
            parameters[7].Value = model.language;
            parameters[8].Value = model.headimgurl;
            parameters[9].Value = model.subscribe_time;
            parameters[10].Value = model.unionid;
            parameters[11].Value = model.createDate;
            parameters[12].Value = model.groupId;
            parameters[13].Value = model.updateDate;
            parameters[14].Value = model.uStatus;
            parameters[15].Value = model.id;

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
            strSql.Append("delete from wx_crm_users ");
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
            strSql.Append("delete from wx_crm_users ");
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
        public MxWeiXinPF.Model.wx_crm_users GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,openid,nickname,sex,city,country,province,language,headimgurl,subscribe_time,unionid,createDate,groupId,updateDate,uStatus  from wx_crm_users ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            MxWeiXinPF.Model.wx_crm_users model = new MxWeiXinPF.Model.wx_crm_users();
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
        public MxWeiXinPF.Model.wx_crm_users DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_crm_users model = new MxWeiXinPF.Model.wx_crm_users();
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
                if (row["openid"] != null)
                {
                    model.openid = row["openid"].ToString();
                }
                if (row["nickname"] != null)
                {
                    model.nickname = row["nickname"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["country"] != null)
                {
                    model.country = row["country"].ToString();
                }
                if (row["province"] != null)
                {
                    model.province = row["province"].ToString();
                }
                if (row["language"] != null)
                {
                    model.language = row["language"].ToString();
                }
                if (row["headimgurl"] != null)
                {
                    model.headimgurl = row["headimgurl"].ToString();
                }
                if (row["subscribe_time"] != null)
                {
                    model.subscribe_time = row["subscribe_time"].ToString();
                }
                if (row["unionid"] != null)
                {
                    model.unionid = row["unionid"].ToString();
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["groupId"] != null && row["groupId"].ToString() != "")
                {
                    model.groupId = int.Parse(row["groupId"].ToString());
                }

                if (row["updateDate"] != null && row["updateDate"].ToString() != "")
                {
                    model.updateDate = DateTime.Parse(row["updateDate"].ToString());
                }
                if (row["uStatus"] != null && row["uStatus"].ToString() != "")
                {
                    model.uStatus = int.Parse(row["uStatus"].ToString());
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
            strSql.Append("select id,wid,openid,nickname,sex,city,country,province,language,headimgurl,subscribe_time,unionid,createDate,groupId,updateDate,uStatus  ");
            strSql.Append(" FROM wx_crm_users ");
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
            strSql.Append(" id,wid,openid,nickname,sex,city,country,province,language,headimgurl,subscribe_time,unionid,createDate,groupId ,updateDate,uStatus ");
            strSql.Append(" FROM wx_crm_users ");
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
            strSql.Append("select count(1) FROM wx_crm_users ");
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
            strSql.Append(")AS Row, T.*  from wx_crm_users T ");
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
            parameters[0].Value = "wx_crm_users";
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
            strSql.Append("select u.*,g.[name] as gName,t.tag from wx_crm_users u left join wx_crm_group g on u.groupid=g.id left join wx_crm_users_tag t on u.openid=t.openid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByWid(int wid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_crm_users ");
            strSql.Append(" where wid=@wid ");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)			};
            parameters[0].Value = wid;

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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int wid,string openid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_crm_users");
            strSql.Append(" where wid=@wid and openid=@openid");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
                    new SqlParameter("@openid", SqlDbType.VarChar,300)
			};

            parameters[0].Value = wid;
            parameters[1].Value = openid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_crm_users GetModel(int wid,string openid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,openid,nickname,sex,city,country,province,language,headimgurl,subscribe_time,unionid,createDate,groupId,updateDate,uStatus  from wx_crm_users ");
            strSql.Append(" where wid=@wid and openid=@openid");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
                    new SqlParameter("@openid", SqlDbType.VarChar,300)
			};

            parameters[0].Value = wid;
            parameters[1].Value = openid;

            MxWeiXinPF.Model.wx_crm_users model = new MxWeiXinPF.Model.wx_crm_users();
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


        #endregion  ExtensionMethod
    }

}