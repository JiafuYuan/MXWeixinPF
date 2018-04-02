using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_paizhao_setting
	/// </summary>
	public partial class wx_paizhao_setting
	{
		public wx_paizhao_setting()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_paizhao_setting"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_paizhao_setting");
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
		public int Add(MxWeiXinPF.Model.wx_paizhao_setting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_paizhao_setting(");
			strSql.Append("wid,isOpen,enterKeyWords,prompt,outKeyWords,initApiUrl,picApiUrl)");
			strSql.Append(" values (");
			strSql.Append("@wid,@isOpen,@enterKeyWords,@prompt,@outKeyWords,@initApiUrl,@picApiUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@isOpen", SqlDbType.Bit,1),
					new SqlParameter("@enterKeyWords", SqlDbType.VarChar,100),
					new SqlParameter("@prompt", SqlDbType.VarChar,500),
					new SqlParameter("@outKeyWords", SqlDbType.VarChar,100),
					new SqlParameter("@initApiUrl", SqlDbType.VarChar,500),
					new SqlParameter("@picApiUrl", SqlDbType.VarChar,500)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.isOpen;
			parameters[2].Value = model.enterKeyWords;
			parameters[3].Value = model.prompt;
			parameters[4].Value = model.outKeyWords;
			parameters[5].Value = model.initApiUrl;
			parameters[6].Value = model.picApiUrl;

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
		public bool Update(MxWeiXinPF.Model.wx_paizhao_setting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_paizhao_setting set ");
			strSql.Append("wid=@wid,");
			strSql.Append("isOpen=@isOpen,");
			strSql.Append("enterKeyWords=@enterKeyWords,");
			strSql.Append("prompt=@prompt,");
			strSql.Append("outKeyWords=@outKeyWords,");
			strSql.Append("initApiUrl=@initApiUrl,");
			strSql.Append("picApiUrl=@picApiUrl");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@isOpen", SqlDbType.Bit,1),
					new SqlParameter("@enterKeyWords", SqlDbType.VarChar,100),
					new SqlParameter("@prompt", SqlDbType.VarChar,500),
					new SqlParameter("@outKeyWords", SqlDbType.VarChar,100),
					new SqlParameter("@initApiUrl", SqlDbType.VarChar,500),
					new SqlParameter("@picApiUrl", SqlDbType.VarChar,500),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.isOpen;
			parameters[2].Value = model.enterKeyWords;
			parameters[3].Value = model.prompt;
			parameters[4].Value = model.outKeyWords;
			parameters[5].Value = model.initApiUrl;
			parameters[6].Value = model.picApiUrl;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from wx_paizhao_setting ");
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
			strSql.Append("delete from wx_paizhao_setting ");
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
		public MxWeiXinPF.Model.wx_paizhao_setting GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,isOpen,enterKeyWords,prompt,outKeyWords,initApiUrl,picApiUrl from wx_paizhao_setting ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MxWeiXinPF.Model.wx_paizhao_setting model=new MxWeiXinPF.Model.wx_paizhao_setting();
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
		public MxWeiXinPF.Model.wx_paizhao_setting DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_paizhao_setting model=new MxWeiXinPF.Model.wx_paizhao_setting();
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
				if(row["isOpen"]!=null && row["isOpen"].ToString()!="")
				{
					if((row["isOpen"].ToString()=="1")||(row["isOpen"].ToString().ToLower()=="true"))
					{
						model.isOpen=true;
					}
					else
					{
						model.isOpen=false;
					}
				}
				if(row["enterKeyWords"]!=null)
				{
					model.enterKeyWords=row["enterKeyWords"].ToString();
				}
				if(row["prompt"]!=null)
				{
					model.prompt=row["prompt"].ToString();
				}
				if(row["outKeyWords"]!=null)
				{
					model.outKeyWords=row["outKeyWords"].ToString();
				}
				if(row["initApiUrl"]!=null)
				{
					model.initApiUrl=row["initApiUrl"].ToString();
				}
				if(row["picApiUrl"]!=null)
				{
					model.picApiUrl=row["picApiUrl"].ToString();
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
			strSql.Append("select id,wid,isOpen,enterKeyWords,prompt,outKeyWords,initApiUrl,picApiUrl ");
			strSql.Append(" FROM wx_paizhao_setting ");
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
			strSql.Append(" id,wid,isOpen,enterKeyWords,prompt,outKeyWords,initApiUrl,picApiUrl ");
			strSql.Append(" FROM wx_paizhao_setting ");
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
			strSql.Append("select count(1) FROM wx_paizhao_setting ");
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
			strSql.Append(")AS Row, T.*  from wx_paizhao_setting T ");
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
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_paizhao_setting GetModelByWid(int wid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,isOpen,enterKeyWords,prompt,outKeyWords,initApiUrl,picApiUrl from wx_paizhao_setting ");
            strSql.Append(" where wid=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;

            MxWeiXinPF.Model.wx_paizhao_setting model = new MxWeiXinPF.Model.wx_paizhao_setting();
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
        /// 取微拍的提示语言
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="enterKeyWords"></param>
        /// <returns></returns>
        public string GetPromptByWid(int wid, string enterKeyWords)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  prompt  from wx_paizhao_setting ");
            strSql.Append(" where isOpen=1  and wid=@wid and enterKeyWords=@enterKeyWords ");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
                    new SqlParameter("@enterKeyWords", SqlDbType.VarChar,100)
			};
            parameters[0].Value = wid;
            parameters[1].Value = enterKeyWords;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 是否开启了，若开启返回true,否则返回false
        /// </summary>
        public bool isOpened(int wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_paizhao_setting");
            strSql.Append(" where isOpen=1  and wid=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		#endregion  ExtensionMethod
	}
}

