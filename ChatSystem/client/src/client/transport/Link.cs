﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.transport
{
    /// <summary>
    /// 传输消息 抽象集合
    /// </summary>
    abstract class Link
    {
        public abstract String receive();
       // public abstract void send(String msg, Encoding chreast);
        public abstract void send(String msg);
        internal abstract void close();
     //   internal abstract String receive(Encoding Chreast);
    }
}
