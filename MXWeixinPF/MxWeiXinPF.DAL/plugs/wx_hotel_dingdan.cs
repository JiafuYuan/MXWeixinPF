using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_hotel_dingdan
	/// </summary>
	public partial class wx_hotel_dingdan
	{
		public wx_hotel_dingdan()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_hotel_dingdan");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_hotel_dingdan");
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
        public int Add(MxWeiXinPF.Model.wx_hotel_dingdan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_hotel_dingdan(");
            strSql.Append("hotelid,openid,oderName,tel,arriveTime,leaveTime,roomType,orderTime,orderNum,price,orderStatus,isDelete,createDate,roomid,yuanjia,remark)");
            strSql.Append(" values (");
            strSql.Append("@hotelid,@openid,@oderName,@tel,@arriveTime,@leaveTime,@roomType,@orderTime,@orderNum,@price,@orderStatus,@isDelete,@createDate,@roomid,@yuanjia,@remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@hotelid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,200),
					new SqlParameter("@oderName", SqlDbType.VarChar,100),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@arriveTime", SqlDbType.DateTime),
					new SqlParameter("@leaveTime", SqlDbType.DateTime),
					new SqlParameter("@roomType", SqlDbType.VarChar,200),
					new SqlParameter("@orderTime", SqlDbType.DateTime),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@orderStatus", SqlDbType.Int,4),
					new SqlParameter("@isDelete", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@roomid", SqlDbType.Int,4),
					new SqlParameter("@yuanjia", SqlDbType.Float,8),
					new SqlParameter("@remark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.hotelid;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.oderName;
            parameters[3].Value = model.tel;
            parameters[4].Value = model.arriveTime;
            parameters[5].Value = model.leaveTime;
            parameters[6].Value = model.roomType;
            parameters[7].Value = model.orderTime;
            parameters[8].Value = model.orderNum;
            parameters[9].Value = model.price;
            parameters[10].Value = model.orderStatus;
            parameters[11].Value = model.isDelete;
            parameters[12].Value = model.createDate;
            parameters[13].Value = model.roomid;
            parameters[14].Value = model.yuanjia;
            parameters[15].Value = model.remark;

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
        public bool Update(MxWeiXinPF.Model.wx_hotel_dingdan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_hotel_dingdan set ");
            strSql.Append("hotelid=@hotelid,");
            strSql.Append("openid=@openid,");
            strSql.Append("oderName=@oderName,");
            strSql.Append("tel=@tel,");
            strSql.Append("arriveTime=@arriveTime,");
            strSql.Append("leaveTime=@leaveTime,");
            strSql.Append("roomType=@roomType,");
            strSql.Append("orderTime=@orderTime,");
            strSql.Append("orderNum=@orderNum,");
            strSql.Append("price=@price,");
            strSql.Append("orderStatus=@orderStatus,");
            strSql.Append("isDelete=@isDelete,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("roomid=@roomid,");
            strSql.Append("yuanjia=@yuanjia,");
            strSql.Append("remark=@remark");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@hotelid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,200),
					new SqlParameter("@oderName", SqlDbType.VarChar,100),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@arriveTime", SqlDbType.DateTime),
					new SqlParameter("@leaveTime", SqlDbType.DateTime),
					new SqlParameter("@roomType", SqlDbType.VarChar,200),
					new SqlParameter("@orderTime", SqlDbType.DateTime),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@orderStatus", SqlDbType.Int,4),
					new SqlParameter("@isDelete", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@roomid", SqlDbType.Int,4),
					new SqlParameter("@yuanjia", SqlDbType.Float,8),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.hotelid;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.oderName;
            parameters[3].Value = model.tel;
            parameters[4].Value = model.arriveTime;
            parameters[5].Value = model.leaveTime;
            parameters[6].Value = model.roomType;
            parameters[7].Value = model.orderTime;
            parameters[8].Value = model.orderNum;
            parameters[9].Value = model.price;
            parameters[10].Value = model.orderStatus;
            parameters[11].Value = model.isDelete;
            parameters[12].Value = model.createDate;
            parameters[13].Value = model.roomid;
            parameters[14].Value = model.yuanjia;
            parameters[15].Value = model.remark;
            parameters[16].Value = model.id;

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
            strSql.Append("delete from wx_hotel_dingdan ");
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
            strSql.Append("delete from wx_hotel_dingdan ");
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
        public MxWeiXinPF.Model.wx_hotel_dingdan GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,hotelid,openid,oderName,tel,arriveTime,leaveTime,roomType,orderTime,orderNum,price,orderStatus,isDelete,createDate,roomid,yuanjia,remark from wx_hotel_dingdan ");
            strSql.Append(" where id=@id and isDelete='0' ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            MxWeiXinPF.Model.wx_hotel_dingdan model = new MxWeiXinPF.Model.wx_hotel_dingdan();
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
        public MxWeiXinPF.Model.wx_hotel_dingdan DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_hotel_dingdan model = new MxWeiXinPF.Model.wx_hotel_dingdan();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["hotelid"] != null && row["hotelid"].ToString() != "")
                {
                    model.hotelid = int.Parse(row["hotelid"].ToString());
                }
                if (row["openid"] != null)
                {
                    model.openid = row["openid"].ToString();
                }
                if (row["oderName"] != null)
                {
                    model.oderName = row["oderName"].ToString();
                }
                if (row["tel"] != null)
                {
                    model.tel = row["tel"].ToString();
                }
                if (row["arriveTime"] != null && row["arriveTime"].ToString() != "")
                {
                    model.arriveTime = DateTime.Parse(row["arriveTime"].ToString());
                }
                if (row["leaveTime"] != null && row["leaveTime"].ToString() != "")
                {
                    model.leaveTime = DateTime.Parse(row["leaveTime"].ToString());
                }
                if (row["roomType"] != null)
                {
                    model.roomType = row["roomType"].ToString();
                }
                if (row["orderTime"] != null && row["orderTime"].ToString() != "")
                {
                    model.orderTime = DateTime.Parse(row["orderTime"].ToString());
                }
                if (row["orderNum"] != null && row["orderNum"].ToString() != "")
                {
                    model.orderNum = int.Parse(row["orderNum"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["orderStatus"] != null && row["orderStatus"].ToString() != "")
                {
                    model.orderStatus = int.Parse(row["orderStatus"].ToString());
                }
                if (row["isDelete"] != null && row["isDelete"].ToString() != "")
                {
                    model.isDelete = int.Parse(row["isDelete"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["roomid"] != null && row["roomid"].ToString() != "")
                {
                    model.roomid = int.Parse(row["roomid"].ToString());
                }
                if (row["yuanjia"] != null && row["yuanjia"].ToString() != "")
                {
                    model.yuanjia = decimal.Parse(row["yuanjia"].ToString());
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
            strSql.Append("select aa.*,bb.hotelName as hotelName FROM wx_hotel_dingdan  as aa right join wx_hotels_info as bb on aa.hotelid=bb.id ");
        
            strSql.Append(" and aa.openid='" + strWhere + "' and aa.isDelete='0' ");
         
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
            strSql.Append(" id,hotelid,openid,oderName,tel,arriveTime,leaveTime,roomType,orderTime,orderNum,price,orderStatus,isDelete,createDate,roomid,yuanjia,remark ");
            strSql.Append(" FROM wx_hotel_dingdan ");
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
            strSql.Append("select count(1) FROM wx_hotel_dingdan ");
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
            strSql.Append(")AS Row, T.*  from wx_hotel_dingdan T ");
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
            parameters[0].Value = "wx_hotel_dingdan";
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
            strSql.Append("select id,hotelid,openid,oderName,tel,arriveTime,leaveTime,roomType,orderTime,orderNum,price,orderStatus,isDelete,'' as payStatusStr,createDate ");
            strSql.Append(" FROM wx_hotel_dingdan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        public DataSet GetList(int hotelid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select aa.id,aa.hotelid,aa.openid,bb.hotelName as hotelName,aa.oderName,aa.tel,");
            strSql.Append(" aa.arriveTime,aa.leaveTime,aa.roomType,aa.orderTime,aa.orderNum,aa.price,aa.orderStatus,aa.isDelete,aa.createDate,aa.roomid,aa.yuanjia,aa.remark  ");
            strSql.Append("from wx_hotel_dingdan  as aa left join (select * from wx_hotels_info where id='" + hotelid + "' ) as bb on bb.id=aa.hotelid");
			return DbHelperSQL.Query(strSql.ToString());
		}

        public bool Updatehotel(MxWeiXinPF.Model.wx_hotel_dingdan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_hotel_dingdan set ");
            strSql.Append("oderName=@oderName,");
            strSql.Append("tel=@tel,");
            strSql.Append("arriveTime=@arriveTime,");
            strSql.Append("orderNum=@orderNum,");
            strSql.Append("price=@price,");
            strSql.Append("yuanjia=@yuanjia,");
            strSql.Append("remark=@remark");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@oderName", SqlDbType.VarChar,100),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@arriveTime", SqlDbType.DateTime),
					new SqlParameter("@orderNum", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@yuanjia", SqlDbType.Float,8),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.oderName;
            parameters[1].Value = model.tel;
            parameters[2].Value = model.arriveTime;
            parameters[3].Value = model.orderNum;
            parameters[4].Value = model.price;
            parameters[5].Value = model.yuanjia;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.id;

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

        public bool Update(int id,string status)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  wx_hotel_dingdan  set orderStatus='" + status + "'  where  id='"+id+"'  ");
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


        public bool Update(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  wx_hotel_dingdan  set isDelete='1'  where  id='" + id + "'  ");
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


        public DataSet GetList(string openid, int hotelid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aa.*,bb.hotelName as hotelName FROM wx_hotel_dingdan  as aa inner join wx_hotels_info as bb on aa.hotelid=bb.id ");

            strSql.Append(" and aa.openid='" + openid + "' and aa.isDelete='0'  and aa.hotelid='" + hotelid + "'  ");

            return DbHelperSQL.Query(strSql.ToString());
        }

		#endregion  ExtensionMethod
	}
}

