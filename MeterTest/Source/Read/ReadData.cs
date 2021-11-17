using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Read
{
    public class ReadData
    {
        private Dlt645Client client;
        private IReadLog log;
        private MeterAddress meterAddress;
        private bool endFlg = false;
        private Object Lock = new object();

        public ReadData(Dlt645Client client, IReadLog log, MeterAddress meterAddress)
        {
            this.client = client;
            this.log = log;
            this.meterAddress = meterAddress;
        }
        public void EndRead()
        {
            lock (Lock)
            {
                endFlg = true;
            }
        }
        public void ReadOnce(Object obj)
        {
            List<DataId> dataIdList = (List<DataId>)obj;
            ReadMsg msg = null;
            lock (Lock)
            {
                endFlg = false;
            }
            foreach (var item in dataIdList)
            {
                try
                {
                    msg = new ReadMsg();
                    Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                    msg.DataId = item;
                    log.SendReadDataId(item);
                    // dic.Add("reading", rst);
                    // synchronizationContext.Post(ReadOptUiUpdate, dic);
                    msg.DataId.DataArray = client.Read(meterAddress, item);
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
                    // Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                    // dic.Add("read", rst);
                    // synchronizationContext.Post(ReadOptUiUpdate, dic);
                    log.SendMsg(msg);
                    Thread.Sleep(500);
                }
                if(endFlg)
                {
                    break;
                }
            }
            log.ReadEnd(); /* 关闭锁 */
        }

        public void ReadCycle(Object obj)
        {
            List<DataId> dataIdList = (List<DataId>)obj;
            ReadMsg msg = null;
            lock (Lock)
            {
                endFlg = false;
            }
            int cycleReadErrorCnt = 0;
            int cycleReadOkCnt = 0;
            int timeOutCnt = 0;
            while(endFlg == false)
            {
                for (int i = 0; i < dataIdList.Count; i++)
                {
                    try
                    {
                        msg = new ReadMsg();
                        DataId item = dataIdList[i];
                        msg.DataId = item;
                        log.SendReadDataId(item);
                        msg.DataId.DataArray = client.Read(meterAddress, item);
                        msg.IsSuccess = true;
                        cycleReadOkCnt++;
                    }
                    catch (ClientException e)
                    {
                        msg.ErrorLog = e.Message;
                        cycleReadErrorCnt++;
                    }
                    catch (TimeoutException)
                    {
                        msg.ErrorLog = "响应超时";
                        timeOutCnt++;
                        // Interlocked.Exchange(ref cycleSwith, 0);
                        // break;
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("未知错误" + e.Message, "MeterTest",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                        msg.ErrorLog = "未知错误";
                        EndRead();
                        break;
                    }
                    finally
                    {
                        // Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                        // dic.Add("Read Cycle", rst);
                        // synchronizationContext.Post(ReadOptUiUpdate, dic);
                        log.SendMsg(msg);
                        Thread.Sleep(500);
                    }
                    if(endFlg)
                    {
                        break;
                    }
                }
            }
            MessageBox.Show("响应超时次数: " + timeOutCnt.ToString() + "\n"
                           + "错误响应次数: "+ cycleReadErrorCnt.ToString() + "\n"
                           + "正常响应次数: "+ cycleReadOkCnt.ToString() + "\n", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            log.ReadEnd(); /* 关闭锁 */
        }
    }
}