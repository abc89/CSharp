﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.msg
{
    class Msg
    {
        private enum MsgContent
        {
            msgType, name, port, msgContent, ip,controlMsg,sessionID,operateID,isAlive,msgID
        }
        //消息类型 msgtype
        public const String CONTROL = "1";//控制类型信息： 新用户登录，好友更新
        public const String ONECHAT = "2";//单聊信息类型
        public const String MANNYCHAT = "3";//多聊信息类型
        public const String EXITCLIENT = "4";//结束服务器链接
        public class ContentType
        {
            //消息内容控制信息 msgContent
            public const String NEWCLIENT = "1";//控制类型信息： 新用户登录，好友更新
            public const String GETMYFRIENDS = "2";
            public const String ADDFRIEND = "3";
            public const String ISALIVE = "4";
        }
        private  static int msgLength = 12;
        private  String[] msgs = new String[msgLength];
        public static String NULLMSG = "null";
        public Msg()
        {
            clear();
        }
        public  void clear()
        {

            for (int i = 0; i < msgLength; i++)
            {
                msgs[i] = "null";
            }

        }

        public Msg(String msg) {
            clear();
            if (msg.IndexOf('&')==-1) {
                msgs[(int)MsgContent.msgContent] = msg;
                return;
            }
            String[] ms = msg.Split('&');
            for (int i = 0; i < ms.Length; i++)
            {
                msgs[i] = ms[i];
            }
        }
        public void setMsgType(String type) {

            msgs[(int)MsgContent.msgType] = type;
        }
        public String getMsgType()
        {

            return msgs[(int)MsgContent.msgType];
        }
        public void setSessionID(String id)
        {

            msgs[(int)MsgContent.sessionID] = id;
        }
        public String getSessionID()
        {

            return msgs[(int)MsgContent.sessionID];
        }
        public void setOperateID(String id)
        {

            msgs[(int)MsgContent.operateID] = id;
        }
        public String getOperateID()
        {

            return msgs[(int)MsgContent.operateID];
        }
        public void setMsgID(String msgID)
        {

            msgs[(int)MsgContent.msgID] = msgID;
        }
        public String getMsgID()
        {

            return msgs[(int)MsgContent.msgID];
        }
        public void setControlType(String type) {
            msgs[(int)MsgContent.controlMsg] = type;
        }
        public String getControlType()
        {
            return msgs[(int)MsgContent.controlMsg];
        }
        public  void config(String msg)
        {
            String[] ms = msg.Split('&');
            for (int i = 0; i < msgLength; i++)
            {
                msgs[i] = ms[i];
            }
        }

        internal void setIP(string ip)
        {
           msgs[(int)MsgContent.ip]=ip;
        }
        internal String getIP(string ip)
        {
           return  msgs[(int)MsgContent.ip] ;
        }

        public String type() {
            return msgs[(int)MsgContent.msgType];
         
        }
        public  void setName(String value)
        {
            msgs[(int)MsgContent.name] = value;
        }
        public void setMsgContents(List<String> values)
        {
            int size = values.Count;
            String content = "null";
            if (size >= 1)
            {
                content = values.ElementAt(0);
            }
            else {
                return;
            }
            
            for (int i=1;i< size;i++) {
                content = content + "/" + values.ElementAt(i);
            }
            msgs[(int)MsgContent.msgContent] = content;
        }
        /// <summary>
        /// 获取好友数组
        /// </summary>
        /// <returns>返回 好友字符串组   或  返回空好友字符串组组</returns>
        public String[]  getMsgContents()
        {           
            if (msgs[(int)MsgContent.msgContent].IndexOf('/')!=-1) {
                String[] friends = msgs[(int)MsgContent.msgContent].Split('/');
                return friends;
            }
            String[] temp = new String[0];
            return temp;
        }
        public  void setMsgContent(String value)
        {
            msgs[(int)MsgContent.msgContent] = value;
        }
        public String getMsgContent()
        {
            return msgs[(int)MsgContent.msgContent];
        }
        public  void setPort(String value)
        {
            msgs[(int)MsgContent.port] = value;
        }
        public  String getName()
        {
            return msgs[(int)MsgContent.name];
        }

     
        public  String getPort()
        {
            return msgs[(int)MsgContent.port];
        }
        public String getMsg()
        {
            String msg = msgs[0];
            for (int i = 1; i < msgLength; i++)
            {
                msg = msg + "&" + msgs[i];
            }
            return msg;
        }
    }
}