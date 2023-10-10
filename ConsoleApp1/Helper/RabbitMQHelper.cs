using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper
{
    public class RabbitMQHelper
    {
       // ConnectionFactory connectionFactory = new ConnectionFactory();
        private static ConnectionFactory connectionFactory = new ConnectionFactory
        {
            HostName = "http://127.0.0.1:15672/#/",
            UserName = "guest",     // 用户名
            Password = "guest"      // 密码
            // Port=5672
        };
        private static IConnection connection;
        private RabbitMQHelper() { }

        private static void CreateConn()
        {
            connection = connectionFactory.CreateConnection();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queName"></param>
        /// <param name="msg"></param>
        public static bool SendMsg<T>(string exchangeName,string queName, T msg) where T : class
        {
            if (msg == null)
            {
                return false;
            }
            try
            {
                if (connection == null || !connection.IsOpen)
                {
                    CreateConn();
                }
                using (var channel = connection.CreateModel())
                {
                    //声明一个队列
                    channel.QueueDeclare(queName, true, false, false, null);
                    if (!string.IsNullOrEmpty(exchangeName))
                    {
                        //声明交换机
                        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true);
                        //绑定队列，交换机，路由键
                        channel.QueueBind(queName, exchangeName, queName);
                    }

                    var basicProperties = channel.CreateBasicProperties();
                    //1：非持久化 2：可持久化
                    basicProperties.DeliveryMode = 2;
                    var payload = Encoding.UTF8.GetBytes(msg.ToJson());
                    var address = new PublicationAddress(ExchangeType.Direct, exchangeName, queName);
                    channel.BasicPublish(address, basicProperties, payload);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发送MQ消息异常.Msg:{ex.Message},Stck:{ex.StackTrace}");
                return false;
            }
          
        }
       
        /// <summary>
        /// 发送多条消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queName"></param>
        /// <param name="msg"></param>
        public static bool SendMessages<T>(string exchangeName, string queName, List<T> msgs) where T : class
        {
            if (msgs == null && !msgs.Any())
            {
                return false;
            }
            try
            {
                if (connection == null || !connection.IsOpen)
                {
                    CreateConn();
                }
                using (var channel = connection.CreateModel())
                {
                    //声明一个队列
                    channel.QueueDeclare(queName, true, false, false, null);
                    if (!string.IsNullOrEmpty(exchangeName))
                    {
                        //声明交换机
                        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true);
                        //绑定队列，交换机，路由键
                        channel.QueueBind(queName, exchangeName, queName);
                    }

                    var basicProperties = channel.CreateBasicProperties();
                    //1：非持久化 2：可持久化
                    basicProperties.DeliveryMode = 2;
                    var address = new PublicationAddress(ExchangeType.Direct, exchangeName, queName);
                    msgs.ForEach((msg) => {
                        var payload = Encoding.UTF8.GetBytes(msg.ToJson());
                        channel.BasicPublish(address, basicProperties, payload);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                var gewa = ex;
                return false;
            }
        }
        /// <summary>
        /// 消息加入队列中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queneName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool EnqueneMsg<T>(string queneName, T msg) where T : class
        {
            if (msg == null)
            {
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                var pushMsgResult = SendMsg("", queneName, msg);
                if (pushMsgResult) return true;
                Thread.Sleep(100);
            }
            return false;
        }
        public static bool EnqueneMessages<T>(string queneName, List<T> msgs) where T : class
        {
            if (msgs == null && !msgs.Any())
            {
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                var pushMsgResult = SendMessages("", queneName, msgs);
                if (pushMsgResult) return true;
                Thread.Sleep(100);
            }
            return false;
        }
        public static bool GetMessageCount(string queName, out uint count)
        {
            count = 0;
            try
            {
                
                if (connection == null || !connection.IsOpen)
                {
                    CreateConn();
                }
                using (var channel = connection.CreateModel())
                {
                    //声明一个队列
                    channel.QueueDeclare(queName, true, false, false, null);
                    count = channel.MessageCount(queName);
                }
                return true;
            }
            catch (Exception ex)
            {
                var gewa = ex;
                return false;
            }

        }
        public static IModel GetChannel()
        {
            if (connection == null || !connection.IsOpen)
            {
                CreateConn();
            }
            var channel = connection.CreateModel();
            return channel;
        }
        /// <summary>
        /// 消费消息
        /// </summary>
        /// <param name="queName"></param>
        /// <param name="received"></param>
        public static void Receive<T>(string exchangeName, string queName, IModel channel, Action<T> received) where T : class
        {
          
            
                try
                {
                                   
                    {
                       //声明一个队列
                        channel.QueueDeclare(queName, true, false, false, null);
                        if (!string.IsNullOrEmpty(exchangeName))
                        {
                            //声明交换机
                            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true);
                            //绑定队列，交换机，路由键
                            channel.QueueBind(queName, exchangeName, queName);
                        }

                        channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                        //事件基本消费者
                        var consumer = new EventingBasicConsumer(channel);
                        //接收到消息事件
                        consumer.Received += (ch, ea) =>
                        {
                            string message = "";// Encoding.UTF8.GetString(ea.Body);
                            var msg = message.ToObject<T>();
                            DateTime time = DateTime.Now;
                            received(msg);
                            var timeEnd = DateTime.Now - time;
                            //channel.DefaultConsumer.HandleBasicCancelOk(consumer.ConsumerTag);
                            if (channel.IsClosed)
                            {
                                Console.WriteLine("连接已关闭.");
                                return;
                            }
                            Console.WriteLine($"任务执行完成，用时 {timeEnd.TotalSeconds.ToString("0.00")}s {queName} 队列剩余任务数量： {channel.MessageCount(queName)}");
                            //确认该消息已被消费
                            channel.BasicAck(ea.DeliveryTag, false);
                        };
                        //启动消费者 设置为手动应答消息
                        channel.BasicConsume(queName, false, consumer);
                    }
                }
                catch (Exception ex)
                {
                Console.WriteLine($"MQ异常Msg:{ex.Message},Trace:{ex.StackTrace}");
                }
                Thread.Sleep(60);
            
            
        }

        /// <summary>
        /// 释放链接
        /// </summary>
        public void Dispose()
        {
            //channel.Dispose();
            connection.Close();
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void ReceiveClose()
        {
           //channel.BasicCancel(consumer.ConsumerTag);
           // channel.Close();
            //Dispose();
        }
    }
}
