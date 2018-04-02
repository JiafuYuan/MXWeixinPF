<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zjdedite.aspx.cs" Inherits="MxWeiXinPF.Web.admin.choujiang.zjdedite" %>

<!DOCTYPE html>
<%@ Import Namespace="MxWeiXinPF.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑砸金蛋活动</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.mp3;" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.mp3;" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });


        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="zjdlist.aspx" class="back"><i></i><span>返回砸金蛋活动列表</span></a>
            <i class="arrow"></i>
            <span>编辑砸金蛋活动</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑砸金蛋活动开始内容</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">活动结束内容</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">基本设置</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">奖项设置</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtKW" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="砸金蛋" />
                    <span class="Validform_checktip">*只能写一个关键词，用户输入此关键词将会触发此活动。</span>
                </dd>
            </dl>
            <dl>
                <dt>开始活动的图片</dt>
                <dd>
                    <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/weixin/zjd/image/activity-zjd-start.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="beginPic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>
                    
                </dd>
            </dl>


            <dl>
                <dt>活动名称</dt>
                <dd>
                    <asp:TextBox ID="actName" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="砸金蛋活动开始了" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>
            <dl>
                <dt>兑奖信息</dt>
                <dd>
                    <asp:TextBox ID="duijiangInfo" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" " Text="兑奖请联系我们，电话189xxxxxxx1" />
                    <span class="Validform_checktip">*请不要多于100字! 这个设定但用户输入兑奖时候的显示信息!</span>
                </dd>
            </dl>

            <dl>
                <dt>简介</dt>
                <dd>
                    <textarea name="brief" rows="2" cols="20" id="brief" class="input" runat="server" datatype="*1-300" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>活动时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="beginDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>开始时间</i>
                    </div>
                    到
                  
                    <div class="input-date">
                        <asp:TextBox ID="endDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>结束时间</i>
                    </div>
                    <span class="Validform_checktip">*</span>

                </dd>
            </dl>

            <dl>
                <dt>活动说明</dt>
                <dd>
                    <textarea name="actContent" rows="2" cols="20" id="actContent" class="input" runat="server">亲，请点击进入砸金蛋砸奖活动页面，祝您好运哦！</textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>重复抽奖回复</dt>
                <dd>
                    <asp:TextBox ID="cfcjhf" runat="server" CssClass="input normal" Text="亲，继续努力哦！" datatype="*1-50" sucmsg=" " />
                    <span class="Validform_checktip">*如果设置只允许抽一次奖的，请写：你已经玩过了，下次再来。 如果设置可多次抽奖，请写：亲，继续努力哦！</span>
                </dd>
            </dl>




        </div>
        <div class="tab-content" style="display: none">
            <dl>
                <dt>活动结束的图片</dt>
                <dd>
                    <asp:Image ID="imgEndPic" runat="server" ImageUrl="/weixin/zjd/image/activity-zjd-end.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="endPic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>
                </dd>
            </dl>

            <dl>
                <dt>活动结束公告主题</dt>
                <dd>
                    <asp:TextBox ID="endNotice" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="砸金蛋活动已经结束了" />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>活动结束说明</dt>
                <dd>
                    <asp:TextBox ID="endContent" runat="server" CssClass="input normal" datatype="*1-300" sucmsg=" " Text="亲，活动已经结束，请继续关注我们的后续活动哦。" />
                    <span class="Validform_checktip">*换行请输入
                        <br/>
                    </span>
                </dd>
            </dl>

        </div>

          <div class="tab-content" style="display: none">

            <dl>
                <dt>预计活动的人数：</dt>
                <dd>
                    <asp:TextBox ID="zhongjianglv" runat="server" CssClass="input small"   datatype="/^(\d*\.)?\d+$/" sucmsg=" " Text=""  />
                    <span class="Validform_checktip">*预估活动人数直接影响抽奖概率：中奖概率 = 实际奖品总数/(预估活动人数*每人抽奖次数) 如果要确保任何时候都100%中奖建议设置为1人参加!</span>
                </dd>
            </dl>

                <dl>
                <dt>每人最多允许砸奖总次数：</dt>
                <dd>
                    <asp:TextBox ID="personMaxTimes" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text=""  />
                    <span class="Validform_checktip">*必须大于0无上限 推荐只设置1次!</span>
                </dd>
            </dl>

             <dl>
                <dt>每人每天最多砸多少次数：</dt>
                <dd>
                    <asp:TextBox ID="dayMaxTimes" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text=""  />
                    <span class="Validform_checktip">*必须小于总砸奖次数！ 0 为不限制 砸完总数就不能砸了! 可以砸奖天数 = 总数/每天砸奖次数!</span>
                </dd>
            </dl>

            <dl>
                <dt>商家兑奖密码：</dt>
                <dd>
                    <asp:TextBox ID="djPwd" runat="server" CssClass="input normal" datatype="*0-15" sucmsg=" " Text=""  />
                    <span class="Validform_checktip">*消费确认密码长度小于15位 不设置密码,兑奖页面的密码输入框则不出现</span>
                </dd>
            </dl>

              <dl>
                <dt>背景音乐：</dt>
                <dd>          
                      <asp:TextBox runat="server" CssClass="input normal upload-path" ID="backMusic"  ></asp:TextBox>
                      <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">*不设置音乐为默认音乐</span>
                </dd>
            </dl>

               <dl style="display:none">
                <dt>SN码生成设置：</dt>
                <dd>
                     <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="snShezhi" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">自动生成</asp:ListItem>
                            <asp:ListItem Value="1">批量导入</asp:ListItem>
                        </asp:RadioButtonList>
                        <span class="Validform_checktip">*预估活动人数直接影响抽奖概率：中奖概率 = 实际奖品总数/(预估活动人数*每人抽奖次数) 如果要确保任何时候都100%中奖建议设置为1人参加!</span>
                    </div>                 
                </dd>
            </dl>

             <dl style="display:none">
                <dt>SN码重命名：</dt>
                <dd>
                    <asp:TextBox ID="snRename" runat="server" CssClass="input small"  sucmsg=" " Text="" />
                    <span class="Validform_checktip">*例如：CND码,充值密码,SN码 这个主意用于修改SN码的名称,你导入自己的SN码可以是充值密码 你就可以设为 充值密码</span>
                </dd>
            </dl>
            <dl style="display:none">
                <dt>手机号重命名：</dt>
                <dd>
                    <asp:TextBox ID="telRename" runat="server" CssClass="input small"  sucmsg=" " Text="" />
                    <span class="Validform_checktip">例如：QQ号,微信号,手机号,,邮寄地址! 不懂请默认设置手机号， 此字段主要收集用户的信息方便联系</span>
                </dd>
            </dl>
            <dl>
                <dt>是否显示奖品数量</dt>
                <dd>
                  
                      <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="jpDisplay" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="True" Selected="True">显示</asp:ListItem>
                            <asp:ListItem Value="False">不显示</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                </dd>
            </dl>

               <dl style="display:none">
                <dt>没中奖是否默认为幸运奖</dt>
                <dd>
     
               <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="mrXingyun" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="False" Selected="True">否</asp:ListItem>
                            <asp:ListItem Value="True">是</asp:ListItem>
                        </asp:RadioButtonList>
                   <span class="Validform_checktip">中默认奖写在描述中即可！</span>
                    </div>
                </dd>
            </dl>

               <dl style="display:none">
                <dt>中奖设置</dt>
                <dd>
                   <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="zhongjiangSZ" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" >允许多次中奖</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">只允许中奖一次</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    
                </dd>
            </dl>

                 <dl style="display:none">
                <dt>抽奖模式</dt>
                <dd>
                      <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="choujiangMode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">只允许关注用户参加</asp:ListItem>
                            <asp:ListItem Value="1">允许所有用户参加(关注前后身份不一样)</asp:ListItem>
                            <asp:ListItem Value="2">允许所有用户参加（关注前后身份一样）</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>              
                </dd>
            </dl>

         </div>


        <div class="tab-content" style="display: none">
            <dl>
                <dt>奖项1（一等奖）</dt>
                <dd>
                    奖项名称：<asp:TextBox ID="txt1JXName" runat="server" CssClass="input " datatype="*1-50" sucmsg=" " nullmsg=" " Text="" />
                    奖品名称：<asp:TextBox ID="txt1JPName" runat="server" CssClass="input " datatype="*1-50" sucmsg=" " nullmsg=" " Text="" />
                    显示奖品数：<asp:TextBox ID="txt1XSName" runat="server" CssClass="input small" datatype="n" sucmsg=" " nullmsg=" " Text="" />
                    奖品数：<asp:TextBox ID="txt1RealNum" runat="server" CssClass="input small" datatype="n" sucmsg=" " nullmsg=" " Text="" />
                    奖品图片：                                
                    <asp:TextBox ID="txt1Num" runat="server" CssClass="input normal upload-path" datatype="*1-1000"    Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl>
                <dt>奖项2（二等奖）</dt>
                <dd>
                    奖项名称：<asp:TextBox ID="txt2JXName" runat="server" CssClass="input " datatype="*0-50"  sucmsg=" " Text="" />
                     奖品名称：<asp:TextBox ID="txt2JPName" runat="server" CssClass="input " datatype="*0-50"    sucmsg=" " Text="" />
                    显示奖品数：<asp:TextBox ID="txt2XSName" runat="server" CssClass="input small"  sucmsg=" " Text="" />
                    奖品数：<asp:TextBox ID="txt2RealNum" runat="server" CssClass="input small"  datatype="/^\d*$/" sucmsg=" " Text="" />
                   
                   奖品图片：  <asp:TextBox ID="txt2Num" runat="server" datatype="*0-1000" CssClass="input normal upload-path" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>   
                  
                </dd>
            </dl>
            <dl>
                <dt>奖项3（三等奖）</dt>
                 <dd>
                     奖项名称：<asp:TextBox ID="txt3JXName" runat="server" CssClass="input "  sucmsg=" " Text="" />
                     奖品名称：<asp:TextBox ID="txt3JPName" runat="server" CssClass="input "  sucmsg=" " Text="" />
                     显示奖品数：<asp:TextBox ID="txt3XSName" runat="server" CssClass="input small"  sucmsg=" " Text="" />
                    奖品数：<asp:TextBox ID="txt3RealNum" runat="server" CssClass="input small" datatype="/^\d*$/"  sucmsg=" " Text="" />
                    
                   奖品图片： <asp:TextBox ID="txt3Num" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>   
                </dd>
            </dl>
            <dl>
                <dt>奖项4（四等奖）</dt>
                <dd>
                    奖项名称：<asp:TextBox ID="txt4JXName" runat="server" CssClass="input "  sucmsg=" " Text="" />
                     奖品名称：<asp:TextBox ID="txt4JPName" runat="server" CssClass="input "  sucmsg=" " Text="" />
                    显示奖品数：<asp:TextBox ID="txt4XSName" runat="server" CssClass="input small"  sucmsg=" " Text="" />
                    奖品数：<asp:TextBox ID="txt4RealNum" runat="server" CssClass="input small" datatype="/^\d*$/"  sucmsg=" " Text="" />
                  
                   奖品图片：<asp:TextBox ID="txt4Num" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>     

                </dd>
            </dl>
            <dl>
                <dt>奖项5（五等奖）</dt>
                <dd>奖项名称：<asp:TextBox ID="txt5JXName" runat="server" CssClass="input "  sucmsg=" " Text="" />
                      奖品名称：<asp:TextBox ID="txt5JPName" runat="server" CssClass="input "  sucmsg=" " Text="" />
                    显示奖品数：<asp:TextBox ID="txt5XSName" runat="server" CssClass="input small"  sucmsg=" " Text="" />
                    奖品数：<asp:TextBox ID="txt5RealNum" runat="server" CssClass="input small" datatype="/^\d*$/"  sucmsg=" " Text="" />
                  
                   奖品图片：<asp:TextBox ID="txt5Num" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>       

                </dd>
            </dl>
            <dl>
                <dt>奖项6（六等奖）</dt>
                <dd>奖项名称：<asp:TextBox ID="txt6JXName" runat="server" CssClass="input "  sucmsg=" " Text="" />
                      奖品名称：<asp:TextBox ID="txt6JPName" runat="server" CssClass="input "  sucmsg=" " Text="" />
                    显示奖品数：<asp:TextBox ID="txt6XSName" runat="server" CssClass="input small"  sucmsg=" " Text="" />
                    奖品数：<asp:TextBox ID="txt6RealNum" runat="server" CssClass="input small" datatype="/^\d*$/"  sucmsg=" " Text="" />
                  
                   奖品图片：<asp:TextBox ID="txt6Num" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>   

                </dd>
            </dl>

           

        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click"  />
                <a href="dzplist.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>

