using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Write
{
    public class ParaConfig
    {
        private Dlt645Client client;
        private MeterAddress meterAddress;
        private Dlt645Password password;
        private Dlt645OperatorCode optCode;
        private IParaConfigLog log;

        private bool stopFlg = false;
        private bool pauseFlg = false;
        private Object Lock = new object();
        private object pauseLock = new Object();

        public ParaConfig(Dlt645Client client, MeterAddress meterAddress, Dlt645Password password, Dlt645OperatorCode optCode, IParaConfigLog log)
        {
            this.client = client;
            this.meterAddress = meterAddress;
            this.password = password;
            this.optCode = optCode;
            this.log = log;
        }
        public void StopOpt()
        {
            lock(Lock)
            {
                stopFlg = true;
            }
        }

        private byte[] ParaRead(DataId dataId)
        {
            int cnt = 3;
            byte[] dataArray = null;
            while (cnt > 0)
            {
                 try
                 {
                    dataArray = client.Read(meterAddress, dataId); 
                    break;
                 }
                 catch (TimeoutException)
                 {
                     if(cnt > 0)
                     {
                         cnt--;
                     }
                     else
                     {
                         throw;
                     }
                 }
            }
            return dataArray;
        }
        private void ParaWrite(DataId dataId)
        {
            if(dataId.Id == 0x04000101)
            {
                int i = 0;
                for (; i < dataId.DataArray.Length; i++)
                {
                    if(dataId.DataArray[i] != 0xaa)
                    {
                        break;
                    }
                }
                if(i >= dataId.DataArray.Length)
                {
                    dataId.DataArray = new byte[4];
                    byte tmp = ((byte)(DateTime.Now.Year - 2000));;
                    dataId.DataArray[3] = (byte)((((tmp) / 10) << 4) + ((tmp) % 10));

                    tmp = (byte)(DateTime.Now.Month);
                    dataId.DataArray[2] = (byte)((((tmp) / 10) << 4) + ((tmp) % 10));

                    tmp = (byte)(DateTime.Now.Day);
                    dataId.DataArray[1] = (byte)((((tmp) / 10) << 4) + ((tmp) % 10));

                    tmp = (byte)(DateTime.Now.DayOfWeek);
                    dataId.DataArray[0] = (byte)((((tmp) / 10) << 4) + ((tmp) % 10));
                }
            }
            else if(dataId.Id == 0x04000102)
            {
                int i = 0;
                for (; i < dataId.DataArray.Length; i++)
                {
                    if(dataId.DataArray[i] != 0xaa)
                    {
                        break;
                    }
                }
                if(i >= dataId.DataArray.Length)
                {
                    dataId.DataArray = new byte[3];
                    byte tmp = (byte)(DateTime.Now.Hour);
                    dataId.DataArray[2] = (byte)((((tmp) / 10) << 4) + ((tmp) % 10));

                    tmp = (byte)(DateTime.Now.Minute);
                    dataId.DataArray[1] = (byte)((((tmp) / 10) << 4) + ((tmp) % 10));

                    tmp = (byte)(DateTime.Now.Second);
                    dataId.DataArray[0] = (byte)((((tmp) / 10) << 4) + ((tmp) % 10));
                }
            }
            int cnt = 3;
            while (cnt > 0)
            {
                 try
                 {
                     client.Write(meterAddress, dataId, password, optCode); 
                     break;
                 }
                 catch (TimeoutException)
                 {
                     if(cnt > 0)
                     {
                         cnt--;
                     }
                     else
                     {
                         throw;
                     }
                 }
            }
        }
        private bool DataCompare(DataId dataId, byte[] dataArray)
        {
            bool rst = false;
            int i = 0;
            
            if(dataArray.Length != dataId.DataBytes)
            {
                return false;
            }
            if(dataId.Id == 0x04000102)
            {
                for (i = 0; i < dataId.DataArray.Length; i++)
                {
                   if(dataId.DataArray[i] != 0xAA)
                   {
                       break;
                   }
                }
                if(i >= dataId.DataArray.Length)
                {
                    int hour, minute, second;
                    
                    byte tmp = dataArray[2];
                    hour = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    tmp = dataArray[1];
                    minute = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    tmp = dataArray[0];
                    second = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);
                    long de = Math.Abs(DateTime.Now.Ticks - dateTime.Ticks);
                    if(de < 5 * TimeSpan.TicksPerSecond)
                    {
                        return true;
                    }
                }
            }
            if(dataId.Id == 0x04000101)
            {
                for (i = 0; i < dataId.DataArray.Length; i++)
                {
                   if(dataId.DataArray[i] != 0xAA)
                   {
                       break;
                   }
                }
                if(i >= dataId.DataArray.Length)
                {
                    int year, month, day, dayOfWeek;
                    
                    byte tmp = dataArray[3];
                    year = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)) + 2000);

                    tmp = dataArray[2];
                    month = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    tmp = dataArray[1];
                    day = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    tmp = dataArray[0];
                    dayOfWeek = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    if((year == DateTime.Now.Year) 
                    && (month == DateTime.Now.Month)
                    && (day == DateTime.Now.Day)
                    && (dayOfWeek == (int)DateTime.Now.DayOfWeek))
                    {
                        return true;
                    }
                }
            }

            for (i = 0; i < dataId.DataBytes; i++)
            {
                if(dataId.DataArray[i] != dataArray[i])
                {
                    break;
                }
            }
            rst = (i >= dataId.DataBytes);
            return rst;
        }
        public void  ParaSet(object obj)
        {
            List<DataId> list = (List<DataId>)(obj);
            lock (Lock)
            {
                stopFlg = false;
            }
            ParaConfigMsg msg = null;
            foreach (var item in list)
            {
                try
                {
                    msg = new ParaConfigMsg();
                    msg.DataId = item;
                    log.SendConfigDataId(item);
                    ParaWrite(item);
                    msg.IsSuccess = true;
                }
                catch (ClientException e)
                {
                    msg.ErrorLog = e.Message;
                }
                catch (TimeoutException)
                {
                    msg.ErrorLog = "响应超时";
                }
                catch(Exception e)
                {
                    MessageBox.Show("未知错误" + e.Message, "MeterTest",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msg.ErrorLog = "未知错误";
                    break;
                }
                finally
                {
                    log.SendMsg(msg);
                    Thread.Sleep(500);
                }
                if(stopFlg)
                {
                    break;
                }
                if(pauseFlg)
                {
                    while (true)
                    {
                        Thread.Sleep(10);
                        if(!pauseFlg)
                        {
                            break;
                        }
                    }
                }
            }
            log.End(); /* 关闭锁 */
        }

        public void ParaCompare(object obj)
        {
            List<DataId> list = (List<DataId>)(obj);
            lock (Lock)
            {
                stopFlg = false;
            }
            ParaConfigMsg msg = null;
            foreach (var item in list)
            {
                try
                {
                    msg = new ParaConfigMsg();
                    msg.DataId = item;
                    log.SendConfigDataId(item);
                    byte[] dataArray = ParaRead(item);
                    if(DataCompare(item, dataArray))
                    {
                        msg.IsSuccess = true;
                    }
                    else
                    {
                        msg.IsSuccess = false;
                        msg.ErrorLog = "不一致";
                    }
                }
                catch (ClientException e)
                {
                    msg.ErrorLog = e.Message;
                }
                catch (TimeoutException)
                {
                    msg.ErrorLog = "响应超时";
                }
                catch(Exception e)
                {
                    MessageBox.Show("未知错误" + e.Message, "MeterTest",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msg.ErrorLog = "未知错误";
                    break;
                }
                finally
                {
                    log.SendMsg(msg);
                    Thread.Sleep(500);
                }
                if(stopFlg)
                {
                    break;
                }
            }
            log.End(); /* 关闭锁 */
        }
    }
}