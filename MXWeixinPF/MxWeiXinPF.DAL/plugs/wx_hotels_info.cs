using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_hotels_info
	/// </summary>
	public partial class wx_hotels_info
	{
		public wx_hotels_info()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_hotels_info");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_hotels_info");
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
        public int Add(MxWeiXinPF.Model.wx_hotels_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_hotels_info(");
            strSql.Append("wid,hotelName,hotelAddress,hotelPhone,mobilPhone,noticeEmail,emailPws,smtp,coverPic,topPic,orderLimit,listMode,messageNotice,pwd,hotelIntroduct,orderRemark,createDate,sortid,xplace,yplace)");
            strSql.Append(" values (");
            strSql.Append("@wid,@hotelName,@hotelAddress,@hotelPhone,@mobilPhone,@noticeEmail,@emailPws,@smtp,@coverPic,@topPic,@orderLimit,@listMode,@messageNotice,@pwd,@hotelIntroduct,@orderRemark,@createDate,@sortid,@xplace,@yplace)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@hotelName", SqlDbType.VarChar,300),
					new SqlParameter("@hotelAddress", SqlDbType.VarChar,300),
					new SqlParameter("@hotelPhone", SqlDbType.VarChar,100),
					new SqlParameter("@mobilPhone", SqlDbType.VarChar,100),
					new SqlParameter("@noticeEmail", SqlDbType.VarChar,100),
					new SqlParameter("@emailPws", SqlDbType.VarChar,50),
					new SqlParameter("@smtp", SqlDbType.VarChar,100),
					new SqlParameter("@coverPic", SqlDbType.VarChar,200),
					new SqlParameter("@topPic", SqlDbType.VarChar,200),
					new SqlParameter("@orderLimit", SqlDbType.Int,4),
					new SqlParameter("@listMode", SqlDbType.Bit,1),
					new SqlParameter("@messageNotice", SqlDbType.Int,4),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
					new SqlParameter("@hotelIntroduct", SqlDbType.VarChar,200),
					new SqlParameter("@orderRemark", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sortid", SqlDbType.Int,4),
					new SqlParameter("@xplace", SqlDbType.Float,8),
					new SqlParameter("@yplace", SqlDbType.Float,8)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.hotelName;
            parameters[2].Value = model.hotelAddress;
            parameters[3].Value = model.hotelPhone;
            parameters[4].Value = model.mobilPhone;
            parameters[5].Value = model.noticeEmail;
            parameters[6].Value = model.emailPws;
            parameters[7].Value = model.smtp;
            parameters[8].Value = model.coverPic;
            parameters[9].Value = model.topPic;
            parameters[10].Value = model.orderLimit;
            parameters[11].Value = model.listMode;
            parameters[12].Value = model.messageNotice;
            parameters[13].Value = model.pwd;
            parameters[14].Value = model.hotelIntroduct;
            parameters[15].Value = model.orderRemark;
            parameters[16].Value = model.createDate;
            parameters[17].Value = model.sortid;
            parameters[18].Value = model.xplace;
            parameters[19].Value = model.yplace;

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
        public bool Update(MxWeiXinPF.Model.wx_hotels_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_hotels_info set ");
            strSql.Append("wid=@wid,");
            strSql.Append("hotelName=@hotelName,");
            strSql.Append("hotelAddress=@hotelAddress,");
            strSql.Append("hotelPhone=@hotelPhone,");
            strSql.Append("mobilPhone=@mobilPhone,");
            strSql.Append("noticeEmail=@noticeEmail,");
            strSql.Append("emailPws=@emailPws,");
            strSql.Append("smtp=@smtp,");
            strSql.Append("coverPic=@coverPic,");
            strSql.Append("topPic=@topPic,");
            strSql.Append("orderLimit=@orderLimit,");
            strSql.Append("listMode=@listMode,");
            strSql.Append("messageNotice=@messageNotice,");
            strSql.Append("pwd=@pwd,");
            strSql.Append("hotelIntroduct=@hotelIntroduct,");
            strSql.Append("orderRemark=@orderRemark,");
           // strSql.Append("createDate=@createDate,");
            strSql.Append("sortid=@sortid,");
            strSql.Append("xplace=@xplace,");
            strSql.Append("yplace=@yplace");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@hotelName", SqlDbType.VarChar,300),
					new SqlParameter("@hotelAddress", SqlDbType.VarChar,300),
					new SqlParameter("@hotelPhone", SqlDbType.VarChar,100),
					new SqlParameter("@mobilPhone", SqlDbType.VarChar,100),
					new SqlParameter("@noticeEmail", SqlDbType.VarChar,100),
					new SqlParameter("@emailPws", SqlDbType.VarChar,50),
					new SqlParameter("@smtp", SqlDbType.VarChar,100),
					new SqlParameter("@coverPic", SqlDbType.VarChar,200),
					new SqlParameter("@topPic", SqlDbType.VarChar,200),
					new SqlParameter("@orderLimit", SqlDbType.Int,4),
					new SqlParameter("@listMode", SqlDbType.Bit,1),
					new SqlParameter("@messageNotice", SqlDbType.Int,4),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
					new SqlParameter("@hotelIntroduct", SqlDbType.VarChar,200),
					new SqlParameter("@orderRemark", SqlDbType.VarChar,200),
				//	new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sortid", SqlDbType.Int,4),
					new SqlParameter("@xplace", SqlDbType.Float,8),
					new SqlParameter("@yplace", SqlDbType.Float,8),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.hotelName;
            parameters[2].Value = model.hotelAddress;
            parameters[3].Value = model.hotelPhone;
            parameters[4].Value = model.mobilPhone;
            parameters[5].Value = model.noticeEmail;
            parameters[6].Value = model.emailPws;
            parameters[7].Value = model.smtp;
            parameters[8].Value = model.coverPic;
            parameters[9].Value = model.topPic;
            parameters[10].Value = model.orderLimit;
            parameters[11].Value = model.listMode;
            parameters[12].Value = model.messageNotice;
            parameters[13].Value = model.pwd;
            parameters[14].Value = model.hotelIntroduct;
            parameters[15].Value = model.orderRemark;
          //  parameters[16].Value = model.createDate;
            parameters[16].Value = model.sortid;
            parameters[17].Value = model.xplace;
            parameters[18].Value = model.yplace;
            parameters[19].Value = model.id;

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
            strSql.Append("delete from wx_hotels_info ");
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
            strSql.Append("delete from wx_hotels_info ");
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
        public MxWeiXinPF.Model.wx_hotels_info GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,hotelName,hotelAddress,hotelPhone,mobilPhone,noticeEmail,emailPws,smtp,coverPic,topPic,orderLimit,listMode,messageNotice,pwd,hotelIntroduct,orderRemark,createDate,sortid,xplace,yplace from wx_hotels_info ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            MxWeiXinPF.Model.wx_hotels_info model = new MxWeiXinPF.Model.wx_hotels_info();
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
        public MxWeiXinPF.Model.wx_hotels_info DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_hotels_info model = new MxWeiXinPF.Model.wx_hotels_info();
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
                if (row["hotelName"] != null)
                {
                    model.hotelName = row["hotelName"].ToString();
                }
                if (row["hotelAddress"] != null)
                {
                    model.hotelAddress = row["hotelAddress"].ToString();
                }
                if (row["hotelPhone"] != null)
                {
                    model.hotelPhone = row["hotelPhone"].ToString();
                }
                if (row["mobilPhone"] != null)
                {
                    model.mobilPhone = row["mobilPhone"].ToString();
                }
                if (row["noticeEmail"] != null)
                {
                    model.noticeEmail = row["noticeEmail"].ToString();
                }
                if (row["emailPws"] != null)
                {
                    model.emailPws = row["emailPws"].ToString();
                }
                if (row["smtp"] != null)
                {
                    model.smtp = row["smtp"].ToString();
                }
                if (row["coverPic"] != null)
                {
                    model.coverPic = row["coverPic"].ToString();
                }
                if (row["topPic"] != null)
                {
                    model.topPic = row["topPic"].ToString();
                }
                if (row["orderLimit"] != null && row["orderLimit"].ToString() != "")
                {
                    model.orderLimit = int.Parse(row["orderLimit"].ToString());
                }
                if (row["listMode"] != null && row["listMode"].ToString() != "")
                {
                    if ((row["listMode"].ToString() == "1") || (row["listMode"].ToString().ToLower() == "true"))
                    {
                        model.listMode = true;
                    }
                    else
                    {
                        model.listMode = false;
                    }
                }
                if (row["messageNotice"] != null && row["messageNotice"].ToString() != "")
                {
                    model.messageNotice = int.Parse(row["messageNotice"].ToString());
                }
                if (row["pwd"] != null)
                {
                    model.pwd = row["pwd"].ToString();
                }
                if (row["hotelIntroduct"] != null)
                {
                    model.hotelIntroduct = row["hotelIntroduct"].ToString();
                }
                if (row["orderRemark"] != null)
                {
                    model.orderRemark = row["orderRemark"].ToString();
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["sortid"] != null && row["sortid"].ToString() != "")
                {
                    model.sortid = int.Parse(row["sortid"].ToString());
                }
                if (row["xplace"] != null && row["xplace"].ToString() != "")
                {
                    model.xplace = decimal.Parse(row["xplace"].ToString());
                }
                if (row["yplace"] != null && row["yplace"].ToString() != "")
                {
                    model.yplace = decimal.Parse(row["yplace"].ToString());
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
            strSql.Append("select id,wid,hotelName,hotelAddress,hotelPhone,mobilPhone,noticeEmail,emailPws,smtp,coverPic,topPic,orderLimit,listMode,messageNotice,pwd,hotelIntroduct,orderRemark,createDate,sortid,xplace,yplace ");
            strSql.Append(" FROM wx_hotels_info ");
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
            strSql.Append(" id,wid,hotelName,hotelAddress,hotelPhone,mobilPhone,noticeEmail,emailPws,smtp,coverPic,topPic,orderLimit,listMode,messageNotice,pwd,hotelIntroduct,orderRemark,createDate,sortid,xplace,yplace ");
            strSql.Append(" FROM wx_hotels_info ");
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
            strSql.Append("select count(1) FROM wx_hotels_info ");
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
            strSql.Append(")AS Row, T.*  from wx_hotels_info T ");
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
            parameters[0].Value = "wx_hotels_info";
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,hotelName,hotelAddress,hotelPhone,mobilPhone,noticeEmail,emailPws,smtp,coverPic,topPic,orderLimit,listMode,messageNotice,pwd,hotelIntroduct,orderRemark,createDate,sortid ");
            strSql.Append(" FROM wx_hotels_info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,hotelName,hotelAddress,hotelPhone,mobilPhone,noticeEmail,emailPws,smtp,coverPic,topPic,orderLimit,listMode,messageNotice,pwd,hotelIntroduct,orderRemark,createDate,sortid,xplace,yplace ");
            strSql.Append(" FROM wx_hotels_info ");

            return DbHelperSQL.Query(strSql.ToString());
        }

		#endregion  ExtensionMethod
	}
}

