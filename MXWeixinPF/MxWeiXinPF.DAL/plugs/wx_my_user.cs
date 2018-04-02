using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_my_user
	/// </summary>
	public partial class wx_my_user
	{
		public wx_my_user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_my_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_my_user");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MxWeiXinPF.Model.wx_my_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_my_user(");
			strSql.Append("wid,username,userpsd,userscore,useractive,dianid,usergrade,useraddr,usertel,userborn,useremail,userqq,forummanager,userpic)");
			strSql.Append(" values (");
			strSql.Append("@wid,@username,@userpsd,@userscore,@useractive,@dianid,@usergrade,@useraddr,@usertel,@userborn,@useremail,@userqq,@forummanager,@userpic)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.Char,30),
					new SqlParameter("@userpsd", SqlDbType.VarChar,50),
					new SqlParameter("@userscore", SqlDbType.Int,4),
					new SqlParameter("@useractive", SqlDbType.Int,4),
					new SqlParameter("@dianid", SqlDbType.Int,4),
					new SqlParameter("@usergrade", SqlDbType.Int,4),
					new SqlParameter("@useraddr", SqlDbType.VarChar,50),
					new SqlParameter("@usertel", SqlDbType.VarChar,50),
					new SqlParameter("@userborn", SqlDbType.DateTime),
					new SqlParameter("@useremail", SqlDbType.Char,50),
					new SqlParameter("@userqq", SqlDbType.VarChar,20),
					new SqlParameter("@forummanager", SqlDbType.Int,4),
					new SqlParameter("@userpic", SqlDbType.VarChar,100)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.username;
			parameters[2].Value = model.userpsd;
			parameters[3].Value = model.userscore;
			parameters[4].Value = model.useractive;
			parameters[5].Value = model.dianid;
			parameters[6].Value = model.usergrade;
			parameters[7].Value = model.useraddr;
			parameters[8].Value = model.usertel;
			parameters[9].Value = model.userborn;
			parameters[10].Value = model.useremail;
			parameters[11].Value = model.userqq;
			parameters[12].Value = model.forummanager;
			parameters[13].Value = model.userpic;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(MxWeiXinPF.Model.wx_my_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_my_user set ");
			strSql.Append("wid=@wid,");
			strSql.Append("username=@username,");
			strSql.Append("userpsd=@userpsd,");
			strSql.Append("userscore=@userscore,");
			strSql.Append("useractive=@useractive,");
			strSql.Append("dianid=@dianid,");
			strSql.Append("usergrade=@usergrade,");
			strSql.Append("useraddr=@useraddr,");
			strSql.Append("usertel=@usertel,");
			strSql.Append("userborn=@userborn,");
			strSql.Append("useremail=@useremail,");
			strSql.Append("userqq=@userqq,");
			strSql.Append("forummanager=@forummanager,");
			strSql.Append("userpic=@userpic");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.Char,30),
					new SqlParameter("@userpsd", SqlDbType.VarChar,50),
					new SqlParameter("@userscore", SqlDbType.Int,4),
					new SqlParameter("@useractive", SqlDbType.Int,4),
					new SqlParameter("@dianid", SqlDbType.Int,4),
					new SqlParameter("@usergrade", SqlDbType.Int,4),
					new SqlParameter("@useraddr", SqlDbType.VarChar,50),
					new SqlParameter("@usertel", SqlDbType.VarChar,50),
					new SqlParameter("@userborn", SqlDbType.DateTime),
					new SqlParameter("@useremail", SqlDbType.Char,50),
					new SqlParameter("@userqq", SqlDbType.VarChar,20),
					new SqlParameter("@forummanager", SqlDbType.Int,4),
					new SqlParameter("@userpic", SqlDbType.VarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.username;
			parameters[2].Value = model.userpsd;
			parameters[3].Value = model.userscore;
			parameters[4].Value = model.useractive;
			parameters[5].Value = model.dianid;
			parameters[6].Value = model.usergrade;
			parameters[7].Value = model.useraddr;
			parameters[8].Value = model.usertel;
			parameters[9].Value = model.userborn;
			parameters[10].Value = model.useremail;
			parameters[11].Value = model.userqq;
			parameters[12].Value = model.forummanager;
			parameters[13].Value = model.userpic;
			parameters[14].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_my_user ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_my_user ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public MxWeiXinPF.Model.wx_my_user GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,username,userpsd,userscore,useractive,dianid,usergrade,useraddr,usertel,userborn,useremail,userqq,forummanager,userpic from wx_my_user ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MxWeiXinPF.Model.wx_my_user model=new MxWeiXinPF.Model.wx_my_user();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public MxWeiXinPF.Model.wx_my_user DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_my_user model=new MxWeiXinPF.Model.wx_my_user();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["userpsd"]!=null)
				{
					model.userpsd=row["userpsd"].ToString();
				}
				if(row["userscore"]!=null && row["userscore"].ToString()!="")
				{
					model.userscore=int.Parse(row["userscore"].ToString());
				}
				if(row["useractive"]!=null && row["useractive"].ToString()!="")
				{
					model.useractive=int.Parse(row["useractive"].ToString());
				}
				if(row["dianid"]!=null && row["dianid"].ToString()!="")
				{
					model.dianid=int.Parse(row["dianid"].ToString());
				}
				if(row["usergrade"]!=null && row["usergrade"].ToString()!="")
				{
					model.usergrade=int.Parse(row["usergrade"].ToString());
				}
				if(row["useraddr"]!=null)
				{
					model.useraddr=row["useraddr"].ToString();
				}
				if(row["usertel"]!=null)
				{
					model.usertel=row["usertel"].ToString();
				}
				if(row["userborn"]!=null && row["userborn"].ToString()!="")
				{
					model.userborn=DateTime.Parse(row["userborn"].ToString());
				}
				if(row["useremail"]!=null)
				{
					model.useremail=row["useremail"].ToString();
				}
				if(row["userqq"]!=null)
				{
					model.userqq=row["userqq"].ToString();
				}
				if(row["forummanager"]!=null && row["forummanager"].ToString()!="")
				{
					model.forummanager=int.Parse(row["forummanager"].ToString());
				}
				if(row["userpic"]!=null)
				{
					model.userpic=row["userpic"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,wid,username,userpsd,userscore,useractive,dianid,usergrade,useraddr,usertel,userborn,useremail,userqq,forummanager,userpic ");
			strSql.Append(" FROM wx_my_user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,wid,username,userpsd,userscore,useractive,dianid,usergrade,useraddr,usertel,userborn,useremail,userqq,forummanager,userpic ");
			strSql.Append(" FROM wx_my_user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM wx_my_user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from wx_my_user T ");
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
			parameters[0].Value = "wx_my_user";
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
            strSql.Append("select  * from wx_my_user   ");

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

