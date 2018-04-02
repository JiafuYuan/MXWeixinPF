using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_fc_panorama
	/// </summary>
	public partial class wx_fc_panorama
	{
		public wx_fc_panorama()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "wx_fc_panorama"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_fc_panorama");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MxWeiXinPF.Model.wx_fc_panorama model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_fc_panorama(");
			strSql.Append("wid,fid,pri_front,pic_right,pic_behind,pic_left,pic_top,pic_bottom,pic_yulan,remark,seq,createDate,jdname)");
			strSql.Append(" values (");
			strSql.Append("@wid,@fid,@pri_front,@pic_right,@pic_behind,@pic_left,@pic_top,@pic_bottom,@pic_yulan,@remark,@seq,@createDate,@jdname)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@fid", SqlDbType.Int,4),
					new SqlParameter("@pri_front", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_right", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_behind", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_left", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_top", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_bottom", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_yulan", SqlDbType.VarChar,1000),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@jdname", SqlDbType.VarChar,800)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.fid;
			parameters[2].Value = model.pri_front;
			parameters[3].Value = model.pic_right;
			parameters[4].Value = model.pic_behind;
			parameters[5].Value = model.pic_left;
			parameters[6].Value = model.pic_top;
			parameters[7].Value = model.pic_bottom;
			parameters[8].Value = model.pic_yulan;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.seq;
			parameters[11].Value = model.createDate;
			parameters[12].Value = model.jdname;

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
		public bool Update(MxWeiXinPF.Model.wx_fc_panorama model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_fc_panorama set ");
			strSql.Append("wid=@wid,");
			strSql.Append("fid=@fid,");
			strSql.Append("pri_front=@pri_front,");
			strSql.Append("pic_right=@pic_right,");
			strSql.Append("pic_behind=@pic_behind,");
			strSql.Append("pic_left=@pic_left,");
			strSql.Append("pic_top=@pic_top,");
			strSql.Append("pic_bottom=@pic_bottom,");
			strSql.Append("pic_yulan=@pic_yulan,");
			strSql.Append("remark=@remark,");
			strSql.Append("seq=@seq,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("jdname=@jdname");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@fid", SqlDbType.Int,4),
					new SqlParameter("@pri_front", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_right", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_behind", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_left", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_top", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_bottom", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_yulan", SqlDbType.VarChar,1000),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@jdname", SqlDbType.VarChar,800),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.fid;
			parameters[2].Value = model.pri_front;
			parameters[3].Value = model.pic_right;
			parameters[4].Value = model.pic_behind;
			parameters[5].Value = model.pic_left;
			parameters[6].Value = model.pic_top;
			parameters[7].Value = model.pic_bottom;
			parameters[8].Value = model.pic_yulan;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.seq;
			parameters[11].Value = model.createDate;
			parameters[12].Value = model.jdname;
			parameters[13].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_fc_panorama ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_fc_panorama ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public MxWeiXinPF.Model.wx_fc_panorama GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,wid,fid,pri_front,pic_right,pic_behind,pic_left,pic_top,pic_bottom,pic_yulan,remark,seq,createDate,jdname from wx_fc_panorama ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			MxWeiXinPF.Model.wx_fc_panorama model=new MxWeiXinPF.Model.wx_fc_panorama();
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
		public MxWeiXinPF.Model.wx_fc_panorama DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_fc_panorama model=new MxWeiXinPF.Model.wx_fc_panorama();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["fid"]!=null && row["fid"].ToString()!="")
				{
					model.fid=int.Parse(row["fid"].ToString());
				}
				if(row["pri_front"]!=null)
				{
					model.pri_front=row["pri_front"].ToString();
				}
				if(row["pic_right"]!=null)
				{
					model.pic_right=row["pic_right"].ToString();
				}
				if(row["pic_behind"]!=null)
				{
					model.pic_behind=row["pic_behind"].ToString();
				}
				if(row["pic_left"]!=null)
				{
					model.pic_left=row["pic_left"].ToString();
				}
				if(row["pic_top"]!=null)
				{
					model.pic_top=row["pic_top"].ToString();
				}
				if(row["pic_bottom"]!=null)
				{
					model.pic_bottom=row["pic_bottom"].ToString();
				}
				if(row["pic_yulan"]!=null)
				{
					model.pic_yulan=row["pic_yulan"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["jdname"]!=null)
				{
					model.jdname=row["jdname"].ToString();
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
			strSql.Append("select Id,wid,fid,pri_front,pic_right,pic_behind,pic_left,pic_top,pic_bottom,pic_yulan,remark,seq,createDate,jdname ");
			strSql.Append(" FROM wx_fc_panorama ");
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
			strSql.Append(" Id,wid,fid,pri_front,pic_right,pic_behind,pic_left,pic_top,pic_bottom,pic_yulan,remark,seq,createDate,jdname ");
			strSql.Append(" FROM wx_fc_panorama ");
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
			strSql.Append("select count(1) FROM wx_fc_panorama ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from wx_fc_panorama T ");
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
			parameters[0].Value = "wx_fc_panorama";
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
            strSql.Append("select a.*  from wx_fc_panorama a ");
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

